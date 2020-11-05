var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");
var solutionPath = "./get-stated-jenkins/get-stated-jenkins.sln";
var testPath = "./get-stated-jenkins/tests/tests.csproj";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"{solutionPath}/bin/{configuration}");
});


Task("Build")
    .IsDependentOn("Clean")
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
        DotNetCoreTest(
            testPath,
            new DotNetCoreTestSettings()
            {
                Configuration = configuration,
                NoBuild = true,
                NoRestore = true,
                // ArgumentCustomization = args=>args.Append($"--logger trx;LogFileName=\"{testResultsFile}\"")
            }
        );
    });

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);