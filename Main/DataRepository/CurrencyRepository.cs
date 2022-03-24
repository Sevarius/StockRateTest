using System;

namespace Main.DataRepository
{
    /// <summary>
    /// Класс предоставления доступа к хранилищу валют
    /// </summary>
    public class CurrencyRepository : ICurrencyRepository
    {
        /// <summary>
        /// Получить стоимость покупки/продажи валюты на бирже за указанную валюту
        /// </summary>
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