using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LabOperationLibraryCore
{
    public class LabFileUtil
    {
        public static IList<LabParam> ReadLabFile(string path)
        {
            IList<LabParam> result = new List<LabParam>();
            using (var sr = new StreamReader(path))
            {
                var csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = " ",
                };
                
                using (var reader = new CsvReader(sr,csvConfiguration))
                {
                    reader.Context.RegisterClassMap<LabParamMapper>();
                    var labParams = reader.GetRecords<LabParam>();

                    foreach (var labParam in labParams)
                    {
                        result.Add(labParam);
                    }
                }
            }
            return result;
        }

        public static void WriteLabFile(string path, IEnumerable<LabParam> data)
        {
            using (var sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            {
                var csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = " ",
                };

                using (var writer = new CsvWriter(sw, csvConfiguration))
                {
                    writer.Context.RegisterClassMap<LabParamMapper>();
                    writer.WriteRecords(data);
                }
            }
        }
    }
}
