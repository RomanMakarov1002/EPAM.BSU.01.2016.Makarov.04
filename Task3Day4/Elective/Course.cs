using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    public class Course
    {
        private readonly List<Teacher> _teacherID;
        public string CourseName { get; }
        public List<Student> StudentID =new List<Student>();
        public List<int?> Mark  = new List<int?>();


        

        internal Course(string name, Teacher teacher)
        {
            if (CourseName == name)
            {
                _teacherID.Add(teacher);
            }
            else
            {
                _teacherID = new List<Teacher>();
                CourseName = name;
                _teacherID.Add(teacher);
            }
        }
    }
}
