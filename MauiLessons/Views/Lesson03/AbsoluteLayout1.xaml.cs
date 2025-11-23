using System;
using System.Collections.Generic;

namespace MauiLessons.Views.Lesson03
{
	public partial class AbsoluteLayout1 : ContentPage
	{
		public AbsoluteLayout1()
		{
			InitializeComponent ();
		}
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            //Routing of this page
            Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
        }
    }
}

