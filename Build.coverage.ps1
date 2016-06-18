Param(
	# Current build configuration in use
	[string]
	$Configuration = $env:CONFIGURATION
)


& .\packages\OpenCover\tools\OpenCover.Console.exe -register:user `
	-target:".\packages\xunit.runner.console\tools\xunit.console.exe" `
	"-targetargs:$PSScriptRoot\src\Toggled.Tests\bin\$Configuration\Toggled.Tests.dll -nologo -noshadow -quiet" `
	-returntargetcode "-filter:+[Toggled*]* -[Toggled.Tests]*" -hideskipped:All -output:.\Toggled_coverage.xml