namespace Main.DataRepository
{
    /// <summary>
    /// Интерфейс предоставления доступа к хранилищу валют
    /// </summary>
    public interface ICurrencyRepository
    {
        /// <summary>
        /// Получить стоимость покупки/продажи валюты на бирже за указанную валюту
        /// </summary>
        /// <param name="stockCurrency">валюта на бирже</param>
        /// <param name="personCurrency">валюта полкупателя/продавца</param>
        /// <returns>значение стоимость покупки/продажи</returns>
        double GetRateForCurrency(CurrencyEnum stockCurrency, CurrencyEnum personCurrency);
    }
}