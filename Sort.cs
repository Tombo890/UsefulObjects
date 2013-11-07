using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSortSomeStuff
{
    class Sort
    {
        public void QuickSort(int[] arrayToSort, int low, int high)
        {
            // Vars
            int pivot = 0;

            // Done when low is greater than high
            if (low < high)
            {
                // Select a pivot point
                pivot = Partition(arrayToSort, low, high);
                
                // Recursive call to QuickSort for low and high
                QuickSort(arrayToSort, low, pivot - 1);
                QuickSort(arrayToSort, pivot + 1, high);
            }
        }

        private int Partition(int[] arrayToPartition, int low, int high)
        {
            // Vars
            int pivot = arrayToPartition[high];
            int i = low - 1;

            // Compare each value with the pivot point
            for (int j = low; j < high; j++)
            {
                // If value is less than the pivot switch the values in i and j
                if (arrayToPartition[j] <= pivot)
                {
                    i++;
                    Swap(arrayToPartition, i, j);
                }
            }

            // Move pivot point and return current position
            Swap(arrayToPartition, i + 1, high);
            return i + 1;
        }

        private void Swap(int[] arrayToSwap, int a, int b)
        {
            // Swap the values in position a and b
            int temp;
            temp = arrayToSwap[a];
            arrayToSwap[a] = arrayToSwap[b];
            arrayToSwap[b] = temp;
        }

        public void MergeSort(int[] arrayToSort, int left, int right)
        {
            // Done when left becomes right
            if (left < right)
            {
                // Vars
                int middle = (left + right) / 2;

                // Recursively Call Merge sort for left and right halves
                MergeSort(arrayToSort, left, middle);
                MergeSort(arrayToSort, middle + 1, right);

                // Vars for merge
                int[] leftArray = new int[middle - left + 1];
                int[] rightArray = new int[right - middle];
                int i = 0;
                int j = 0;

                // Copy wanted portions of array, this way we can write over our arrayToSort
                Array.Copy(arrayToSort, left, leftArray, 0, middle - left + 1);
                Array.Copy(arrayToSort, middle + 1, rightArray, 0, right - middle);

                // Merge Arrays 
                for (int k = left; k < right + 1; k++)
                {
                    // Stop looking in leftArray if you reach the end
                    if (i == leftArray.Length)
                    {
                        arrayToSort[k] = rightArray[j];
                        j++;
                    }
                    // Stop looking in rightArray if you reach the end
                    else if (j == rightArray.Length)
                    {
                        arrayToSort[k] = leftArray[i];
                        i++;
                    }
                    // Place the lowest value at current indexs 
                    else if (leftArray[i] <= rightArray[j])
                    {
                        arrayToSort[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        arrayToSort[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }
    }
}
