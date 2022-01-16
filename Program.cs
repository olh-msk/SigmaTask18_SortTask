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
            //тест квік сорта--------
            Person[] sortedPersons = SortClass.GeneralQuikSort<Person>(
                persons, Person.CompareByAge, 0, persons.Length - 2, SortOrder.inGrowth,
                pers => pers.Age < 100);

            Console.WriteLine("Sorted By Age in growth, age <100:\n");
            foreach (Person person in sortedPersons)
            {
                Console.WriteLine(person);
            }
            //тест пірамідного сортування
            sortedPersons = SortClass.GeneralHeapSort<Person>(persons, Person.CompareByName,0,persons.Length,
                SortOrder.inDecline, (pers)=>pers.Age>50);

            Console.WriteLine("\nSorted By Name in decline, age > 50:\n");
            foreach (Person person in sortedPersons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
