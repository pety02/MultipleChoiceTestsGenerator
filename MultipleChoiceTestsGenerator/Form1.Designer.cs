namespace MultipleChoiceTestsGenerator
{
    partial class TestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            questionNoLabel = new Label();
            questionTextLabel = new Label();
            firstAnswerRadioBtn = new RadioButton();
            secondAnswerRadioBtn = new RadioButton();
            thirdAnswerRadioBtn = new RadioButton();
            fourthAnswerRadioBtn = new RadioButton();
            greetingUserLabel = new Label();
            submitTestButton = new Button();
            answersGroupBox = new GroupBox();
            fourthAnswerCheckBox = new CheckBox();
            thirdAnswerCheckBox = new CheckBox();
            secondAnswerCheckBox = new CheckBox();
            firstAnswerCheckBox = new CheckBox();
            nextQuestionButton = new Button();
            prevQuestionButton = new Button();
            timelabel = new Label();
            saveAnswerBtn = new Button();
            answersGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // questionNoLabel
            // 
            questionNoLabel.AutoSize = true;
            questionNoLabel.Location = new Point(12, 24);
            questionNoLabel.Name = "questionNoLabel";
            questionNoLabel.Size = new Size(96, 20);
            questionNoLabel.TabIndex = 1;
            questionNoLabel.Text = "Question No ";
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Location = new Point(146, 24);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(99, 20);
            questionTextLabel.TabIndex = 2;
            questionTextLabel.Text = "Question Text";
            // 
            // firstAnswerRadioBtn
            // 
            firstAnswerRadioBtn.Location = new Point(0, 0);
            firstAnswerRadioBtn.Name = "firstAnswerRadioBtn";
            firstAnswerRadioBtn.Size = new Size(104, 24);
            firstAnswerRadioBtn.TabIndex = 0;
            // 
            // secondAnswerRadioBtn
            // 
            secondAnswerRadioBtn.Location = new Point(0, 0);
            secondAnswerRadioBtn.Name = "secondAnswerRadioBtn";
            secondAnswerRadioBtn.Size = new Size(104, 24);
            secondAnswerRadioBtn.TabIndex = 0;
            // 
            // thirdAnswerRadioBtn
            // 
            thirdAnswerRadioBtn.Location = new Point(0, 0);
            thirdAnswerRadioBtn.Name = "thirdAnswerRadioBtn";
            thirdAnswerRadioBtn.Size = new Size(104, 24);
            thirdAnswerRadioBtn.TabIndex = 0;
            // 
            // fourthAnswerRadioBtn
            // 
            fourthAnswerRadioBtn.Location = new Point(0, 0);
            fourthAnswerRadioBtn.Name = "fourthAnswerRadioBtn";
            fourthAnswerRadioBtn.Size = new Size(104, 24);
            fourthAnswerRadioBtn.TabIndex = 0;
            // 
            // greetingUserLabel
            // 
            greetingUserLabel.AutoSize = true;
            greetingUserLabel.Location = new Point(657, 24);
            greetingUserLabel.Name = "greetingUserLabel";
            greetingUserLabel.Size = new Size(116, 20);
            greetingUserLabel.TabIndex = 13;
            greetingUserLabel.Text = "Hello, username";
            // 
            // submitTestButton
            // 
            submitTestButton.Location = new Point(351, 409);
            submitTestButton.Name = "submitTestButton";
            submitTestButton.Size = new Size(94, 29);
            submitTestButton.TabIndex = 14;
            submitTestButton.Text = "Submit";
            submitTestButton.UseVisualStyleBackColor = true;
            submitTestButton.Click += submitTestButton_Click;
            // 
            // answersGroupBox
            // 
            answersGroupBox.Controls.Add(fourthAnswerCheckBox);
            answersGroupBox.Controls.Add(thirdAnswerCheckBox);
            answersGroupBox.Controls.Add(secondAnswerCheckBox);
            answersGroupBox.Controls.Add(firstAnswerCheckBox);
            answersGroupBox.Location = new Point(146, 115);
            answersGroupBox.Name = "answersGroupBox";
            answersGroupBox.Size = new Size(185, 206);
            answersGroupBox.TabIndex = 15;
            answersGroupBox.TabStop = false;
            answersGroupBox.Text = "Answers";
            // 
            // fourthAnswerCheckBox
            // 
            fourthAnswerCheckBox.AutoSize = true;
            fourthAnswerCheckBox.Location = new Point(6, 154);
            fourthAnswerCheckBox.Name = "fourthAnswerCheckBox";
            fourthAnswerCheckBox.Size = new Size(101, 24);
            fourthAnswerCheckBox.TabIndex = 14;
            fourthAnswerCheckBox.Text = "checkBox4";
            fourthAnswerCheckBox.UseVisualStyleBackColor = true;
            fourthAnswerCheckBox.CheckedChanged += fourthAnswer_CheckedChanged;
            // 
            // thirdAnswerCheckBox
            // 
            thirdAnswerCheckBox.AutoSize = true;
            thirdAnswerCheckBox.Location = new Point(6, 115);
            thirdAnswerCheckBox.Name = "thirdAnswerCheckBox";
            thirdAnswerCheckBox.Size = new Size(101, 24);
            thirdAnswerCheckBox.TabIndex = 13;
            thirdAnswerCheckBox.Text = "checkBox3";
            thirdAnswerCheckBox.UseVisualStyleBackColor = true;
            thirdAnswerCheckBox.CheckedChanged += thirdAnswer_CheckedChanged;
            // 
            // secondAnswerCheckBox
            // 
            secondAnswerCheckBox.AutoSize = true;
            secondAnswerCheckBox.Location = new Point(6, 76);
            secondAnswerCheckBox.Name = "secondAnswerCheckBox";
            secondAnswerCheckBox.Size = new Size(101, 24);
            secondAnswerCheckBox.TabIndex = 12;
            secondAnswerCheckBox.Text = "checkBox2";
            secondAnswerCheckBox.UseVisualStyleBackColor = true;
            secondAnswerCheckBox.CheckedChanged += secondAnswer_CheckedChanged;
            // 
            // firstAnswerCheckBox
            // 
            firstAnswerCheckBox.AutoSize = true;
            firstAnswerCheckBox.Location = new Point(6, 37);
            firstAnswerCheckBox.Name = "firstAnswerCheckBox";
            firstAnswerCheckBox.Size = new Size(101, 24);
            firstAnswerCheckBox.TabIndex = 11;
            firstAnswerCheckBox.Text = "checkBox1";
            firstAnswerCheckBox.UseVisualStyleBackColor = true;
            firstAnswerCheckBox.CheckedChanged += firstAnswer_CheckedChanged;
            // 
            // nextQuestionButton
            // 
            nextQuestionButton.Location = new Point(657, 409);
            nextQuestionButton.Name = "nextQuestionButton";
            nextQuestionButton.Size = new Size(131, 29);
            nextQuestionButton.TabIndex = 16;
            nextQuestionButton.Text = "Next Question";
            nextQuestionButton.UseVisualStyleBackColor = true;
            nextQuestionButton.Click += nextQuestionButton_Click;
            // 
            // prevQuestionButton
            // 
            prevQuestionButton.Location = new Point(12, 409);
            prevQuestionButton.Name = "prevQuestionButton";
            prevQuestionButton.Size = new Size(138, 29);
            prevQuestionButton.TabIndex = 17;
            prevQuestionButton.Text = "Previous Question";
            prevQuestionButton.UseVisualStyleBackColor = true;
            prevQuestionButton.Click += prevQuestionButton_Click;
            // 
            // timelabel
            // 
            timelabel.AutoSize = true;
            timelabel.Location = new Point(723, 54);
            timelabel.Name = "timelabel";
            timelabel.Size = new Size(50, 20);
            timelabel.TabIndex = 18;
            timelabel.Text = "label1";
            // 
            // saveAnswerBtn
            // 
            saveAnswerBtn.Location = new Point(351, 183);
            saveAnswerBtn.Name = "saveAnswerBtn";
            saveAnswerBtn.Size = new Size(111, 29);
            saveAnswerBtn.TabIndex = 20;
            saveAnswerBtn.Text = "Save Answer";
            saveAnswerBtn.UseVisualStyleBackColor = true;
            saveAnswerBtn.Click += saveAnswerBtn_Click;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveAnswerBtn);
            Controls.Add(timelabel);
            Controls.Add(prevQuestionButton);
            Controls.Add(nextQuestionButton);
            Controls.Add(answersGroupBox);
            Controls.Add(submitTestButton);
            Controls.Add(greetingUserLabel);
            Controls.Add(questionTextLabel);
            Controls.Add(questionNoLabel);
            Name = "TestForm";
            Text = "Test";
            Load += TestForm_Load;
            answersGroupBox.ResumeLayout(false);
            answersGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label questionNoLabel;
        private Label questionTextLabel;
        private RadioButton firstAnswerRadioBtn;
        private RadioButton secondAnswerRadioBtn;
        private RadioButton thirdAnswerRadioBtn;
        private RadioButton fourthAnswerRadioBtn;
        private Label greetingUserLabel;
        private Button submitTestButton;
        private GroupBox answersGroupBox;
        private Button nextQuestionButton;
        private Button prevQuestionButton;
        private Label timelabel;
        private CheckBox fourthAnswerCheckBox;
        private CheckBox thirdAnswerCheckBox;
        private CheckBox secondAnswerCheckBox;
        private CheckBox firstAnswerCheckBox;
        private Button saveAnswerBtn;
    }
}