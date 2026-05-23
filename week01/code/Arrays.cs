public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {

    /* 
        Step One -> Create a fixed array with the length parameter as it size to contain the multiples of the base number
        Step two ->  Initialize an index variable to add the values into the array, 
            this variable must be incrementd with new value addes
        Step three ->  Make a loop to multiply the base number until the length provided
        Step four ->  Return the array
    */

        // Create a fixed array with the length parameter as it size 
        double[] multiples = new double[length];

        //Initialize an index variable to add the values into the array
        int index = 0;

        // Make a loop to multiply the base number until the length provided
        for (int i = 1; i <= length; i++)
        {
            multiples[index] = number * i;
            index++;
        }

        // Return the array
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
    /* 
        First step -> Initialize three variables to contain:
            1) a new list with the items to rotate
            2) the starting position of this(ese) item(s)
            3) the position to insert these item when they are being moved in the list
        Second step -> Find and Store the items in the new list
        Third Step -> Remove the items that were stored from the primary list of data with a loop
        Last step -> Insert them at a choosing position (0 in this case) of the primary list with a loop
    */

        // A new list with the items to rotate
        List<int> firstHalf = [];

        // The starting position of this(ese) item(s)
        //amount parameter is the key to find how many items are to be rotated
        int index = data.Count - amount;
        
        //The position to insert these item when they are being moved in the list        
        int insertPosition = 0;

        // Find and Store the items in the new list
        firstHalf = data.GetRange(index, amount);

        // Remove the items that were stored from the primary list of data with a loop
        for (int i = data.Count - 1; i >= index; i--)
        {
            data.RemoveAt(i);
        }
        
        // Insert these items at a choosing position (0 in this case) of the primary list with a loop
        foreach(int item in firstHalf)
        {
            data.Insert(insertPosition, item);
            insertPosition++;
        }
    }
}
