using System;
using System.Collections.Generic;
using Main.ParseService;
using Main.ParseService.Options;

namespace Main.CommandService.Commands
{
    /// <summary>
    /// Обработчик команды вызова помощи
    /// </summary>
    [Alias("h")]
    [Alias("help")]
    public class HelpCommandHandler : BaseCommandHandler
    {
        /// <summary>
        /// Вызов команды
        /// </summary>
        public override void Invoke(string argument, IList<CommandOption> options)
        {
            Console.WriteLine("Данная программа позволяет получить стоимость валюты при покупке её за другую валюту на бирже (все данные тестовые)");
            Console.WriteLine("Команды:\n-h\\-help - инструкция");
            Console.WriteLine("-s\\-stock [список валют] - вывод стоимости валюты на бирже");
            Console.WriteLine("Параметры команды:");
            Console.WriteLine("-c\\-currency [обозначение валюты] - за какую валюту будет покупаться указанная валюта");
            Console.WriteLine("Доступные валюты: AUD, GBP, DKK, EUR, CAD, NZD, RUR");
        }
    }
}