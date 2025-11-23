using MauiLessons.Views.Lesson06;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MauiLessons.ViewModels
{
    public class Lesson06bViewModel
    {
        private static string RoutePrefix = "//lesson6/nontrivialbinding/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }

        public Lesson06bViewModel(Type type, string title, string description, string route = null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }
        static Lesson06bViewModel()
        {
            All = new List<Lesson06bViewModel>
            {
                new Lesson06bViewModel(typeof(NonTrivialDataBinding1), "Non trivial Databinding 1",
                        "Without INotifyPropertyChange implemented"),

                new Lesson06bViewModel(typeof(NonTrivialDataBinding2), "Non trivial Databinding 2",
                        "With INotifyPropertyChange implemented"),

                new Lesson06bViewModel(typeof(NonTrivialDataBinding3), "Non trivial Databinding 3",
                        "Towards ViewModel"),
            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson06bViewModel> All { private set; get; }
    }
}
