using MauiLessons.Views.Lesson03;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MauiLessons.ViewModels
{
    public class Lesson03aViewModel
    {
        private static string RoutePrefix = "//lesson3/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }

        public Lesson03aViewModel(Type type, string title, string description, string route=null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }
        static Lesson03aViewModel()
        {
            All = new List<Lesson03aViewModel>
            {
                
                    new Lesson03aViewModel(typeof(StackLayout1), "StackLayout demo1",
                                      "Explore StackLayout"),
                    new Lesson03aViewModel(typeof(AbsoluteLayout1), "AbsoluteLayout demo1",
                                      "Explore AbsoluteLayout"),
                    new Lesson03aViewModel(typeof(AbsoluteLayout2), "AbsoluteLayout demo2",
                                      "AbsoluteLayout more advanced"),
                    new Lesson03aViewModel(typeof(GridLayout1), "GridLayout demo1",
                                      "Explore GridLayout"),
                    new Lesson03aViewModel(typeof(GridLayout2), "GridLayout demo2",
                                      "GridLayout more advanced")
            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson03aViewModel> All { private set; get; }
    }
}
