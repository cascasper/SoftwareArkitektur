namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberLinear(int[] array, int tal) {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == tal)
                {
                    return i; // Returnerer indekset, hvor tallet er fundet.
                }
            }
            return -1; // Returnerer -1, hvis tallet ikke findes i arrayet.
        }
        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberBinary(int[] array, int tal) {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (array[mid] == tal)
                {
                    return mid; // Tallet er fundet.
                }
                else if (array[mid] < tal)
                {
                    low = mid + 1; // Søg i den højre halvdel.
                }
                else
                {
                    high = mid - 1; // Søg i den venstre halvdel.
                }
            }

            return -1; // Tallet blev ikke fundet.
        }

        private static int[] sortedArray { get; set; } =
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private static int next = 0;

        /// <summary>
        /// Indsætter et helt array. Arrayet skal være sorteret på forhånd.
        /// </summary>
        /// <param name="sortedArray">Array der skal indsættes.</param>
        /// <param name="next">Den næste ledige plads i arrayet.</param>
        public static void InitSortedArray(int[] sortedArray, int next)
        {
            Search.sortedArray = sortedArray;
            Search.next = next;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int tal) {
            // Tjek om der er plads i arrayet
            if (next >= sortedArray.Length)
            {
                // Ingen ledige pladser, returnér arrayet som det er.
                return sortedArray;
            }

            // Find positionen hvor tallet skal indsættes
            int insertIndex = next;
            for (int i = 0; i < next; i++)
            {
                if (sortedArray[i] > tal)
                {
                    insertIndex = i;
                    break;
                }
            }

            // Flyt elementerne til højre for at skabe plads
            for (int i = next; i > insertIndex; i--)
            {
                sortedArray[i] = sortedArray[i - 1];
            }

            // Indsæt det nye tal
            sortedArray[insertIndex] = tal;

            // Opdater 'next' til at vise til det næste ledige index
            next++;

            return sortedArray;
        }
    }
}