using System;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager(); !!
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _locker = new object();

        private CustomerManager()
        {
        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_locker)
            {
                _customerManager ??= new CustomerManager();
            }

            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}