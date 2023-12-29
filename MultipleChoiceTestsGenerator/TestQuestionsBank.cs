using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultipleChoiceTestsGenerator
{
    public class TestQuestionsBank
    {
        private TestQuestion[] questions;

        public TestQuestionsBank(int questionsCount)
        {
            XElement xml = XElement.Load("C:\\Users\\User\\OneDrive\\Documents\\University\\2kurs_3semestur\\C# OOP\\Project\\MultipleChoiceTestsGenerator\\MultipleChoiceTestsGenerator\\Questions.xml");
            var questionList = xml.Elements("Question");

            Questions = new TestQuestion[questionsCount];

            int i = 0;

            Random random = new Random();
            while(i < questionsCount)
            {
                int r = random.Next(0, 29);
                var question = questionList.ElementAt(r);

                string questionText = question.Element("QuestionText").Value;
                string[] possibleAnswers = question
                    .Element("PossibleAnswers")
                    .Elements("Answer").Select(a => a.Value)
                    .ToArray();
                string[] correctAnswers = question
                    .Element("CorrectAnswers")
                    .Elements("Answer").Select(a => a.Value)
                    .ToArray();
                
                questions[i] = new TestQuestion(questionText, possibleAnswers, correctAnswers);
                i++;
            }
        }

        public TestQuestion[] Questions 
        { 
            get
            {
                return questions;
            }
            set
            {
                questions = value != null && value.Length == 30 ? value : new TestQuestion[30];
            }
        }
    }
}
