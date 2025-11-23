namespace MauiLessons.Views.Lesson02
{
    public partial class OnPlatformDemoPage : ContentPage
    {
        public OnPlatformDemoPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
    }
}
