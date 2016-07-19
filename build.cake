#tool "nuget:?package=Fixie"
#addin "nuget:?package=Cake.Watch"
#addin "MagicChunks"

var target = Argument("target", "Default");
var test = Argument("test", string.Empty);

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

Task("testargs")
    .Does(() => {
        var config = testDll + ".config";
        TransformConfig(config, new TransformationCollection {
         { "configuration/appSettings/add[@key='fixie']/@value", test }
        });

        DotNetBuild(solution);
        Fixie(testDll);
});

Task("watch")
    .Does(() => {
        var settings = new WatchSettings {
            Recursive = true,
            Path = "./",
            Pattern = "*.cs"
        };
        Watch(settings, (changed) => {
            RunTarget("test");
        });
    });

if (test != string.Empty) {
    RunTarget("testargs");
}else {
    RunTarget(target);
}