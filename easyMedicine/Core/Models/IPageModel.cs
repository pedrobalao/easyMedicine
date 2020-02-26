using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace easyMedicine.Core.Models
{


    public interface IPageModel : INotifyPropertyChanged
    {
        string Title { get; set; }

        void SetState<T>(Action<T> action) where T : class, IPageModel;

        Task LoadAsync();

        Task LoadChildPages();

        bool CreationAction
        {
            get;
            set;
        }
    }


}

