using System;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;

namespace MultipleChoiceTestsGenerator
{
    public partial class Form1 : Form
    {
        private TestQuestionsBank questionsBank;
        private TestQuestion currentQuestion;
        private int currentQuestionNo;
        private int totalScore;
        private int maxQuestions;
        private string currentAnswer;
        private Random random;
        private System.Timers.Timer countdownTimer;
        private CancellationTokenSource cancellationTokenSource;
        private int secondsLeft;

        private TestQuestionsBank makeTest(int questionsCount)
        {
            return new TestQuestionsBank(questionsCount);
        }

        private void initializeQuestion(int questionNo)
        {
            if (1 == questionNo)
            {
                prevQuestionButton.Enabled = false;
                submitTestButton.Enabled = false;
                nextQuestionButton.Enabled = true;
            }
            if (1 < questionNo)
            {
                prevQuestionButton.Enabled = true;
            }
            else
            {
                prevQuestionButton.Enabled = false;
            }

            CurrentQuestion = QuestionsBank.Questions[questionNo - 1];
            questionNoLabel.Text = "Question No " + questionNo.ToString();
            questionTextLabel.Text = CurrentQuestion.QuestionText;

            firstAnswerRadioBtn.Text = CurrentQuestion.PossibleAnswers[0];
            answersGroupBox.Controls.Add(firstAnswerRadioBtn);
            secondAnswerRadioBtn.Text = CurrentQuestion.PossibleAnswers[1];
            answersGroupBox.Controls.Add(secondAnswerRadioBtn);
            thirdAnswerRadioBtn.Text = CurrentQuestion.PossibleAnswers[2];
            answersGroupBox.Controls.Add(thirdAnswerRadioBtn);
            fourthAnswerRadioBtn.Text = CurrentQuestion.PossibleAnswers[3];
            answersGroupBox.Controls.Add(fourthAnswerRadioBtn);

            firstAnswerRadioBtn.Checked = false;
            secondAnswerRadioBtn.Checked = false;
            thirdAnswerRadioBtn.Checked = false;
            fourthAnswerRadioBtn.Checked = false;
        }

        private void finishTest()
        {
            
                double percentage = (totalScore * maxQuestions) / 100;
                int grade = 0;
                if (0.0 <= percentage && percentage <= 0.54)
                {
                    grade = 2;
                }
                else if (0.55 <= percentage && percentage <= 0.64)
                {
                    grade = 3;
                }
                else if (0.65 <= percentage && percentage <= 0.74)
                {
                    grade = 4;
                }
                else if (0.75 <= percentage && percentage <= 0.84)
                {
                    grade = 5;
                }
                else
                {
                    grade = 6;
                }
                MessageBox.Show("Points: " + totalScore + "/" + maxQuestions + "\nYour grade is: " + grade);
                return;
        }

        private async void StartCountdown()
        {
            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                while (secondsLeft >= 0)
                {
                    timelabel.Text = secondsLeft.ToString();
                    secondsLeft--;
                    await Task.Delay(1000, cancellationTokenSource.Token);
                }

                finishTest();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Timer cannot start counting down.");
            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timelabel.Text = secondsLeft.ToString();
            secondsLeft--;
            if (secondsLeft < 0)
            {
                countdownTimer.Stop();
                finishTest();
            }
        }

        public TestQuestionsBank QuestionsBank
        {
            get
            {
                return questionsBank;
            }
            set
            {
                questionsBank = value;
            }
        }


        public TestQuestion CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }
            set
            {
                currentQuestion = value;
            }
        }


        public Form1(int questionsCount, int seconds, string studentName)
        {
            InitializeComponent();
            random = new Random();

            countdownTimer = new System.Timers.Timer();
            secondsLeft = seconds;
            countdownTimer.Interval = 1000;
            countdownTimer.Elapsed += CountdownTimer_Tick;
            StartCountdown();

            greetingUserLabel.Text = "Hello, " + studentName;
            totalScore = 0;
            currentAnswer = "";
            currentQuestionNo = 1;
            maxQuestions = questionsCount;
            QuestionsBank = makeTest(maxQuestions);

            initializeQuestion(currentQuestionNo);
        }

        private void firstAnswerRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            currentAnswer = firstAnswerRadioBtn.Text;
        }

        private void secondAnswerRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            currentAnswer = secondAnswerRadioBtn.Text;
        }

        private void thirdAnswerRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            currentAnswer = thirdAnswerRadioBtn.Text;
        }

        private void fourthAnswerRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            currentAnswer = fourthAnswerRadioBtn.Text;
        }

        private void submitTestButton_Click(object sender, EventArgs e)
        {
            if(0 < secondsLeft)
            {
                countdownTimer.Stop();
            }
            finishTest();
        }

        private void prevQuestionButton_Click(object sender, EventArgs e)
        {
            currentQuestionNo--;
            initializeQuestion(currentQuestionNo);
            submitTestButton.Enabled = false;
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            if (currentAnswer == CurrentQuestion.CorrectAnswer)
            {
                totalScore++;
            }

            currentQuestionNo++;
            initializeQuestion(currentQuestionNo);

            if (currentQuestionNo == maxQuestions)
            {
                submitTestButton.Enabled = true;
                nextQuestionButton.Enabled = false;
            }
        }
    }
}