namespace MultipleChoiceTestsGenerator
{
    partial class Form1
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
            testTopicLabel = new Label();
            questionNoLabel = new Label();
            questionTextLabel = new Label();
            firstAnswerRadioBtn = new RadioButton();
            secondAnswerRadioBtn = new RadioButton();
            thirdAnswerRadioBtn = new RadioButton();
            fourthAnswerRadioBtn = new RadioButton();
            greetingUserLabel = new Label();
            submitTestButton = new Button();
            answersGroupBox = new GroupBox();
            nextQuestionButton = new Button();
            prevQuestionButton = new Button();
            timelabel = new Label();
            answersGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // testTopicLabel
            // 
            testTopicLabel.AutoSize = true;
            testTopicLabel.Location = new Point(12, 24);
            testTopicLabel.Name = "testTopicLabel";
            testTopicLabel.Size = new Size(75, 20);
            testTopicLabel.TabIndex = 0;
            testTopicLabel.Text = "Test Topic";
            // 
            // questionNoLabel
            // 
            questionNoLabel.AutoSize = true;
            questionNoLabel.Location = new Point(12, 80);
            questionNoLabel.Name = "questionNoLabel";
            questionNoLabel.Size = new Size(96, 20);
            questionNoLabel.TabIndex = 1;
            questionNoLabel.Text = "Question No ";
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Location = new Point(121, 80);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(99, 20);
            questionTextLabel.TabIndex = 2;
            questionTextLabel.Text = "Question Text";
            // 
            // firstAnswerRadioBtn
            // 
            firstAnswerRadioBtn.AutoSize = true;
            firstAnswerRadioBtn.Location = new Point(6, 36);
            firstAnswerRadioBtn.Name = "firstAnswerRadioBtn";
            firstAnswerRadioBtn.Size = new Size(88, 24);
            firstAnswerRadioBtn.TabIndex = 7;
            firstAnswerRadioBtn.TabStop = true;
            firstAnswerRadioBtn.Text = "answer 1";
            firstAnswerRadioBtn.UseVisualStyleBackColor = true;
            firstAnswerRadioBtn.CheckedChanged += firstAnswerRadioBtn_CheckedChanged;
            // 
            // secondAnswerRadioBtn
            // 
            secondAnswerRadioBtn.AutoSize = true;
            secondAnswerRadioBtn.Location = new Point(6, 83);
            secondAnswerRadioBtn.Name = "secondAnswerRadioBtn";
            secondAnswerRadioBtn.Size = new Size(88, 24);
            secondAnswerRadioBtn.TabIndex = 8;
            secondAnswerRadioBtn.TabStop = true;
            secondAnswerRadioBtn.Text = "answer 2";
            secondAnswerRadioBtn.UseVisualStyleBackColor = true;
            secondAnswerRadioBtn.CheckedChanged += secondAnswerRadioBtn_CheckedChanged;
            // 
            // thirdAnswerRadioBtn
            // 
            thirdAnswerRadioBtn.AutoSize = true;
            thirdAnswerRadioBtn.Location = new Point(6, 123);
            thirdAnswerRadioBtn.Name = "thirdAnswerRadioBtn";
            thirdAnswerRadioBtn.Size = new Size(88, 24);
            thirdAnswerRadioBtn.TabIndex = 9;
            thirdAnswerRadioBtn.TabStop = true;
            thirdAnswerRadioBtn.Text = "answer 3";
            thirdAnswerRadioBtn.UseVisualStyleBackColor = true;
            thirdAnswerRadioBtn.CheckedChanged += thirdAnswerRadioBtn_CheckedChanged;
            // 
            // fourthAnswerRadioBtn
            // 
            fourthAnswerRadioBtn.AutoSize = true;
            fourthAnswerRadioBtn.Location = new Point(6, 169);
            fourthAnswerRadioBtn.Name = "fourthAnswerRadioBtn";
            fourthAnswerRadioBtn.Size = new Size(88, 24);
            fourthAnswerRadioBtn.TabIndex = 10;
            fourthAnswerRadioBtn.TabStop = true;
            fourthAnswerRadioBtn.Text = "answer 4";
            fourthAnswerRadioBtn.UseVisualStyleBackColor = true;
            fourthAnswerRadioBtn.CheckedChanged += fourthAnswerRadioBtn_CheckedChanged;
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
            answersGroupBox.Controls.Add(firstAnswerRadioBtn);
            answersGroupBox.Controls.Add(secondAnswerRadioBtn);
            answersGroupBox.Controls.Add(thirdAnswerRadioBtn);
            answersGroupBox.Controls.Add(fourthAnswerRadioBtn);
            answersGroupBox.Location = new Point(121, 112);
            answersGroupBox.Name = "answersGroupBox";
            answersGroupBox.Size = new Size(185, 206);
            answersGroupBox.TabIndex = 15;
            answersGroupBox.TabStop = false;
            answersGroupBox.Text = "Answers";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(timelabel);
            Controls.Add(prevQuestionButton);
            Controls.Add(nextQuestionButton);
            Controls.Add(answersGroupBox);
            Controls.Add(submitTestButton);
            Controls.Add(greetingUserLabel);
            Controls.Add(questionTextLabel);
            Controls.Add(questionNoLabel);
            Controls.Add(testTopicLabel);
            Name = "Form1";
            Text = "Form1";
            answersGroupBox.ResumeLayout(false);
            answersGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label testTopicLabel;
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
    }
}