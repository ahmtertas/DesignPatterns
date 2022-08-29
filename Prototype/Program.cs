using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Prototip deseninde amacımız nesne üretim maliyetini aza indirmektir.
            //Customer1'i newledik
            Customer customer1 = new Customer 
            { 
                FirstName="Engin",
                LastName= "Demiroğ", 
                Id= 2,
                City="Eskişehir" 
            };

            //Customer2'yi ise customer1'den cloneladık newleme yapmamıza gerek kalmadı.
            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }


}
