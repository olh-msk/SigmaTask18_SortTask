using System;
using System.Collections.Generic;
using System.Numerics;

namespace SigmaTask18_SortTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("N = ");
            //var len = Convert.ToInt32(Console.ReadLine());
            //var a = new int[len];
            //for (var i = 0; i < a.Length; ++i)
            //{
            //    Console.Write("a[{0}] = ", i);
            //    a[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //Console.WriteLine("Впорядкований масив: {0}", string.Join(", ", QuikSort.DoQuickSort(a)));

            //Console.WriteLine("PyramidSort: \n");

            //int[] arr = { 12, 11, 13, 5, 6, 7 };
            //int n = arr.Length;

            //PyramidSort.DoPyramidSort(arr);

            //Console.WriteLine("Sorted array is");
            //PyramidSort.PrintArray(arr);

            //Console.ReadLine();

            int listSize = 10;
            List<Person> personList = new List<Person>();
            Console.WriteLine("Before sort: ");
            for(int i = 0; i <listSize; i++)
            {
                personList.Add(new Person());
                Console.WriteLine("age:{0}\tname: {1}",personList[i].Age,personList[i].Name);
            }
            Console.WriteLine("\nAfter sort by age: ");
            QuikSort.Quick_sort<Person>(personList, 5, personList.Count-1, false);

            //personList = QuikSort.GeneralQuickSort<Person>(personList,0,personList.Count);
            for (int i = 0; i < listSize; i++)
            {
                Console.WriteLine("i={2}\tage:{0}\tname: {1}", personList[i].Age, personList[i].Name,i);
            }
        }
    }
}
