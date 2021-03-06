using System;

namespace ESort
{
    public class ESort
    {
        private int[] _numArr;
        private int _arrSize;

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public ESort()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _arrSize = input.Length;
            _numArr = new int[_arrSize];
            for (int i = 0; i < _arrSize; i++)
                _numArr[i] = int.Parse(input[i]);
        }

        public void ExchangeSort()
        {
            for (int i = 0; i < _arrSize - 1; i++)
                for (int j = i + 1; j < _arrSize; j++)
                    if (_numArr[i] > _numArr[j]) Swap(ref _numArr[i], ref _numArr[j]);
        }

        public void PrintArray()
        {
            foreach (int i in _numArr)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ESort e = new();
            e.PrintArray();
            e.ExchangeSort();
            e.PrintArray();
        }
    }
}

/*
Input:
5 4 3 2 1

Output:
5 4 3 2 1
1 2 3 4 5
*/