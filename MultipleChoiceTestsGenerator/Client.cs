namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// Client application starting class
    /// </summary>
    class Client
    {   
        /// <summary>
        /// Start point of the client application.
        /// </summary>
        /// <param name="args"> nothing - only triggers the client application </param>
        static void Main(string[] args)
        {
            TestDimensionsForm testDimensionsForm = new TestDimensionsForm();
            testDimensionsForm.ShowDialog();
        }
    }
}