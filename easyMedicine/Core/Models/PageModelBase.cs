using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace easyMedicine.Core.Models
{
	public abstract class PageModelBase : IPageModel
	{
		public string Title { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public void SetState<T> (Action<T> action) where T : class, IPageModel
		{
			action (this as T);
		}

		protected virtual bool SetProperty<T> (ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (object.Equals (storage, value))
				return false;

			storage = value;
			OnPropertyChanged (propertyName);

			return true;
		}

		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			var eventHandler = PropertyChanged;
			if (eventHandler != null) {
				eventHandler (this, new PropertyChangedEventArgs (propertyName));
			}
		}

		protected void OnPropertyChanged<T> (Expression<Func<T>> propertyExpression)
		{
			var propertyName = PropertySupport.ExtractPropertyName (propertyExpression);
			OnPropertyChanged (propertyName);
		}

		public async Task LoadAsync ()
		{
			if (CreationAction) {
				await Started ();
				CreationAction = false;
			}
			await Activated ();
		}

		public async Task UnloadAsync ()
		{
			await Deactivated ();
		}

		public bool CreationAction {
			get;
			set;
		}

		protected async virtual Task Started ()
		{
		}

		protected async virtual  Task Activated ()
		{
		}

		protected async virtual  Task Deactivated ()
		{

		}

		public virtual bool IsShareActive {
			get{ return false; }
		}

		public virtual string ShareUrl {
			get{ return String.Empty; }
		}

		public virtual string ShareTitle {
			get{ return null; }
		}

		public virtual string ShareMessage {
			get{ return null; }
		}

		public virtual void Share ()
		{
			//if (IsShareActive && (!String.IsNullOrEmpty (ShareUrl)))
			//CrossShare.Current.ShareLink (this.ShareUrl, this.ShareMessage, this.ShareTitle);

		}

		public const string IsShareActivePropertyName = "IsShareActive";




		public virtual  void LoadChildPages ()
		{
		}
		/* public async virtual Task LoadAsync()
        {

        }*/



	}


}

