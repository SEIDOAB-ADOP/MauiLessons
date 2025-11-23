using MauiLessons.Views.Lesson05;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MauiLessons.ViewModels
{
    public class Lesson05aViewModel
    {
        private static string RoutePrefix = "//lesson5/hierachial/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }

        public Lesson05aViewModel(Type type, string title, string description, string route=null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }

        static Lesson05aViewModel()
        {
            All = new List<Lesson05aViewModel>
            {
                new Lesson05aViewModel(typeof(Actions), "Actions",
                        "Navigate to Actions page"),

                new Lesson05aViewModel(typeof(Alerts), "Alerts",
                        "Navigate to Alerts page"),
                
                new Lesson05aViewModel(typeof(Prompts), "Prompts",
                        "Navigate to Prompts page"),
            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson05aViewModel> All { private set; get; }
    }
}
