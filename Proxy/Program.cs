﻿using System;
using System.Threading;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditBase manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        CreditManager _creditManager;
        int _cachedValue;

        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }

            return _cachedValue;
        }
    }
}