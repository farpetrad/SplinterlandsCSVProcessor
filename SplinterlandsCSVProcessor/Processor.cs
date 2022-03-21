namespace SplinterlandsCSVProcessor
{
    public static class Processor
    {
        public static void ProcessUserSelections(CommandLineOptions opts)
        {
            var transactions = LoadTransactionsFromUserOptions(opts);

            var outputPath = string.IsNullOrEmpty(opts.Output) ?
                $"{opts.Token}.csv" :
                opts.Output;
            if (opts.Verbose)
            {
                Console.WriteLine($"Using output file: {outputPath}");
            }

            if (opts.Verbose)
            {
                Console.WriteLine($"There are {transactions.Count} for token {opts.Token}");
            }

            if (File.Exists(outputPath))
            {
                if (opts.Verbose)
                {
                    Console.WriteLine($"Output file {outputPath} exists, removing");
                }
                File.Delete(outputPath);
            }

            using (var stream = new FileStream(outputPath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine("Date,Received Quantity,Received Currency,Sent Quantity,Sent Currency,Fee Amount,Fee Currency,Tag");
                    foreach (var transaction in transactions)
                    {
                        string line = transaction?.ToString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(line))
                        {
                            writer.WriteLine(line);
                        }
                    }
                    writer.Close();
                }
                stream.Close();
            }

            Console.WriteLine($"The file {opts.Source} has been processed for {opts.Token} and {Path.GetFullPath(outputPath)} was generated");
        }

        private static List<Transaction> LoadTransactionsFromUserOptions(CommandLineOptions opts)
        {
            var transactionList = new List<Transaction>();

            using (var stream = new FileStream(opts.Source, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    string? line = reader?.ReadLine(); // go past header row
                    while ((line = reader?.ReadLine()) != null)
                    {
                        if (opts.Verbose)
                        {
                            Console.WriteLine($"Processing {line}");
                        }
                        var transaction = line.Split(',').ToTransaction();
                        if (transaction?.Token == opts.Token)
                        {
                            transactionList.Add(transaction);
                        }
                    }
                    reader?.Close();
                }
                stream?.Close();
            }

            return transactionList;
        }
    }
}
