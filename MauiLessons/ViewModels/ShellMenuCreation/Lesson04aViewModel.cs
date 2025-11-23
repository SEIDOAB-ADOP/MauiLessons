using MauiLessons.Views.Lesson04;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MauiLessons.ViewModels
{
    public class Lesson04aViewModel
    {
        private static string RoutePrefix = "//lesson4/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }
        
        public Lesson04aViewModel(Type type, string title, string description, string route=null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }

        static Lesson04aViewModel()
        {
            All = new List<Lesson04aViewModel>
            {
                new Lesson04aViewModel(typeof(SettingValueDemoPage), "Setting and Getting Values Demo",
                        "Set and get values from various UI elements"),

                new Lesson04aViewModel(typeof(AlteringViewXamlPage), "Altering View",
                        "Alter view properties using XAML binding"),

                new Lesson04aViewModel(typeof(ListViewDemoPage), "ListView Demo",
                        "Use a ListView with data bindings"),
 
                new Lesson04aViewModel(typeof(ListViewCustomizationPage), "ListView Customization",
                        "Customize a ListView using ViewCell"),
                
                new Lesson04aViewModel(typeof(ListViewGroupingPage), "ListView Grouping",
                        "Group ListView using GroupHeaderTemplate and Linq"),

                new Lesson04aViewModel(typeof(ApplicationState), "Application State Management",
                        "Read the Application global variables set in App.xaml.cs"),
                
            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson04aViewModel> All { private set; get; }
    }
}
