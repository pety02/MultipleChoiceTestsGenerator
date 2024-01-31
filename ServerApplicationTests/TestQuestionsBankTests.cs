using MultipleChoiceTestsGenerator;

namespace ServerApplicationTests
{
    /// <summary>
    /// This class describes the TestQuestionsBank NUnit tests.
    /// </summary>
    [TestFixture]
    public class TestQuestionsBankTests
    {
        private TestQuestionsBank questionsBank;

        /// <summary>
        /// Initialize class private fields to prepare them for testing.
        /// </summary>
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

        /// <summary>
        /// Clears the memory where it is needed.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        }

        /// <summary>
        /// Tests the length of the TestQuestion array.
        /// </summary>
        [Test]
        public void LengthTest()
        {
            int expected = 3;
            int actual = questionsBank.Questions.Length;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}