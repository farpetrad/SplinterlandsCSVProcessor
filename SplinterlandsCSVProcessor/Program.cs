using SplinterlandsCSVProcessor;
using CommandLine;


static void RunOptions(CommandLineOptions opts)
{
    Processor.ProcessUserSelections(opts);
}
static void HandleParseError(IEnumerable<Error> errs)
{
    Console.WriteLine("You must provide args");
    return;
}

Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(RunOptions)
    .WithNotParsed(HandleParseError);

