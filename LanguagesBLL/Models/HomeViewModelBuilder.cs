using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LanguagesBLL.Dictionary;
using Newtonsoft.Json;

namespace LanguagesBLL.Models
{
	public class HomeViewModelBuilder
	{
		private readonly IDictionaryProvider _dictionaryProvider;
		private readonly IUserProvider _userProvider;

		public HomeViewModelBuilder(IDictionaryProvider dictionaryProvider, IUserProvider userProvider)
		{
			_dictionaryProvider = dictionaryProvider;
			_userProvider = userProvider;
		}

		public HomeViewModel GetViewModel()
		{
			HomeViewModel viewModel = new HomeViewModel();

			viewModel.Title = "Francez - Roman";
			viewModel.Types.Add(new SelectListItem()
			{
				Selected = true,
				Text = "Francez - Roman",
				Value = "FR-RO"
			});

			viewModel.Types.Add(new SelectListItem()
			{
				Selected = false,
				Text = "Roman - Francez",
				Value = "RO-FR"
			});

			string currentUser = _userProvider.GetUser();
			IEnumerable<int> levels = _dictionaryProvider.GetLevelsForUser(currentUser);

			viewModel.Levels.AddRange(levels.Select(l => new SelectListItem
			{
				Selected = true,
				Value = l.ToString(CultureInfo.InvariantCulture),
				Text = l.ToString(CultureInfo.InvariantCulture)
			}));

			IEnumerable<WordJSON> words = _dictionaryProvider.GetWords(levels)
				.Select(w => new WordJSON
					{
						From = w.Word1,
						To = w.Translated,
						Description = w.Description
					});
			
			viewModel.WordsJSON = JsonConvert.SerializeObject(words);
			
			return viewModel;
		}
	}
}
