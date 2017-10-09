using System;

namespace MergeSort
{
    public class Startup
    {
        public static void Main()
        {
            var arr = new[] { 6, 5, 3, 1, 8, 7, 2, 4 };

            var sorted = Algorithm(arr);

            for (int i = 0; i < sorted.Length; i++)
            {
                Console.WriteLine(sorted[i]);
            }
        }

        public static int[] Algorithm(int[] arr)
        {
            var sorted = new int[arr.Length];
            Array.Copy(arr, sorted, arr.Length);

            var helperArr = new int[arr.Length];
            Array.Copy(arr, helperArr, arr.Length);

            return Split(sorted, helperArr, 0, arr.Length - 1);
        }

        public static int[] Split(int[] arr, int[] helperArr, int start, int end)
        {
            //One element
            if (start == end)
            {
                return arr;
            }

            //Swap two elements
            if (end - start == 1)
            {
                if (arr[start] > arr[end])
                {
                    int temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                }

                return arr;
            }

            int middle = start + (end - start) / 2;
            Split(arr, helperArr, start, middle);
            Split(arr, helperArr, middle + 1, end);

            Merge(arr, helperArr, start, end);

            Copy(arr, helperArr, start, end);

            return arr;
        }

        public static int[] Merge(int[] arr, int[] helperArr, int start, int end)
        {
            int middle = start + (end - start) / 2;

            int placedIndex = start;
            int firstIndex = start;
            int secondIndex = middle + 1;

            while (firstIndex <= middle || secondIndex <= end)
            {
                if (firstIndex == middle + 1)
                {
                    helperArr[placedIndex] = arr[secondIndex];
                    secondIndex++;
                    placedIndex++;
                    continue;
                }

                if (secondIndex == end + 1)
                {
                    helperArr[placedIndex] = arr[firstIndex];
                    firstIndex++;
                    placedIndex++;
                    continue;
                }

                if (arr[firstIndex] < arr[secondIndex])
                {
                    helperArr[placedIndex] = arr[firstIndex];
                    firstIndex++;
                }
                else
                {
                    helperArr[placedIndex] = arr[secondIndex];
                    secondIndex++;
                }

                placedIndex++;
            }

            return helperArr;
        }

        public static void Copy(int[] arr, int[] arrCopy, int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                arr[i] = arrCopy[i];
            }
        }
    }
}
