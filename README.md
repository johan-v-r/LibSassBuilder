# LibSassBuilder

> Inspired by [Delegate.SassBuilder](https://github.com/delegateas/Delegate.SassBuilder) and [LibSassHost](https://github.com/Taritsyn/LibSassHost)

![LibSassBuilder](https://raw.githubusercontent.com/johan-v-r/LibSassBuilder/main/package/sass.png)

`LibSassHost` NuGet package adds a build task to compile Sass files to `.css`. It's compatible with both MSBuild (VS) and `dotnet build`.

No configuration is required, it will compile the files implicitly on project build.

___

## Requirements

`LibSassHost` can be installed on any project, however the underlying build tool requires [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) installed on the machine.

It's currently only built with support for **Win x64** - but this can be extended on request.