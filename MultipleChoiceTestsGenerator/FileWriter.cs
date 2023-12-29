using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTestsGenerator
{
    public class FileWriter
    {
        private string filePath;
        private string message;

        public FileWriter(string filePath, string message)
        {
            this.filePath = filePath;
            this.message = message;
        }

        public string FilePath 
        { 
            get
            {
                return filePath;
            }
        }
        public string Message 
        {
            get
            {
                return message;
            }
        }

        public void Write()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
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
