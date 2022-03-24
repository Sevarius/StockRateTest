using Main.ParseService.Options;
using Main.WriteService.Writers;

namespace Main.WriteService
{
    /// <summary>
    /// Фабрика Писателей
    /// </summary>
    public class WriterFactory : IWriterFactory
    {
        private IWriter _defaultWriter;
        
        /// <summary>
        /// Создать Писателя в зависимости от параметров, пришедших в командной строке
        /// </summary>
        public IWriter CreateWriter(WriterOption option)
        {
            _defaultWriter = new ConsoleWriter();

            if (option == null)
            {
                return _defaultWriter;
            }
            
            switch (option.Option)
            {
                case WriterOptionEnum.Console:
                    return _defaultWriter;
                default:
                    return _defaultWriter;
            }
        }
    }
}