using System;
using System.Collections.Generic;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager turan = new Manager { Name = "Turan", Salary = 5000 };
            Manager mustafa = new Manager { Name = "Mustafa", Salary = 4500 };

            Worker ali = new Worker { Name = "Ali", Salary = 2000 };
            Worker erhan = new Worker { Name = "Erhan", Salary = 1500 };

            turan.Subordinates.Add(mustafa);
            mustafa.Subordinates.Add(ali);
            mustafa.Subordinates.Add(erhan);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(turan);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public List<EmployeeBase> Subordinates { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor:VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    class PayriseVisitor:VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.15);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.35);
        }
    }
}