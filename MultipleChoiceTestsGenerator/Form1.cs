using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// This class describes a test form.
    /// </summary>
    public partial class TestForm : Form
    {
        private TestQuestionsBank questionsBank;                    // bank of all questions
        private TestQuestion currentQuestion;                       // current question
        private TestQuestion prevQuestion;                          // previous question
        private TestQuestion nextQuestion;                          // next question
        private int currentQuestionNo;                              // number of the current question
        private int totalScore;                                     // total score till now
        private int maxQuestions;                                   // max number of questions
        private int currentAnswersCount;                            // count of the current answers
        private System.Timers.Timer countdownTimer;                 // timer object
        private CancellationTokenSource cancellationTokenSource;    // cancelation timer token source
        private int secondsLeft;                                    // seconds left till end of the try
        private string studentName;                                 // student name
        private TcpClient tcpClient;                                // tcp client
        private NetworkStream stream;                               // stream of messages between client and server
        private StreamWriter writer;                                // client stream writer

        /// <summary>
        /// Makes connection to the server.
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
        /// Ends connection with the server.
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
        /// Parse questions after reading them as string from the server.
        /// </summary>
        /// <param name="data"> generated from the server questions as string </param>
        /// <returns> questions as an array of TestQuestion objects </returns>
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
        /// Receives data from the server.
        /// </summary>
        /// <param name="client"> the tcp client </param>
        /// <param name="clientData"> received data as a string </param>
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
                if (result == DialogResult.OK)
                {
                    DisconnectFromServer();
                }
            }
        }

        /// <summary>
        /// Updates the UI of the client application.
        /// </summary>
        /// <param name="data"> recived data from the server </param>
        private void UpdateUI(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(data)));
            }
        }

        /// <summary>
        /// Sends data to the server
        /// </summary>
        /// <param name="client"> client - the server in this situation </param>
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
        /// Loads the test form. 
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
        /// Enables and disables buttons in different situations - 
        /// on differnt question number.
        /// </summary>
        /// <param name="questionNo"> question number </param>
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
        /// Disables all controls.
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
        /// Unchecks all check boxes.
        /// </summary>
        private void UncheckCheckBoxes()
        {
            firstAnswerCheckBox.Checked = false;
            secondAnswerCheckBox.Checked = false;
            thirdAnswerCheckBox.Checked = false;
            fourthAnswerCheckBox.Checked = false;
        }

        /// <summary>
        /// Initialize a question with a definite question number.
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
        /// Evaluates the test after finish it.
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
        /// Writing report in a plain text file after finishing test.
        /// </summary>
        /// <param name="grade"> student's current grade </param>
        /// <param name="percentage"> student's current grade as point percentage </param>
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
        /// Finishes the test.
        /// </summary>
        private void FinishTest()
        {
            countdownTimer.Stop();
            secondsLeft = 0;

            DisableAllControls();
            double percentage = (totalScore * 100d) / maxQuestions;
            int grade = EvaluateTest(percentage);

            string message = $"Points: {totalScore}/{maxQuestions}\nYour grade is: {grade}";
            DialogResult msgDialog = MessageBox.Show(message, "Test Result", MessageBoxButtons.OK);
            if (msgDialog == DialogResult.OK)
            {
                WriteReport(grade, percentage);
                Close();
            }
        }

        /// <summary>
        /// Starts countdown on initializng the test form.
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
        /// Action on countdownTimer_Tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timelabel.Text = secondsLeft.ToString();
            secondsLeft--;
            if (secondsLeft <= 0)
            {
                FinishTest();
            }
        }

        /// <summary>
        /// Increases total score if current answer is correct.
        /// </summary>
        /// <param name="questionsBank"> a bank of questions </param>
        private void IncreaseTotalScore(TestQuestionsBank questionsBank)
        {
            foreach (var currQuestion in questionsBank.Questions)
            {
                foreach (var currQuestionCorrectAnswers in currentQuestion.CorrectAnswers)
                {
                    foreach (var currQuestionCurrentnswers in currentQuestion.CurrentAnswers)
                    {
                        if (currQuestionCorrectAnswers == currQuestionCurrentnswers)
                        {
                            totalScore++;
                            break;
                        }
                    }
                    break;
                }
                break;
            }
        }

        /// <summary>
        /// Submits the test after finishing it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitTestButton_Click(object sender, EventArgs e)
        {
            IncreaseTotalScore(QuestionsBank);
            FinishTest();
        }

        /// <summary>
        /// Goes to the previous question.
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
        /// Goes to the next question.
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
        /// Marking a definite answer's check box as correct.
        /// </summary>
        /// <param name="answer"> definite answer's check box </param>
        private void MarkAnswer(CheckBox answer)
        {
            if (answer.Checked)
            {
                currentAnswersCount++;
                return;
            }

            currentAnswersCount--;
        }

        /// <summary>
        /// Marking the first answer as correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstAnswer_CheckedChanged(object sender, EventArgs e)
        {
            MarkAnswer(firstAnswerCheckBox);
        }

        /// <summary>
        /// Marking the second answer as correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondAnswer_CheckedChanged(object sender, EventArgs e)
        {
            MarkAnswer(secondAnswerCheckBox);
        }

        /// <summary>
        /// Marking the third answer as correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thirdAnswer_CheckedChanged(object sender, EventArgs e)
        {
            MarkAnswer(thirdAnswerCheckBox);
        }

        /// <summary>
        /// Marking the fourth answer as correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fourthAnswer_CheckedChanged(object sender, EventArgs e)
        {
            MarkAnswer(fourthAnswerCheckBox);
        }

        /// <summary>
        /// Enables and disables next question button in different scenarious.
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
        /// Saves the given answers for a definite question.
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
        /// TestForm class's generous purpose constructor.
        /// </summary>
        /// <param name="questionsCount"> count of the questions </param>
        /// <param name="seconds"> seconds for solving the test </param>
        /// <param name="studentName">student's name </param>
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
        /// Get/Set QuestionBank property.
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
        /// Get/Set current question property.
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
        /// Get/Set previuos question  property.
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
        /// Get/Set next question property.
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