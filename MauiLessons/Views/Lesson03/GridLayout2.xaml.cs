using System;
using System.Collections.Generic;


namespace MauiLessons.Views.Lesson03
{
	public partial class GridLayout2 : ContentPage
	{
		public GridLayout2()
		{
			InitializeComponent ();
		}
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
	}
}

