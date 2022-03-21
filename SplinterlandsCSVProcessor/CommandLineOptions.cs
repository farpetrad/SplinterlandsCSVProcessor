using System;
using CommandLine;


namespace SplinterlandsCSVProcessor
{
    public class CommandLineOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.", Default = false)]
        public bool Verbose { get; set; } = false;

        [Option('t', "Token", Required = true, HelpText = "Set the token type to parse, available options SPS, DEC, VOUCHER")]
        public string Token { get; set; } = string.Empty;

        [Option('s', "Source", Required = true, HelpText = "Specify the full file path of the input file from Splinterlands.com")]
        public string Source { get; set; } = string.Empty;

        [Option('o', "Output", Required = false, HelpText = "Specify the full output path", Default = "")]
        public string Output { get; set; } = string.Empty;
    }
}
