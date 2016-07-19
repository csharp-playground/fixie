#tool "nuget:?package=Fixie"
#addin "nuget:?package=Cake.Watch"

var solution = "TryFixie.sln";
var testDll = "MyLibrary.Tests/bin/Debug/MyLibrary.Tests.dll";

Task("default")
    .Does(() => {
        Console.WriteLine("Hello!");
    });

Task("test")
    .Does(() => {
        DotNetBuild(solution);
        Fixie(testDll);
    });

Task("watch")
    .Does(() => {
        var settings = new WatchSettings {
            Recursive = true,
            Path = "./",
            Pattern = "*Tests.cs"
        };
        Watch(settings, (changed) => {
            RunTarget("test");
        });
    });

var target = Argument("target", "Default");
RunTarget(target);