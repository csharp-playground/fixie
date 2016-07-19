## Try Fixie

- http://fixie.github.io


## Test class

```csharp
public class AaaBbbCccSpec {
    public void HelloWorld() {
        Console.WriteLine("ABC");
    }
}
```

## Test only if class contain `ABC` and ends with `Spec`

```csharp
public class CaseConvention : Convention {
    public CaseConvention() {
        Classes
            .Where(x => MatchUpperCase(x.Name))
            .NameEndsWith("Spec");
    }

   private bool MatchUpperCase(string input) {
        var upper = input.ToCharArray()
            .Where(x => char.IsUpper(x))
            .Select(x => x.ToString());
        return string.Join("", upper).ToLower() == "abcs";
    }
}
```

## Test

> build.sh --target test