using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Main.CommandService;
using Main.ParseService.Options;

namespace Main.ParseService
{
    public class Parser : IParser
    {
        private readonly ICommandStorage _commandStorage;
        private const char CommandPrefix = '-';

        public Parser()
        {
            _commandStorage = new CommandReflectionStorage();
        }
        
        /// <summary>
        /// Распарсить неразделённую строку аргументов
        /// </summary>
        public ArgumentInfo ParseArguments(string argumentString)
        {
            var parsed = argumentString.Split(new[] {' ', '\t', '\n', '\r'},
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return ParseArguments(parsed);
        }

        /// <summary>
        /// Распарсить разделённую строку аргументов
        /// </summary>
        public ArgumentInfo ParseArguments(IList<string> arguments)
        {
            var parsedArguments = GetListOfCommands(arguments);

            if (!parsedArguments.Any())
            {
                throw new ApplicationException("Для данного приложения требуется ввести команду для действия");
            }

            var command = parsedArguments[0].commandName;

            if (!_commandStorage.ContainsCommand(command))
            {
                throw new ApplicationException($"В системе не задана команда: {command}");
            }

            var argumentInfo = new ArgumentInfo
            {
                CommandHandler = _commandStorage.GetCommandHandler(command),
                CommandArgument = parsedArguments[0].argument
            };

            for (int i = 1; i < parsedArguments.Count; i++)
            {
                var optionName = parsedArguments[i].commandName;
                if (TryParseCommandOption<CommandOptionEnum>(optionName, out var commandOption))
                {
                    argumentInfo.Options.Add(new CommandOption{Option = commandOption, Argument = parsedArguments[i].argument});
                }
                else if (i == parsedArguments.Count - 1 && TryParseCommandOption<WriterOptionEnum>(optionName, out var writeOption))
                {
                    argumentInfo.WriterOption = new WriterOption
                        {Option = writeOption, Argument = parsedArguments[i].argument};
                }
                else
                {
                    throw new ApplicationException(
                        $"Не удалось преобразовать параметр {optionName} в один из используемых приложением параметров");
                }
            }

            return argumentInfo;
        }

        /// <summary>
        /// Перегруперовать список аргументов в список [команда-её аргументы] 
        /// </summary>
        /// <param name="arguments">список аргументов</param>
        /// <returns>список [команда-её аргументы]</returns>
        /// <exception cref="ApplicationException">Первый аргумент должен являться командой</exception>
        private IList<(string commandName, string argument)> GetListOfCommands(IList<string> arguments)
        {
            var res = new List<(string, string)>();

            if (!arguments.Any())
            {
                return res;
            }

            var index = 0;
            if (!arguments[index].StartsWith(CommandPrefix))
            {
                throw new ApplicationException("В начале должна быть указана команда, которая должна выполняться");
            }

            while (index < arguments.Count)
            {
                var argumentBuilder = new StringBuilder();
                var subIndex = 1;
                while (index + subIndex < arguments.Count)
                {
                    var argument = arguments[index + subIndex];
                    if (argument.StartsWith(CommandPrefix))
                    {
                        break;
                    }
                    
                    argumentBuilder.Append(argument);
                    argumentBuilder.Append(' ');
                    subIndex++;
                }
                var stringArgument = argumentBuilder.ToString().TrimEnd(' ');
                res.Add((arguments[index].TrimStart(CommandPrefix).ToLower(), stringArgument));
                index += subIndex;
            }

            return res;
        }

        /// <summary>
        /// Попытаться получить значение перечисления по атрибутам псевдонима
        /// </summary>
        /// <param name="option">псевдоним параметра</param>
        /// <param name="result">результат парсинга</param>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <returns>Удалось ли получить значение перечисления или нет</returns>
        private bool TryParseCommandOption<T>(string option, out T result) where T : Enum
        {
            if (option.StartsWith(CommandPrefix))
            {
                option = option.TrimStart(CommandPrefix);
            }

            var dict = GetEnumAliases<T>();

            return dict.TryGetValue(option, out result);
        }

        /// <summary>
        /// Получить словарь [псевдоним-значение перечисления]
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <returns>словарь</returns>
        /// <exception cref="ApplicationException">Если для указанного перечисления заданы два одинаковых псевдонима</exception>
        private Dictionary<string, T> GetEnumAliases<T>() where T : Enum
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            var res = new Dictionary<string, T>();

            foreach (var fieldInfo in fields)
            {
                var aliases = fieldInfo.GetCustomAttributes<AliasAttribute>();
                
                foreach (var aliasAttribute in aliases)
                {
                    var value = (T) fieldInfo.GetValue(type);
                    if (!res.TryAdd(aliasAttribute.Alias, value))
                    {
                        var firstType = res[aliasAttribute.Alias];
                        throw new ApplicationException(
                            $"Для двух параметров перечисления {type.Name} ({type.GetEnumName(firstType)} и {type.GetEnumName(value)}) задан один и тот же псевдоним: {aliasAttribute.Alias}");
                    }
                }
            }

            return res;
        }
    }
}