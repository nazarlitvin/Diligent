using System;
using System.Collections.Generic;

namespace Diligent.Models
{
	public sealed class WordStorage
	{
		private static readonly WordStorage instance = new WordStorage();

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static WordStorage()
		{ }

		private WordStorage()
		{ }

		public static WordStorage Instance { get { return instance; } }

		public List<Word> GetWords()
		{
			return data;
		}

		public void SetWords(List<Word> _data)
		{
			data = _data;
		}

		private List<Word> data { get; set; }
	}
}