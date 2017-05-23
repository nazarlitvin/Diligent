using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diligent.Models;
using Plugin.RestClient;

namespace Diligent.Services
{
    public class WordsServices
    {
		public async Task<List<Word>> GetWordsAsync()
		{
            RestClient<Word> restClient = new RestClient<Word>();

            var wordList = await restClient.GetAsync();

            return wordList;
        }
    }
}


