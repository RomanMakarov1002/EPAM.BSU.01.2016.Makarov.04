using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elective;
using NUnit.Framework;

namespace NUnit_Tests
{
    [TestFixture]
    public class ElectiveClassTests
    {
        [TestCase("", 10, ExpectedException = typeof (ArgumentException))]
        [TestCase("Aaron", -1, ExpectedException = typeof (ArgumentException))]
        public void Exception_Tests(string name, int age)
        {
            Teacher teacher = new Teacher(name, age);
        }

        [TestCase("abcdef", ExpectedException = typeof (KeyNotFoundException))]
        public void SignforCourse_Test(string name)
        {
            Teacher teacher = new Teacher("alan", 40);
            Student student = new Student("james",20, 01);
            teacher.CreateCourse("Best course ever");
            student.SignForCourse(name);
        }

        [Test]
        public void Elective_Tests()
        {
            Teacher teacher = new Teacher("Leonardo DiCaprio", 45);
            teacher.CreateCourse("On a way to Oscar");
            teacher.CreateCourse("Actor courses");
            Student student = new Student("Aaron Ramsey",40, 01924);
            Student student1 = new Student("Jennifer Lowrence", 23, 12414);
            Student student2 = new Student("Samuel Jackson", 50, 23401);
            student.SignForCourse("On a way to Oscar");
            student1.SignForCourse("On a way to Oscar");
            student2.SignForCourse("Actor courses");
            student2.SignForCourse("On a way to Oscar");
            Assert.AreEqual(3,TheElective.Course[0].StudentID.Count);
            student2.LeaveCourse("On a way to Oscar");
            teacher.FinishCourse("On a way to Oscar",10,8);
            Assert.AreEqual(2,TheElective.Archive[0].StudentID.Count);
            Assert.AreEqual(1,TheElective.Course[0].StudentID.Count);
            Assert.AreEqual(10, TheElective.Archive[0].Mark[0]);
        }
    }
}
