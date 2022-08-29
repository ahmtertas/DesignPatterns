using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor //ziyaretçi tasarım deseni
{
    internal class Program
    {
        //bir şirketteki bütün hiyerarşiye maaş ödemesi yapmak istiyoruz
        //Ayrıca maaş zammı yapacaz ve her pozisyona farklı zam oranı uygulacaz.
        static void Main(string[] args)
        {
            Manager ahmet = new Manager { Name = "Ahmet", Salary = 1000};
            Manager abbas = new Manager { Name = "Abbas", Salary = 1050 };

            Worker derin = new Worker { Name = "Derin", Salary = 800 };
            Worker ali = new Worker { Name = "Ali", Salary = 800 };

            ahmet.Subordinates.Add(abbas);
            abbas.Subordinates.Add(derin);
            abbas.Subordinates.Add(ali);

            OrganisationalStructurs organisationalStructurs = new OrganisationalStructurs(ahmet);

            PayrolVisitor payrolVisitor = new PayrolVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organisationalStructurs.Accept(payrolVisitor);
            organisationalStructurs.Accept(payriseVisitor);

            Console.ReadLine();
        }
    }

    class OrganisationalStructurs
    {
        public EmployeeBase Employee;
        public OrganisationalStructurs(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitorBase)
        {
            Employee.Accept(visitorBase);
        }
        
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitorBase);
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
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitorBase);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    class PayrolVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);

        }
    }

    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}
