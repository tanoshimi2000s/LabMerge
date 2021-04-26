using LabOperationLibraryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMerge
{
    class LabMergeService
    {
        public static void Merge(IEnumerable<string> inputPaths, string outputPath)
        {
            var mergeParamList = new List<Queue<LabParam>>();

            // Construct Settings
            foreach (var input in inputPaths)
            {
                var labParamList = LabFileUtil.ReadLabFile(input);
                var paramQueue = new Queue<LabParam>();

                foreach (var labParam in labParamList)
                {
                    if (labParam.IsPause())
                    {
                        continue;
                    }

                    paramQueue.Enqueue(labParam);
                }
                if (paramQueue.Count != 0)
                {
                    mergeParamList.Add(paramQueue);
                }
            }

            // Merge
            var resultList = new List<LabParam>();
            long startOffset = 0;
            while (mergeParamList.Count != 0)
            {
                Queue<LabParam> targetQueue = mergeParamList.First();
                foreach (var queue in mergeParamList)
                {
                    if (queue.First().Start < targetQueue.First().Start)
                    {
                        targetQueue = queue;
                    }
                }

                var targetParam = targetQueue.Dequeue();
                if (targetQueue.Count == 0)
                {
                    mergeParamList.Remove(targetQueue);
                }

                if (startOffset < targetParam.Start)
                {
                    var mergePauseLab = LabParamUtil.GeneratePause(startOffset, targetParam.Start);
                    resultList.Add(mergePauseLab);
                }
                else
                {
                    targetParam.Start = startOffset;
                }

                if (targetParam.Start < targetParam.End)
                {
                    resultList.Add(targetParam);
                }
                else
                {
                    targetParam.End = targetParam.Start;
                }
                startOffset = targetParam.End;
            }

            // Write
            LabFileUtil.WriteLabFile(outputPath, resultList);
        }

    }
}
