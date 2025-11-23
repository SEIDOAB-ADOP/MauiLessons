using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MauiLessons.ViewModels
{
    #region UsingCommand1ViewModel is ItemC implemented as a full ViewModel
    public class UsingCommand1ViewModel : BaseViewModel
    {
        
        string _message;
        public string Message
        {
            set => Set<string>(ref _message, value, "Message");
            get => _message;
        }

        DateTime _creation;
        public DateTime Creation
        {
            set => Set<DateTime>(ref _creation, value, "Creation");
            get => _creation;
        }


        Random rnd;

        ICommand _changeValueCommand;
        public ICommand ChangeValueCommand => _changeValueCommand;

        public UsingCommand1ViewModel()
        {
            Message = "A message from item";
            Creation = DateTime.Now;

            rnd = new Random();
            _changeValueCommand = new Command<string>(OnChangeValues);
        }

        private void OnChangeValues(string commandParameter)
        {

            Message = $"A message set in C# code with a random number: {rnd.Next(1000)}, Parameter: {commandParameter}";
            Creation += new TimeSpan(10, 10, 10, 0); // add 10 days, 10 hours, 10 minutes 
        }
    }
    #endregion
}
