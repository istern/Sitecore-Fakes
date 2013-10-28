@ECHO OFF

ECHO Bulding...

"%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe" .\..\Sitecore.Fakes.sln /p:Configuration=Release /t:Clean;Build /v:m

ECHO Packaging...

.\..\packages\NuGet.CommandLine.2.7.1\tools\nuget.exe pack .\Sitecore.Fakes.nuspec

ECHO Done!

PAUSE