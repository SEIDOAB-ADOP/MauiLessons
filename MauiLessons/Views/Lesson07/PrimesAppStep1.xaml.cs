using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MauiLessons.Services;
using MauiLessons.Models;

namespace MauiLessons.Views.Lesson07
{
    public partial class PrimesAppStep1 : ContentPage
    {
        PrimeNumberService _service;

        public PrimesAppStep1()
        {
            InitializeComponent();
            _service = new PrimeNumberService();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(enNrBatches.Text, out int nrbatches)) return;

            lvPrimes.ItemsSource = await _service.GetPrimeBatchCountsAsync(nrbatches, null);
        }
    }
}

/* Primes Application Step1 - Very basic. Moving Model and Services into MAUI

Move Model and Services into MAUI App
- Get the PrimeBatch.cs Model and Service PrimeNumberService.cs from the Console App testing the Service
- Create an interface for the IPrimeNumberService.cs to be used later with Dependecy Injection

Create the MAUI App
- Create a PrimesAppStep1.xaml and PrimesAppStep1.xaml.cs accessable from Shell Menu
- Create the Label, Entry, Button and ListView in the xaml page accordingly
- Bind the TextCell in the ListView to  the current BindingContext {Bidning .}
- Implement the Button Clicked for "Get Primes" Button to call the Service async and assign the result to
  the ListView lvPrimes.ItemSource

*/