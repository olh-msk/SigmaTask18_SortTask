using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    static class PyramidSort
    {
        //пірамідне сортування=================================
        //elements - вхідний масив екземплярів класу
        //first, last - це межі [first,last)
        //inGrowth - чи у порядку зростання
        public static void GeneralHeapSort<T>(ref List<T> elements, int first, int last, bool inGrowth) where T : IComparable<T>
        {
            //для елементів лівіше від вказаного діапазону
            List<T> leftList = new List<T>();
            //для елементів у діапазоні
            List<T> forSortList = new List<T>();
            //для елементів правіше від діапазону
            List<T> rightlist = new List<T>();

            //отримуєм ліву частину
            leftList = elements.GetRange(0,first);
            //частина, що сортується
            forSortList = elements.GetRange(first,last-first);

            HeapSort(forSortList);

            if(!inGrowth)
            {
                forSortList.Reverse();
            }

            //права частина, що не сортується
            rightlist = elements.GetRange(last,elements.Count-last);

            //об'єднюємо частини
            leftList.AddRange(forSortList);
            leftList.AddRange(rightlist);

            elements = leftList;
        }
        //сам алгоритм пірамідного сортування
        private static void HeapSort<T>(List<T> elements) where T : IComparable<T>
        {
            int sizeOfList = elements.Count;

            // Збудувати купу
            for (int currendIndex = (sizeOfList/2)-1; currendIndex >=0; currendIndex--)
            {
                MakeHeap(elements, sizeOfList, currendIndex);
            }
                

            // Починаємо міняти елементи місцями у жаданих межах починаючи з кінця
            for (int i = sizeOfList-1; i >0; i--)
            {
                // Поміняти місцями корінь і останній елент, що є в i
                Swap(elements, 0, i);

                // викликаємо будування купи, але вже без елемента, що став на своє місце
                //просіювання
                MakeHeap(elements, i, 0);
            }
        }

        //створити кучу з піддерева, корінь якого це вузол і,
        //і також індекс у elements, sizeOfList - розмір масиву
        static void MakeHeap<T>(List<T> elements, int sizeOfList, int currentIndex) where T : IComparable<T>
        {
            // ініціалізуємо найбільший елем як кореневий
            int indexRootElem = currentIndex;
            // лівий син має індекс 2*i + 1
            int indexLeftSon = (2 * currentIndex) + 1;
            // правий син має індекс 2*i + 2
            int indexRightSon = (2 * currentIndex) + 2; 

            // якщо лівий син більший за кореневий
            if (indexLeftSon < sizeOfList &&
                elements[indexLeftSon].CompareTo(elements[indexRootElem]) > 0)
            {
                //це новий кореневий елемент
                indexRootElem = indexLeftSon;
            }
                
            //Якщо правий син більший за більший за кореневий елемент
            if (indexRightSon < sizeOfList &&
                elements[indexRightSon].CompareTo(elements[indexRootElem]) > 0)
            {
                indexRootElem = indexRightSon;
            }
            //якщо найбільший елемент це не початковий корінь
            if (indexRootElem != currentIndex)
            {
                //поміняти місцями
                Swap(elements, currentIndex, indexRootElem);

                //ще раз робимо переверку на кучу у неправильному піддереві
                MakeHeap(elements, sizeOfList, indexRootElem);
            }
        }
        //міняє місцями елементи у масиві об'єктів------------
        private static void Swap<T>(List<T> elements, int i, int j)
        {
            var temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}
