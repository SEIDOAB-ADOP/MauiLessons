using MauiLessons.Views.Lesson06;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MauiLessons.ViewModels
{
    public class Lesson06aViewModel
    {
        private static string RoutePrefix = "//lesson6/indicators/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }

        public Lesson06aViewModel(Type type, string title, string description, string route = null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }


        static Lesson06aViewModel()
        {
            All = new List<Lesson06aViewModel>
            {
                new Lesson06aViewModel(typeof(ActivityProgressPage), "ActivityIndicator and ProgressBar",
                        "Show usage of Activity and Progress indicators"),
            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson06aViewModel> All { private set; get; }
    }
}
