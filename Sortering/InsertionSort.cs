namespace Sortering
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                // Flyt elementer, der er st�rre end key, en position frem
                // for at lave plads til inds�ttelse af key
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                // Inds�t key p� den korrekte position
                array[j + 1] = key;
            }
        }
    }
}