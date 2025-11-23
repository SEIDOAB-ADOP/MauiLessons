using Microsoft.Maui.Controls;

namespace MauiLessons.Views.Lesson05;

//Data that is passed from Actions as querystring
//Example of using QueryProperty attributes to map to public properties in Alerts
[QueryProperty(nameof(time), "time")]
[QueryProperty(nameof(message), "message")]
public partial class Alerts : ContentPage
{
    //Data that is passed from Actions as querystring
    //Properties mapped from query parameters using QueryProperty above 
    public string time { get; set; }
    public string message { get; set; }

    public Alerts()
	{
		InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }
    protected override void OnAppearing()
    {
        //This is a safe time to initialize the page, e.g. use the data passed as a querystring
        lblMessage.Text = message;
        lblTime.Text = time;

        base.OnAppearing();
    }

    async void OnAlertSimpleClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", $"You have been alerted", "OK");
    }

    async void OnAlertYesNoClicked(object sender, EventArgs e)
    {
        var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        lblAnswer.Text = $"Action: {answer}";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //Pass data with QueryString to Alerts
        //Example using Dictionary to generate a querystring
        var queryParams = new Dictionary<string, object>();

        queryParams.Add("message", $"{message}. Hello from {nameof(Alerts)}");
        queryParams.Add("time", DateTime.Now);  //Note that I pass this as a DateTime not a string 

        await Shell.Current.GoToAsync("//lesson5/hierachial/prompts", queryParams);
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//lesson5/hierachial/actions");
    }
    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}