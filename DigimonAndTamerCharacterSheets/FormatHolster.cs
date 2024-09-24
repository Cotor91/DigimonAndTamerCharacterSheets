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
    public partial class FormatHolster : Form
    {
        public FormatHolster()
        {
            InitializeComponent();
        }

        private void BasicAttack_Enter(object sender, EventArgs e)
        {

        }

        private void ActBasicAttack_Click(object sender, EventArgs e)
        {

        }

        private void FormatHolster_Load(object sender, EventArgs e)
        {

        }

        private void BasicConcept_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void BasicEffect_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool MultiCrit = BasicCritSuccess.Text.Contains("x");
            bool MultiFail = BasicCritFail.Text.Contains("x");
            int.TryParse(BasicCritSuccess.Text.Replace("x", ""), out int CritRequire);
            int.TryParse(BasicCritFail.Text.Replace("x", ""), out int FailRequire);



            /*
              // Get the number of dice from the Attack Box
            int.TryParse(DigiAttackRoll.Text, out int NumberOfDice);

            Random random = new Random();
            int TotalResult = 0;
            string IndividualRolls = "";
            int TargetDefense = 0;
            int.TryParse(TargetArmour.Text, out TargetDefense);
            string StrikeInflicted = "";

            for (int i = 0; i < NumberOfDice; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }

            if (TotalResult < TargetDefense - 15)
            {
                StrikeInflicted = "Hard Fail - " + BasicAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail - " + BasicAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail - " + BasicAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit - " + BasicAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit - " + BasicAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit - " + BasicAttackHardHit.Text;
            }

            // Display the result
            MessageBox.Show($"\n{BasicAttack.Text}\nAttack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetDefense}\nResults: {StrikeInflicted}");
        }
            */


            // Get the individual dice
            Random random = new Random();
            string IndividualRolls = null;
            string TotalResult = null;
            int DiceRolling = 0;
            int DiceScore = 0;



            for (int i = 0; i < DiceRolling; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }

            // Get the target score
            string TargetDefense = null;
            int TargetDice = 0;
            
            string StrikeInflicted = null;

            MessageBox.Show($"Attack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetDefense}\nResults: {StrikeInflicted}");

            if (DiceScore < TargetDice - 1)
            {
                if (DiceScore - TargetDice < CritRequire)
                {
                    if (MultiCrit)
                    {
                        string MultiPoint = ((DiceScore - TargetDice) / CritRequire).ToString();
                        BasicBonus.Text.Replace("x", MultiPoint);
                        MessageBox.Show($"{BasicEffect}\n{BasicBonus}");
                    }
                    else
                    {
                        MessageBox.Show($"{BasicEffect}\n{BasicBonus}");
                    }

                }
                else
                {
                    MessageBox.Show($"{BasicEffect}");
                }
            }
            else
            {
                if (TargetDice - DiceScore < FailRequire)
                {
                    if (MultiCrit)
                    {
                        string MultiPoint = ((TargetDice - DiceScore) / FailRequire).ToString();
                        BasicPenalty.Text.Replace("x", MultiPoint);
                        MessageBox.Show($"{BasicPenalty}");
                    }
                    else
                    {
                        MessageBox.Show($"Nothing happened.");
                    }

                }
                else
                {
                    MessageBox.Show($"{BasicEffect}");
                }
            }
        }

        private void BasicCritFail_Click(object sender, EventArgs e)
        {

        }

        private void BasicPenalty_Click(object sender, EventArgs e)
        {

        }
    }
}
