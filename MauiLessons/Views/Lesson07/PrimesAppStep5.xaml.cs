using System;

using MauiLessons.Models;
using MauiLessons.Services;
using MauiLessons.ViewModels;


namespace MauiLessons.Views.Lesson07
{
    [QueryProperty(nameof(NrBatches), "NrBatches")]

    public partial class PrimesAppStep5 : ContentPage
    {
        public string NrBatches { get; set; }

        private PrimePageViewModel _viewModel;
        public PrimesAppStep5()
        {
            InitializeComponent();

            BindingContext = _viewModel = DependencyService.Resolve<PrimePageViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            int nrbatches;
            if (int.TryParse(NrBatches, out nrbatches))
            {
                _viewModel.NrOfBatches = nrbatches;
                MainThread.BeginInvokeOnMainThread(async () => { await _viewModel.LoadPrimes(progressBar); });
            }
        }

        private async void lvPrimes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (PrimeBatch)e.Item;
            var answer = await DisplayAlert("Write to disk?",
                $"Would you like to write the {item.NrPrimes} prime numbers to disk", "Yes", "No");
            if (answer)
            {
                string userMessage = null, path = null;
                try
                {
                    path = await _viewModel.WriteAsync(item, $"Primes_from_{item.BatchStart}_to_{item.BatchEnd}.txt");
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
    }
}