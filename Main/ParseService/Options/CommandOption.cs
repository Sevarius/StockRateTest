namespace Main.ParseService.Options
{
    /// <summary>
    /// Параметры для команды
    /// </summary>
    public class CommandOption
    {
        /// <summary>
        /// Тип параметра
        /// </summary>
        public CommandOptionEnum Option { get; set; }

        /// <summary>
        /// Аргументы параметра
        /// </summary>
        public string Argument { get; set; }
    }
}