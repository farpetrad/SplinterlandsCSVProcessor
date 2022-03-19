using SplinterlandsCSVProcessor;


var transactionList = new List<Transaction>();

using(var stream = new FileStream("C:\\Users\\nealc\\Downloads\\splinterlands-balances.csv", FileMode.Open))
{
    using(var reader = new StreamReader(stream)){
        string? line = reader?.ReadLine(); // go past header row
        while ((line = reader?.ReadLine()) != null)
        {
            var transaction = line.Split(',').ToTransaction();
            transactionList.Add(transaction);
        }
        reader.Close();
    }
    stream.Close();
}

transactionList.Sort((a, b) =>
{
    return a.Token.CompareTo(b.Token);
});

var decTransactions = transactionList.Where(t => t.Token == "DEC").ToList();
Console.WriteLine($"There are {decTransactions.Count} dec transactions");
var spsTransactions = transactionList.Where(t => t.Token == "SPS").ToList();
Console.WriteLine($"There are {spsTransactions.Count} sps transactions");
var voucherTransactions = transactionList.Where(t => t.Token == "VOUCHER").ToList();
Console.WriteLine($"There are {voucherTransactions.Count} voucher transactions");

var outputPath = "C:\\Users\\nealc\\Downloads";

if (File.Exists($"{outputPath}\\sps.csv")) File.Delete($"{outputPath}\\sps.csv");

using (var stream = new FileStream($"{outputPath}\\sps.csv", FileMode.OpenOrCreate))
{
    using (var writer = new StreamWriter(stream))
    {
        writer.WriteLine("Date,Received Quantity,Received Currency,Sent Quantity,Sent Currency,Fee Amount,Fee Currency,Tag");
        foreach (var transaction in spsTransactions)
        {
            if (transaction.Type == "token_award")
                writer.WriteLine($"{transaction.CreatedDate.ToString("MM/dd/yyyy")},{transaction.Amount},{transaction.Token},,,,,airdrop");
            else if (transaction.Type == "stake_tokens") {
                var line = $"{transaction.CreatedDate.ToString("MM/dd/yyyy")},{Math.Abs(transaction.Amount)},{transaction.Token},,,,,staked";
                writer.WriteLine(line);
            }
        }
        writer.Close();
    }
    stream.Close();
}
