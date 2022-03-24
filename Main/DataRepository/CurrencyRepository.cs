using System;

namespace Main.DataRepository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public double GetRateForCurrency(CurrencyEnum stockCurrency, CurrencyEnum personCurrency)
        {
            var data = InlineData.GetCurrencyValues();

            var stockCurrencyIndex = (int) stockCurrency;
            var personCurrencyIndex = (int) personCurrency;

            if (stockCurrencyIndex >= data.Length)
            {
                throw new ApplicationException($"Данные по валюте {stockCurrency} не были добавлены в систему");
            }

            if (personCurrencyIndex >= data.Length)
            {
                throw new ApplicationException($"Данные по валюте {personCurrency} не были добавлены в систему");
            }

            var result = data[personCurrencyIndex][stockCurrencyIndex];

            return result;
        }
    }
}