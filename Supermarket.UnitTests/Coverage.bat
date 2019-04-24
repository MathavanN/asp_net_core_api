@ECHO OFF
dotnet test --logger "trx;LogFileName=TestResults.trx" --logger "xunit;LogFileName=TestResults.xml" --results-directory ./CoverageReports/UnitTests /p:CollectCoverage=true /p:CoverletOutput=CoverageReports\Coverage\ /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit.*]*

dotnet reportgenerator "-reports:CoverageReports\Coverage\coverage.cobertura.xml" "-targetdir:CoverageReports\Coverage" -reporttypes:HTML;HTMLSummary

start CoverageReports\Coverage\index.htm
