using MauiLessons.ViewModels;          //Need to use ViewModel namespace as ItemC i there

namespace MauiLessons.Views.Lesson06;

public partial class NonTrivialDataBinding3 : ContentPage
{

    private ItemC_AsViewModel _viewModel;  //ItemC is ItemB with INotifyChange in inherited BaseViewModel

    Random rnd;

    public NonTrivialDataBinding3()
	{
		InitializeComponent();
        this.BindingContext = _viewModel = new ItemC_AsViewModel();

        rnd = new Random();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }
    public async void ButtonClicked(object sender, EventArgs args)
    {
        await DisplayAlert("Values of Item", $"Message: {_viewModel.Message}\nCreation: {_viewModel.Creation:F}", "OK");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        _viewModel.Message = $"A message set in C# code with a random number: {rnd.Next(1000)}";
        _viewModel.Creation = _viewModel.Creation + new TimeSpan(10, 10, 10, 0); // add 10 days, 10 hours, 10 minutes 
    }
}