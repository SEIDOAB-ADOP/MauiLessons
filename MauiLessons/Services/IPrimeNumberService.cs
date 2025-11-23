using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using MauiLessons.Models;

namespace MauiLessons.Services
{
    //IPrimeNumerService is used only for DI
    public interface IPrimeNumberService
    {
        Task<List<PrimeBatch>> GetPrimeBatchCountsAsync(int NrOfBatches);
        Task<List<PrimeBatch>> GetPrimeBatchCountsAsync(int NrOfBatches, IProgress<float> onProgressReporting);

        Task<int> GetPrimesCountAsync(int start, int count);
        Task<List<int>> GetPrimesAsync(int start, int count);
    }
}
