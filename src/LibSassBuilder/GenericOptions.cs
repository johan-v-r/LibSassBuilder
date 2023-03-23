using CommandLine;
using LibSassHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSassBuilder
{
    public abstract class GenericOptions
    {
        [Option('l', "level", Required = false, HelpText = "Specify the level of output (silent, default, verbose)")]
        public OutputLevel OutputLevel { get; set; } = OutputLevel.Default;

        public CompilationOptions SassCompilationOptions { get; } = new CompilationOptions()
        {
            OutputStyle = OutputStyle.Compressed
        };

        [Option("outputstyle", Required = false, HelpText = "Specify the style of output (compressed, compact, nested, expanded)")]
        public OutputStyle OutputStyle
        {
            get
            {
                return SassCompilationOptions.OutputStyle;
            }
            set
            {
                SassCompilationOptions.OutputStyle = value;
            }
        }

        [Option("sourcemap", Required = false, HelpText = "Flag for whether to enable source map generation.")]
        public bool SourceMap
        {
            get
            {
                return SassCompilationOptions.SourceMap;
            }
            set
            {
                SassCompilationOptions.SourceMap = value;
            }
        }
    }

    public enum OutputLevel
    {
        Silent,
        Default,
        Verbose
    }
}
