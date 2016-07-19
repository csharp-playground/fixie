using Fixie;
using System.Linq;

namespace MyLibrary.Tests {
	public class CaseConvention : Convention {
		public CaseConvention() {
			Classes
				.Where(x => MatchUpperCase(x.Name))
				.NameEndsWith("Spec");
		}

       private bool MatchUpperCase(string input) {
			var upper = input.TrimEnd(new[] { 'S', 'p', 'e', 'c' })
				.ToCharArray().Where(x => char.IsUpper(x)).Select(x => x.ToString());
			var token = string.Join("", upper).ToLower();
			return token == "abc";
		}
	}
}