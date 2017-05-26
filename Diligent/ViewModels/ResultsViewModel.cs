using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Diligent.Views;
using Diligent.Models;
using System.Linq;

namespace Diligent.ViewModels
{
    public class ResultsViewModel : INotifyPropertyChanged
    {
        public ResultsViewModel()
        {
            TryAgainCommand = new Command(() => Application.Current.MainPage = new WordsPage());

            WordList = WordStorage
                .Instance
                .GetWords()
				.Where(CheckCorrectness)
				.ToList();

			var mistakes = CalculateMistakes();
			ResultsMessage = "Mistakes: " + mistakes;
		}

        public string _resultsMessage { get; set; }

		public string ResultsMessage
		{
			get { return _resultsMessage; }
			set { _resultsMessage = value; OnPropertyChanged(); }
		}

		public ICommand TryAgainCommand { get; }

		public event PropertyChangedEventHandler PropertyChanged;

		private List<Word> _wordList { get; set; }
		public List<Word> WordList
		{
			get { return _wordList; }
			set { _wordList = value; OnPropertyChanged(); }
		}

		private int CalculateMistakes()
		{
			return WordList.Count(CheckCorrectness);
		}

        private Boolean CheckCorrectness(Word word) {
            return word.Value?.ToLower().Trim() != word.Translate.ToLower();
        }

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
