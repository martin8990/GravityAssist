namespace Utility
{
    public static class ArrayShuffle
    {
        public static void Shuffle<T>(this T[] arr, int seed)
        {
            System.Random prng = new System.Random(seed);
            for (int i = 0; i < arr.Length-1; i++)
            {
                int randomIndex = prng.Next(i, arr.Length);
                T tempItem = arr[randomIndex];
                arr[randomIndex] = arr[i];
                arr[i] = tempItem;
            }
        }
    }
}
