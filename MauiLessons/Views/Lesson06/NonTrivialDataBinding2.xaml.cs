using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiLessons.Views.Lesson06;

public partial class NonTrivialDataBinding2 : ContentPage
{
    ItemB item;
    Random rnd;

    public NonTrivialDataBinding2()
	{
		InitializeComponent();

        item = new ItemB { Message = "A message from item", Creation = DateTime.Now };
        rnd = new Random();

        this.BindingContext = item;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Routing of this page
        Title += $"   ({Shell.Current.CurrentState.Location.ToString()})";
    }
    public async void ButtonClicked(object sender, EventArgs args)
    {
        await DisplayAlert("Values of Item", $"Message: {item.Message}\nCreation: {item.Creation:F}", "OK");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        item.Message = $"A message set in C# code with a random number: {rnd.Next(1000)}";
        item.Creation = item.Creation + new TimeSpan(10, 10, 10, 0); // add 10 days, 10 hours, 10 minutes 
    }
}

#region ItemB is ItemA with INotifyPropertyChange
public class ItemB : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    string _message;

    public string Message
    {
        set
        {
            if (value != _message)
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        get => _message;
    }

    DateTime _creation;

    public DateTime Creation
    {
        set
        {
            if (value != _creation)
            {
                _creation = value;
                OnPropertyChanged("Creation");
            }
        }
        get => _creation;
    }


    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
#endregion