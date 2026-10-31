using System;
namespace Task30_BankAccount
{
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message)
            : base(message)
        {
        }
    }
    class BankAccount
    {
        private decimal balance;
        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(initialBalance),
                    "Начальный баланс не может быть отрицательным.");
            balance = initialBalance;
        }
        public decimal Balance
        {
            get { return balance; }
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Сумма пополнения должна быть больше нуля.");
            balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Сумма снятия должна быть больше нуля.");
            if (amount > balance)
            {
                throw new InsufficientFundsException(
                    $"Недостаточно средств. Баланс: {balance} руб., " +
                    $"запрошено: {amount} руб.");
            }
            balance -= amount;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(1000m);
            Console.WriteLine("Начальный баланс: " +
                account.Balance + " руб.");
            try
            {
                account.Withdraw(300m);
                Console.WriteLine("Снято 300 руб.");
                Console.WriteLine("Текущий баланс: " +
                    account.Balance + " руб.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            try
            {
                account.Withdraw(1000m);

                Console.WriteLine("Текущий баланс: " +
                    account.Balance + " руб.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
