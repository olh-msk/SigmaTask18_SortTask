using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    static class SortClass
    {
        //Загальний квік сорт
        static public T[] GeneralQuikSort<T>(T[] elements, Comparer<T> comparer,
            int start, int end, SortOrder order, Func<T, bool>predicate)
        {
            T[] elementsToSort = new T[end - start];

            //вивдялємо частини, що треба посортувати
            for(int i=start, j=0; i<end; i++, j++)
            {
                elementsToSort[j] = elements[i];
            }
            //виділяємо елементи, що були задані додатковою умовою
            elementsToSort = elementsToSort.Where(predicate).ToArray();
            return Sort(elementsToSort,comparer,0,elementsToSort.Length-1,order);
        }
        //приймає межі як [minIndex, maxIndex]
        static private T[] Sort<T>(T[] elements, Comparer<T> comparer,
            int minIndex, int maxIndex, SortOrder order)
        {
            if(minIndex >= maxIndex)
            {
                return elements;
            }

            int keyIndex = Partion(elements,comparer,minIndex,maxIndex,order);
            //рукерсивне розбиття
            Sort(elements, comparer, minIndex, keyIndex-1, order);
            Sort(elements, comparer, keyIndex+1, maxIndex, order);

            return elements;
        }
        //вертає індекс опорного елемента
        static private int Partion<T>(T[] elements, Comparer<T> comparer,
            int minIndex, int maxIndex, SortOrder order)
        {
            int pivot = minIndex - 1;

            for(int i = minIndex; i<maxIndex; i++)
            {
                //тут елементи між собою перевіряються
                if (comparer(elements[i], elements[maxIndex], order))
                {
                    pivot++;
                    Swap(ref elements[pivot], ref elements[i]);
                }
            }
            pivot++;
            Swap(ref elements[pivot], ref elements[maxIndex]);

            return pivot;
        }
        //функція обміну елементів у масиві
        static private void Swap<T>(ref T fisrt, ref T second)
        {
            var temp = fisrt;
            fisrt = second;
            second = temp;
        }

        //функція загального пірамідного сортування
        static public T[] GeneralHeapSort<T>()
        {
            return null;
        }
    }
}
