using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        //Dışardaki bir servisi kendi projemize davet etmek istiyoruz
        //Örneğin Mernisi kendi sistemimize dahil etmek istiyoruz
        //O servisi kullanırken, referans olarak alırken metodu kullanacaz bu bağımlı hale getirecek bizi
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EdLogger());
            productManager.Save();

            Console.ReadLine();
        }
    }

    public class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save() 
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved!");
        }

    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}", message);
        }
    }

    //Nugetten indirdiğimiz bir dll olsun ve bu classa hiç dokunamıyoruz.
    //ProductManager'a log4net'i nasıl çağırırız problem bu 
    //ILogger şeklinde interface yazamıyoruz 
    public class Log4Net
    {
        public void LogMessage(string message) 
        {
            Console.WriteLine("Logged with log4net , {0}", message);
        }
    }
    //log4netinadapter şeklinde oluşturduğumuz class ile bunu çözüme kavuşturduk
    public class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4net = new Log4Net();
            log4net.LogMessage(message);
        }
    }



}
