using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LanguagesBLL.Models
{
	public class HomeViewModel
	{
		public HomeViewModel()
		{
			Types = new List<SelectListItem>();
			Levels = new List<SelectListItem>();
		}

		public string Title { get; set; }
		public List<SelectListItem> Types { get; set; }
		public List<SelectListItem> Levels { get; set; }
		public string WordsJSON { get; set; }
	}
}
