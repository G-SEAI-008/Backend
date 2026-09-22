class AccountOps
{
    public void Deposit(Account account, decimal amount)
    {
        account.Balance += amount;
    }

    public void Reset(Account account)
    {
        account = new Account();
    }
}