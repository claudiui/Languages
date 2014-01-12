
namespace LanguagesBLL.Models
{
	public class UserProvider : IUserProvider
	{
		public string GetUser()
		{
			return "Guest";
		}
	}
}