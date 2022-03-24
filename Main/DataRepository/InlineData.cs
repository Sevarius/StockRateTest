namespace Main.DataRepository
{
    /// <summary>
    /// Внутреннее хранилище данных
    /// </summary>
    public class InlineData
    {
        public static double[][] GetCurrencyValues()
        {
            var res = new[]
            { 
                //       AUD     GBP     DKK     EUR     CAD     NZD     RUR
                new [] {  1.00 ,  2.00 ,  3.00 ,  4.00 ,  5.00 ,  6.00 ,  7.00  }, //AUD
                new [] {  8.00 ,  9.00 , 10.00 , 11.00 , 12.00 , 13.00 , 14.00  }, //GBP
                new [] { 15.00 , 16.00 , 17.00 , 18.00 , 19.00 , 20.00 , 21.00  }, //DKK
                new [] { 22.00 , 23.00 , 24.00 , 25.00 , 26.00 , 27.00 , 28.00  }, //EUR
                new [] { 29.00 , 30.00 , 31.00 , 32.00 , 33.00 , 34.00 , 35.00  }, //CAD
                new [] { 36.00 , 37.00 , 38.00 , 39.00 , 40.00 , 41.00 , 42.00  }, //NZD
                new [] { 43.00 , 44.00 , 45.00 , 46.00 , 47.00 , 48.00 , 49.00  }, //RUR
            };

            return res;
        }
    }
}