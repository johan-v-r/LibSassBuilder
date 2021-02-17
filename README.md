# LibSassBuilder

> Inspired by [Delegate.SassBuilder](https://github.com/delegateas/Delegate.SassBuilder) and [LibSassHost](https://github.com/Taritsyn/LibSassHost)

Build | NuGet Package | .NET Global Tool
---|---|---
![Build](https://github.com/johan-v-r/LibSassBuilder/workflows/Build/badge.svg) | [![Nuget](https://img.shields.io/nuget/v/LibSassBuilder)](https://www.nuget.org/packages/LibSassBuilder/) | [![.NET Tool](https://img.shields.io/nuget/v/LibSassBuilder-Tool)](https://www.nuget.org/packages/LibSassBuilder-Tool/) 


![LibSassBuilder](https://raw.githubusercontent.com/johan-v-r/LibSassBuilder/main/package/sass.png)

## [Nuget Package](https://www.nuget.org/packages/LibSassBuilder) 

`LibSassBuilder` NuGet package adds a build task to compile Sass files to `.css`. It's compatible with both MSBuild (VS) and `dotnet build`.

No configuration is required, it will compile the files implicitly on project build.  

## [.NET Global Tool](https://www.nuget.org/packages/LibSassBuilder-Tool)  

Install:
```
dotnet tool install --global LibSassBuilder-Tool
```

Use:
```
lsb [optional-path]
```

> Files in the following directories are excluded by default:
> - `bin`
> - `obj`
> - `logs`
> - `node_modules`

___

## Requirements

`LibSassBuilder` can be installed on any project, however the underlying build tool requires [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) installed on the machine.

## Project options

The project file can be tailored to specify what files should be processed by the sass processor:

```xml
<PropertyGroup>
   <EnableDefaultSassItems>false</EnableDefaultSassItems>  <!-- take full-control -->
   <DefaultSassExcludes>node_modules/**;lib/vendor/**</DefaultSassExcludes> <!-- exclude certain directories -->
</PropertyGroup>

<ItemGroup>
  <SassFile Include="Styles/*.scss" /> <!-- add files manually -->
</ItemGroup>
```

## Bypass Visual Studio fast up to date check

Visual studio does a quick check to find changed files. However if you edit the sass files, it does not see these as project changes.
If you edit sass files a lot you can instruct Visual Studio to rely on msbuild, place the following property in your .csproj.

```xml
<PropertyGroup>
    <DisableFastUpToDateCheck>true</DisableFastUpToDateCheck>
</PropertyGroup>
```
## Support

The support is largely dependant on [LibSassHost](https://github.com/Taritsyn/LibSassHost)

This tool contains the following supporting packages:
- LibSassHost.Native.win-x64
- LibSassHost.Native.linux-x64
- LibSassHost.Native.osx-x64

## Package as nuget package

```powershell
./package.ps1 -PackageDir 'C:/LocalPackages' -Version '1.4.0.1'
```
