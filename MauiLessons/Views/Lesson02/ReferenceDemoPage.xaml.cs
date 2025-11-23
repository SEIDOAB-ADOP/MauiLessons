namespace MauiLessons.Views.Lesson02
{
    public partial class ReferenceDemoPage : ContentPage
    {
        public ReferenceDemoPage()
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