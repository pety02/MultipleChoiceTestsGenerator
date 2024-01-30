using System.Xml.Linq;

namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// This class describes a questions bank.
    /// </summary>
    public class TestQuestionsBank
    {
        private TestQuestion[] questions;   // an array of random questions

        /// <summary>
        /// Sets definite questions in the questions array. 
        /// </summary>
        /// <param name="questions"></param>
        public TestQuestionsBank(TestQuestion[] questions)
        {
            Questions = questions;
        }

        /// <summary>
        /// Reads definite count random questions from an XML file.
        /// </summary>
        /// <param name="questionsCount">definite count of random questions</param>
        public TestQuestionsBank(int questionsCount)
        {
            XElement xml = XElement.Load("C:\\Users\\User\\OneDrive\\Documents\\University\\2kurs_3semestur\\C# OOP\\Project\\MultipleChoiceTestsGenerator\\ServerApplication\\Questions.xml");
            var questionList = xml.Elements("Question");

            Questions = new TestQuestion[questionsCount];

            int i = 0;

            Random random = new Random();
            while(i < questionsCount)
            {
                int r = random.Next(0, 29);
                var question = questionList.ElementAt(r);

                string questionText = question
                    .Element("QuestionText")
                    .Value;
                string[] possibleAnswers = question
                    .Element("PossibleAnswers")
                    .Elements("Answer")
                    .Select(a => a.Value)
                    .ToArray();
                
                string[] correctAnswers = question
                    .Element("CorrectAnswers")
                    .Elements("Answer")
                    .Select(a => a.Value)
                    .ToArray();
                
                questions[i] = new TestQuestion(questionText, possibleAnswers, correctAnswers);
                i++;
            }
        }

        /// <summary>
        /// Get/Set questions property.
        /// </summary>
        public TestQuestion[] Questions 
        { 
            get
            {
                return questions;
            }
            set
            {
                questions = value;
            }
        }
    }
}