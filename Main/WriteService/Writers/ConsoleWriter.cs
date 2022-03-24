using System;
using System.Collections.Generic;

namespace Main.WriteService.Writers
{
    /// <summary>
    /// Писатель в консоль
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        private static readonly ConsoleColor DefaultColor = Console.ForegroundColor;

        private readonly Dictionary<MessageLevelEnum, ConsoleColor> _colorMap;

        public ConsoleWriter()
        {
            _colorMap = new Dictionary<MessageLevelEnum, ConsoleColor>
            {
                [MessageLevelEnum.Text] = DefaultColor,
                [MessageLevelEnum.Warning] = ConsoleColor.Yellow,
                [MessageLevelEnum.Error] = ConsoleColor.Red
            };
        }
        
        /// <summary>
        /// Вывести сообщение
        /// </summary>
        public void Write(string message, MessageLevelEnum levelEnum = MessageLevelEnum.Text)
        {
            if (!_colorMap.TryGetValue(levelEnum, out var backgroundColor))
            {
                backgroundColor = DefaultColor;
            }

            Console.ForegroundColor = backgroundColor;
            Console.WriteLine(message);
            Console.ForegroundColor = DefaultColor;
        }
    }
}