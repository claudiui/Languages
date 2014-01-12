using System;
using System.Collections.Generic;

namespace LanguagesBLL.Dictionary
{
	public class DictionaryProvider : IDictionaryProvider
	{
		private readonly IDictionaryDataAccess _dataAccess;

		public DictionaryProvider(IDictionaryDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public IEnumerable<Word> GetWords(IEnumerable<int> levels)
		{
			IEnumerable<Word> words = _dataAccess.GetWords(new int[]{1});
			return words;
		}

		public IEnumerable<int> GetLevelsForUser(string user)
		{
			return _dataAccess.GetLevelsForUser(user);
		}
	}
}
