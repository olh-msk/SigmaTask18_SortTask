using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    //класи для тестування=============================
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
        //порівнянн по віку
        public int CompareTo(Person? person)
        {
            if (person is null)
            {
                throw new ArgumentException("Object is NULL");
            }

            return this.Age.CompareTo(person.Age);
        }
    }

    class Table: IComparable<Table>
    {
        public int Weight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Table()
        {
            Randomize();
        }
        //випадково заповнює атрибути
        void Randomize()
        {
            Random r = new Random();
            this.Weight = r.Next(1, 200);
            this.Width = r.Next(1,200);
            this.Height = r.Next(1,200);
        }

        //порівнює по висоті
        public int CompareTo(Table? other)
        {
            if (other is null)
            {
                throw new ArgumentException("Object is NULL");
            }

            return this.Height.CompareTo(other.Height);
        }
    }
}
