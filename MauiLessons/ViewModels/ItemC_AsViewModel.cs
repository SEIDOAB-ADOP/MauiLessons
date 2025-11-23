using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLessons.ViewModels
{
    #region ItemC_AsViewModel is ItemB with INotifyChange in inherited BaseViewModel
    public class ItemC_AsViewModel : BaseViewModel
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

        public ItemC_AsViewModel()
        {
            Message = "A message from item";
            Creation = DateTime.Now;
        }
    }
    #endregion
}
