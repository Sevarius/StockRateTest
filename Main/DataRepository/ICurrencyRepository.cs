namespace Main.DataRepository
{
    public interface ICurrencyRepository
    {
        double GetRateForCurrency(CurrencyEnum stockCurrency, CurrencyEnum personCurrency);
    }
}