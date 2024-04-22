namespace Sortering;

public class BubbleSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    
        public static void Sort(int[] array)
        {
            bool swapped;
            for (int i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                        swapped = true;
                    }
                }

                // Hvis der ikke blev lavet nogen byt i det indre loop, er arrayet sorteret.
                if (!swapped)
                    break;
            }
        }
    }
