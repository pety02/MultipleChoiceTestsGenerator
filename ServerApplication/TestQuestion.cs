using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTestsGenerator
{
    public class TestQuestion
    {
        private string questionText;
        private string[] possibleAnswers; 
        private string[] correctAnswers;
        private string[] currentAnswers;

        public TestQuestion()
        {
            QuestionText = "";
            PossibleAnswers = new string[4];
            CorrectAnswers = new string[4];
            CurrentAnswers = new string[4];
        }
        public TestQuestion(string questionText, string[] possibleAnswers, string[] correctAnswers)
        {
            QuestionText = questionText;
            PossibleAnswers = possibleAnswers;
            CorrectAnswers = correctAnswers;
            CurrentAnswers = new string[possibleAnswers.Length];
        }

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
