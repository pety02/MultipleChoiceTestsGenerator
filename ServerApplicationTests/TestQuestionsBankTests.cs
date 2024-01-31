using MultipleChoiceTestsGenerator;

namespace ServerApplicationTests
{
    [TestFixture]
    public class TestQuestionsBankTests
    {
        private TestQuestionsBank questionsBank;
        [SetUp]
        public void Setup()
        {
            TestQuestion[] questions = new TestQuestion[] { 
                new TestQuestion("Question1?", 
                    new string[]{"A", "B", "C", "D"}, 
                    new string[]{"D"}),
                new TestQuestion("Question 2?", 
                    new string[]{"A", "B", "C", "D"},
                    new string[]{"A", "C"}),
                new TestQuestion("Question3?",
                    new string[]{"A", "B", "C", "D"},
                    new string[]{"B"})
            };

            this.questionsBank = new TestQuestionsBank(questions);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void LengthTest()
        {
            int expected = 3;
            int actual = questionsBank.Questions.Length;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}