using System;
using Microsoft.Maui.Controls;
using MauiLessons.Models;

namespace MauiLessons.Views.Lesson04
{
    public partial class ListViewDemoPage : ContentPage
    {
        public ListViewDemoPage()
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

        private async void lvFriends_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Friend friend = (Friend)e.Item;
            await DisplayAlert("Tapped", friend.ToString(), "Got it!");
        }

        private async void lvFriends_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Check that the selected item is not null
            if (e.SelectedItem == null) return;

            await DisplayAlert("Selected", ((Friend)e.SelectedItem).ToString(), "Got it!");
        }
    }
}