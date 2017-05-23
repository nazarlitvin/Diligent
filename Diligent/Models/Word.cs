using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Diligent.Models
{
    public class Word : INotifyPropertyChanged
    {
		public string Title { get; set; }

		public string Translate { get; set; }

		private string _value { get; set; }

		public string Value
		{
			get { return _value; }
			set { _value = value; OnPropertyChanged(); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
