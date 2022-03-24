using System;
using System.Collections.Generic;
using System.Linq;
using Main.DataRepository;
using Main.ParseService;
using Main.ParseService.Options;
using Main.WriteService;

namespace Main.CommandService.Commands
{
    [Alias("s")]
    [Alias("stock")]
    public class CurrencyCommand : BaseCommandHandler
    {
        private readonly ICurrencyRepository _currencyRepository;
        private const CurrencyEnum DefaultCurrency = CurrencyEnum.RUR;

        public CurrencyCommand()
        {
            _currencyRepository = new CurrencyRepository();
        }
        
        public override void Invoke(string argument, IList<CommandOption> options)
        {
            var stockCurrencyList = GetStockCurrency(argument);
            if (!stockCurrencyList.Any())
            {
                WriteMessage("Не удалось преобразовать ни одну строку в валюту, работа программы будет завершена.", MessageLevelEnum.Error);
                return;
            }

            var personCurrency = GetPersonCurrency(options);

            foreach (var stockCurrency in stockCurrencyList)
            {
                var currencyRate = _currencyRepository.GetRateForCurrency(stockCurrency, personCurrency);
                WriteMessage($"{personCurrency} 1 = {currencyRate} {stockCurrency}", MessageLevelEnum.Text);
            }
        }

        private IList<CurrencyEnum> GetStockCurrency(string currenciesString)
        {
            var currencyList = currenciesString.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var stockCurrencyList = new List<CurrencyEnum>();

            foreach (var currencyString in currencyList)
            {
                if (TryParseCurrency(currencyString, out var currency))
                {
                    stockCurrencyList.Add(currency);
                }
            }

            return stockCurrencyList;
        }

        private CurrencyEnum GetPersonCurrency(IList<CommandOption> options)
        {
            var personCurrencyOption = options.FirstOrDefault(opt => opt.Option == CommandOptionEnum.Currency);
            if (personCurrencyOption == null || !TryParseCurrency(personCurrencyOption.Argument, out var personCurrency))
            {
                return DefaultCurrency;
            }

            return personCurrency;
        }

        private bool TryParseCurrency(string currencyString, out CurrencyEnum currency)
        {
            currency = DefaultCurrency;
            if (string.IsNullOrEmpty(currencyString))
            {
                WriteMessage($"Не удалось преобразовать пустую строку к валюте. Данная строка не будет учтена в результате.", MessageLevelEnum.Warning);
                return false;
            }
            
            if (!Enum.TryParse(currencyString, true, out currency))
            {
                WriteMessage($"Не удалось преобразовать строку {currencyString} к валюте. Данная строка не будет учтена в результате.", MessageLevelEnum.Warning);
                return false;
            }

            return true;
        }
    }
}