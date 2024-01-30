namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// This class describes definite test question.
    /// </summary>
    public class TestQuestion
    {
        private string questionText;        // text of the question
        private string[] possibleAnswers;   // array of possible answers - max four
        private string[] correctAnswers;    // array of correct answers - max four
        private string[] currentAnswers;    // array of client chosen answers - max four

        /// <summary>
        /// TestQuetion default constructor.
        /// </summary>
        public TestQuestion()
        {
            QuestionText = "";
            PossibleAnswers = new string[4];
            CorrectAnswers = new string[4];
            CurrentAnswers = new string[4];
        }

        /// <summary>
        /// TestQuestion generous purpose constructor.
        /// </summary>
        /// <param name="questionText"> text of the question </param>
        /// <param name="possibleAnswers"> possible answers </param>
        /// <param name="correctAnswers"> correct answers </param>
        public TestQuestion(string questionText, string[] possibleAnswers, string[] correctAnswers)
        {
            QuestionText = questionText;
            PossibleAnswers = possibleAnswers;
            CorrectAnswers = correctAnswers;
            CurrentAnswers = new string[possibleAnswers.Length];
        }

        /// <summary>
        /// Get/Set questionText property.
        /// </summary>
        public string QuestionText 
        { 
            get
            {
                return questionText;
            }
            set
            {
                questionText = !String.IsNullOrEmpty(value) ? value : "";
            }
        }

        /// <summary>
        /// Get/Set possibleAnswes property.
        /// </summary>
        public string[] PossibleAnswers 
        { 
            get
            {
                return possibleAnswers;
            }
            set
            {
                possibleAnswers = value != null && value.Length == 4 ? value : new string[4]; 
            }
        }

        /// <summary>
        /// Get/Set correctAnswers property.
        /// </summary>
        public string[] CorrectAnswers
        { 
            get
            {
                return correctAnswers;
            }
            set
            {
                correctAnswers = value != null ? value : new string[4];
            }
        }

        /// <summary>
        /// Get/Set currentAnswers property.
        /// </summary>
        public string[] CurrentAnswers
        {
            get
            {
                return currentAnswers;
            }
            set
            {
                currentAnswers = value != null ? value : new string[4];
            }
        }
    }
}