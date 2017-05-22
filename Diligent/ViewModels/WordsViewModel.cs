using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;
using Diligent.Models;
using Diligent.Services;
using Diligent.Views;

namespace Diligent.ViewModels
{
	public class NavigationMessage
	{
		public string TargetView { get; set; }
		public object Parameter { get; set; }
	}

	public class WordsViewModel
	{
		public WordsViewModel()
		{
			var wordsServices = new WordsServices();

			WordList = wordsServices.GetWords();

            ShowResultsCommand = new Command(() => {
                var mistakes = CalculateMistakes();
                var message = "Mistakes: " + mistakes;

                Application.Current.MainPage = new ResultsPage();
				MessagingCenter.Send(this, "Hi", message);
            });
		}

        private int CalculateMistakes() {
			var mistakes = 0;

			foreach (var word in WordList)
			{
				if (word.Value?.ToLower().Trim() != word.Translate.ToLower())
				{
					mistakes++;
				}
			}

            return mistakes;
        }

        public List<Word> WordList { get; set; }

        public ICommand ShowResultsCommand { get; }
	}
}