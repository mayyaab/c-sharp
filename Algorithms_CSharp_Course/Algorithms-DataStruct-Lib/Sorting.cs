﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib
{
    public class Sorting
    {

        public static void SelectionSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                Swap(array, largestAt, partIndex);
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int curUnsorted = array[partIndex];
                int i = 0;
                for (i = partIndex; i > 0 && array[i-1] > curUnsorted; i--)
                {
                    array[i] = array[i - 1];
                }

                array[i] = curUnsorted;
            }
        }

        private static void Swap (int[] array, int i, int j)
        {
            if (i == j)
            {
                return;
            }
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
