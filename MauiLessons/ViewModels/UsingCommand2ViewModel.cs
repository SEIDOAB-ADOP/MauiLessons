using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

using MauiLessons.Models;


namespace MauiLessons.ViewModels
{
    public class UsingCommand2ViewModel : BaseViewModel
    {
        public ObservableCollection<Friend> Items { get; set; }

        ICommand _changeCommand;
        ICommand _deleteCommand;

        public ICommand ChangeCommand => _changeCommand;
        public ICommand DeleteCommand => _deleteCommand;

        public UsingCommand2ViewModel()
        {
            Items = new ObservableCollection<Friend>(Friend.Factory.CreateRandom(20));

            _changeCommand = new Command<Friend>(OnChange);
            _deleteCommand = new Command<Friend>(OnDelete);
        }

        private void OnChange(Friend friend)
        {
            int idx = Items.IndexOf(friend);
            Items[idx] = Friend.Factory.CreateRandom();

        }
        private void OnDelete(Friend friend)
        {
            int idx = Items.IndexOf(friend);
            Items.RemoveAt(idx);
        }
    }
}
