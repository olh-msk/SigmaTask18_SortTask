using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    enum SortOrder {inGrowth, inDecline };

    delegate bool Comparer<T>(T par1, T par2, SortOrder order);

    //класи для тестування=============================
    class Person
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

        static public bool CompareByAge(Person person1, Person person2, SortOrder order)
        {
            switch (order)
            {
                case SortOrder.inDecline:
                    return person1.Age < person2.Age;
                default:
                    return person1.Age > person2.Age;
            }
        }
        static public bool CompareByName(Person person1, Person person2, SortOrder order)
        {
            switch (order)
            {
                case SortOrder.inDecline:
                    return person1.Name.CompareTo(person2.Name) < 0;
                default:
                    return person1.Name.CompareTo(person2.Name) > 0;
            }
        }
        public override string ToString()
        {
            return string.Format($"Age: {Age}  \tName: {Name}\n");
        }
    }
}
