namespace Main.WriteService.Writers
{
    /// <summary>
    /// Интерфейс Писателя
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Вывести сообщение
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="levelEnum">Тип сообщения</param>
        public void Write(string message, MessageLevelEnum levelEnum = MessageLevelEnum.Text);
    }
}