using System.Collections.Generic;
using Main.CommandService.Commands;

namespace Main.ParseService.Options
{
    /// <summary>
    /// Информацию об распарсенных аргументах командной строки
    /// </summary>
    public class ArgumentInfo
    {
        /// <summary>
        /// Обработчик команды
        /// </summary>
        public ICommandHandler CommandHandler { get; set; }
        
        /// <summary>
        /// Аргументы для обработчика команды
        /// </summary>
        public string CommandArgument { get; set; }

        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        public IList<CommandOption> Options { get; set; } = new List<CommandOption>();
        
        /// <summary>
        /// Параметры Писателя
        /// </summary>
        public WriterOption WriterOption { get; set; }
    }
}