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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // studentNameTextBox
            // 
            studentNameTextBox.Location = new Point(370, 128);
            studentNameTextBox.Name = "studentNameTextBox";
            studentNameTextBox.Size = new Size(211, 27);
            studentNameTextBox.TabIndex = 0;
            studentNameTextBox.TextChanged += studentNameTextBox_TextChanged;
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(370, 184);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(211, 27);
            timeTextBox.TabIndex = 1;
            timeTextBox.TextChanged += timeTextBox_TextChanged;
            // 
            // startTestButton
            // 
            startTestButton.Location = new Point(217, 303);
            startTestButton.Name = "startTestButton";
            startTestButton.Size = new Size(364, 52);
            startTestButton.TabIndex = 2;
            startTestButton.Text = "Start Test";
            startTestButton.UseVisualStyleBackColor = true;
            startTestButton.Click += startTestButton_Click;
            // 
            // questionsCountTextBox
            // 
            questionsCountTextBox.Location = new Point(370, 242);
            questionsCountTextBox.Name = "questionsCountTextBox";
            questionsCountTextBox.Size = new Size(211, 27);
            questionsCountTextBox.TabIndex = 3;
            questionsCountTextBox.TextChanged += questionsCountTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 135);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 5;
            label1.Text = "Student Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(217, 191);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 6;
            label2.Text = "Time (in sec.)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 249);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 7;
            label3.Text = "Questions Count";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(217, 65);
            label5.Name = "label5";
            label5.Size = new Size(164, 20);
            label5.TabIndex = 9;
            label5.Text = "Define Test Dimensions";
            // 
            // TestDimensionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
    }
}