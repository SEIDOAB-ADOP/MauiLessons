using MauiLessons.Models;

namespace MauiLessons.Views.Lesson05;

public partial class TabbedColorPage : ContentPage
{
	public TabbedColorPage()
	{
		InitializeComponent();
	}

	//Constructor invoked from the Shell menu passing data through a constructor
	public TabbedColorPage(NamedColor color):this()
	{
		this.BindingContext= color;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }
}