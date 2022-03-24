using System.Collections.Generic;
using Main.ParseService.Options;
using Main.WriteService.Writers;

namespace Main.CommandService.Commands
{
    /// <summary>
    /// Интерфейс обработчика команд
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        /// Вызов команды
        /// </summary>
        /// <param name="argument">главный аргумент команды</param>
        /// <param name="options">дополнительные настройки для команды</param>
        void Invoke(string argument, IList<CommandOption> options);
        
        /// <summary>
        /// Писатель
        /// </summary>
        IWriter Writer { set; }
    }
}