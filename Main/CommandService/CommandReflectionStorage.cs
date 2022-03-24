using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Main.CommandService.Commands;
using Main.ParseService;

namespace Main.CommandService
{
    public class CommandReflectionStorage : ICommandStorage
    {
        private Dictionary<string, Type> _allCommands;
        
        public bool ContainsCommand(string alias)
        {
            return GetAllCommandsNames().Contains(alias);
        }
        
        public IList<string> GetAllCommandsNames()
        {
            var allCommands = GetAllCommands();
            return allCommands.Keys.ToList();
        }

        public ICommandHandler GetCommandHandler(string alias)
        {
            var allCommands = GetAllCommands();

            if (!allCommands.TryGetValue(alias, out var commandHandlerType))
            {
                throw new ApplicationException($"В системе не задан обработчик команды с псевдонимом {alias}");
            }

            var commandHandler = Activator.CreateInstance(commandHandlerType) as ICommandHandler;

            if (commandHandler == null)
            {
                throw new ApplicationException($"Не удалось создать объект обработчика команды с псевдонимом {alias}");
            }

            return commandHandler;
        }

        private Dictionary<string, Type> GetAllCommands()
        {
            if (_allCommands == null)
            {
                _allCommands = ReflectAllCommands();
            }

            return _allCommands;
        }

        private Dictionary<string, Type> ReflectAllCommands()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            var commandTypes = myAssembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(BaseCommandHandler)))
                .ToList();
            
            var res = new Dictionary<string, Type>();

            foreach (var commandType in commandTypes)
            {
                var aliases = commandType.GetCustomAttributes<AliasAttribute>();
                foreach (var aliasAttribute in aliases)
                {
                    if (!res.TryAdd(aliasAttribute.Alias, commandType))
                    {
                        var firstType = res[aliasAttribute.Alias];
                        throw new ApplicationException(
                            $"Для двух обработчиков команд ({firstType.Name} и {commandType.Name}) задан один и тот же псевдоним: {aliasAttribute.Alias}");
                    }
                }
            }

            return res;
        }
    }
}