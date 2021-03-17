# LibSassBuilder

> Inspired by [Delegate.SassBuilder](https://github.com/delegateas/Delegate.SassBuilder) and [LibSassHost](https://github.com/Taritsyn/LibSassHost)

Build | NuGet Package | .NET Global Tool
---|---|---
![Build](https://github.com/johan-v-r/LibSassBuilder/workflows/Build/badge.svg) | [![Nuget](https://img.shields.io/nuget/v/LibSassBuilder)](https://www.nuget.org/packages/LibSassBuilder/) | [![.NET Tool](https://img.shields.io/nuget/v/LibSassBuilder-Tool)](https://www.nuget.org/packages/LibSassBuilder-Tool/) 


![LibSassBuilder](https://raw.githubusercontent.com/johan-v-r/LibSassBuilder/main/package/sass.png)

## [Nuget Package](https://www.nuget.org/packages/LibSassBuilder) 

`LibSassBuilder` NuGet package adds a build task to compile Sass files to `.css`. It's compatible with both MSBuild (VS) and `dotnet build`.

No configuration is required, it will compile the files implicitly on project build.

- ### Optionally provide arguments (see _Options_ below):

```xml
<PropertyGroup>
  <!-- outputstyle option -->
  <LibSassOutputStyle>compressed</LibSassOutputStyle>
  <LibSassOutputStyle Condition="'$(Configuration)' == 'Debug'">expanded</LibSassOutputStyle>
  <!-- level option -->
  <LibSassOutputLevel>verbose</LibSassOutputLevel>
  <!-- msbuild output level -->
  <LibSassMessageLevel>High</LibSassMessageLevel>
</PropertyGroup>
```

- ### Or take control of what files to process

```xml
<PropertyGroup>
  <!-- take full-control -->
  <EnableDefaultSassItems>false</EnableDefaultSassItems>  
</PropertyGroup>

<ItemGroup>
  <!-- add files manually -->
  <SassFile Include="Vendor/**/*.scss" > 
  <SassFile Include="Styles/**/*.scss" Exclude="Styles/unused/**" />
</ItemGroup>
```

- ### Or ignore all previous options (except for `<LibSassMessageLevel>`) and determine the arguments to the tool yourself

```xml
<PropertyGroup>
  <!-- Take even more full-control -->
  <LibSassBuilderArgs>directory "$(MSBuildProjectDirectory)"</LibSassBuilderArgs>
  <!-- msbuild output level -->
  <LibSassMessageLevel>High</LibSassMessageLevel>
</PropertyGroup>
```

___
## [.NET Global Tool](https://www.nuget.org/packages/LibSassBuilder-Tool)  

Install:
```
dotnet tool install --global LibSassBuilder-Tool
```

Use:
```
lsb [optional-path] [options]
lsb help
lsb help directory
lsb help files
```

## Generic options 

 ```
-l, --level      Specify the level of output (silent, default, verbose)

--outputstyle    Specify the style of output (compressed, condensed, nested, expanded)
```

## Directory command (default)

Scans a directory recursively to generate .css files

```
-e, --exclude    (Default: bin obj logs node_modules) Specify explicit directories to exclude. Overrides the default.

--help           Display this help screen.

--version        Display version information.

value pos. 0     Directory in which to run. Defaults to current directory.
```

Example:

```
lsb directory
lsb directory sources/styles -e node_modules
lsb directory sources/styles -e node_modules -l verbose
```

Files in the following directories are excluded by default:
 - `bin`
 - `obj`
 - `logs`
 - `node_modules`


## Files command (default)

Processes the files given on the commandline

```
--help           Display this help screen.

--version        Display version information.

value pos. 0     File(s) to process.
```

Example:

```
lsb files sources/style/a.scss sources/vendor/b.scss
lsb files sources/style/a.scss sources/vendor/b.scss -l verbose
```
___

## Requirements

`LibSassBuilder` can be installed on any project, however the underlying build tool requires [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) installed on the machine.

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
