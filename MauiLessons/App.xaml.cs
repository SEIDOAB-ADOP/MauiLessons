using MauiLessons.Globals;

namespace MauiLessons
{
    public partial class App : Application
    {
        public static string Message { get; set; }
        public static DateTime Time { get; set; }


        DateTime starttime = DateTime.Now;
        string greeting = "Application Started";

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new AppShell((starttime, greeting)));
        }

        protected override void OnStart()
        {
            //Demonstrate State management
            //using Global variables
            Global.Data.Message = greeting;
            Global.Data.Time = starttime;

            //using static properties in Application
            Message = greeting;
            Time = starttime;

            //using Application Properties Dictionary
            Preferences.Default.Set("Message", greeting);
            Preferences.Default.Set("Time", starttime.ToShortTimeString());
        }

        protected override void OnSleep()
        {
            //Application Properties Dictionary should be used for Disk persistance in Sleep
            Preferences.Default.Set("Message", "Application in Sleep");
            Preferences.Default.Set("Time", DateTime.Now.ToShortTimeString());
        }
    }
}