using System.Collections.Generic;
using System.Linq;

namespace LanguagesBLL.Dictionary
{
	public class DictionaryDataAccess : IDictionaryDataAccess
	{
		public IEnumerable<Word> GetWords(IEnumerable<int> levels)
		{
			using (var db = new LanguageFREntities())
			{
				var query = from w in db.Words select w;
				
				List<Word> result = query.ToList();

				return result;
			}
		}

		public IEnumerable<int> GetLevelsForUser(string user)
		{
			using (var db = new LanguageFREntities())
			{
				var query = from l in db.Levels
				            join u in db.Users on l.UserID equals u.ID
				            select l.Level1;

				var levels = query.ToList();
				return levels;
			}
		}
	}
}