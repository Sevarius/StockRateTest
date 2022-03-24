using Main.ParseService.Options;
using Main.WriteService.Writers;

namespace Main.WriteService
{
    public interface IWriterFactory
    {
        IWriter CreateWriter(WriterOption option);
    }
}