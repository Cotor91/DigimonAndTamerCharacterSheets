namespace DigimonAndTamerCharacterSheets
{
    partial class ExperienceQuestions
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
            AddExperience = new Button();
            SixthQuestion = new CheckBox();
            FifthQuestion = new CheckBox();
            FourthQuestion = new CheckBox();
            ThirdQuestion = new CheckBox();
            SecondQuestion = new CheckBox();
            FirstQuestion = new CheckBox();
            SuspendLayout();
            // 
            // AddExperience
            // 
            AddExperience.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddExperience.Location = new Point(305, 381);
            AddExperience.Name = "AddExperience";
            AddExperience.Size = new Size(181, 40);
            AddExperience.TabIndex = 13;
            AddExperience.Text = "Add Experience";
            AddExperience.UseVisualStyleBackColor = true;
            AddExperience.Click += AddExperience_Click;
            // 
            // SixthQuestion
            // 
            SixthQuestion.AutoSize = true;
            SixthQuestion.Font = new Font("Microsoft Sans Serif", 10F);
            SixthQuestion.Location = new Point(99, 314);
            SixthQuestion.Name = "SixthQuestion";
            SixthQuestion.Size = new Size(324, 24);
            SixthQuestion.TabIndex = 12;
            SixthQuestion.Text = "Have you had a brand new experience?";
            SixthQuestion.UseVisualStyleBackColor = true;
            // 
            // FifthQuestion
            // 
            FifthQuestion.AutoSize = true;
            FifthQuestion.Font = new Font("Microsoft Sans Serif", 10F);
            FifthQuestion.Location = new Point(99, 262);
            FifthQuestion.Name = "FifthQuestion";
            FifthQuestion.Size = new Size(299, 24);
            FifthQuestion.TabIndex = 11;
            FifthQuestion.Text = "Have you avoided a tricky situation?";
            FifthQuestion.UseVisualStyleBackColor = true;
            // 
            // FourthQuestion
            // 
            FourthQuestion.AutoSize = true;
            FourthQuestion.Font = new Font("Microsoft Sans Serif", 10F);
            FourthQuestion.Location = new Point(99, 206);
            FourthQuestion.Name = "FourthQuestion";
            FourthQuestion.Size = new Size(335, 24);
            FourthQuestion.TabIndex = 10;
            FourthQuestion.Text = "Have you gotten out of a tricky situation?";
            FourthQuestion.UseVisualStyleBackColor = true;
            // 
            // ThirdQuestion
            // 
            ThirdQuestion.AutoSize = true;
            ThirdQuestion.Font = new Font("Microsoft Sans Serif", 10F);
            ThirdQuestion.Location = new Point(99, 154);
            ThirdQuestion.Name = "ThirdQuestion";
            ThirdQuestion.Size = new Size(557, 24);
            ThirdQuestion.TabIndex = 9;
            ThirdQuestion.Text = "Have you bonded with your Digimon by respecting their Value system?";
            ThirdQuestion.UseVisualStyleBackColor = true;
            // 
            // SecondQuestion
            // 
            SecondQuestion.AutoSize = true;
            SecondQuestion.Font = new Font("Microsoft Sans Serif", 10F);
            SecondQuestion.Location = new Point(99, 98);
            SecondQuestion.Name = "SecondQuestion";
            SecondQuestion.Size = new Size(404, 24);
            SecondQuestion.TabIndex = 8;
            SecondQuestion.Text = "Have you made a big mistake you can learn from?";
            SecondQuestion.UseVisualStyleBackColor = true;
            // 
            // FirstQuestion
            // 
            FirstQuestion.AutoSize = true;
            FirstQuestion.Font = new Font("Microsoft Sans Serif", 10F);
            FirstQuestion.Location = new Point(99, 49);
            FirstQuestion.Name = "FirstQuestion";
            FirstQuestion.Size = new Size(471, 24);
            FirstQuestion.TabIndex = 7;
            FirstQuestion.Text = "Have you had to re-examine how the world seems to work?";
            FirstQuestion.UseVisualStyleBackColor = true;
            // 
            // ExperienceQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddExperience);
            Controls.Add(SixthQuestion);
            Controls.Add(FifthQuestion);
            Controls.Add(FourthQuestion);
            Controls.Add(ThirdQuestion);
            Controls.Add(SecondQuestion);
            Controls.Add(FirstQuestion);
            Name = "ExperienceQuestions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Experience Questions";
            Load += ExperienceQuestions_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddExperience;
        private CheckBox SixthQuestion;
        private CheckBox FifthQuestion;
        private CheckBox FourthQuestion;
        private CheckBox ThirdQuestion;
        private CheckBox SecondQuestion;
        private CheckBox FirstQuestion;
    }
}