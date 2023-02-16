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

            // Init counter array and output array
            for(int i = 0; i < C.Length; i++)
                C[i] = 0;

            // Init output array
            for(int i = 0; i < n; i ++)
                T[i] = 0;

            // Get counters for all digits, why are we using n instead of digits.Length?
            for(int i = 0; i < n; i++)
                C[digits[i]]++;

            // Make counter array cummalative
            for(int i = 1; i < C.Length; i++)
                C[i] = C[i - 1] + C[i];

            // Use the counter array to figure out where to put elements of A
            for(int i = n - 1; i >= 0; i--) {
                T[C[digits[i]] - 1] = A[i];
                C[digits[i]]--;
            }
                
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
        { // complete this function, okay
            // Init the positive and negative arrays
            List<int> neg = new List<int>();
            List<int> pos = new List<int>();

            for(int i = 0; i < n; i++) {
                if (this.array[i] < 0)
                    neg.Add(this.array[i] * -1);
                else
                    pos.Add(this.array[i]);
            }
            
            // Convert the dynamic arrays into static arrays, because that's what the radixsort uses
            int[] negList = neg.ToArray();
            int[] posList = pos.ToArray();

            radixSortNonNeg(negList, negList.Length);
            radixSortNonNeg(posList, posList.Length);

            // Replacing the first few values in original array with values in the negative array (reverse order)
            // Then replaces the rest with values in the positive array
            int counter = 0;
            for(int i = negList.Length - 1; i >= 0; i--, counter++)
                this.array[counter] = negList[i] * -1;
            for(int i = 0; i < posList.Length; i++, counter++)
                this.array[counter] = posList[i];
        }
    }
}
