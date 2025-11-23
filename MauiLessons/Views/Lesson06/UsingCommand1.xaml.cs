using MauiLessons.ViewModels;

namespace MauiLessons.Views.Lesson06;

public partial class UsingCommand1 : ContentPage
{
	UsingCommand1ViewModel _viewmodel;

	public UsingCommand1()
	{
		InitializeComponent();

        _viewmodel = new UsingCommand1ViewModel();
        this.BindingContext = _viewmodel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }

    public async void ButtonClicked(object sender, EventArgs args)
    {
        await DisplayAlert("Values of Item", $"Message: {_viewmodel.Message}\nCreation: {_viewmodel.Creation:F}", "OK");
    }
}