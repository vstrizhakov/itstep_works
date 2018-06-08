using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hospital.Models
{
    public class MenuItemModel : INotifyPropertyChanged
    {
		private string name;
		private object content;

		public MenuItemModel(string name, object content)
		{
			this.Name = name;
			this.Content = content;
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				this.name = value;
				this.OnPropertyChanged("Name");
			}
		}

		public object Content
		{
			get { return this.content; }
			set
			{
				this.content = value;
				this.OnPropertyChanged("Content");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(/*[CallerMemberName]*/string prop = "")
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
    }
}
