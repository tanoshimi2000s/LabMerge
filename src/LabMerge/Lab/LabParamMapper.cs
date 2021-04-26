using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabOperationLibraryCore
{
    class LabParamMapper : ClassMap<LabParam>
    {
        public LabParamMapper()
        {
            Map(x => x.Start).Index(0);
            Map(x => x.End).Index(1);
            Map(x => x.Value).Index(2);
        }
    }
}
