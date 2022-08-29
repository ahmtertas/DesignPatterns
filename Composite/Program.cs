using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee ahmet = new Employee { Name = "Ahmet Ertaş"};
            Employee rasim = new Employee { Name = "Rasim Ertaş"};

            ahmet.AddSubordinate(rasim);

            Employee kubra = new Employee { Name = "Kübra Ertaş" };
            ahmet.AddSubordinate(kubra);

            Contractor ali = new Contractor { Name = "Ali"};
            kubra.AddSubordinate(ali);

            Employee hatice = new Employee {Name = "Hatice Ertaş" };
            rasim.AddSubordinate(hatice);

            Console.WriteLine(ahmet.Name);

            foreach (Employee manager in ahmet)
            {
                
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }
            Console.ReadLine();
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
            foreach (var item in _subordinates)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
