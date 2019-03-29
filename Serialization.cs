using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        [Serializable]
        public class Student
        {
            public string name;
            public double gpa;

            public Student()
            {
                name = " ";
                gpa = 0.0;
            }
            
            public Student(string name, double gpa)
            {
                this.name = name;
                this.gpa = gpa;
            }
        }
        [Serializable]
        public class Lesson
        {
            public List<Student> students;
            public string name;
            public Lesson()
            {
                name = "pp1";
                students = new List<Student>();
            }

            public void AddStudent(Student s)
            {
                students.Add(s);
            }

            public void save()
            {
                FileStream fs = new FileStream("lesson.xml", FileMode.OpenOrCreate,FileAccess.ReadWrite );
                XmlSerializer xs = new XmlSerializer(typeof(Lesson));
                xs.Serialize(fs, this);
                fs.Close();

            }
            public Lesson GetData()
            {
                FileStream fs = new FileStream("lesson.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(Lesson));
                Lesson lesson = (Lesson)xs.Deserialize(fs);
                fs.Close();
                return lesson;
            }
            public void Print()
            {
                Console.WriteLine(name + " ");
            }
        }
        static void Main(string[] args)
        {
            Student s = new Student("Masha", 3.5);
            Student s1 = new Student("Dan", 2.5);
            Lesson l = new Lesson();
            Lesson l1 = l.GetData();
            l.AddStudent(s);
            l.save();
            l1.Print();
            Console.ReadKey();
        }
    }
}
