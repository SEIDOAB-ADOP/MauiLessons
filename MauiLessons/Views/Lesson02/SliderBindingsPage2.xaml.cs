namespace MauiLessons.Views.Lesson02
{
    public partial class SliderBindingsPage2 : ContentPage
    {
        public SliderBindingsPage2()
        {
            InitializeComponent();

            //C# Binding using BindingContext
            brdBinding.BindingContext = slider2;
        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
    }
}