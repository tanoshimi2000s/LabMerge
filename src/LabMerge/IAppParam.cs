using System.Collections.Generic;

namespace LabMerge
{
    internal interface IAppParam
    {
        IEnumerable<string> InputPaths { get; }
        string OutputPath { get; }
    }
}