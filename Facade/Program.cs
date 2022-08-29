using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    //Ortak kullanılan sınıfları tek bir cephede toplamak amaçlanır.
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    public interface ILogging
    {
        void Log();
    }

    public class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    public interface ICaching
    {
        void Cache();
    }

    public class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    public interface IAuthorize
    {
        void CheckUser();
    }

    public class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    public interface IValidate
    {
        void Validate();
    }
    public class CustomerManager
    {
        private CrossCuttingConcernsFacade _concerns;       
        public CustomerManager( )
        {
            _concerns = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.CheckUser();
            _concerns.Validate.Validate();
            Console.WriteLine("Saved");
        }
    }

    public class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validate;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validate = new Validation();
        }
    }
}
