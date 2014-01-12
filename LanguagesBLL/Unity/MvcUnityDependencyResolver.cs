using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace LanguagesBLL.Unity
{
	public class MvcUnityDependencyResolver : IDependencyResolver
	{
		public object GetService(Type serviceType)
		{
			try
			{
				return ProviderRoot.Current.Resolve(serviceType);
			}
			catch (ResolutionFailedException exc)
			{
				return null;
			}
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return ProviderRoot.Current.ResolveAll(serviceType);
		}
	}
}
