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
        private string correctAnswer;

        public TestQuestion(string questionText, string[] possibleAnswers, string correctAnswer)
        {
            QuestionText = questionText;
            PossibleAnswers = possibleAnswers;
            CorrectAnswer = correctAnswer;
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
        public string CorrectAnswer 
        { 
            get
            {
                return correctAnswer;
            }
            set
            {
                correctAnswer = !String.IsNullOrEmpty(value) ? value : "";
            }
        }
    }
}
