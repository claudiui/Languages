using System.Collections.Generic;
using System.Web.Mvc;
using LanguagesBLL.Dictionary;
using LanguagesBLL.Models;

namespace LanguagesBLL
{
	public class HomeController : Controller
	{
		private readonly HomeViewModelBuilder _homeViewModelBuilder;

		public HomeController(HomeViewModelBuilder homeViewModelBuilder)
		{
			_homeViewModelBuilder = homeViewModelBuilder;
		}

		public ActionResult Index()
		{
			HomeViewModel viewModel = _homeViewModelBuilder.GetViewModel();
			return View(viewModel);
		}
	}
}