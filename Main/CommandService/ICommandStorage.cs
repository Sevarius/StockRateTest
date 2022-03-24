using System.Collections.Generic;
using Main.CommandService.Commands;

namespace Main.CommandService
{
    public interface ICommandStorage
    {
        public IList<string> GetAllCommandsNames();

        public bool ContainsCommand(string alias);
        
        public ICommandHandler GetCommandHandler(string alias);
    }
}