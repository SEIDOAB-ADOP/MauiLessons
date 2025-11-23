using MauiLessons.ViewModels;

namespace MauiLessons.Views
{

    public partial class Lesson07a : ContentPage
    {
        public Lesson07a()
        {
            InitializeComponent();
        }
        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                Lesson07aViewModel pageData = args.SelectedItem as Lesson07aViewModel;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                //await Navigation.PushAsync(page);
                await Shell.Current.GoToAsync(pageData.Route);
            }
        }
    }
}