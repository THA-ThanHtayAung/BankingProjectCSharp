using System.Collections.Generic;
using System.Text;

class BankAccount
{
    public string Owner { get; }
    public string Number { get; }
    public decimal Balance 
    { 
        get
        {
            decimal balance = 0;
            foreach (var item in allTransaction)
            {
                balance = item.Amount;
            }
            return balance;
        }  
    }
    public BankAccount(string name,decimal initialBalance)
    {
        Owner = name;
        MakeDeposite(initialBalance,DateTime.Now,"Initial balance");
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;
    }

    private static int accountNumberSeed = 1234567890;
    private List<Transaction> allTransaction = new List<Transaction>();

    public void MakeDeposite(decimal amount, DateTime date,string note)
    {
        if(amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposite must be positive.");
        }
        var deposite = new Transaction(amount,date,note);
        allTransaction.Add(deposite);
    }
    public void MakeWithdrawal(decimal amount, DateTime date,string note)
    {
        if(amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdrawal must be positive");
        }
        else if(Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient fund for this withdrawal");
        }
        var withdrawal = new Transaction(-amount,date,note);
        allTransaction.Add(withdrawal);
    }
    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        report.AppendLine("Date\t\tAmount\tNote");
        foreach (var item in allTransaction)
        {
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
        }
        return report.ToString();
    }
}