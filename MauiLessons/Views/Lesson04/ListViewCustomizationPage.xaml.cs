using System;
using Microsoft.Maui.Controls;
using MauiLessons.Models;

namespace MauiLessons.Views.Lesson04
{
    public partial class ListViewCustomizationPage : ContentPage
    {
        public ListViewCustomizationPage()
        {
            InitializeComponent();
            lvFriends.ItemsSource = Friend.Factory.CreateRandom(20);

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
            var item = (Friend)mi.CommandParameter;

            await DisplayAlert("Menu Clicked", $"Invite {item.FirstName} to your party!", "Got it!");


        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var item = (Friend)mi.CommandParameter;

            await DisplayAlert("Menu Clicked", $"Send a gift to {item.FirstName}!", "Got it!");
        }
    }
}