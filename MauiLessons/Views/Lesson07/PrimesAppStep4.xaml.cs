using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MauiLessons.Models;
using MauiLessons.Services;

namespace MauiLessons.Views.Lesson07
{
    [QueryProperty(nameof(NrBatches), "NrBatches")]
    public partial class PrimesAppStep4 : ContentPage
    {
        public string NrBatches { get; set; }
        public List<PrimeBatch> Primes { get; private set; }

        PrimeNumberService _service;
        Progress<float> _progressReporter;

        public PrimesAppStep4()
        {
            InitializeComponent();
            _service = new PrimeNumberService();
            BindingContext = this;

            _progressReporter = new Progress<float>(async value =>
            {
                await progressBar.ProgressTo(value, 750, Easing.Linear);
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            enNrBatches.Text = NrBatches;

            //This is making the first load of data
            MainThread.BeginInvokeOnMainThread(async () => { await LoadPrimes(); });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await LoadPrimes();
        }

        private async Task LoadPrimes()
        {
            if (!int.TryParse(enNrBatches.Text, out int nrbatches)) return;

            progressBar.Progress = 0;

            layBusy.IsVisible = true;
            activityIndicator.IsRunning = true;
            lvPrimes.IsVisible = false;

            Primes = await _service.GetPrimeBatchCountsAsync(nrbatches, _progressReporter);
            OnPropertyChanged("Primes");

            lvPrimes.IsVisible = true;
            activityIndicator.IsRunning = false;
            layBusy.IsVisible = false;
        }

        private async void lvPrimes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (PrimeBatch)e.Item;
            var answer = await DisplayAlert("Write to disk?", 
                $"Would you like to write the {item.NrPrimes} prime numbers to disk", "Yes", "No");
            if (answer)
            {
                string userMessage=null, path=null;
                try
                {
                    path = await WriteAsync(item, $"Primes_from_{item.BatchStart}_to_{item.BatchEnd}.txt");
                    userMessage = "Write Completed";
                }
                catch (Exception ex)
                {
                    userMessage = $"Cannot write: {ex.Message}";
                }
                finally 
                {
                    await DisplayAlert(userMessage, $"Filename: {path}", "OK");
                }
            }
        }
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

            var documentPath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "PrimesAppStep4", "Primes");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return System.IO.Path.Combine(documentPath, name);
        }
    }
}
/* Primes Application Step4 - Adding TappedItem eventhandler, AlertBox and Write all primes to disk

- lvPrimes_ItemTapped eventhadler added to the ListView
- DisplayAlert used to ask if a PrimeBatch should be written to disk
- fname created to create a platform independant filepath
- WriteAsync created to get the primes from the batch and write to disk. All async

Note: MAUI has changed disk storage policy to use FileSystem.Current.AppDataDirectory instead of
Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

*/
