using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Diligent.Models;
using Diligent.Services;
using Diligent.Views;
using System.Linq;

namespace Diligent.ViewModels
{
    public class WordsViewModel : INotifyPropertyChanged
    {
        public WordsViewModel()
        {
            WordsAreLoading = false;

            FetchWords();

            ShowResultsCommand = new Command(() =>
            {
                var mistakes = CalculateMistakes();
                var message = "Mistakes: " + mistakes;

                Application.Current.MainPage = new ResultsPage();
                MessagingCenter.Send(this, "Hi", message);
            });
        }

        private async void FetchWords()
        {
			WordsAreLoading = true;

            var wordsServices = new WordsServices();
            WordList = await wordsServices.GetWordsAsync();

            WordsAreLoading = false;
        }

        private int CalculateMistakes()
        {
            return WordList.Count(w => w.Value?.ToLower().Trim() != w.Translate.ToLower());
        }

        private List<Word> _wordList { get; set; }
		public List<Word> WordList
		{
			get { return _wordList; }
			set
			{
				_wordList = value;
				OnPropertyChanged();
			}
		}

        private Boolean _wordsAreLoading { get; set; }
		public Boolean WordsAreLoading
		{
			get { return _wordsAreLoading; }
			set
			{
				_wordsAreLoading = value;
				OnPropertyChanged();
			}
		}

        public ICommand ShowResultsCommand { get; }

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}