using CommandLine;
using System;
using System.IO;
using System.Linq;

namespace LabMerge
{
    class Application
    {
        internal int Run(IAppParam param)
        {
            foreach (var inputPath in param.InputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"{inputPath} にファイルが存在しません");
                    return -1;
                }
            }

            var outputPath = param.OutputPath;
            if (string.IsNullOrEmpty(outputPath))
            {
                var firstInputPath = param.InputPaths.First();
                var outputFileNameBase = Path.Combine(Path.GetDirectoryName(firstInputPath), Path.GetFileNameWithoutExtension(firstInputPath));
                var postfix = "-merge";
                outputPath = outputFileNameBase + postfix + ".lab";

                var postfixCounter = 2;
                while (File.Exists(outputPath))
                {
                    outputPath = outputFileNameBase + postfix + "(" + postfixCounter + ")" + ".lab";
                    postfixCounter++;
                }
            }

            if (!Path.IsPathRooted(outputPath))
            {
                Console.Error.WriteLine("${outputPath} に指定したパスが不正です");
                return -1;
            }

            try
            {
                LabMergeService.Merge(param.InputPaths, outputPath);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("何らかの理由で lab ファイルのマージに失敗しました。");
                Console.Error.WriteLine("---------------------------------------------------");
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
                return -1;
            }

            return 0;
        }
    }
}
