namespace Sortering
{
    public static class QuickSort
    {
        private static void Swap(int[] array, int k, int j)
        {
            int tmp = array[k];
            array[k] = array[j];
            array[j] = tmp;
        }

        private static void _quickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);
                _quickSort(array, low, pivot - 1);
                _quickSort(array, pivot + 1, high);
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, high);
            return i + 1;
        }

        public static void Sort(int[] array)
        {
            _quickSort(array, 0, array.Length - 1);
        }
    }
}