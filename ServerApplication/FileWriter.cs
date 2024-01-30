namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// FileWriter class for logging students' results.
    /// </summary>
    public class FileWriter
    {
        private string filePath;    // path of the file
        private string message;     // message to be written in the file

        /// <summary>
        /// Generous purpose FileWriter constructor.
        /// </summary>
        /// <param name="filePath"> peth of the file </param>
        /// <param name="message"> message to be written in the file </param>
        public FileWriter(string filePath, string message)
        {
            this.filePath = filePath;
            this.message = message;
        }

        /// <summary>
        /// Get filePath property.
        /// </summary>
        public string FilePath 
        { 
            get
            {
                return filePath;
            }
        }

        /// <summary>
        /// Get message property.
        /// </summary>
        public string Message 
        {
            get
            {
                return message;
            }
        }

        /// <summary>
        /// Writing the message in the file. 
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