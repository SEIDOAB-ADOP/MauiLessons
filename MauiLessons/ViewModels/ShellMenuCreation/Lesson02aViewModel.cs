using MauiLessons.Views.Lesson02;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MauiLessons.ViewModels
{
    public class Lesson02aViewModel
    {
        private static string RoutePrefix = "//lesson2/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }

        public Lesson02aViewModel(Type type, string title, string description, string route = null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }

        static Lesson02aViewModel()
        {
            All = new List<Lesson02aViewModel>
            {
                
                // Part 1. Getting Started with XAML
                new Lesson02aViewModel(typeof(HelloXamlPage), "Hello, XAML",
                                      "Display a Label with many properties set"),

                new Lesson02aViewModel(typeof(XamlPlusCodePage), "XAML + Code",
                                      "Interact with a Slider and Button"),

                // Part 2. Essential XAML Syntax
                new Lesson02aViewModel(typeof(GridDemoPage), "Grid Demo",
                                      "Explore XAML syntax with the Grid"),

                /*
                 // Part 3. XAML Markup Extensions
                new Lesson02aViewModel(typeof(SharedResourcesPage), "Shared Resources",
                                      "Using resource dictionaries to share resources"),


                new Lesson02aViewModel(typeof(StaticDemoPage), "x:Static Demo",
                                      "Using the x:Static markup extensions"),
                */

                new Lesson02aViewModel(typeof(TypeDemoPage), "x:Type Demo",
                                      "Associate Buttons with a Type"),

                new Lesson02aViewModel(typeof(ReferenceDemoPage), "x:Reference Demo",
                                      "Reference named elements on the page in Binding"),

                new Lesson02aViewModel(typeof(OnPlatformDemoPage), "OnPlatform Demo",
                        "Specify values per platform"),
 
                new Lesson02aViewModel(typeof(OnIdiomDemoPage), "OnIdiom Demo",
                        "Specify values per idiom"),
                               
                new Lesson02aViewModel(typeof(SliderBindingsPage1), "Slider Bindings1",
                                      "Bind using Source={x:Reference Name="),

                new Lesson02aViewModel(typeof(SliderBindingsPage2), "Slider Bindings2",
                                      "Bind using BindingContext={x:Reference"),

                new Lesson02aViewModel(typeof(SliderTransformsPage), "Slider Transforms",
                                      "More advanced binding example"),

                 new Lesson02aViewModel(typeof(StringFormattingPage), "String Formatting1",
                                      "Use standard .NET formatting specfications"),
                 
                 new Lesson02aViewModel(typeof(MultiBindingStringFormatPage), "String Formatting2",
                                      "Combine strings from a MultiBinding"),
            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson02aViewModel> All { private set; get; }
    }
}
