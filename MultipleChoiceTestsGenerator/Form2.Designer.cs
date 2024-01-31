namespace MultipleChoiceTestsGenerator
{
    partial class TestDimensionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            studentNameTextBox = new TextBox();
            timeTextBox = new TextBox();
            startTestButton = new Button();
            questionsCountTextBox = new TextBox();
            label5 = new Label();
            addCustomQuestionButton = new Button();
            customQuestionTextField = new TextBox();
            firstAnswerTextField = new TextBox();
            secondAnswerTextField = new TextBox();
            thirdAnswerTextField = new TextBox();
            fourthAnswerTextField = new TextBox();
            isFirstAnswerCorrectCheckBox = new CheckBox();
            isSecondAnswerCorrectCheckBox = new CheckBox();
            isThirdAnswerCorrectCheckBox = new CheckBox();
            isFourthAnswerCorrectCheckBox = new CheckBox();
            customQuestionsCountField = new TextBox();
            createCustomQuestionsArrayButton = new Button();
            SuspendLayout();
            // 
            // studentNameTextBox
            // 
            studentNameTextBox.Location = new Point(48, 128);
            studentNameTextBox.Name = "studentNameTextBox";
            studentNameTextBox.PlaceholderText = "Student Name";
            studentNameTextBox.Size = new Size(364, 27);
            studentNameTextBox.TabIndex = 0;
            studentNameTextBox.TextChanged += studentNameTextBox_TextChanged;
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(48, 171);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.PlaceholderText = "Time (in seconds)";
            timeTextBox.Size = new Size(364, 27);
            timeTextBox.TabIndex = 1;
            timeTextBox.TextChanged += timeTextBox_TextChanged;
            // 
            // startTestButton
            // 
            startTestButton.Location = new Point(48, 327);
            startTestButton.Name = "startTestButton";
            startTestButton.Size = new Size(364, 52);
            startTestButton.TabIndex = 2;
            startTestButton.Text = "Start Test";
            startTestButton.UseVisualStyleBackColor = true;
            startTestButton.Click += startTestButton_Click;
            // 
            // questionsCountTextBox
            // 
            questionsCountTextBox.Location = new Point(48, 214);
            questionsCountTextBox.Name = "questionsCountTextBox";
            questionsCountTextBox.PlaceholderText = "Questions Count";
            questionsCountTextBox.Size = new Size(364, 27);
            questionsCountTextBox.TabIndex = 3;
            questionsCountTextBox.TextChanged += questionsCountTextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 27);
            label5.Name = "label5";
            label5.Size = new Size(164, 20);
            label5.TabIndex = 9;
            label5.Text = "Define Test Dimensions";
            // 
            // addCustomQuestionButton
            // 
            addCustomQuestionButton.Location = new Point(526, 327);
            addCustomQuestionButton.Name = "addCustomQuestionButton";
            addCustomQuestionButton.Size = new Size(274, 52);
            addCustomQuestionButton.TabIndex = 10;
            addCustomQuestionButton.Text = "Add Custom Questions";
            addCustomQuestionButton.UseVisualStyleBackColor = true;
            addCustomQuestionButton.Click += addCustomQuestionButton_Click;
            // 
            // customQuestionTextField
            // 
            customQuestionTextField.Location = new Point(526, 89);
            customQuestionTextField.Name = "customQuestionTextField";
            customQuestionTextField.PlaceholderText = "Question Text";
            customQuestionTextField.Size = new Size(241, 27);
            customQuestionTextField.TabIndex = 11;
            customQuestionTextField.TextChanged += customQuestionTextField_TextChanged;
            // 
            // firstAnswerTextField
            // 
            firstAnswerTextField.Location = new Point(526, 159);
            firstAnswerTextField.Name = "firstAnswerTextField";
            firstAnswerTextField.PlaceholderText = "First Answer Text";
            firstAnswerTextField.Size = new Size(241, 27);
            firstAnswerTextField.TabIndex = 12;
            firstAnswerTextField.TextChanged += firstAnswerTextField_TextChanged;
            // 
            // secondAnswerTextField
            // 
            secondAnswerTextField.Location = new Point(526, 192);
            secondAnswerTextField.Name = "secondAnswerTextField";
            secondAnswerTextField.PlaceholderText = "Second Answer Text";
            secondAnswerTextField.Size = new Size(241, 27);
            secondAnswerTextField.TabIndex = 13;
            secondAnswerTextField.TextChanged += secondAnswerTextField_TextChanged;
            // 
            // thirdAnswerTextField
            // 
            thirdAnswerTextField.Location = new Point(526, 225);
            thirdAnswerTextField.Name = "thirdAnswerTextField";
            thirdAnswerTextField.PlaceholderText = "Third Answer Text";
            thirdAnswerTextField.Size = new Size(241, 27);
            thirdAnswerTextField.TabIndex = 14;
            thirdAnswerTextField.TextChanged += thirdAnswerTextField_TextChanged;
            // 
            // fourthAnswerTextField
            // 
            fourthAnswerTextField.Location = new Point(526, 258);
            fourthAnswerTextField.Name = "fourthAnswerTextField";
            fourthAnswerTextField.PlaceholderText = "Fourth Answer Text";
            fourthAnswerTextField.Size = new Size(241, 27);
            fourthAnswerTextField.TabIndex = 15;
            fourthAnswerTextField.TextChanged += fourthAnswerTextField_TextChanged;
            // 
            // isFirstAnswerCorrectCheckBox
            // 
            isFirstAnswerCorrectCheckBox.AutoSize = true;
            isFirstAnswerCorrectCheckBox.Location = new Point(782, 161);
            isFirstAnswerCorrectCheckBox.Name = "isFirstAnswerCorrectCheckBox";
            isFirstAnswerCorrectCheckBox.Size = new Size(18, 17);
            isFirstAnswerCorrectCheckBox.TabIndex = 16;
            isFirstAnswerCorrectCheckBox.UseVisualStyleBackColor = true;
            isFirstAnswerCorrectCheckBox.CheckedChanged += isFirstAnswerCorrectCheckBox_CheckedChanged;
            // 
            // isSecondAnswerCorrectCheckBox
            // 
            isSecondAnswerCorrectCheckBox.AutoSize = true;
            isSecondAnswerCorrectCheckBox.Location = new Point(782, 192);
            isSecondAnswerCorrectCheckBox.Name = "isSecondAnswerCorrectCheckBox";
            isSecondAnswerCorrectCheckBox.Size = new Size(18, 17);
            isSecondAnswerCorrectCheckBox.TabIndex = 17;
            isSecondAnswerCorrectCheckBox.UseVisualStyleBackColor = true;
            isSecondAnswerCorrectCheckBox.CheckedChanged += isSecondAnswerCorrectCheckBox_CheckedChanged;
            // 
            // isThirdAnswerCorrectCheckBox
            // 
            isThirdAnswerCorrectCheckBox.AutoSize = true;
            isThirdAnswerCorrectCheckBox.Location = new Point(782, 225);
            isThirdAnswerCorrectCheckBox.Name = "isThirdAnswerCorrectCheckBox";
            isThirdAnswerCorrectCheckBox.Size = new Size(18, 17);
            isThirdAnswerCorrectCheckBox.TabIndex = 18;
            isThirdAnswerCorrectCheckBox.UseVisualStyleBackColor = true;
            isThirdAnswerCorrectCheckBox.CheckedChanged += isThirdAnswerCorrectCheckBox_CheckedChanged;
            // 
            // isFourthAnswerCorrectCheckBox
            // 
            isFourthAnswerCorrectCheckBox.AutoSize = true;
            isFourthAnswerCorrectCheckBox.Location = new Point(782, 258);
            isFourthAnswerCorrectCheckBox.Name = "isFourthAnswerCorrectCheckBox";
            isFourthAnswerCorrectCheckBox.Size = new Size(18, 17);
            isFourthAnswerCorrectCheckBox.TabIndex = 19;
            isFourthAnswerCorrectCheckBox.UseVisualStyleBackColor = true;
            isFourthAnswerCorrectCheckBox.CheckedChanged += isFourthAnswerCorrectCheckBox_CheckedChanged;
            // 
            // customQuestionsCountField
            // 
            customQuestionsCountField.Location = new Point(526, 48);
            customQuestionsCountField.Name = "customQuestionsCountField";
            customQuestionsCountField.PlaceholderText = "Custom Questions Count";
            customQuestionsCountField.Size = new Size(241, 27);
            customQuestionsCountField.TabIndex = 20;
            customQuestionsCountField.TextChanged += customQuestionsCountField_TextChanged;
            // 
            // createCustomQuestionsArrayButton
            // 
            createCustomQuestionsArrayButton.Location = new Point(782, 46);
            createCustomQuestionsArrayButton.Name = "createCustomQuestionsArrayButton";
            createCustomQuestionsArrayButton.Size = new Size(230, 29);
            createCustomQuestionsArrayButton.TabIndex = 21;
            createCustomQuestionsArrayButton.Text = "Create Custom Questions Array";
            createCustomQuestionsArrayButton.UseVisualStyleBackColor = true;
            createCustomQuestionsArrayButton.Click += createCustomQuestionsArrayButton_Click;
            // 
            // TestDimensionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 450);
            Controls.Add(createCustomQuestionsArrayButton);
            Controls.Add(customQuestionsCountField);
            Controls.Add(isFourthAnswerCorrectCheckBox);
            Controls.Add(isThirdAnswerCorrectCheckBox);
            Controls.Add(isSecondAnswerCorrectCheckBox);
            Controls.Add(isFirstAnswerCorrectCheckBox);
            Controls.Add(fourthAnswerTextField);
            Controls.Add(thirdAnswerTextField);
            Controls.Add(secondAnswerTextField);
            Controls.Add(firstAnswerTextField);
            Controls.Add(customQuestionTextField);
            Controls.Add(addCustomQuestionButton);
            Controls.Add(label5);
            Controls.Add(questionsCountTextBox);
            Controls.Add(startTestButton);
            Controls.Add(timeTextBox);
            Controls.Add(studentNameTextBox);
            Name = "TestDimensionsForm";
            Text = "Test Dimensions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox studentNameTextBox;
        private TextBox timeTextBox;
        private Button startTestButton;
        private TextBox questionsCountTextBox;
        private Label label5;
        private Button addCustomQuestionButton;
        private TextBox customQuestionTextField;
        private TextBox firstAnswerTextField;
        private TextBox secondAnswerTextField;
        private TextBox thirdAnswerTextField;
        private TextBox fourthAnswerTextField;
        private CheckBox isFirstAnswerCorrectCheckBox;
        private CheckBox isSecondAnswerCorrectCheckBox;
        private CheckBox isThirdAnswerCorrectCheckBox;
        private CheckBox isFourthAnswerCorrectCheckBox;
        private TextBox customQuestionsCountField;
        private Button createCustomQuestionsArrayButton;
    }
}