using System;
namespace _433_PA1
{
    public class Selection : Partition
    {
        public Selection(int[] array, int n) : base(array, n)
        {
        }

        public int select(int k)
        {
            return select(0, n - 1, k);
        }

        private int select(int left, int right, int k)
        {   // complete this function, oh man
            // If the array is size of one, then that must be the answer
            if(left == right) return this.array[left];

            // Do some prep work for the recursion
            int pivot = generateRandomPivot(left, right);
            int partitionIndex = partition(left, right, pivot);

            if(k == partitionIndex - left + 1)
                return pivot;
            else if(k < partitionIndex - left + 1) {
                return select(left, partitionIndex - 1, k);
            }
            else {
                return select(partitionIndex + 1, right, k - (partitionIndex - left + 1));
            }
        }
    }
}
