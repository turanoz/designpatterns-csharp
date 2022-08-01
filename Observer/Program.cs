using System;
using System.Collections.Generic;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();
        }
    }

    class ProductManager
    {
        List<Observer> _observers=new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Customer: Product price changed");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Employee: Product price changed");
        }
    }
}