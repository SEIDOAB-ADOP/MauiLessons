namespace MauiLessons.Views.Lesson02
{
    public partial class SharedResourcesPage : ContentPage
    {
        public SharedResourcesPage()
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