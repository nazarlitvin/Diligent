using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Diligent.Views;

namespace Diligent.ViewModels
{
    public class ResultsViewModel : INotifyPropertyChanged
    {
        public ResultsViewModel()
        {
            TryAgainCommand = new Command(() => Application.Current.MainPage = new WordsPage());
            SubscribeToResult();
		}

        public string _resultsMessage { get; set; }

		public string ResultsMessage
		{
			get { return _resultsMessage; }
			set
			{
				_resultsMessage = value;
				OnPropertyChanged();
			}
		}

		public ICommand TryAgainCommand { get; }

		public event PropertyChangedEventHandler PropertyChanged;

        private void SubscribeToResult()
        {
			MessagingCenter.Subscribe<WordsViewModel, string>(this, "Hi", (sender, resultMessage) =>
			{
				ResultsMessage = resultMessage;
			});
        }

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
