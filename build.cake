var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");
var solutionPath = "./get-stated-jenkins/get-stated-jenkins.sln";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"{solutionPath}/bin/{configuration}");
});

Task("NuGet-Restore")
    .IsDependentOn("Clean")
    .Does(() => 
{
    NuGetRestore(solutionPath);
});

Task("Build")
    .IsDependentOn("NuGet-Restore")
    .Does(() =>
{
    DotNetCoreBuild(solutionPath, new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest(solutionPath, new DotNetCoreTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
    });
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);