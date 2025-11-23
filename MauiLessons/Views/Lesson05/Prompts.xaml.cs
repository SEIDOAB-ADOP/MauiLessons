namespace MauiLessons.Views.Lesson05;

public partial class Prompts : ContentPage, IQueryAttributable
{
    //Data that is passed from Alerts as IDictionary<string, object>
    //Properties mapped from query parameters using IQueryAttributable implementation 
    public DateTime? time { get; set; }      //nullable DateTime struct in case no data is passed to page
    public string message { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        //when data is passed as IDictionary, they are passed as their types, not text
        time = query.ContainsKey("time") ? query["time"] as DateTime? : null;         
        message = query.ContainsKey("message") ? query["message"] as string : null;
    }

    public Prompts()
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
        //This is a safe time to initialize the page, e.g. use the data passed as a IDictionary
        lblMessage.Text = message;
        lblTime.Text = time.HasValue ? time.Value.ToString() : null;

        base.OnAppearing();
    }

    async void OnQuestion1ButtonClicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 1", "What's your name?", initialValue: string.Empty);
        if (!string.IsNullOrWhiteSpace(result))
        {
            lblAnswer.Text = $"Hello {result}.";
        }
    }

    async void OnQuestion2ButtonClicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 2", "What's 5 + 5?", initialValue: "10",
            maxLength: 2, keyboard: Keyboard.Numeric);
        if (!string.IsNullOrWhiteSpace(result))
        {
            int number = Convert.ToInt32(result);
            lblAnswer.Text = number == 10 ? "Correct." : "Incorrect.";
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//lesson5/hierachial/alerts");
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}