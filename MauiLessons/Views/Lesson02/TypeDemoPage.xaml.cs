using System.Windows.Input;

namespace MauiLessons.Views.Lesson02
{
    public partial class TypeDemoPage : ContentPage
    {
        public ICommand CreateCommand { get; private set; }
        public ICommand NavigateCommand { get; private set; }

        public TypeDemoPage()
        {
            InitializeComponent();

            CreateCommand = new Command<Type>((Type viewType) =>
            {
                View view = (View)Activator.CreateInstance(viewType);
                view.VerticalOptions = LayoutOptions.Center;
                stackLayout.Add(view);
            });

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            //Routing of this page
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
    }
}