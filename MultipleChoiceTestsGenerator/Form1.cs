using System.Diagnostics;

namespace MultipleChoiceTestsGenerator
{
    public partial class Form1 : Form
    {
        private TestQuestionsBank questionsBank;
        private TestQuestion currentQuestion;
        private TestQuestion prevQuestion;
        private TestQuestion nextQuestion;
        private int currentQuestionNo;
        private int totalScore;
        private int maxQuestions;
        private int currentAnswersCount;
        private System.Timers.Timer countdownTimer;
        private CancellationTokenSource cancellationTokenSource;
        private int secondsLeft;
        private string studentName;

        private TestQuestionsBank makeTest(int questionsCount)
        {
            return new TestQuestionsBank(questionsCount);
        }

        private void EnableAndDisableButtons(int questionNo)
        {
            if (!InputValidator.hasCheckedAnswers(answersGroupBox))
            {
                if (1 == questionNo)
                {
                    prevQuestionButton.Enabled = false;
                    submitTestButton.Enabled = false;
                    nextQuestionButton.Enabled = false;
                }
                if (1 < questionNo && questionNo < maxQuestions)
                {
                    prevQuestionButton.Enabled = true;
                    submitTestButton.Enabled = false;
                    nextQuestionButton.Enabled = false;
                }
                if (questionNo == maxQuestions)
                {
                    prevQuestionButton.Enabled = true;
                    submitTestButton.Enabled = true;
                    nextQuestionButton.Enabled = false;
                }
            }
            else
            {
                if (1 <= questionNo && questionNo < maxQuestions)
                {
                    prevQuestionButton.Enabled = true;
                    submitTestButton.Enabled = true;
                    nextQuestionButton.Enabled = true;
                }
                if (questionNo == maxQuestions)
                {
                    prevQuestionButton.Enabled = true;
                    submitTestButton.Enabled = true;
                    nextQuestionButton.Enabled = false;
                }
            }
        }

        private void DisableAllControls()
        {
            prevQuestionButton.Enabled = false;
            nextQuestionButton.Enabled = false;
            submitTestButton.Enabled = false;
            saveAnswerBtn.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
        }

        private void UncheckCheckBoxes()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void initializeQuestion(int questionNo)
        {
            EnableAndDisableButtons(questionNo);

            CurrentQuestion = QuestionsBank.Questions[questionNo - 1];
            if (questionNo - 1 > 0)
            {
                PrevQuestion = QuestionsBank.Questions[questionNo - 2];
            }

            if (questionNo - 1 < QuestionsBank.Questions.Length)
            {
                NextQuestion = QuestionsBank.Questions[questionNo];
            }

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

            UncheckCheckBoxes();
        }

        private int EvaluateTest(double percentage)
        {
            int grade = 0;
            if (0 <= percentage && percentage <= 54)
            {
                grade = 2;
            }
            else if (55 <= percentage && percentage <= 64)
            {
                grade = 3;
            }
            else if (65 <= percentage && percentage <= 74)
            {
                grade = 4;
            }
            else if (75 <= percentage && percentage <= 84)
            {
                grade = 5;
            }
            else
            {
                grade = 6;
            }

            return grade;
        }

        private void WriteReport(int grade, double percentage)
        {
            DateTime now = new DateTime();
            string filePath = $"{studentName}"
                + $".txt";
            string reportMessage = $"Test Report - [{now}]:"
                + $"\n\tStudent Name: {studentName}\n\tTotal Score: {totalScore}/{maxQuestions}"
                + $"\n\twith percetage {percentage}% of 100% => Grade: {grade}\n";

            FileWriter fw = new FileWriter(filePath, reportMessage);
            fw.Write();
        }

        private void FinishTest()
        {
            double percentage = (totalScore * 100d) / maxQuestions;
            int grade = EvaluateTest(percentage);

            string message = $"Points: {totalScore}/{maxQuestions}\nYour grade is: {grade}";
            DialogResult msgDialog = MessageBox.Show(message, "Test Resukt", MessageBoxButtons.OK);
            if(msgDialog == DialogResult.OK)
            {
                WriteReport(grade, percentage);
                Close();
            }
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
                FinishTest();
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

        public TestQuestion PrevQuestion
        {
            get
            {
                return prevQuestion;
            }
            set
            {
                prevQuestion = value;
            }
        }

        public TestQuestion NextQuestion
        {
            get
            {
                return nextQuestion;
            }
            set
            {
                nextQuestion = value;
            }
        }


        public Form1(int questionsCount, int seconds, string studentName)
        {
            InitializeComponent();

            countdownTimer = new System.Timers.Timer();
            secondsLeft = seconds;
            countdownTimer.Interval = 1000;
            countdownTimer.Elapsed += CountdownTimer_Tick;
            StartCountdown();

            currentAnswersCount = 0;
            this.studentName = studentName;
            greetingUserLabel.Text = "Hello, " + studentName;
            totalScore = 0;
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
            DisableAllControls();
            FinishTest();
        }

        private void prevQuestionButton_Click(object sender, EventArgs e)
        {
            currentQuestionNo--;
            initializeQuestion(currentQuestionNo);
            submitTestButton.Enabled = false;

            foreach (CheckBox answerCheckBox in answersGroupBox.Controls)
            {
                for (int i = CurrentQuestion.CurrentAnswers.Length - 1; i >= 0; --i)
                {
                    string answer = CurrentQuestion.CurrentAnswers[i];
                    if (answer == answerCheckBox.Text)
                    {
                        answerCheckBox.Checked = true;
                        break;
                    }
                }
            }

        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            foreach (string answer in CurrentQuestion.CorrectAnswers)
            {
                foreach (string currentAnswer in CurrentQuestion.CurrentAnswers)
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

            foreach (CheckBox answerCheckBox in answersGroupBox.Controls)
            {
                foreach (string answer in CurrentQuestion.CurrentAnswers)
                {
                    if (answer == answerCheckBox.Text)
                    {
                        answerCheckBox.Checked = true;
                        break;
                    }
                }
            }

            if (currentQuestionNo == maxQuestions)
            {
                submitTestButton.Enabled = true;
                nextQuestionButton.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
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

        private void EnableOrDisableNextQuestionAndSubmitButtons()
        {
            if (currentQuestionNo == maxQuestions)
            {
                submitTestButton.Enabled = true;
                nextQuestionButton.Enabled = false;
            }
            else
            {
                nextQuestionButton.Enabled = true;
                submitTestButton.Enabled = false;
            }
        }

        private void saveAnswerBtn_Click(object sender, EventArgs e)
        {
            EnableOrDisableNextQuestionAndSubmitButtons();
            int questionIndex = 0;
            foreach (CheckBox ctrl in answersGroupBox.Controls)
            {
                if (ctrl.Checked)
                {
                    CurrentQuestion.CurrentAnswers[questionIndex] = ctrl.Text;
                    questionIndex++;
                }
            }
        }
    }
}