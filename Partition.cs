using System;
namespace _433_PA1
{
    public class Partition
    {

        protected readonly int[] array;
        protected readonly int n;

        static Random rand;

        public Partition(int[] array, int n)
        {
            this.array = array;
            this.n = n;
            rand = new Random((int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));
        }

        protected void swap(int x, int y)
        {
            int temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }

        protected int generateRandomPivot(int left, int right)
        {
            int pivotIndex = left + rand.Next(right - left + 1);
            return array[pivotIndex];
        }

        protected int generateMedianOf3Pivot(int left, int right)
        {
            int mid = (left + right) / 2;

            if (array[left] > array[mid])
                swap(left, mid);

            if (array[left] > array[right])
                swap(left, right);

            if (array[mid] > array[right])
                swap(mid, right);

            return array[mid];
        }

        public int partition(int left, int right, int pivot) { // complete this function, you know what? Maybe I will!

            // Didn't know what to call the counter of numbers less than the pivot without it being too long, so count is fine.
            int count = 0;
            int pIndex = 0;

            // Go through the array, count all numbers <= pivot and increment count by 1 everytime. Also find out which index holds pivot.
            for(int a = 0; a < this.array.Length; a++) {
                if (this.array[a] == pivot)
                    pIndex = a;
                if (this.array[a] <= pivot)
                    count++;
            }
            swap(pIndex, count);

            int i = left, j = right;

            /*  The arduous partition while-loop. This loop goes through the entire array and swaps the numbers left
                of the pivot that are greater than the pivot with numbers right of the pivot that are less than the pivot.
                It's a little confusing to explain, so just look it up online or refer to your notes.*/
            while(i < j) {
                if(this.array[i] <= pivot) i++;
                else if(this.array[j] > pivot) j--;
                else {
                    swap(this.array[i], this.array[j]);
                    i++;
                }
            }

            return pIndex;
        }
    }
}
