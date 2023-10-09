class Program
{
    static void Main()
    {
        BankAccount bank1 = new BankAccount("Hsu Yoon",10000);
        Console.WriteLine(bank1.GetAccountHistory()) ;
    }
}