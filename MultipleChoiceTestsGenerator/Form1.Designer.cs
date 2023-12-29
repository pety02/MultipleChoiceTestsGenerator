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
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            nextQuestionButton = new Button();
            prevQuestionButton = new Button();
            timelabel = new Label();
            saveAnswerBtn = new Button();
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
            answersGroupBox.Controls.Add(checkBox4);
            answersGroupBox.Controls.Add(checkBox3);
            answersGroupBox.Controls.Add(checkBox2);
            answersGroupBox.Controls.Add(checkBox1);
            answersGroupBox.Location = new Point(121, 112);
            answersGroupBox.Name = "answersGroupBox";
            answersGroupBox.Size = new Size(185, 206);
            answersGroupBox.TabIndex = 15;
            answersGroupBox.TabStop = false;
            answersGroupBox.Text = "Answers";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(6, 154);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(101, 24);
            checkBox4.TabIndex = 14;
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(6, 115);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(101, 24);
            checkBox3.TabIndex = 13;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(6, 76);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(101, 24);
            checkBox2.TabIndex = 12;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 37);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(101, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
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
            saveAnswerBtn.Location = new Point(322, 183);
            saveAnswerBtn.Name = "saveAnswerBtn";
            saveAnswerBtn.Size = new Size(111, 29);
            saveAnswerBtn.TabIndex = 20;
            saveAnswerBtn.Text = "Save Answer";
            saveAnswerBtn.UseVisualStyleBackColor = true;
            saveAnswerBtn.Click += saveAnswerBtn_Click;
            // 
            // Form1
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
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button saveAnswerBtn;
    }
}