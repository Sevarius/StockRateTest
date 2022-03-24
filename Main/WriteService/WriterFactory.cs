using Main.ParseService.Options;
using Main.WriteService.Writers;

namespace Main.WriteService
{
    public class WriterFactory : IWriterFactory
    {
        private IWriter _defaultWriter;
        
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