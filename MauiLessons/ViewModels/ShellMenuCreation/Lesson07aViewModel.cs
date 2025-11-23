using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;


using MauiLessons.Views.Lesson07;
namespace MauiLessons.ViewModels
{
    public class Lesson07aViewModel
    {
        private static string RoutePrefix = "//lesson7/";
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public string Route { private set; get; }

        public Lesson07aViewModel(Type type, string title, string description, string route = null)
        {
            Type = type;
            Title = title;
            Description = description;
            Route = route ?? RoutePrefix + Regex.Replace(title.ToLower(), @"\W", "");
        }
        static Lesson07aViewModel()
        {
            All = new List<Lesson07aViewModel>
            {
                new Lesson07aViewModel(typeof(PrimesAppStep1), "Primes Application Step1",
                        "Very basic. Moving Model and Services into MAUI"),
                
                new Lesson07aViewModel(typeof(PrimesAppStep2), "Primes Application Step2",
                        "Query parameters to initiate page. BindingContext set to page class. OnAppearing to load primes",
                        "//lesson7/primesapplicationstep2?NrBatches=2"),

                new Lesson07aViewModel(typeof(PrimesAppStep3), "Primes Application Step3",
                        "Adding ProgressBar and ActivityIndicator",
                        "//lesson7/primesapplicationstep3?NrBatches=2"),
                
                new Lesson07aViewModel(typeof(PrimesAppStep4), "Primes Application Step4",
                        "Adding TappedItem eventhandler, AlertBox and Write all primes to disk",
                        "//lesson7/primesapplicationstep4?NrBatches=2"),
                
                new Lesson07aViewModel(typeof(PrimesAppStep5), "Primes Application Step5",
                        "Step4 refractured into ViewModel",
                        "//lesson7/primesapplicationstep5?NrBatches=2"),


            };

            foreach (var item in All)
            {
                Routing.RegisterRoute(item.Route, item.Type);
            }
        }

        public static IList<Lesson07aViewModel> All { private set; get; }
    }
}
