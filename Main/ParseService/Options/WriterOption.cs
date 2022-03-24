namespace Main.ParseService.Options
{
    /// <summary>
    /// Параметр для Писателя
    /// </summary>
    public class WriterOption
    {
        /// <summary>
        /// Тип Писателя
        /// </summary>
        public WriterOptionEnum Option { get; set; }
        
        /// <summary>
        /// Аргументы для Писателя
        /// </summary>
        public string Argument { get; set; }
    }
}