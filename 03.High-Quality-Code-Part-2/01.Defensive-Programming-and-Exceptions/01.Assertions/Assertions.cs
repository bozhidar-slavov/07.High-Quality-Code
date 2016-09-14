using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Input array must not be null!");
        Debug.Assert(arr.Length > 0, "Input array must not be empty!");
        Debug.Assert(arr.Length != 1, "Input array which contains one element is already sorted!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int i = 1; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i - 1]) >= 0, "Array is not sorted correctly!");
        }
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Input array must not be null or empty!");
        Debug.Assert(startIndex <= endIndex, "Start index must be smaller than end index!");
        Debug.Assert(startIndex >= 0, "Start index must be bigger or equal to zero!");
        Debug.Assert(endIndex >= 0, "End index must be bigger or equal to zero!");
        Debug.Assert(endIndex < arr.Length, "End index must be less than the length of the input array!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        for (int i = startIndex + 1; i < endIndex; i++)
        {
            Debug.Assert(arr[minElementIndex].CompareTo(arr[i]) <= 0, "The element is not the minimum in the array!");
        }

        return minElementIndex; 
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Input array must not be null!");
        Debug.Assert(value != null, "Input value must not be null!");

        for (int i = 1; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i - 1]) >= 0, "Binary search algorithm works only on sorted array!");
        }

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Input array must not be null!");
        Debug.Assert(value != null, "Input value must not be null!");
        Debug.Assert(startIndex <= endIndex, "Start index must be smaller than end index!");
        Debug.Assert(startIndex >= 0, "Start index should be bigger or equal to zero!");
        Debug.Assert(endIndex >= 0, "End index should be bigger or equal to zero!");
        Debug.Assert(endIndex < arr.Length, "End index should be less than the length of the array!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));
        FindMinElementIndex(arr, -2, -20);

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}