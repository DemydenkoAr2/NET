namespace Task_3_CreditCard;

class Program
{
    static void Main(string[] args)
    {
        CreditCard monoBankCreditCard = new CreditCard("Mono Bank", 13200.65m);
        CreditCard privateBankCreditCard = new CreditCard("Private Bank", 1220.50m);
        
        monoBankCreditCard += 2000;
        privateBankCreditCard -= 3052.45m;
        
        monoBankCreditCard.GetInfo(); // Name: Mono Bank, Balance: 15200,65 CVC: 171
        privateBankCreditCard.GetInfo(); //   Name: Private Bank, Balance: -1831,95 CVC: 199
        
        Console.WriteLine(monoBankCreditCard == privateBankCreditCard); //  False
        Console.WriteLine(monoBankCreditCard != privateBankCreditCard); // True
        Console.WriteLine(monoBankCreditCard > privateBankCreditCard); // False
        Console.WriteLine(monoBankCreditCard < privateBankCreditCard); // False
    }
}