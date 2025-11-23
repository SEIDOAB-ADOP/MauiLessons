namespace MauiLessons.Views.Lesson02
{
    public partial class SliderBindingsPage1 : ContentPage
    {
        public SliderBindingsPage1()
        {
            InitializeComponent();

            label2.SetBinding(Label.RotationProperty, new Binding("Value", source: slider2a));
            label2.SetBinding(Label.ScaleProperty, new Binding("Value", source: slider2b));
            label2.SetBinding(Label.OpacityProperty, new Binding("Value", source: slider2c));
        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
    }
}