namespace Sortering
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            _mergeSort(array, 0, array.Length - 1);
        }

        private static void _mergeSort(int[] array, int l, int h)
        {
            if (l < h)
            {
                int m = (l + h) / 2;
                _mergeSort(array, l, m);
                _mergeSort(array, m + 1, h);
                Merge(array, l, m, h);
            }
        }

        private static void Merge(int[] array, int low, int middle, int high)
        {
            // Opret to midlertidige arrays til at gemme de to halvdele
            int n1 = middle - low + 1;
            int n2 = high - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
                L[i] = array[low + i];
            for (int j = 0; j < n2; j++)
                R[j] = array[middle + 1 + j];

            // Initialiser indekser for de to under-arrays og det samlede array
            int k = low;
            int iLeft = 0, iRight = 0;

            // Flet de to halvdele ind i array
            while (iLeft < n1 && iRight < n2)
            {
                if (L[iLeft] <= R[iRight])
                {
                    array[k] = L[iLeft];
                    iLeft++;
                }
                else
                {
                    array[k] = R[iRight];
                    iRight++;
                }
                k++;
            }

            // Kopier resterende elementer af L[], hvis der er nogle
            while (iLeft < n1)
            {
                array[k] = L[iLeft];
                iLeft++;
                k++;
            }

            // Kopier resterende elementer af R[], hvis der er nogle
            while (iRight < n2)
            {
                array[k] = R[iRight];
                iRight++;
                k++;
            }
        }
    }
}