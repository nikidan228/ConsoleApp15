using System;

namespace BankCards
{
    class BankCard
    {
        private string fullName;
        private string type;
        private string cardNumber;
        private int securityCode;
        private DateTime expiryDate;

        private static int totalCards;
        private static int expiringThisYear;

        public string FullName { get => fullName; set => fullName = value; }
        public string Type { get => type; set => type = value; }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public int SecurityCode { get => securityCode; set => securityCode = value; }
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }

        public static int TotalCards { get => totalCards; }
        public static int ExpiringThisYear { get => expiringThisYear; }

        public BankCard(string fullName, string type, string cardNumber, int securityCode, DateTime expiryDate)
        {
            if (fullName != "" && type != "" && cardNumber.Length == 20 && securityCode.ToString().Length == 3 &&
                expiryDate >= new DateTime(2022, 1, 1) && expiryDate <= new DateTime(2026, 1, 1))
            {
                this.fullName = fullName;
                this.type = type;
                this.cardNumber = cardNumber;
                this.securityCode = securityCode;
                this.expiryDate = expiryDate;

                totalCards++;
                if (expiryDate.Year == DateTime.Now.Year)
                {
                    expiringThisYear++;
                }
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }
        }

        public static void PrintStatistics()
        {
            Console.WriteLine($"Total number of bank cards: {totalCards}");
            Console.WriteLine($"Number of bank cards expiring this year: {expiringThisYear}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankCard card1 = new BankCard("John Smith", "Visa", "12345678901234567890", 123, new DateTime(2024, 6, 30));
            BankCard card2 = new BankCard("Jane Doe", "Mastercard", "09876543210987654321", 456, new DateTime(2022, 12, 31));
            BankCard card3 = new BankCard("Bob Johnson", "American Express", "11112222333344445555", 789, new DateTime(2023, 4, 30));

            BankCard.PrintStatistics();
        }
    }
}