namespace Main.ParseService.Options
{
    /// <summary>
    /// Типы параметров
    /// </summary>
    public enum CommandOptionEnum
    {
        /// <summary>
        /// Указать валюту, за которую будет производиться покупка/продажа
        /// </summary>
        [Alias("c")]
        [Alias("currency")]
        Currency = 1,
    }
}