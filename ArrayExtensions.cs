namespace Extensions
{
    public static class ArrayExtensions
    {
        public static void Reset(this bool[,] arr, bool value = false)
        {
            (int x, int y) size = (arr.GetLength(0), arr.GetLength(1));
            for (int x = 0; x < size.x; x++)
                for (int y = 0; y < size.y; y++)
                    arr[x, y] = value;
        }
    }
}
