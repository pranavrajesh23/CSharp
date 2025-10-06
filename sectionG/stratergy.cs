using System;

namespace StrategyPatternExample
{
    // Strategy Interface
    interface ISortingStrategy
    {
        void Sort(int[] array);
    }

    // Concrete Strategy: Bubble Sort
    class BubbleSortStrategy : ISortingStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Bubble Sort");
        }
    }

    // Concrete Strategy: Merge Sort
    class MergeSortStrategy : ISortingStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Merge Sort");
        }
    }

    // Concrete Strategy: Quick Sort
    class QuickSortStrategy : ISortingStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Quick Sort");
        }
    }

    // Context
    class SortingContext
    {
        private ISortingStrategy _sortingStrategy;

        public SortingContext(ISortingStrategy sortingStrategy)
        {
            _sortingStrategy = sortingStrategy;
        }

        public void SetSortingStrategy(ISortingStrategy sortingStrategy)
        {
            _sortingStrategy = sortingStrategy;
        }

        public void PerformSort(int[] array)
        {
            _sortingStrategy.Sort(array);
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            SortingContext sortingContext = new SortingContext(new BubbleSortStrategy());
            int[] array1 = { 5, 2, 9, 1, 5 };
            sortingContext.PerformSort(array1); // Output: Sorting using Bubble Sort

            sortingContext.SetSortingStrategy(new MergeSortStrategy());
            int[] array2 = { 8, 3, 7, 4, 2 };
            sortingContext.PerformSort(array2); // Output: Sorting using Merge Sort

            sortingContext.SetSortingStrategy(new QuickSortStrategy());
            int[] array3 = { 6, 1, 3, 9, 5 };
            sortingContext.PerformSort(array3); // Output: Sorting using Quick Sort
        }
    }
}
