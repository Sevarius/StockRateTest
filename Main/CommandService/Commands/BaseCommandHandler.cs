using System;
using System.Collections.Generic;
using Main.ParseService.Options;
using Main.WriteService;
using Main.WriteService.Writers;

namespace Main.CommandService.Commands
{
    /// <summary>
    /// Обработчик комманд
    /// </summary>
    public abstract class BaseCommandHandler : ICommandHandler
    {
        /// <summary>
        /// Писатель
        /// </summary>
        public IWriter Writer { get; set; }
        
        /// <summary>
        /// Вызов команды
        /// </summary>
        public abstract void Invoke(string argument, IList<CommandOption> options);

        /// <summary>
        /// Написать сообщение
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="level">тип сообщения</param>
        /// <exception cref="ApplicationException">Возникает, если Писатель не был указан</exception>
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