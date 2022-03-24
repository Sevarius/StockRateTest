using System.Collections.Generic;
using Main.CommandService.Commands;

namespace Main.CommandService
{
    /// <summary>
    /// Интерфейс хранилища команд
    /// </summary>
    public interface ICommandStorage
    {
        /// <summary>
        /// Получить псевдонимы всех команд
        /// </summary>
        /// <returns>псевдонимы всех доступных команд</returns>
        public IList<string> GetAllCommandsNames();

        /// <summary>
        /// Содержится ли в хранилище команда с данным псевдонимом
        /// </summary>
        /// <param name="alias">псевдоним команды</param>
        /// <returns></returns>
        public bool ContainsCommand(string alias);
        
        /// <summary>
        /// Получить обработчик команды по его псевдониму
        /// </summary>
        /// <param name="alias">псевдоним команды</param>
        /// <returns>обработчик команды</returns>
        public ICommandHandler GetCommandHandler(string alias);
    }
}