namespace Main.WriteService.Writers
{
    public interface IWriter
    {
        public void Write(string message, MessageLevelEnum levelEnum = MessageLevelEnum.Text);
    }
}