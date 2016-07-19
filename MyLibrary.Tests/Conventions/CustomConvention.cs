using Fixie;
using System.Linq;

namespace MyLibrary.Tests {
	public class CustomConvention : Convention {
		public CustomConvention() {
			Classes.NameEndsWith("Test");
		}
	}
}

