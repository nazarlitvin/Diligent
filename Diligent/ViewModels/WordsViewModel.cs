using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Diligent.Models;
using Diligent.Services;
using Diligent.Views;

namespace Diligent.ViewModels
{
    public class WordsViewModel : INotifyPropertyChanged
    {
        public WordsViewModel()
        {
            FetchWords();

            ShowResultsCommand = new Command(() =>
            {
                WordStorage.Instance.SetWords(WordList);
                Application.Current.MainPage = new ResultsPage();
            });
        }

        private async void FetchWords()
        {
			WordsAreLoading = true;

            var wordsServices = new WordsServices();
            WordList = await wordsServices.GetWordsAsync();

            WordsAreLoading = false;
        }

        private List<Word> _wordList { get; set; } 
		public List<Word> WordList
		{
			get { return _wordList; }
			set { _wordList = value; OnPropertyChanged(); }
		}

        private Boolean _wordsAreLoading { get; set; } = false;
		public Boolean WordsAreLoading
		{
			get { return _wordsAreLoading; }
			set { _wordsAreLoading = value; OnPropertyChanged(); }
		}

        public ICommand ShowResultsCommand { get; }

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void listSelection(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}