namespace Main.ParseService.Options
{
    /// <summary>
    /// Тип Писателя
    /// </summary>
    public enum WriterOptionEnum
    {
        /// <summary>
        /// Писатель в консоль
        /// </summary>
        [Alias("cl")]
        [Alias("console")]
        Console = 1
    }
}