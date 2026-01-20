using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using MauiLessons.Models;

namespace MauiLessons.Services
{
    public class PrimeNumberService : IPrimeNumberService  //IPrimeNumberService is used for Dependecy Injection
    {
        public Task<List<PrimeBatch>> GetPrimeBatchCountsAsync(int NrOfBatches) => GetPrimeBatchCountsAsync(NrOfBatches, null);
        public Task<List<PrimeBatch>> GetPrimeBatchCountsAsync(int NrOfBatches, IProgress<float> onProgressReporting) =>
            Task.Run(async () => GetPrimeBatchCounts(NrOfBatches, onProgressReporting));

        public Task<int> GetPrimesCountAsync(int start, int count) => 
            Task.Run(async () => GetPrimesCount(start, count));


        public Task<List<int>> GetPrimesAsync(int start, int count)
        {
            return Task.Run(() =>
               ParallelEnumerable.Range(start, count).Where(n =>
                 Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)).ToList<int>());
        }


        public List<PrimeBatch> GetPrimeBatchCounts(int NrOfBatches, IProgress<float> onProgressReporting)
        {
            var batchList = new List<PrimeBatch>();
            for (int i = 0; i < NrOfBatches; i++)
            {
                var batch = new PrimeBatch { BatchStart = i * PrimeBatch.BatchSize + 2 };
                batch.NrPrimes = GetPrimesCount(batch.BatchStart, PrimeBatch.BatchSize);
                batchList.Add(batch);

                float fProgress = ((float)i + 1) / NrOfBatches;
                onProgressReporting?.Report(fProgress);
            }
            return batchList;
        }

        public int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count).Count(n =>
                 Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }
    }
}
