using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceTestsGenerator
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private void startTestButton_Click(object sender, EventArgs e)
        {
            int questionsCount = Int32.Parse(questionsCountTextBox.Text);
            string studentName = studentNameTextBox.Text;
            int seconds = Int32.Parse(timeTextBox.Text);

            Form1 testForm = new Form1(questionsCount, seconds, studentName);
            testForm.Show();
            this.Hide();
        }

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
