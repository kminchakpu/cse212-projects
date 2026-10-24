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
        // TODO Problem 1 Start
        // Step 1: Create an array with the requested number of elements.
        // Step 2: Loop through each index of the array.
        // Step 3: Calculate the multiple using the starting number and the index.
        // Step 4: Store each multiple in the array.
        // Step 5: Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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
       // TODO Problem 2 Start
        // Step 1: Calculate the index where the last 'amount' elements begin.
        // Step 2: Copy the last 'amount' elements into a temporary list.
        // Step 3: Copy the elements before that index into another temporary list.
        // Step 4: Clear the original list.
        // Step 5: Add the last section to the original list first.
        // Step 6: Add the first section after it to complete the right rotation.

        int splitIndex = data.Count - amount;

        List<int> lastSection = data.GetRange(splitIndex, amount);
        List<int> firstSection = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(lastSection);
        data.AddRange(firstSection);
    }
}