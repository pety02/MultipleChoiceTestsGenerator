namespace MultipleChoiceTestsGenerator
{
    public class TestQuestion
    {
        private string questionText;        //
        private string[] possibleAnswers;   //
        private string[] correctAnswers;    //
        private string[] currentAnswers;    //

        /// <summary>
        /// 
        /// </summary>
        public TestQuestion()
        {
            QuestionText = "";
            PossibleAnswers = new string[4];
            CorrectAnswers = new string[4];
            CurrentAnswers = new string[4];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionText"></param>
        /// <param name="possibleAnswers"></param>
        /// <param name="correctAnswers"></param>
        public TestQuestion(string questionText, string[] possibleAnswers, string[] correctAnswers)
        {
            QuestionText = questionText;
            PossibleAnswers = possibleAnswers;
            CorrectAnswers = correctAnswers;
            CurrentAnswers = new string[possibleAnswers.Length];
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
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