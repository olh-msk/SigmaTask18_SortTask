using System;
using System.Collections.Generic;
using System.Numerics;

namespace SigmaTask18_SortTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //вивід у main лише для показових цілей   ===================

            int listSize = 10;
            List<Person> personList = new List<Person>();
            Console.WriteLine("Before sort: ");
            for(int i = 0; i <listSize; i++)
            {
                personList.Add(new Person());
                Console.WriteLine("age:{0}\tname: {1}",personList[i].Age,personList[i].Name);
            }

            Console.WriteLine("\nAfter sort by age: ");

            // межі [2,8)
            PyramidSort.GeneralHeapSort<Person>(ref personList, 2, 8, false);

            // межі [1,7]
            //QuikSort.GeneralQuikSort<Person>(personList, 1, 7, false);

            for (int i = 0; i < listSize; i++)
            {
                Console.WriteLine("i={2}\tage:{0}\tname: {1}", personList[i].Age, personList[i].Name,i);
            }
        }
    }
}
