using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    public class Student : Human
    {
         
        public int Group { get; }
        public Student(string name, int age, int group) : base(name, age)
        {
            Group = group;
        }

        public void SignForCourse(string courseName)
        {
            bool found = false;
            if (String.IsNullOrEmpty(courseName))
                throw new ArgumentException("You must declare course name");
            foreach (var item in Course)
            {
                if (item.CourseName == courseName)
                {
                    item.StudentID.Add(this);
                    item.Mark.Add(0);
                    found = true;
                }                    
            }
            if (found == false)
            {
                throw new KeyNotFoundException("Selected course not found");
            }
        }

        public void LeaveCourse(string courseName)
        {
            bool found = false;
            if (String.IsNullOrEmpty(courseName))
                throw new ArgumentException("You must declare course name");
            foreach (var item in Course)
            {
                if (item.CourseName == courseName)
                {
                    item.StudentID.Remove(this);
                    item.Mark.Remove(0);
                    found = true;
                }
            }
            if (found == false)
            {
                throw new KeyNotFoundException("Selected course not found");
            }

        }
    }
}
