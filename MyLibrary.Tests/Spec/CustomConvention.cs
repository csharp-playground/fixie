using Fixie;
using System.Linq;

namespace MyLibrary.Tests {
	public class CustomConvention : Convention {
		public CustomConvention() {
			Classes.NameEndsWith("Spec");
		}
	}

	public class CaseConvention : Convention {
		public CaseConvention() {
			Classes
				.Where(x => MatchUpperCase(x.Name))
				.NameEndsWith("Spec");
		}

       private bool MatchUpperCase(string input) {
			var upper = input.ToCharArray().Where(x => char.IsUpper(x)).Select(x => x.ToString());
			return string.Join("", upper).ToLower() == "abc";
		}
	}
}

