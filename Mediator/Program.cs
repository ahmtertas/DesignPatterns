using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator   //Arabulucu desen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();


            Teacher abbas = new Teacher(mediator);
            abbas.Name = "Abbas";

            mediator.Teacher = abbas;

            Student derin = new Student(mediator);
            derin.Name = "Derin";

            

            Student salih = new Student(mediator);
            salih.Name = "Salih";

            mediator.Student = new List<Student> { derin, salih };

            abbas.SendNewImageUrl("slide.jpg");
            abbas.RecieveQuestion("Is it true?",salih);

            Console.ReadLine();

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
        }
        public string Name { get; set; }
        public void RecieveQuestion(string question,Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0},{1}",student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}", url,Name);
        }

        public  void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student received answer {0}", answer);

        }

        public string Name { get; set; }
    }

    class  Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Student { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Student)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }


}
