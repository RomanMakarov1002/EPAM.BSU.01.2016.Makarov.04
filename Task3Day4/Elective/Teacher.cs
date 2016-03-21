using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    public class Teacher :Human
    {
        public Teacher(string name, int age) : base(name, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            if (String.IsNullOrEmpty(courseName))
                throw  new ArgumentException("You must declare course name");
            if (Course == null)
                Course = new List<Course>();
            Course.Add(new Course(courseName, this));
        }

        public void FinishCourse(string courseName, params int[] marks)
        {           
            if (!String.IsNullOrEmpty(courseName))
            foreach (var item in Course)
            {
                if (item.CourseName == courseName)
                {
                    if (marks.Length!=item.StudentID.Count)
                        throw new ArgumentException("You must mark all students");
                    for (int i = 0; i < item.StudentID.Count; i++)
                        item.Mark[i] = marks[i];
                    // archive
                    Archive.Add(item);
                        Course.Remove(item);
                    break;

                }
            }
            
        }

    }
}
