using System;
public class BankAccount{
    private decimal balance;
    public BankAccount(decimal initialBalance){
        if (initialBalance < 0) throw new ArgumentException("Initial balance cannot be negative.");
        balance = initialBalance;
    }
    public void Deposit(decimal amount){
        if (amount > 0) {
            balance += amount;
            Console.WriteLine($"Deposited: ${amount}. New balance: ${balance}");
        }
        else {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }
    public void Withdraw(decimal amount){
        if (amount > 0 && amount <= balance){
            balance -= amount;
            Console.WriteLine($"Withdrew: ${amount}. New balance: ${balance}");
        }
        else{
            Console.WriteLine("Insufficient funds or invalid amount.");
        }
    }
    public decimal Balance{
        get { return balance; }
    }
}
class Program { 
    static void Main(){
        BankAccount account = new BankAccount(1000);
        account.Deposit(500);
        account.Withdraw(200);
        Console.WriteLine("Current balance: $" + account.Balance);
        // Trying to access balance directly will fail
        // Console.WriteLine(account.balance); // Error: 'BankAccount.balance' is inaccessible
    }
}
