using System;
using Microsoft.Maui.Controls;
using MauiLessons.Models;

namespace MauiLessons.Views.Lesson04
{
    public partial class ListViewGroupingPage : ContentPage
    {
        public ListViewGroupingPage()
        {
            InitializeComponent();

            //Do Grouping is very easy with Linq - Keep the grouped list as an IEnumerable

            var ungrouped = Friend.Factory.CreateRandom(20);
            //For ungrouped do not forget to set the ListViews IsGroupingEnabled=false either in C# or in Xaml
            //lvFriends.ItemsSource = ungrouped;

            //For grouped do not forget to set the ListViews IsGroupingEnabled=true either in C# or in Xaml
            var grouped = ungrouped.OrderByDescending(f => f.Birthday).GroupBy(f => f.Birthday.Year);
            lvFriends.ItemsSource = grouped;


            //This is an alternative when binding ListView.ItemSource
            //lvFriends.BindingContext = Friend.Factory.CreateRandom(20);
        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            //Routing of this page
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }

        private async void lvFriends_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Check that the selected item is not null
            if (e.SelectedItem == null) return;

            await DisplayAlert("Selected", ((Friend)e.SelectedItem).ToString(), "Got it!");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button= (Button)sender;
            var item = ((Friend)button.CommandParameter);

            await DisplayAlert("Button Clicked", $"Hello {item.FirstName}!", "Got it!");

        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var item = ((Friend)mi.CommandParameter);

            await DisplayAlert("Menu Clicked", $"Invite {item.FirstName} to your party!", "Got it!");


        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var item = ((Friend)mi.CommandParameter);

            await DisplayAlert("Menu Clicked", $"Send a gift to {item.FirstName}!", "Got it!");
        }
    }
}