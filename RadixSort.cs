using System;
namespace _433_PA1
{
    public class RadixSort
    {
        private readonly int[] array;
        private readonly int n;

        public RadixSort(int[] array, int length)
        {
            this.array = array;
            this.n = length;
        }

        private static void countSortOnDigits(int[] A, int n, int[] digits)
        {   // complete this function, ok sure
            // Declare counter array and output array
            int[] C = new int[10];
            int[] T = new int[n];

            // Init counter array
            for(int i = 0; i < C.Length; i++)
                C[i] = 0;

            // Get counters for all digits, why are we using n instead of digits.Length?
            for(int i = 0; i < n; i++)
                C[digits[i]]++;

            // Make counter array cummalative
            for(int i = 1; i < C.Length; i++)
                C[i] = C[i - 1] + C[i];

            // Use the counter array to figure out where to put elements of A
            for(int i = n - 1; i >= 0; i--)
                T[C[digits[i]]] = A[i];

            // Overwrite A with T
            for(int i = 0; i < n; i++)
                A[i] = T[i];
        }

        private static void radixSortNonNeg(int[] A, int n)
        {   // complete this function, Countsort took a lot of for-loops, will this one too?
            int[] digits = new int[n];

            // Find the biggest value
            int maxNum = A[0];
            for(int i = 1; i < n; i++)
                if(A[i] > maxNum)
                    maxNum = A[i];

            /*  Go through the count sorting rounds, starting with the last digit.
                This part is sorta confusing, but know that all the numbers last digits
                are being ripped off, modulo is used, and the digits array has values and is passed
                as a parameter to the countsort method.*/
            int roundMult = 1;
            while (maxNum / roundMult > 0) {
                for(int i = 0; i < n; i++)
                    digits[i] = (A[i] / roundMult) % 10;
                
                // Call upon the help of an ally (call another method to do the work)
                countSortOnDigits(A, n, digits);
                roundMult *= 10;
            }
        }

        public void radixSort()
        { // complete this function
            // Init the positive and negative arrays
            int[] neg = new int[] {};
            int[] pos = new int[] {};

            int negCount = 0, posCount = 0;
            for(int i = 0; i < n; i++)
                if (this.array[i] < 0)
                    neg[negCount] = this.array[i] * -1;
                else
                    pos[posCount] = this.array[i];

            radixSortNonNeg(neg, neg.Length);
            radixSortNonNeg(pos, pos.Length);

            for(int i = 0; i < neg.Length; i++)
                this.array[i] = neg[i];
            for(int i = neg.Length; i < n; i++)
                this.array[i] = pos[i];
        }
    }
}
