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

    public partial class PrimesAppStep2 : ContentPage
    {
        public string NrBatches { get; set; }
        public List<PrimeBatch> Primes { get; private set; }

        PrimeNumberService _service;
        public PrimesAppStep2()
        {
            InitializeComponent();
            _service = new PrimeNumberService();

            BindingContext = this;
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
                        
            Primes = await _service.GetPrimeBatchCountsAsync(nrbatches, null);
            OnPropertyChanged("Primes");
        }
    }
}
/* Primes Application Step2 - Query parameters to initiate page. BindingContext set to page class. OnAppearing to load primes

- Initial Batch size is set using QueryParams //lesson7/primesapplicationstep2?NrBatches=10
- QueryParams read in cs file using [QueryProperty(nameof(NrBatches), "NrBatches")]

- public List<PrimeBatch> Primes { get; private set; } creates and ListView.ItemSource Bound to Primes
- BindingContext set to this

- protected override void OnAppearing() created to initiate page when about to be rendered 
- private async Task LoadPrimes() created and called from OnAppearing to make initial primes calculation
- OnPropertyChanged("Primes") used to update DataBinding when new primes calculation made

*/