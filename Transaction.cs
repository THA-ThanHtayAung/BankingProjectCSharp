class Transaction
{
    public decimal Amount { get; }
    public string Notes {get;}
    public DateTime Date { get; }

    public Transaction(decimal amount, DateTime date, string note )
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }

}