using System;
namespace _433_PA1
{
    public class QuickSort : Partition
    {
        public QuickSort(int[] array, int n) : base(array, n)
        {
        }

        public void quicksortMedianOf3()
        {
            quicksortMedianOf3(0, n - 1);
        }

        public void quicksortRandom()
        {
            quicksortRandom(0, n - 1);
        }

        private void quicksortMedianOf3(int left, int right)
        { // complete this function, yessir
            if (left < right) {
                int pivotMed3 = generateMedianOf3Pivot(left, right);
                int partitionIndex = partition(left, right, pivotMed3);
                quicksortMedianOf3(left, partitionIndex - 1);
                quicksortMedianOf3(partitionIndex + 1, right);
            }
        }

        private void quicksortRandom(int left, int right)
        { // complete this function, ogie dogie
            if (left < right) {
                int pivotRando = generateRandomPivot(left, right);
                int partitionIndex = partition(left, right, pivotRando);
                quicksortRandom(left, partitionIndex - 1);
                quicksortRandom(partitionIndex + 1, right);
            }
        }
    }
}
