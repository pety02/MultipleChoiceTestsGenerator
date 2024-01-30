using System.Net.Sockets;
using System.Text;

namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TestForm : Form
    {
        private TestQuestionsBank questionsBank;                    //
        private TestQuestion currentQuestion;                       //
        private TestQuestion prevQuestion;                          //
        private TestQuestion nextQuestion;                          //
        private int currentQuestionNo;                              //
        private int totalScore;                                     //
        private int maxQuestions;                                   //
        private int currentAnswersCount;                            //
        private System.Timers.Timer countdownTimer;                 //
        private CancellationTokenSource cancellationTokenSource;    //
        private int secondsLeft;                                    //
        private string studentName;                                 //
        private TcpClient tcpClient;                                //
        private NetworkStream stream;                               //
        private StreamWriter writer;                                //

        /// <summary>
        /// 
        /// </summary>
        private void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 1234);
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("Cannot connect to the server!");
                if (result == DialogResult.OK)
                {
                    DisconnectFromServer();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DisconnectFromServer()
        {
            if (this != null)
            {
                this.Close();
                Application.Exit();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="clientData"></param>
        private void ReceiveData(TcpClient client, string clientData)
        {
            try
            {
                stream = client.GetStream();
                int bytes = 8192;
                byte[] bytesArr = new byte[bytes];
                stream.Read(bytesArr, 0, bytes);
                clientData = Encoding.UTF8.GetString(bytesArr);
                TestQuestion[] qs = ParseQuestions(clientData);
                QuestionsBank = new TestQuestionsBank(qs);
                InitializeQuestion(currentQuestionNo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"Error: {ex.Message}");
                if(result == DialogResult.OK)
                {
                    DisconnectFromServer();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void UpdateUI(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(data)));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        private void SendData(TcpClient client)
        {
            stream = client.GetStream();
            writer = new StreamWriter(stream);
            try
            {
                string clientResponse = $"{studentName},{secondsLeft},{maxQuestions}";

                writer.Write(clientResponse);
                writer.Flush();
                stream.Flush();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"Error: {ex.Message}. " +
                    $"Please try to connect to the server again.");
                if (result == DialogResult.OK)
                {
                    DisconnectFromServer();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectToServer();
                SendData(tcpClient);
                string clientData = "";
                ReceiveData(tcpClient, clientData);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"Error: {ex.Message} " +
                    $"Please try to connect to the server again.");
                if (result == DialogResult.OK)
                {
                    DisconnectFromServer();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionNo"></param>
        private void EnableAndDisableButtons(int questionNo)
        {
            if (!InputValidator.HasCheckedAnswers(answersGroupBox))
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

        /// <summary>
        /// 
        /// </summary>
        private void DisableAllControls()
        {
            prevQuestionButton.Enabled = false;
            nextQuestionButton.Enabled = false;
            submitTestButton.Enabled = false;
            saveAnswerBtn.Enabled = false;
            firstAnswerCheckBox.Enabled = false;
            secondAnswerCheckBox.Enabled = false;
            thirdAnswerCheckBox.Enabled = false;
            fourthAnswerCheckBox.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UncheckCheckBoxes()
        {
            firstAnswerCheckBox.Checked = false;
            secondAnswerCheckBox.Checked = false;
            thirdAnswerCheckBox.Checked = false;
            fourthAnswerCheckBox.Checked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionNo"></param>
        private void InitializeQuestion(int questionNo)
        {
            EnableAndDisableButtons(questionNo);

            CurrentQuestion = QuestionsBank.Questions[questionNo - 1];
            if (questionNo - 1 > 0)
            {
                PrevQuestion = QuestionsBank.Questions[questionNo - 2];
            }

            if (questionNo - 1 < QuestionsBank.Questions.Length && questionNo < QuestionsBank.Questions.Length)
            {
                NextQuestion = QuestionsBank.Questions[questionNo];
            }

            questionNoLabel.Text = "Question No " + questionNo.ToString();
            questionTextLabel.Text = CurrentQuestion.QuestionText;

            firstAnswerCheckBox.Text = CurrentQuestion.PossibleAnswers[0];
            answersGroupBox.Controls.Add(firstAnswerCheckBox);
            secondAnswerCheckBox.Text = CurrentQuestion.PossibleAnswers[1];
            answersGroupBox.Controls.Add(secondAnswerCheckBox);
            thirdAnswerCheckBox.Text = CurrentQuestion.PossibleAnswers[2];
            answersGroupBox.Controls.Add(thirdAnswerCheckBox);
            fourthAnswerCheckBox.Text = CurrentQuestion.PossibleAnswers[3];
            answersGroupBox.Controls.Add(fourthAnswerCheckBox);

            UncheckCheckBoxes();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="percentage"></param>
        private void WriteReport(int grade, double percentage)
        {
            DateTime now = DateTime.Now;
            string filePath = $"{studentName}.txt";
            string reportMessage = $"Test Report - [{now}]:"
                + $"\n\tStudent Name: {studentName}\n\tTotal Score: {totalScore}/{maxQuestions}"
                + $"\n\twith percetage {percentage}% of 100% => Grade: {grade}\n";

            FileWriter fw = new FileWriter(filePath, reportMessage);
            fw.Write();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FinishTest()
        {
            double percentage = (totalScore * 100d) / maxQuestions;
            int grade = EvaluateTest(percentage);

            string message = $"Points: {totalScore}/{maxQuestions}\nYour grade is: {grade}";
            DialogResult msgDialog = MessageBox.Show(message, "Test Resukt", MessageBoxButtons.OK);
            if (msgDialog == DialogResult.OK)
            {
                WriteReport(grade, percentage);
                Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private async void StartCountdown()
        {
            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                while (secondsLeft >= 0)
                {
                    int hours = secondsLeft / 3600;
                    int minutes = secondsLeft / 60;
                    int seconds = secondsLeft % 60;

                    timelabel.Text = $"{hours}:{minutes}:{seconds}";
                    secondsLeft--;
                    await Task.Delay(1000, cancellationTokenSource.Token);
                }
            }
            catch (TaskCanceledException)
            {
                DialogResult result = MessageBox.Show("Timer cannot start counting down. " +
                    $"Please try to connect to the server again.");
                if (result == DialogResult.OK)
                {
                    DisconnectFromServer();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitTestButton_Click(object sender, EventArgs e)
        {
            if (0 < secondsLeft)
            {
                countdownTimer.Stop();
            }
            DisableAllControls();
            foreach (var currQuestion in QuestionsBank.Questions)
            {
                foreach (var currQuestionCorrectAnswers in currentQuestion.CorrectAnswers)
                {
                    foreach (var currQuestionCurrentnswers in currentQuestion.CurrentAnswers)
                    {
                        if(currQuestionCorrectAnswers == currQuestionCurrentnswers)
                        {
                            totalScore++;
                            break;
                        }
                    }
                    break;
                }
                break;
            }
            FinishTest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevQuestionButton_Click(object sender, EventArgs e)
        {
            currentQuestionNo--;
            InitializeQuestion(currentQuestionNo);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            currentQuestionNo++;
            InitializeQuestion(currentQuestionNo);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (firstAnswerCheckBox.Checked)
            {
                currentAnswersCount++;
                return;
            }

            currentAnswersCount--;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (secondAnswerCheckBox.Checked)
            {
                currentAnswersCount++;
                return;
            }

            currentAnswersCount--;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thirdAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (thirdAnswerCheckBox.Checked)
            {
                currentAnswersCount++;
                return;
            }

            currentAnswersCount--;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fourthAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (fourthAnswerCheckBox.Checked)
            {
                currentAnswersCount++;
                return;
            }

            currentAnswersCount--;
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private TestQuestion[] ParseQuestions(string data)
        {
            TestQuestion[] questions = new TestQuestion[maxQuestions];
            string currText = "";
            bool isCorrectAnswersPart = false, isPossibleAnswersPart = false;
            for (int i = 0, currQuestionNo = 0, answerIndex = 0; i < data.Length; ++i)
            {
                if (data[i] == '\n' && data[i + 1] == 'P')
                {
                    questions[currQuestionNo] = new TestQuestion();
                    questions[currQuestionNo].QuestionText = currText;
                    currText = "";
                }
                else if (data[i] == '\n' && currText.Equals("Possible Answers"))
                {
                    isPossibleAnswersPart = true;
                    isCorrectAnswersPart = false;
                    currText = "";
                }
                else if (data[i] == '\n' && currText.Equals("Correct Answers"))
                {
                    isPossibleAnswersPart = false;
                    isCorrectAnswersPart = true;
                    currText = "";
                    answerIndex = 0;
                }
                else if (data[i] == '\n' && isPossibleAnswersPart && 0 <= answerIndex && answerIndex <= 3)
                {
                    questions[currQuestionNo].PossibleAnswers[answerIndex] = currText;
                    currText = "";
                    ++answerIndex;
                }
                else if (data[i] == '\n' && isCorrectAnswersPart && 0 <= answerIndex && answerIndex <= 3)
                {
                    questions[currQuestionNo].CorrectAnswers[answerIndex] = currText;
                    currText = "";
                    ++answerIndex;
                }
                else if (data[i] == '*' && data[i + 1] == '\n')
                {
                    currQuestionNo++;
                    answerIndex = 0;
                    currText = "";
                    isPossibleAnswersPart = false;
                    isCorrectAnswersPart = false;
                }
                else
                {
                    currText += data[i];
                }
            }

            return questions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionsCount"></param>
        /// <param name="seconds"></param>
        /// <param name="studentName"></param>
        public TestForm(int questionsCount, int seconds, string studentName)
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
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
    }
}