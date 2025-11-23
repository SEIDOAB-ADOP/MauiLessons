using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MauiLessons.Services;
using MauiLessons.Models;

namespace MauiLessons.Views.Lesson07
{
    [QueryProperty(nameof(NrBatches), "NrBatches")]

    public partial class PrimesAppStep3 : ContentPage
    {
        public string NrBatches { get; set; }
        public List<PrimeBatch> Primes { get; private set; }

        PrimeNumberService _service;
        Progress<float> _progressReporter;

        public PrimesAppStep3()
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
    }
}
/* Primes Application Step3 - Adding progress bar and activity indicator

- creating a _progressReporter that is used when calling _service.GetPrimeBatchCountsAsync
- ProgressBar, ActivityIndicatorm and Primes ListView visible as appropraite

*/