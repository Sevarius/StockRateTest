using System;
using System.Collections.Generic;
using Main.ParseService.Options;
using Main.WriteService;
using Main.WriteService.Writers;

namespace Main.CommandService.Commands
{
    public abstract class BaseCommandHandler : ICommandHandler
    {
        public IWriter Writer { get; set; }
        
        public abstract void Invoke(string argument, IList<CommandOption> options);

        protected virtual void WriteMessage(string message, MessageLevelEnum level)
        {
            if (Writer == null)
            {
                throw new ApplicationException("Для обработчика команд не задан класс вывода результатов");
            }

            Writer.Write(message, level);
        }
    }
}