# LibSassBuilder - [![Nuget](https://img.shields.io/nuget/v/LibSassBuilder)](https://www.nuget.org/packages/LibSassBuilder/) ![Build](https://github.com/johan-v-r/LibSassBuilder/workflows/Build/badge.svg)

> Inspired by [Delegate.SassBuilder](https://github.com/delegateas/Delegate.SassBuilder) and [LibSassHost](https://github.com/Taritsyn/LibSassHost)

![LibSassBuilder](https://raw.githubusercontent.com/johan-v-r/LibSassBuilder/main/package/sass.png)

`LibSassBuilder` NuGet package adds a build task to compile Sass files to `.css`. It's compatible with both MSBuild (VS) and `dotnet build`.

No configuration is required, it will compile the files implicitly on project build.

> Files in the following directories are excluded by default:
> - `bin`
> - `obj`
> - `logs`
> - `node_modules`

___

## Requirements

`LibSassBuilder` can be installed on any project, however the underlying build tool requires [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) installed on the machine.

## Support

The support is largely dependant on [LibSassHost](https://github.com/Taritsyn/LibSassHost)

This tool contains the following supporting packages:
- LibSassHost.Native.win-x64
- LibSassHost.Native.linux-x64
- LibSassHost.Native.osx-x64
