﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee turan = new Employee
            {
                Name = "Turan Öz"
            };

            Employee mustafa = new Employee
            {
                Name = "Mustafa Öz"
            };

            Contractor mahmut = new Contractor { Name = "Mahmut" };

            mustafa.AddSubordinate(mahmut);

            turan.AddSubordinate(mustafa);

            Employee emre = new Employee
            {
                Name = "Emre Polat"
            };

            turan.AddSubordinate(emre);

            Employee omer = new Employee
            {
                Name = "Ömer Sevinç"
            };

            mustafa.AddSubordinate(omer);

            Console.WriteLine(turan.Name);

            foreach (Employee manager in turan)
            {
                Console.WriteLine("  " + manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    " + employee.Name);
                }
            }
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}