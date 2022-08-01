using System;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonalCar personalCar = new PersonalCar { Make = "BMW", Model = "5.20", HirePrice = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("Special offer : " + specialOffer.HirePrice);
            Console.WriteLine("Personal : " + personalCar.HirePrice);
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract double HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override double HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override double HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }

        public override double HirePrice
        {
            get => (_carBase.HirePrice - _carBase.HirePrice * DiscountPercentage / 100);
            set { }
        }
    }
}