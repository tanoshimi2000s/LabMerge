using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;

namespace LabMerge
{
    class ConsoleOption : IAppParam
    {
        [Value(0, Required = true, HelpText = "入力する lab ファイル")]
        public IEnumerable<string> InputPaths { get; set; }

        [Option('o', "output", HelpText = "出力先の lab ファイル")]
        public string OutputPath { get; set; }
    }

    class Program
    {
        static IAppParam _param = null;

        static int HandleParseError(IEnumerable<Error> err)
        {
            return -1;
        }

        static int Parse(ConsoleOption ops)
        {
            _param = ops;
            return 1;
        }

        static int Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<ConsoleOption>(args)
              .WithParsed<ConsoleOption>(opts => Parse(opts))
              .WithNotParsed<ConsoleOption>((errs) => HandleParseError(errs));

            if (_param == null)
            {
                return -1;
            }
            return new Application().Run(_param);
        }
    }
}
