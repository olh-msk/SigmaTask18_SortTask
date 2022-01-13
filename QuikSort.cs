using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    public static class QuikSort
    {
        public static List<T> GeneralQuickSort<T>(List<T> elements, int start, int end) where T : IComparable<T>
        {
            //перевірка чи правильно введені межі сортування
            if (start < 0 || start > end || end > elements.Count)
            {
                Console.WriteLine("start {0}\t end {1}", start, end);
                throw new ArgumentException("Wrong input parametrs");
            }
            //розділяємо на частини, що треба сортувати і ні
            //ліва чатина, що не сортується
            var leftNotForSort = new List<T>();
            //частина для сортування
            var listForSort = new List<T>();
            //ліва частина не для сортування
            var rightForSort = new List<T>();

            //їх заповнення


            return null;
        }
        //універсальний квік сорт
        //elements - сам масив екземплярів класу
        //start, end - межі сортування, i = start; i < end
        public static List<T> GeneralQuickSort<T>(List<T> elements) where T : IComparable<T>
        {
            //умова виходу з рекурсії
            if (elements.Count() < 2)
            {
                return elements;
            }
            //обирається опорний індекс як 1 
            var keyElemIndex = 0;
            //копія опорного лемента
            var keyElem = elements[keyElemIndex];

            //масив екземплярів, менший за опорний
            var lesserList = new List<T>();
            //масив ля більших за опорний
            var greaterList = new List<T>();

            for (int i = 0; i < elements.Count; i++)
            {
                //пропускаємо індекс опорниго лемента
                if (i != keyElemIndex)
                {
                    //у самих класах має бути реалізовано як порівнювати
                    if (elements[i].CompareTo(keyElem) < 0)
                    {
                        lesserList.Add(elements[i]);
                    }
                    else
                    {
                        greaterList.Add(elements[i]);
                    }
                }
            }
            //рекурсивний виклик для масиву менших значень
            var merged = GeneralQuickSort(lesserList);

            //додаємо ключовий елемент
            merged.Add(keyElem);

            //додаємо масив більших значень, що рекурсивно викликав квік сорт
            merged.AddRange(GeneralQuickSort(greaterList));

            //вертаємо посортований масив екземплярів класу
            return merged;
        }




        //швидке сортування==============
        //elements - сам масив об'єктів
        //fisrt,last,  last це має бути count -1 тобто межі включно є наприклад [1,3] 
        //inGrowth - сортувати у зростання чи спадання
        //isParent - показує чи виклик функції є першим, необхідно, щоб коректоно працювало inGrowth
        //бо функція рекурсивна і обертання використовується до інших викликів
        public static void Quick_sort<T>(List<T> elements, int first, int last, bool inGrowth, bool isParent=true) where T : IComparable<T>
        {
            //умова виходу, розмір масиву є 1
            if (elements.Count() < 2 || first>last)
            {
                return;
            }
            //перевірка чи правильно введені межі сортування
            if (first < 0 || first > last || last > elements.Count)
            {
                Console.WriteLine("start {0}\t end {1}", first, last);
                throw new ArgumentException("Wrong input parametrs");
            }

            //індекси, що будуть мінятись
            int i = first, j = last;
            //ключовий елемент, від якого і робиться сортування
            var key_elem = elements[first];
            //Цикл пошуку і перестановик лементів
            while (true)
            {
                //шукаємо наступні елементи
                //що задовільняють умову
                //шукаємо менше число за ключ
                while (elements[i].CompareTo(key_elem) < 0)
                {
                    ++i;
                    //якщо дійшло краю і не знайшло
                    if (i == last)
                    {
                        break;
                    }
                }
                //шукамо більше число за ключовий
                while (elements[j].CompareTo(key_elem) >= 0)
                {
                    --j;
                    //якщо зайшло край і не найшло
                    if (j <= first)
                    {
                        break;
                    }
                }
                //swap можна в окрему функцію винести
                if (i <= j)
                {
                    var temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    //починаємо заново
                    i++;
                    j--;
                }
                //інакше кінець пошуку, розбиваємо
                //множину на 2
                else
                {
                    break;
                }
            }
            //розбиття на дві підмножини
            if (first < j)
            {
                Quick_sort(elements, first, j, inGrowth,false);
            }
            if (last > i)
            {
                Quick_sort(elements, i, last, inGrowth,false);
            }

            //посортувати у спадання якщо заданий параметр-----
            if (!inGrowth && isParent)
            {
                elements.Reverse(first,last-first+1);
            }
        }
    }
}
