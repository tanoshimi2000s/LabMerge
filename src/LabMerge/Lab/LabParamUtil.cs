using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabOperationLibraryCore
{
    public class LabParamUtil
    {
        public static void Invalidate(IList<LabParam> dataList)
        {
            if(dataList.Count == 0)
            {
                return;
            }

            long prevEnd = 0;
            foreach (var data in dataList)
            {
                if(data.Start != prevEnd)
                {
                    throw new NotSupportedException();
                }

                prevEnd = data.End;
            }

        }

        public static LabParam GeneratePause(long start, long end)
        {
            return new LabParam() { Start = start, End = end, Value = "pau" };
        }
    }
}
