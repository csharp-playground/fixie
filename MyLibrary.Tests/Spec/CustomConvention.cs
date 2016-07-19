using Fixie;

namespace MyLibrary.Tests {
	public class CustomConvention : Convention {
		public CustomConvention() {
			Classes.NameEndsWith("Spec");
		}
	}

	public class C2 : Convention {
		public C2() {
			Classes.NameEndsWith("Test");
		}
	}
}

