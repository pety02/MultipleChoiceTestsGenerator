namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TestDimensionsForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public TestDimensionsForm()
        {
            InitializeComponent();
            if (!InputValidator.IsValidNumberInput(questionsCountTextBox.Text)
                || !InputValidator.IsValidNumberInput(timeTextBox.Text)
                || studentNameTextBox.Text == "")
            {
                startTestButton.Enabled = false;
                return;
            }

            startTestButton.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startTestButton_Click(object sender, EventArgs e)
        {
            int questionsCount = Int32.Parse(questionsCountTextBox.Text);
            string studentName = studentNameTextBox.Text;
            int seconds = Int32.Parse(timeTextBox.Text);

            this.Hide();
            TestForm testForm = new TestForm(questionsCount, seconds, studentName);
            testForm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!InputValidator.IsValidNumberInput(questionsCountTextBox.Text)
                || !InputValidator.IsValidNumberInput(timeTextBox.Text)
                || studentNameTextBox.Text == "")
            {
                startTestButton.Enabled = false;
                return;
            }

            startTestButton.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!InputValidator.IsValidNumberInput(questionsCountTextBox.Text)
                || !InputValidator.IsValidNumberInput(timeTextBox.Text)
                || studentNameTextBox.Text == "")
            {
                startTestButton.Enabled = false;
                return;
            }

            startTestButton.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void questionsCountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!InputValidator.IsValidNumberInput(questionsCountTextBox.Text)
                || !InputValidator.IsValidNumberInput(timeTextBox.Text)
                || studentNameTextBox.Text == "")
            {
                startTestButton.Enabled = false;
                return;
            }

            startTestButton.Enabled = true;
        }
    }
}