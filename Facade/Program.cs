using System;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
        }
    }


    interface ILogging
    {
        void Log();
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }


    interface ICaching
    {
        void Cache();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }


    interface IAuthorize
    {
        void CheckUser();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    class CustomerManager
    {
        private readonly CrossCuttingConcernsFacade _concerns;

        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.CheckUser();


            Console.WriteLine("Saved!");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public Authorize Authorize;


        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize=new Authorize();

        }
    }
}