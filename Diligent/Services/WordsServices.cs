using System;
using System.Collections.Generic;
using Diligent.Models;

namespace Diligent.Services
{
    public class WordsServices
    {
        public List<Word> GetWords()
        {
            var list = new List<Word>
            {
				new Word
				{
					Title = "Старательный",
					Translate = "Diligent"
				},
				new Word
				{
					Title = "Работодатель",
					Translate = "Eployer"
				},
				new Word
				{
                    Title = "Хирург",
					Translate = "Surgeon"
				},
				new Word
				{
					Title = "Пылесос",
					Translate = "Vacuum cleaner"
				},
				new Word
				{
					Title = "Щедрий",
					Translate = "Generous"
				},
            };

            return list;
        }
    }
}


