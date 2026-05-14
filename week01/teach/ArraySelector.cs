public static class ArraySelector
{
    // private static object list;

    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var new_array = new int[select.Length];
        int selectorIndex = 0;
        int list1Index = 0;
        int list2Index = 0;
        foreach (var item in select)
        {
            if (item == 1)
            {
                new_array[selectorIndex] = list1[list1Index];
                list1Index++;
            }
            else
            {
                new_array[selectorIndex] = list2[list2Index];
                list2Index++;
            }
            selectorIndex++;
        }

        return new_array;
    }
}