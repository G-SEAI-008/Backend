// BankAccount.cs
public class BankAccount
{
    public string Iban { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "EUR";
    public bool Active { get; set; } = true;
}

