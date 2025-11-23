using MauiLessons.Models;
using MauiLessons.Views.Lesson04;
using MauiLessons.Views.Lesson05;


namespace MauiLessons;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

    public AppShell()
	{
		InitializeComponent();
	}

    //alternative constructor to show parameter passing from App.xaml.cs
    public AppShell((DateTime date, string greeting) shellData) : this()
	{
        //Demonstrate how I receieve data from App using AppShell constructor 
        var recievedDate = shellData.date;
        var recievedGreeting = shellData.greeting;


        //Demonstrate how to dynamically build menus in Shell and
        //using parameters to pass data through page constructor
        var Colors = NamedColor.All.ToList();
        var aTab = new Tab { Title = Colors[0].FriendlyName };
        aTab.Items.Add(new ShellContent
        {
            Title = Colors[0].FriendlyName,
            Route = Colors[0].Name.ToLower(),
            ContentTemplate = new DataTemplate(() => new TabbedColorPage(Colors[0]))
        });
        flyLesson05.Items.Add(aTab);

        aTab = new Tab { Title = Colors[1].FriendlyName };
        aTab.Items.Add(new ShellContent
        {
            Title = Colors[1].FriendlyName,
            Route = Colors[1].Name.ToLower(),
            ContentTemplate = new DataTemplate(() => new TabbedColorPage(Colors[1]))
        });
        flyLesson05.Items.Add(aTab);

        aTab = new Tab { Title = Colors[2].FriendlyName };
        aTab.Items.Add(new ShellContent
        {
            Title = Colors[2].FriendlyName,
            Route = Colors[2].Name.ToLower(),
            ContentTemplate = new DataTemplate(() => new TabbedColorPage(Colors[2]))
        });
        flyLesson05.Items.Add(aTab);
    }
}
