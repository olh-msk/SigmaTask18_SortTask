using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask18_SortTask
{
    static class PyramidSort
    {
        public static void GeneralHeapSort<T>(List<T> elements) where T : IComparable<T>
        {
            int sizeOfList = elements.Count;

            // Збудувати купу
            for (int i = sizeOfList / 2 - 1; i >= 0; i--)
            {
                MakeHeap(elements, sizeOfList, i);
            }
                

            // Починаємо міняти елементи місцями починаючи з кінця
            for (int i = sizeOfList - 1; i > 0; i--)
            {
                // Поміняти місцями корінь і останній елент, що є в i
                Swap(elements, 0, i);

                // викликаємо будування купи, але вже без елемента, що став на своє місце
                MakeHeap(elements, i, 0);
            }
        }

        //створити кучу з піддерева, корінь якого це вузол і,
        //і також індекс у elements, sizeOfList - розмір масиву
        static void MakeHeap<T>(List<T> elements, int sizeOfList, int i) where T : IComparable<T>
        {
            int indexRootElem = i;  // ініціалізуємо найбільший елем як кореневий
            int indexLeftSon = (2 * i) + 1; // лівий син має індекс 2*i + 1
            int indexRightSon = (2 * i) + 2; // правий син має індекс 2*i + 2

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
            if (indexRootElem != i)
            {
                //поміняти місцями
                Swap(elements, i, indexRootElem);

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
