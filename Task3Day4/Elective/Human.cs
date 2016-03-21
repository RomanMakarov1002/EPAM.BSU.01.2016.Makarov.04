using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    public abstract class Human : TheElective
    {     
        public string Name { get; }
        public int Age { get; }

        protected Human(string name, int age)
        {
            if (String.IsNullOrEmpty(name) || age < 0)
                throw new ArgumentException("You must declare both name and age");
            Name = name;
            Age = age;
        }

    }
}
