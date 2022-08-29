using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DependencyInjection //bağımlılığı azaltma 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //productmanager'ı newledik ancak bu prof. projelerde newlenmiyor
            //IOC containerlar, istediğimiz gibi değiştirebiliyoruz 



            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<NHibernade>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());

            productManager.Save();
            Console.ReadLine();

        }
    }

    interface IProductDal
    {
        void Save();
    }
    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }
    class NHibernade : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }
    class ProductManager
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            //business code
            
            _productDal.Save();
        }
    }
}
