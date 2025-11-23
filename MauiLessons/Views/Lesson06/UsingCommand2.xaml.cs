using MauiLessons.Models;
using MauiLessons.ViewModels;

namespace MauiLessons.Views.Lesson06;

public partial class UsingCommand2 : ContentPage
{
    UsingCommand2ViewModel _viewmodel;
    public UsingCommand2()
	{
        InitializeComponent();
        _viewmodel = new UsingCommand2ViewModel();
        this.BindingContext = _viewmodel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }
    private async void lvFriends_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //Check that the selected item is not null
        if (e.SelectedItem == null) return;

        await DisplayAlert("Selected", ((Friend)e.SelectedItem).ToString(), "Got it!");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var item = ((Friend)button.CommandParameter);

        await DisplayAlert("Button Clicked", $"Hello {item.FirstName}!\n{item}", "Got it!");
    }
}