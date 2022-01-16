using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    //енам на два види сортування
    enum SortOrder { inGrowth, inDecline };

    //делегат, що буде приймати реалізовані порівняння по параметру у самому класі 
    //і вертатиме bool
    delegate bool ParameterComparer<T>(T elem1, T elem2, SortOrder order);
    static class SortClass
    {
        
        //Загальний квік сорт=========================
        static public T[] GeneralQuikSort<T>(T[] elements, ParameterComparer<T> comparer,
            int start, int end, SortOrder order, Func<T, bool>predicate)
        {
            T[] elementsToSort = new T[end - start];

            //вивдялємо частини, що треба посортувати
            for(int i=start, j=0; i<end; i++, j++)
            {
                elementsToSort[j] = elements[i];
            }
            //виділяємо елементи, що були задані додатковою умовою предиката
            elementsToSort = elementsToSort.Where(predicate).ToArray();

            return Sort(elementsToSort,comparer,0,elementsToSort.Length-1,order);
        }
        //приймає межі як [minIndex, maxIndex]
        static private T[] Sort<T>(T[] elements, ParameterComparer<T> comparer,
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
        static private int Partion<T>(T[] elements, ParameterComparer<T> comparer,
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

        //функція загального пірамідного сортування=================
        static public T[] GeneralHeapSort<T>(T[] elements, ParameterComparer<T> comparer,
            int start, int end, SortOrder order, Func<T, bool> predicate)
        {

            T[] elementsToSort = new T[end - start];

            //вивдялємо частини, що треба посортувати
            for (int i = start, j = 0; i < end; i++, j++)
            {
                elementsToSort[j] = elements[i];
            }
            //виділяємо елементи, що були задані додатковою умовою предиката
            elementsToSort = elementsToSort.Where(predicate).ToArray();

            int size = elementsToSort.Length;
            //побудова кучі
            //побудова кучі (перегруповуємо масив)
            for (int i = size / 2 - 1; i >= 0; i--)
                Heapify(elementsToSort, size, i, comparer, order);

            // Один за одним витягуємо елементи з кучі
            for (int i = size - 1; i >= 0; i--)
            {
                //Переміщуємо текучий корінь в кінець
                Swap(ref elementsToSort[0], ref elementsToSort[i]);

                //викликаємо процедуру heapify на зменшеній кучі
                Heapify(elementsToSort, i, 0, comparer, order);
            }

            return elementsToSort;
        }
        static private void Heapify<T>(T[] elements, int size, int i, ParameterComparer<T> comparer, SortOrder order)
        {
            int largest = i;
            //Ініціалізуємо найбільший елемент як корінь
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            //Якщо лівий дочірній елемент більший за корінь
            if (l < size && !comparer(elements[l], elements[largest], order))
                largest = l;

            //Якщо правий дочірній елемент більший за найбільший елемент на даний момент
            if (r < size && !comparer(elements[r], elements[largest], order))
                largest = r;

            //Якщо найбільший елемент не корінь
            if (largest != i)
            {
                Swap(ref elements[i], ref elements[largest]);

                //Рекурсивно перетворюємо в двійкову кучу піддерево
                Heapify(elements, size, largest, comparer, order);
            }
        }
    }
}
