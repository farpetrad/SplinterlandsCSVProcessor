namespace SplinterlandsCSVProcessor
{
    public class Transaction
    {
        //Token,Type,From/To,Amount,Balance,Created Date
        public string Token { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string FromTo { get; set; } = string.Empty;
        public double Amount { get; set; } = 0.0d;
        public double Balance { get; set; } = 0.0d;
        public DateTime CreatedDate { get; set; } = new DateTime(1999, 1, 1);
    }
}
