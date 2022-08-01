using System;
using System.Collections.Generic;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher teacher = new Teacher(mediator) { Name = "Turan" };
            mediator.Teacher = teacher;

            Student mustafa = new Student(mediator) { Name = "Mustafa" };
            Student ahmet = new Student(mediator) { Name = "Ahmet" };

            mediator.Students = new List<Student> { mustafa, ahmet };

            
            teacher.SendNewImageUrl("turandeneme.jpg");
            teacher.ReceiveQuestion("is it true?",mustafa);
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

        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0} , {1} ", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }


        public void ReceiveImage(string url)
        {
            Console.WriteLine("{0} received image : {1}", Name, url);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("{0} received answer : {1}", Name, answer);
        }

        public string Name { get; set; }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}