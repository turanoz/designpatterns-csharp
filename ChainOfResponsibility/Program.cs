using System;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);
            Expense expense = new Expense { Detail = "Kasa", Amount = 500 };
            manager.HandleExpense(expense);
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            //else if (Successor!=null) {Successor.HandleExpense(expense);}

            else
            {
                Successor?.HandleExpense(expense);
            }
        }
    }

    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount is > 100 and <= 1000)
            {
                Console.WriteLine("VicePresident handled the expense!");
            }
            //else if (Successor!=null) {Successor.HandleExpense(expense);}
            else
            {
                Successor?.HandleExpense(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            Console.WriteLine("President handled the expense!");
        }
    }
}