namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class FileWriter
    {
        private string filePath;    //
        private string message;     //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="message"></param>
        public FileWriter(string filePath, string message)
        {
            this.filePath = filePath;
            this.message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FilePath 
        { 
            get
            {
                return filePath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Message 
        {
            get
            {
                return message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Write()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine(message);
                }

                Console.WriteLine("Text has been written to the file.");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while writing to the file: " + e.Message);
            }
        }
    }
}