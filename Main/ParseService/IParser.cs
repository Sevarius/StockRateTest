using System.Collections.Generic;
using Main.ParseService.Options;

namespace Main.ParseService
{
    /// <summary>
    /// Парсер аргументов командной строки
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Распарсить неразделённую строку аргументов
        /// </summary>
        /// <param name="argumentString">строка аргументов</param>
        /// <returns>Результат парсинга</returns>
        public ArgumentInfo ParseArguments(string argumentString);

        /// <summary>
        /// Распарсить разделённую строку аргументов
        /// </summary>
        /// <param name="arguments">список аргументов</param>
        /// <returns>Результат парсинга</returns>
        public ArgumentInfo ParseArguments(IList<string> arguments);
    }
}