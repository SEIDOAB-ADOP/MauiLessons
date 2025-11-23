using MauiLessons.ViewModels;

namespace MauiLessons.Views
{

    public partial class Lesson06b : ContentPage
    {
        public Lesson06b()
        {
            InitializeComponent();
        }
        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                Lesson06bViewModel pageData = args.SelectedItem as Lesson06bViewModel;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                //await Navigation.PushAsync(page);
                await Shell.Current.GoToAsync(pageData.Route);
            }
        }
    }
}