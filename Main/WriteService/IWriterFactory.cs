using Main.ParseService.Options;
using Main.WriteService.Writers;

namespace Main.WriteService
{
    /// <summary>
    /// Фабрика писателей
    /// </summary>
    public interface IWriterFactory
    {
        /// <summary>
        /// Создать Писателя в зависимости от параметров, пришедших в командной строке
        /// </summary>
        /// <param name="option">параметры</param>
        /// <returns>Объект Писателя</returns>
        IWriter CreateWriter(WriterOption option);
    }
}