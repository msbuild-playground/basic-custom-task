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

Task("Sev")
    .Does(() => {
        build("BasicCustomTask.Tests/Serv/Project.xml", "MyTarget", "Debug");
    });

Task("Sev.Property")
    .Does(() => {
        build("BasicCustomTask.Tests/Serv.Property/Project.xml", "MyTarget", "Debug");
    });

var target = Argument("target", "default");
RunTarget(target);