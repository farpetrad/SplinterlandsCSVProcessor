namespace SplinterlandsCSVProcessor
{
    public class Transaction
    {
        public string Token { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string FromTo { get; set; } = string.Empty;
        public double Amount { get; set; } = 0.0d;
        public double Balance { get; set; } = 0.0d;
        public DateTime CreatedDate { get; set; } = new DateTime(1999, 1, 1);

        public override string ToString()
        {
            if (Token == "SPS")
            {
                if (Type == "token_award")
                    return $"{CreatedDate.ToString("MM/dd/yyyy")},{Amount},{Token},,,,,airdrop";
                else if (Type == "stake_tokens")
                    return $"{CreatedDate.ToString("MM/dd/yyyy")},{Math.Abs(Amount)},{Token},,,,,staked";
                else
                    return "";
            }
            else if(Token == "DEC")
            {
                if(Type == "rental_payment")
                {
                    return $"{CreatedDate.ToString("MM/dd/yyyy")},{Math.Abs(Amount)},{"DarkEnergyCrystal"},,,,,";
                }
            }
            return "";
        }
    }
}
