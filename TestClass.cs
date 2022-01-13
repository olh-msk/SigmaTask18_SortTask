using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    class Person: IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Randomize();
        }
        //випадково заповнює атрибути
        public void Randomize()
        {
            Name = "";
            Random r = new Random();
            Age = r.Next(1,200);
            int nameLength = r.Next(4,7);
            for(int i = 0; i < nameLength; i++)
            {
                Name += r.Next(0,9).ToString();
            }
        }

        public int CompareByAge(Person? person)
        {
            if (person is null)
            {
                throw new ArgumentException("Object is NULL");
            }
            return this.Age.CompareTo(person.Age);
        }
        //порівнянн по імені
        public int CompareTo(Person? person)
        {
            if (person is null)
            {
                throw new ArgumentException("Object is NULL");
            }

            return this.Age.CompareTo(person.Age);
        }
    }

    class Table
    {
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Table()
        {

        }
    }
}
