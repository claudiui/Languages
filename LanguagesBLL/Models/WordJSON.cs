using Newtonsoft.Json;

namespace LanguagesBLL.Models
{
	public class WordJSON
	{
		[JsonProperty("from")]
		public string From { get; set; }

		[JsonProperty("to")]
		public string To { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}
}
