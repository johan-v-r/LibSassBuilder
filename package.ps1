param (
    [string] $PackageDir = 'out',
    
    [Parameter(Mandatory)]
    [string] $Version 
)

$projectFile = "$PSScriptRoot/src/LibSassBuilder/LibSassBuilder.csproj"
$nuspecProjectFile = "$PSScriptRoot/package/LibSassBuilder.csproj"
$nuspecFile = "$PSScriptRoot/package/LibSassBuilder.nuspec"

& dotnet build $projectFile -p:Version=$Version -c Release -o "$PSScriptRoot/package/tool"
& dotnet pack $projectFile -p:Version=$Version -c Release -o $PackageDir
$xml = [Xml](Get-Content -Path $nuspecFile -Raw)
$xml.package.metadata.version = $Version
$xml.Save($nuspecFile)
& dotnet pack $nuspecProjectFile -p:Version=$Version -c Release -o $PackageDir
#& dotnet pack --project $projectFile -pVersion=$Version -o $OutputDir