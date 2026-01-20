using MauiLessons.Services;

namespace MauiLessons.Views.Lesson06;

public partial class ActivityProgressPage2 : ContentPage
{
    public string Message { get; set; } = "Click the button to start calculating prime numbers in batches of 1,000,000.";  

    PrimeNumberService _service;
    Progress<float> _progressReporter;
    
    public ActivityProgressPage2()
	{
		InitializeComponent();

        _service = new PrimeNumberService();
        _progressReporter = new Progress<float>(async value =>
        {
            defaultProgressBar.Progress = value;
            await styledProgressBar.ProgressTo(value, 750, Easing.Linear);
        });

        BindingContext = this;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }

    async void OnButtonClicked(object sender, EventArgs e)
    {
        Message = "Calculating prime numbers...";
        OnPropertyChanged(nameof(Message));

        /*
        IProgress<float> onProgressReporting = _progressReporter;


        await Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Task.Delay(50).Wait();
                onProgressReporting.Report(i / 100f);
            }
        });
        */
        var result = await _service.GetPrimeBatchCountsAsync(20, _progressReporter);

        Message = $"Calculated {result.Sum(b => b.NrPrimes)} prime numbers in {result.Count} batches.";
        //Message = "Done";
        OnPropertyChanged(nameof(Message));
    }
}