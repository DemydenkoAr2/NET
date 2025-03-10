namespace Task_3_CreditCard;

public class CreditCard
{
    private String CardName { get; set; }
    private decimal CardBalance { get; set; }
    
    private int CardCVC { get; set; }

    public CreditCard(String cardName, decimal cardBalance)
    {
        CardName = cardName;
        CardBalance = cardBalance;
        CardCVC = SetRandomCVC();
    }

    public static CreditCard operator +(CreditCard card, decimal amount)
    {
        card.CardBalance += amount;
        return card;
    }
    
    public static CreditCard operator -(CreditCard card, decimal amount)
    {
        card.CardBalance -= amount;
        return card;
    }

    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        return card1.CardCVC == card2.CardCVC;
    }

    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return card1.CardCVC != card2.CardCVC;
    }

    public static bool operator <(CreditCard card1, CreditCard card2)
    {
        return card1.CardBalance < card2.CardBalance;
    }

    public static bool operator >(CreditCard card1, CreditCard card2)
    {
        return card1.CardBalance < card2.CardBalance;
    }

    private int SetRandomCVC()
    {
        Random random = new Random();
        return random.Next(100, 999);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Name: {CardName}, Balance: {CardBalance} CVC: {CardCVC}");
    }
}