namespace MauiLessons.Views.Lesson06;

public partial class ActivityProgressPage : ContentPage
{
    bool isTaskRunning = false;
    float progress = 0f;

    public string ActivityText { get; set; } = "All tasks complete!";


    public ActivityProgressPage()
	{
		InitializeComponent();
        BindingContext = this;

        UpdateUiState();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }

    async void OnButtonClicked(object sender, EventArgs e)
    {
        progress += 0.2f;

        if (progress > 1)
        {
            progress = 0;
        }

        // directly set the new progress value
        defaultProgressBar.Progress = progress;

        // animate to the new value over 750 milliseconds using Linear easing
        await styledProgressBar.ProgressTo(progress, 750, Easing.Linear);
    }
    void OnButtonClicked1(object sender, EventArgs e)
    {
        isTaskRunning = !isTaskRunning;
        UpdateUiState();
    }


    void UpdateUiState()
    {
        ActivityText = isTaskRunning ? "A task is in progress." : "All tasks complete!";
        OnPropertyChanged(nameof(ActivityText));

        defaultActivityIndicator.IsRunning = isTaskRunning;
        styledActivityIndicator.IsRunning = isTaskRunning;
    }
}