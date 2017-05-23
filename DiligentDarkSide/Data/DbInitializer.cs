using System;
using System.Linq;
using DiligentDarkSide.Models;

namespace DiligentDarkSide.Data
{
	public static class DbInitializer
	{
		public static void Initialize(DiligentContext context)
		{
			context.Database.EnsureCreated();

			// Look for any words.
			if (context.Words.Any())
			{
				return;   // DB has been seeded
			}

			var words = new Word[]
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

			foreach (Word w in words)
			{
				context.Words.Add(w);
			}

			context.SaveChanges();
		}
	}
}