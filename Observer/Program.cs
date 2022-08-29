using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(new EmployeeObserver());
            
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }
    //Üründeki fiyat değişikliğinden istediğimiz kişilerin haberdar olması için;
    //Observer vasıtası ile haber etmek için bir tasarım deseni oluşturduk
    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
    //Base bir observer soyut nesne oluşturduk
    abstract class Observer
    {
        public abstract void Update();
    }
    //Haberdar olmasını istediğimiz nesne -->müşteriler
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }
    }
    //Haberdar olmasını istediğimiz nesne -->işçi
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price changed!");
        }
    }


}
