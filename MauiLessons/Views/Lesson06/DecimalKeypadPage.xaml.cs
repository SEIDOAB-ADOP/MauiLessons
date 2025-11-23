namespace MauiLessons.Views.Lesson06;

public partial class DecimalKeypadPage : ContentPage
{
	public DecimalKeypadPage()
	{
		InitializeComponent();
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }
}