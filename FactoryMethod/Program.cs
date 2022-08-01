using System;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            CustomerManager customerManager2 = new CustomerManager(new LoggerFactory2());
            customerManager.Save();
            customerManager2.Save();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new ToLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new SbLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class ToLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ToLogger");
        }
    }

    public class SbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with SbLogger");
        }
    }

    public class CustomerManager
    {
        private readonly ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
            
        }
    }
}