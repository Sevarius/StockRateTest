using System.Collections.Generic;
using Main.ParseService.Options;
using Main.WriteService.Writers;

namespace Main.CommandService.Commands
{
    public interface ICommandHandler
    {
        void Invoke(string argument, IList<CommandOption> options);
        
        IWriter Writer { set; }
    }
}