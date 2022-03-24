using System.Collections.Generic;
using Main.ParseService.Options;

namespace Main.ParseService
{
    public interface IParser
    {
        public ArgumentInfo ParseArguments(string argumentString);

        public ArgumentInfo ParseArguments(IList<string> arguments);
    }
}