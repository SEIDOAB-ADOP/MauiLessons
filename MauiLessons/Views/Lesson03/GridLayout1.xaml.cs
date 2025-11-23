using System;
using System.Collections.Generic;

namespace MauiLessons.Views.Lesson03
{
	public partial class GridLayout1 : ContentPage
	{
		public GridLayout1()
		{
			InitializeComponent();
		}
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
	}
}

