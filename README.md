# LibSassBuilder

> Inspired by [Delegate.SassBuilder](https://github.com/delegateas/Delegate.SassBuilder) and [LibSassHost](https://github.com/Taritsyn/LibSassHost)

Build | NuGet Package | .NET Global Tool
---|---|---
![Build](https://github.com/johan-v-r/LibSassBuilder/workflows/Build/badge.svg) | [![Nuget](https://img.shields.io/nuget/v/LibSassBuilder)](https://www.nuget.org/packages/LibSassBuilder/) | [![.NET Tool](https://img.shields.io/nuget/v/LibSassBuilder-Tool)](https://www.nuget.org/packages/LibSassBuilder-Tool/) 


![LibSassBuilder](https://raw.githubusercontent.com/johan-v-r/LibSassBuilder/main/package/sass.png)

## [Nuget Package](https://www.nuget.org/packages/LibSassBuilder) 

`LibSassBuilder` NuGet package adds a build task to compile Sass files to `.css`. It's compatible with both MSBuild (VS) and `dotnet build`.

No configuration is required, it will compile the files implicitly on project build.

Optionally provide arguments (see _Options_ below):
```xml
<PropertyGroup>
  <LibSassBuilderArgs>.\Pages -e temp</LibSassBuilderArgs>
</PropertyGroup>
```

## [.NET Global Tool](https://www.nuget.org/packages/LibSassBuilder-Tool)  

Install:
```
dotnet tool install --global LibSassBuilder-Tool
```

Use:
```
lsb [optional-path] [options]
lsb --help
```


## Options 

```
  -e, --exclude    (Default: bin obj logs node_modules) Specify explicit directories to exclude. Overrides the default.

  --help           Display this help screen.

  --version        Display version information.

  value pos. 0     Directory in which to run. Defaults to current directory.
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
