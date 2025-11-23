using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using MauiLessons.Models;
using MauiLessons.Services;
//Note that namespace PrimeNumbers.Views is not included as Views should not be directly referred to from VM

namespace MauiLessons.ViewModels
{
    public class PrimePageViewModel : BaseViewModel
    {
        #region Step5
        int _NrOfBatches;
        public int NrOfBatches
        {
            set => Set<int>(ref _NrOfBatches, value, "NrOfBatches");
            get => _NrOfBatches;
        }
        #endregion

        #region Step6
        IPrimeNumberService _service;
        List<PrimeBatch> _primes;
        public List<PrimeBatch> Primes
        {
            set => Set<List<PrimeBatch>>(ref _primes, value, "Primes");
            get => _primes;
        }

        public PrimePageViewModel()
        {

            _service = DependencyService.Resolve<IPrimeNumberService>();
        }
        public async Task LoadPrimes()
        {
            Primes = await _service.GetPrimeBatchCountsAsync(NrOfBatches, null);
        }
        #endregion

        #region Step7
        Command<ProgressBar> _LoadPrimesCommand;
        public Command<ProgressBar> LoadPrimesCommand => _LoadPrimesCommand ?? (_LoadPrimesCommand = new Command<ProgressBar>(async (pb) => await LoadPrimes(pb)));

        public async Task LoadPrimes(ProgressBar pb)
        {
            Progress<float> progressReporter = new Progress<float>(value =>
            {
               pb.Progress = value;
            });

            pb.IsVisible = true;
            Primes = null;
            Primes = await _service.GetPrimeBatchCountsAsync(NrOfBatches, progressReporter);
            pb.IsVisible = false;
        }
        #endregion

        #region Step8
        public async Task<string> WriteAsync(PrimeBatch batch, string filename)
        {
            List<int> primes = await _service.GetPrimesAsync(batch.BatchStart, PrimeBatch.BatchSize);
            string path = fname(filename);
            using (FileStream fs = File.Create(path))
            using (TextWriter writer = new StreamWriter(fs))
            {
                await writer.WriteLineAsync(batch.ToString());
                await writer.WriteLineAsync($"First Prime: {primes.First()}  Last Prime: {primes.Last()}");
                int nrPerLine = 50;
                for (int i = 0; i <= batch.NrPrimes; i++)
                {
                    string sPrimes = String.Join<int>(", ", primes.Take(nrPerLine));
                    await writer.WriteLineAsync(sPrimes);

                    if (primes.Count > nrPerLine)
                        primes.RemoveRange(0, nrPerLine);
                }
            }

            return path;
        }
        static string fname(string name)
        {
            //var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            //Note: MAUI has changed storage policy to use FileSystem.Current.AppDataDirectory
            //instead of Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var documentPath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "PrimesAppStep4vm", "Primes");
            documentPath = System.IO.Path.Combine(documentPath, "AOOP2", "Examples");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return System.IO.Path.Combine(documentPath, name);
        }
        #endregion
    }
}
