using System;
using Main.ParseService;
using Main.WriteService;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IParser parser = new Parser();
                var argumentInfo = parser.ParseArguments(args);
                IWriterFactory writerFactory = new WriterFactory();
                var writer = writerFactory.CreateWriter(argumentInfo.WriterOption);
                argumentInfo.CommandHandler.Writer = writer;
                argumentInfo.CommandHandler.Invoke(argumentInfo.CommandArgument, argumentInfo.Options);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла ошибка при работе программы:\n{e.Message}\n\nРабота программы будет завершена.");
            }
            finally
            {
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}