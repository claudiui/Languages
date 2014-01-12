using System.Collections.Generic;

namespace LanguagesBLL.Dictionary
{
	public interface IDictionaryDataAccess
	{
		IEnumerable<Word> GetWords(IEnumerable<int> levels);
		IEnumerable<int> GetLevelsForUser(string user);
	}
}
