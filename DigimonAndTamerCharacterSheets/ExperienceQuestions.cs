using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigimonAndTamerCharacterSheets
{
    public partial class ExperienceQuestions : Form
    {

        public ExperienceQuestions()
        {
            InitializeComponent();

        }


        private Form1 MainSheet = null;
        public ExperienceQuestions(Form callingForm)
        {
            MainSheet = callingForm as Form1;
            InitializeComponent();
        }


        int Expoint = 0;
        public void AddExperience_Click(object sender, EventArgs e)
        {


            if (FirstQuestion.Checked)
            {
                Expoint = Expoint + 1;
            }
            if (SecondQuestion.Checked)
            {
                Expoint = Expoint + 1;
            }
            if (ThirdQuestion.Checked)
            {
                Expoint = Expoint + 1;
            }
            if (FourthQuestion.Checked)
            {
                Expoint = Expoint + 1;
            }
            if (FifthQuestion.Checked)
            {
                Expoint = Expoint + 1;
            }
            if (SixthQuestion.Checked)
            {
                Expoint = Expoint + 1;
            }

            this.MainSheet.ExperienceModify = Expoint.ToString();
            MessageBox.Show($"Good morning sunshine, its a brand new day!");
            this.Hide();
        }

        private void ExperienceQuestions_Load(object sender, EventArgs e)
        {

        }

    }

}
