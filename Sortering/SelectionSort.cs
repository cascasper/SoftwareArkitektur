namespace Sortering
{
    public class SelectionSort
    {
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                // Antag at det første usorterede element er det mindste
                int minIndex = i;

                // Find det mindste element i den resterende usorterede del
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Byt det mindste fundne element med det første usorterede element
                Swap(array, minIndex, i);
            }
        }
    }
}