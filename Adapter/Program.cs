using System;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class ToLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0} ",message);
        }
    }

    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    class Log4NetAdapter:ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net=new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
