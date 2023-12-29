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
        private string[] currentAnswers;
        private int currentAnswersCount = 0;
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

            checkBox1.Text = CurrentQuestion.PossibleAnswers[0];
            answersGroupBox.Controls.Add(checkBox1);
            checkBox2.Text = CurrentQuestion.PossibleAnswers[1];
            answersGroupBox.Controls.Add(checkBox2);
            checkBox3.Text = CurrentQuestion.PossibleAnswers[2];
            answersGroupBox.Controls.Add(checkBox3);
            checkBox4.Text = CurrentQuestion.PossibleAnswers[3];
            answersGroupBox.Controls.Add(checkBox4);

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
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
            currentAnswers = new string[4];
            currentQuestionNo = 1;
            maxQuestions = questionsCount;
            QuestionsBank = makeTest(maxQuestions);

            initializeQuestion(currentQuestionNo);
        }

        private void submitTestButton_Click(object sender, EventArgs e)
        {
            if (0 < secondsLeft)
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
            currentAnswers = new string[currentAnswersCount];
            int i = 0;
            foreach(CheckBox ctrl in answersGroupBox.Controls)
            {
                if(ctrl.Checked)
                {
                    currentAnswers[i] = ctrl.Text;
                    i++;
                }
            }
            foreach (string answer in CurrentQuestion.CorrectAnswers) 
            {
                foreach (string currentAnswer in currentAnswers)
                {
                    if (answer == currentAnswer)
                    {
                        totalScore++;
                        break;
                    }
                }
            }

            currentQuestionNo++;
            initializeQuestion(currentQuestionNo);

            if (currentQuestionNo == maxQuestions)
            {
                submitTestButton.Enabled = true;
                nextQuestionButton.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                currentAnswersCount++;
                return;
            } 
            
            currentAnswersCount--;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                currentAnswersCount++;
                return;
            }

            currentAnswersCount--;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                currentAnswersCount++;
                return;
            }
            
            currentAnswersCount--;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                currentAnswersCount++;
                return;
            }
            
            currentAnswersCount--;
        }
    }
}