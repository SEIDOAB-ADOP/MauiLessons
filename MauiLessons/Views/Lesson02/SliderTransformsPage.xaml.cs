namespace MauiLessons.Views.Lesson02
{
    public partial class SliderTransformsPage : ContentPage
    {
        public SliderTransformsPage()
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