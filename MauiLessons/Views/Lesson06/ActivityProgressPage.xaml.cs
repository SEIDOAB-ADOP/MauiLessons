namespace MauiLessons.Views.Lesson06;

public partial class ActivityProgressPage : ContentPage
{
    bool isTaskRunning;
    float progress = 0f;
    
    public ActivityProgressPage()
	{
		InitializeComponent();
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
        runningStatusLabel.Text = isTaskRunning ? "A task is in progress." : "All tasks complete!";
        defaultActivityIndicator.IsRunning = isTaskRunning;
        styledActivityIndicator.IsRunning = isTaskRunning;
    }
}