using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Main.ParseService;
using Main.ParseService.Options;
using NuGet.Frameworks;
using Xunit;

namespace TestProject1
{
    public class ParserTests
    {
        private readonly IParser _parser;

        public ParserTests()
        {
            _parser = new Parser();
        }
        
        [Theory]
        [InlineData("-h", "seva")]
        [InlineData("-help", "")]
        public void CommandStringParseWithArgumentNoOptionsNoWriteTest(string command, string arguments)
        {
            var result = _parser.ParseArguments(new List<string> {command, arguments});
            Assert.Equal(arguments, result.CommandArgument);
            Assert.Null(result.WriterOption);
            Assert.Empty(result.Options);
            Assert.NotNull(result.CommandHandler);
        }

        [Theory]
        [InlineData("-h")]
        [InlineData("-Help")]
        public void CommandStringParseNoArgumentNoOptionsNoWriteTest(string command)
        {
            var result = _parser.ParseArguments(new List<string> {command});
            Assert.True(string.IsNullOrEmpty(result.CommandArgument));
            Assert.Null(result.WriterOption);
            Assert.Empty(result.Options);
            Assert.NotNull(result.CommandHandler);
        }

        [Fact]
        public void CommandStringParseArgumentNoOptionWriteTest()
        {
            var result = _parser.ParseArguments("-s  rur  gbp   -cl");
            Assert.Equal("rur gbp", result.CommandArgument);
            Assert.Empty(result.Options);
            Assert.NotNull(result.WriterOption);
            Assert.Equal(WriterOptionEnum.Console, result.WriterOption.Option);
            Assert.True(string.IsNullOrEmpty(result.WriterOption.Argument));
        }
        
        [Fact]
        public void CommandStringParseArgumentNoOptionNoWriteTest()
        {
            var result = _parser.ParseArguments("-s  rur  gbp");
            Assert.Equal("rur gbp", result.CommandArgument);
            Assert.Empty(result.Options);
            Assert.Null(result.WriterOption);
        }
    }
}