using System;
using Microsoft.Maui.Controls;

using MauiLessons.Globals;
using MauiLessons.Models;

namespace MauiLessons.Views.Lesson04
{

	public partial class ApplicationState : ContentPage
	{
        
        public ApplicationState()
		{
			InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            //Routing of this page
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Reading the Globals Lazy data 
            globalMessage.Text = Global.Data.Message;
            globalTime.Text = Global.Data.Time.ToShortTimeString();

            //Reading App static properties
            appPropMessage.Text = App.Message;
            appPropTime.Text = App.Time.ToShortTimeString();

            //Reading Preference Dictionary
            prefMessage.Text = Preferences.Default.Get("Message", "Unknown");
            prefTime.Text = Preferences.Default.Get("Time", "Unknown");
        }
    }
}

