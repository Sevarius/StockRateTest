using System.Collections.Generic;
using Main.CommandService.Commands;

namespace Main.ParseService.Options
{
    public class ArgumentInfo
    {
        public ICommandHandler CommandHandler { get; set; }
        
        public string CommandArgument { get; set; }

        public IList<CommandOption> Options { get; set; } = new List<CommandOption>();
        
        public WriterOption WriterOption { get; set; }
    }
}