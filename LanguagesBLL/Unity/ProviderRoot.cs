using Microsoft.Practices.Unity;

namespace LanguagesBLL.Unity
{
	public class ProviderRoot
	{
		private static readonly IUnityContainer _current = new UnityContainer();

		public static IUnityContainer Current
		{
			get { return _current; }
		}

		static ProviderRoot()
		{
			ConfigureUnity.Configure(_current);
		}
	}
}
