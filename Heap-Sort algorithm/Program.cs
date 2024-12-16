using System;

class HeapSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
            Heap(arr, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            Swap(arr, 0, i);
            Heap(arr, i, 0);
        }
    }

    public static void Heap(int[] arr, int n, int i)
    {
        int root = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[root])
            root = left;

        if (right < n && arr[right] > arr[root])
            root = right;

        if (root != i)
        {
            Swap(arr, i, root);
            Heap(arr, n, root);
        }
    }
   
    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }  

    public static void Print(int[] arr)
    {
        string result = "";
        foreach (int ele in arr)
        {
            result += ele + ",";  
        }
        result = result.TrimEnd(',', ' ');

        Console.WriteLine(result);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter List Elements Like This: (e1 e2 e3)");
        string input = Console.ReadLine();
        int[] arr = Array.ConvertAll(input.Split(' '), int.Parse);

        Console.WriteLine("----------");

        Console.Write("Unsorted: ");
        Print(arr);

        Console.WriteLine("");
        Sort(arr);

        Console.Write("Sorted: ");
        Print(arr);

        Console.ReadKey();
    }
}
