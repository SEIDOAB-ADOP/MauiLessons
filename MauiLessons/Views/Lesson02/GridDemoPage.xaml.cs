namespace MauiLessons.Views.Lesson02
{
    public partial class GridDemoPage : ContentPage
    {
        public GridDemoPage()
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
}