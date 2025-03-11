namespace Lesson4
{
	public class Wallet
	{
		public string Currency { get; }
		public decimal Balance { get; private set; }
		private static readonly Dictionary<string, decimal> ExchangeRates = new()
		{
			{ "USD", 1.0m },
			{ "EUR", 1.1m }
		};

		public Wallet(decimal balance, string currency)
		{
			if (!ExchangeRates.ContainsKey(currency))
				throw new ArgumentException("Unsupported currency.");

			Balance = balance;
			Currency = currency;
		}

		public static Wallet operator +(Wallet w1, Wallet w2)
		{
			if (w1.Currency != w2.Currency)
			{
				w2 = w2.ConvertTo(w1.Currency);
			}
			return new Wallet(w1.Balance + w2.Balance, w1.Currency);
		}

		public static Wallet operator -(Wallet w1, Wallet w2)
		{
			if (w1.Currency != w2.Currency)
			{
				w2 = w2.ConvertTo(w1.Currency);
			}
			return new Wallet(w1.Balance - w2.Balance, w1.Currency);
		}

		public static bool operator >(Wallet w1, Wallet w2)
		{
			if (w1.Currency != w2.Currency)
			{
				w2 = w2.ConvertTo(w1.Currency);
			}
			return w1.Balance > w2.Balance;
		}

		public static bool operator <(Wallet w1, Wallet w2)
		{
			if (w1.Currency != w2.Currency)
			{
				w2 = w2.ConvertTo(w1.Currency);
			}
			return w1.Balance < w2.Balance;
		}

		public Wallet ConvertTo(string newCurrency)
		{
			if (!ExchangeRates.ContainsKey(newCurrency))
				throw new ArgumentException("Unsupported currency.");

			decimal newBalance = Balance * ExchangeRates[newCurrency] / ExchangeRates[Currency];
			return new Wallet(newBalance, newCurrency);
		}

		public override string ToString() => $"{Balance:F2} {Currency}";
	}

	public class WalletTest
	{
		public static void StartTest()
		{
			Wallet wallet1 = new(100, "USD");
			Wallet wallet2 = new(90, "EUR");

			Console.WriteLine($"Wallet 1: {wallet1}");
			Console.WriteLine($"Wallet 2: {wallet2}");

			Wallet combined = wallet1 + wallet2;
			Console.WriteLine($"After adding: {combined}");

			Wallet subtracted = wallet1 - wallet2;
			Console.WriteLine($"After subtraction: {subtracted}");

			Console.WriteLine(wallet1 > wallet2 ? "Wallet 1 has more money." : "Wallet 2 has more money.");

			Wallet convertedWallet = wallet2.ConvertTo("USD");
			Console.WriteLine($"Wallet 2 in USD: {convertedWallet}");
		}
	}
}
