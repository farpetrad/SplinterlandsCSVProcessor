namespace SplinterlandsCSVProcessor
{
    public static class StringCollectionToTransaction
    {
        public static Transaction ToTransaction(this string[] items)
        {
            if( items.Length != 6) throw new ArgumentException("Invalid transaction");

            if (!DateTime.TryParse(items[5], out var date)) throw new ArgumentException("Invalid date");

            return new Transaction()
            {
                Token = items[0],
                Type = items[1],
                FromTo = items[2],
                Amount = Convert.ToDouble(items[3]),
                Balance = Convert.ToDouble(items[4]),
                CreatedDate = DateTime.Parse(items[5])
            };
        }
    }
}
