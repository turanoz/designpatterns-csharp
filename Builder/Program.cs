using System;

namespace Builder //iş katmanından business logiclerde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id + " " + model.CategoryName + " " + model.ProductName + " " +
                              model.DiscountedPrice + " " + model.DiscountApplied);
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Security";
            model.ProductName = "Camera";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Security";
            model.ProductName = "Camera";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * 0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}