using System;
using System.Collections.Generic;
using System.Numerics;

namespace SigmaTask18_SortTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = {new Person(),new Person(), new Person(),
            new Person(), new Person(), new Person(), new Person(), new Person()
            , new Person(), new Person(), new Person(), new Person()};

            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }

            Person[] sortedPersons = SortClass.GeneralQuikSort<Person>(
                persons, Person.CompareByAge, 0, persons.Length - 2, SortOrder.inGrowth,
                pers => pers.Age < 100);

            Console.WriteLine("Sorted By Age:\n");
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
