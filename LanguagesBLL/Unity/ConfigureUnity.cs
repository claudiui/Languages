using LanguagesBLL.Dictionary;
using LanguagesBLL.Models;
using Microsoft.Practices.Unity;

namespace LanguagesBLL.Unity
{
	public class ConfigureUnity
	{
		public static void Configure(IUnityContainer container)
		{
			container.RegisterType<IDictionaryProvider, DictionaryProvider>();
			container.RegisterType<IDictionaryDataAccess, DictionaryDataAccess>();
			container.RegisterType<IUserProvider, UserProvider>();
		}
	}
}