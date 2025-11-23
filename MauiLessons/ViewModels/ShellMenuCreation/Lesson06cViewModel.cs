using MauiLessons.Views.Lesson06;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MauiLessons.ViewModels
{
    public class Lesson06cViewModel
    {
        private static string RoutePrefix = "//lesson6/viewmodels/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }

        public Lesson06cViewModel(Type type, string title, string description, string route = null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }
        static Lesson06cViewModel()
        {
            All = new List<Lesson06cViewModel>
            {
                new Lesson06cViewModel(typeof(UsingCommand1), "Viewmodel using Command 1",
                        "Full ViewModel implemented"),

                new Lesson06cViewModel(typeof(UsingCommand2), "Viewmodel using Command 2",
                        "L4 ListViewDemo implemented with full ViewModel"),

                new Lesson06cViewModel(typeof(DecimalKeypadPage), "Advanced Command",
                        "Decimal keypad with ViewModel and Commands"),
            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson06cViewModel> All { private set; get; }
    }
}
