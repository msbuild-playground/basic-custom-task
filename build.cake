#tool "nuget:?package=Fixie"
#addin "nuget:?package=Cake.Watch"

var solution = "BasicCustomTask.sln";

Action<string,string,string> build = (proj, t, configuration) => {
    DotNetBuild(proj, settings => {
        settings.SetConfiguration(configuration)
            .WithTarget(t);
    });
};

Task("Build-Debug")
    .Does(() => {
        build(solution, "Build", "Debug");
    });

Task("Run-SEV")
    .Does(() => {
        build("BasicCustomTask.Tests/SEV.proj", "MyTarget", "Debug");
    });

var target = Argument("target", "default");
RunTarget(target);