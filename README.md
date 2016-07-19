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

## Test if class match value of key `fixie` in `AppSettings`.

```csharp
public class ConfigConvention: Convention {
    public ConfigConvention() {
        var target = ConfigurationManager.AppSettings.Get("fixie");
        Classes
            .Where(x => MatchUpperCase(x.Name, target))
            .NameEndsWith("Spec");
    }

    private bool MatchUpperCase(string input, string target) {
        var upper = input.TrimEnd(new[] { 'S', 'p', 'e', 'c' })
            .ToCharArray().Where(x => char.IsUpper(x)).Select(x => x.ToString());
        var token = string.Join("", upper).ToLower();
        return token == target;
    }
}
```

## Test

> build.sh --test=abc