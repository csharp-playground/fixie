using System;
using Fixie;
using System.Configuration;
using System.Linq;

namespace MyLibrary.Tests {
	public class ConfigConvention: Convention {
		public ConfigConvention() {
			var target = ConfigurationManager.AppSettings.Get("fixie");
			Classes.Where(x => MatchUpperCase(x.Name, target));
		}

		private bool MatchUpperCase(string input, string target) {
			var upper = input.TrimEnd(new[] { 'S', 'p', 'e', 'c' })
				.ToCharArray().Where(x => char.IsUpper(x)).Select(x => x.ToString());
			var token = string.Join("", upper).ToLower();
			return token == target;
		}
	}
}

