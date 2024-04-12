using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DigimonAndTamerCharacterSheets.Enums;

namespace DigimonAndTamerCharacterSheets
{
    public partial class Form1 : Form
    {
        private string xmlFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CharacterInformation.xml");

        public Form1()
        {
            InitializeComponent();
            LoadCharacterInformation(); // Load data when the form initializes
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCharacterInformation(); // Save data when the form is closing
        }

        private void LoadCharacterInformation()
        {
            try
            {
                if (System.IO.File.Exists(xmlFilePath))
                {
                    // Load the XML document if the file exists
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    // Read character data from XML
                    string playerName = xmlDoc.SelectSingleNode("/CharacterInformation/PlayerName")?.InnerText;
                    string characterName = xmlDoc.SelectSingleNode("/CharacterInformation/CharacterName")?.InnerText;
                    string characterGender = xmlDoc.SelectSingleNode("/CharacterInformation/CharacterGender")?.InnerText;

                    // Populate textboxes
                    PlayerName.Text = playerName;
                    CharacterName.Text = characterName;
                    CharacterGender.Text = characterGender;
                }
                else
                {
                    // Handle missing file scenario (e.g., display a message)
                    MessageBox.Show("Character information file not found. Creating a new one.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading character information: {ex.Message}");
            }
        }

        private void SaveCharacterInformation()
        {
            try
            {
                // Create or load the XML document
                XmlDocument xmlDoc = new XmlDocument();
                if (System.IO.File.Exists(xmlFilePath))
                    xmlDoc.Load(xmlFilePath);
                else
                    xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));

                // Update character data
                XmlElement playerNameElement = (XmlElement)xmlDoc.SelectSingleNode("/CharacterInformation/PlayerName");
                if (playerNameElement != null)
                {
                    playerNameElement.InnerText = PlayerName.Text;
                }
                XmlElement characterNameElement = (XmlElement)xmlDoc.SelectSingleNode("/CharacterInformation/CharacterName");
                if (characterNameElement != null)
                {
                    characterNameElement.InnerText = CharacterName.Text;
                }
                XmlElement characterGenderElement = (XmlElement)xmlDoc.SelectSingleNode("/CharacterInformation/CharacterGender");
                if (characterGenderElement != null)
                {
                    characterGenderElement.InnerText = CharacterGender.Text;
                }

                // Save the XML back to the file
                xmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving character information: {ex.Message}");
            }
        }

        public void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar4_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar5_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar6_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar12_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar11_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar10_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar15_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar14_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar13_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar9_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar8_Scroll(object sender, EventArgs e)
        {

        }

        public void trackBar7_Scroll(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GaurdPoints = 0;
            StratPoints.Text = "";
            int lifespanOver;
            if (int.TryParse(RemainingLife.Text, out lifespanOver) && lifespanOver < 1)
            {
                // Lose current form
                Partner.SelectedIndex = -1;
                Partner.Enabled = true;
                RecordRookie = "________";
                RecordChampion = "________";
                RecordUltimate = "________";
                RecordMega = "________";
                Day.Text = "0";

                // Remove Evolution Options
                ChampionSelect.Enabled = false;
                ChampionSelect.Checked = false;
                ChampionLevel.Text = "________";
                UltimateSelect.Enabled = false;
                UltimateSelect.Checked = false;
                UltimateLevel.Text = "________";
                MegaSelect.Enabled = false;
                MegaSelect.Checked = false;
                MegaLevel.Text = "________";

                // Restart Lifespan
                RemainingLife.Text = MaximumLife.Text;
                Digivolve.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void TamerSkills_Click(object sender, EventArgs e)
        {

        }

        private void Bruise_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TamerStats_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BruiseFive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InjuryTwo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InjuryThree_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InjuryFour_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InjuryFive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WoundTwo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WoundThree_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WoundFour_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WoundOne_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

            // Read input from TextBox
            string HealthNow = CurrentHealth.Text;
            string HealthMod = ModifyHealth.Text;
            string HealthMax = MaxHealth.Text;

            // Try to convert to integers
            int HealthNowValue;
            int HealthModValue;
            int HealthMaxValue;
            int.TryParse(HealthMax, out HealthMaxValue);

            if (int.TryParse(HealthNow, out HealthNowValue) && int.TryParse(HealthMod, out HealthModValue) && HealthModValue > -1)
            {
                // Calculation
                HealthNowValue = HealthNowValue + HealthModValue;

                // Convert the calculated integer back to a string
                string updatedHealthString = HealthNowValue.ToString();

                // Update the text property
                CurrentHealth.Text = updatedHealthString;
            }
            else
            {
                // Handle the conversion failure (e.g., display an error message)
                MessageBox.Show("Please enter valid numbers for health  modification.");
            }

            if (HealthMaxValue < HealthNowValue)
            {
                CurrentHealth.Text = MaxHealth.Text;
            }


        }

        private void button21_Click(object sender, EventArgs e)
        {

            // Read input from TextBox
            string HealthNow = CurrentHealth.Text;
            string HealthMod = ModifyHealth.Text;

            // Try to convert to integers
            int HealthNowValue;
            int HealthModValue;

            if (int.TryParse(HealthNow, out HealthNowValue) && int.TryParse(HealthMod, out HealthModValue) && HealthModValue > -1)
            {
                if (HealthNowValue == 0)
                {
                    Wound.PerformClick();
                }

                // Calculation
                HealthNowValue = HealthNowValue - HealthModValue;

                // Convert the calculated integer back to a string
                string updatedHealthString = HealthNowValue.ToString();

                // Update the text property
                CurrentHealth.Text = updatedHealthString;
            }
            else
            {
                // Handle the conversion failure (e.g., display an error message)
                MessageBox.Show("Please enter valid numbers for health  modification.");
            }

            if (HealthNowValue < 0)
            {
                CurrentHealth.Text = "0";
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }




        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void WoundTwo_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void WoundFive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WoundFour_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void InjuryOne_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            // If InjuryFive is checked
            if (InjuryFive.Checked)
            {
                // Click Injury
                Wound.PerformClick();
            }
            // If InjuryFour is checked
            else if (InjuryFour.Checked)
            {
                InjuryFive.Checked = true;
                BruiseFive.Checked = true;
            }
            // If InjuryThree is checked
            else if (InjuryThree.Checked)
            {
                InjuryFour.Checked = true;
                BruiseFour.Checked = true;
            }
            // If InjuryTwo is checked
            else if (InjuryTwo.Checked)
            {
                InjuryThree.Checked = true;
                BruiseThree.Checked = true;
            }
            // If InjuryOne is checked
            else if (InjuryOne.Checked)
            {
                InjuryTwo.Checked = true;
                BruiseTwo.Checked = true;
            }
            else
            {
                InjuryOne.Checked = true;
                BruiseOne.Checked = true;
            }

        }

        private void Bruise_Click(object sender, EventArgs e)
        {
            // If BruiseFive is checked
            if (BruiseFive.Checked)
            {
                // Click Injury
                Injury.PerformClick();
            }
            // If BruiseFour is checked
            if (BruiseFour.Checked)
            {
                BruiseFive.Checked = true;
            }
            // If BruiseThree is checked
            if (BruiseThree.Checked)
            {
                BruiseFour.Checked = true;
            }
            // If BruiseTwo is checked
            if (BruiseTwo.Checked)
            {
                BruiseThree.Checked = true;
            }
            // If BruiseOne is checked
            if (BruiseOne.Checked)
            {
                BruiseTwo.Checked = true;
            }
            else
            {
                BruiseOne.Checked = true;
            }

        }


        // Strength Dice
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Maximum Stats
        int HighestCarry = 0;
        int HighestHold = 0;
        int HighestThrow = 0;
        int HighestBalance = 0;
        int HighestParkour = 0;
        int HighestReflex = 0;
        int HighestPerform = 0;
        int HighestIntimidate = 0;
        int HighestPersuade = 0;
        int HighestInvestigation = 0;
        int HighestEmpathy = 0;
        int HighestIngenuity = 0;
        int HighestTechnology = 0;
        int HighestOccultism = 0;
        int HighestSociety = 0;


        // Carry Trackbar
        public void trackBar12_Scroll_1(object sender, EventArgs e)
        {

            // Compare prior maximum to current value
            if (HighestCarry < CarryTrack.Value)
            {
                HighestCarry++;
                CarryTrack.Value = HighestCarry;

                // Spent Skill Points
                TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                DialogResult BoostCarry = MessageBox.Show("Do you want to increase your Carry skill?", "Skill Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show("Carry skill increased!");
                    foreach (TrackBar track in tracks)
                    {
                        CarryTrack.Value = HighestCarry;
                        HoldTrack.Value = HighestHold;
                        ThrowTrack.Value = HighestThrow;
                        BalanceTrack.Value = HighestBalance;
                        ParkourTrack.Value = HighestParkour;
                        ReflexTrack.Value = HighestReflex;
                        PerformTrack.Value = HighestPerform;
                        IntimidateTrack.Value = HighestIntimidate;
                        PersuadeTrack.Value = HighestPersuade;
                        InvestigationTrack.Value = HighestInvestigation;
                        EmpathyTrack.Value = HighestEmpathy;
                        IngenuityTrack.Value = HighestIngenuity;
                        TechnologyTrack.Value = HighestTechnology;
                        OccultismTrack.Value = HighestOccultism;
                        SocietyTrack.Value = HighestSociety;
                        track.Enabled = false;
                    }
                }
                else
                {
                    CarryTrack.Value--;
                    HighestCarry--;
                }
            }



            // Calculate the total of the Strength Skills
            int totalValue = (int)CarryTrack.Value + (int)ThrowTrack.Value + (int)HoldTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            StrengthStat.Text = halvedValue.ToString();
        }

        // Carry Calculations
        private void button5_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = StrengthStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int StrengthScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = StrengthScore;

                // Apply the modifiers
                if (CarryPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (CarryPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (CarryMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (CarryMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";


                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                // Final result
                TotalResult += CarryTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nCarry Skill: {CarryTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Strength Stat.", "Error");
            }
        }

        // Throw Trackbar
        public void trackBar11_Scroll_1(object sender, EventArgs e)
        {

            // Compare prior maximum to current value
            if (HighestThrow < ThrowTrack.Value)
            {
                HighestThrow++;
                ThrowTrack.Value = HighestThrow;

                // Spent Skill Points
                TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                DialogResult BoostThrow = MessageBox.Show("Do you want to increase your Throw skill?", "Skill Increase", MessageBoxButtons.YesNo);
                if (BoostThrow == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show("Throw skill increased!");
                    foreach (TrackBar track in tracks)
                    {
                        CarryTrack.Value = HighestCarry;
                        HoldTrack.Value = HighestHold;
                        ThrowTrack.Value = HighestThrow;
                        BalanceTrack.Value = HighestBalance;
                        ParkourTrack.Value = HighestParkour;
                        ReflexTrack.Value = HighestReflex;
                        PerformTrack.Value = HighestPerform;
                        IntimidateTrack.Value = HighestIntimidate;
                        PersuadeTrack.Value = HighestPersuade;
                        InvestigationTrack.Value = HighestInvestigation;
                        EmpathyTrack.Value = HighestEmpathy;
                        IngenuityTrack.Value = HighestIngenuity;
                        TechnologyTrack.Value = HighestTechnology;
                        OccultismTrack.Value = HighestOccultism;
                        SocietyTrack.Value = HighestSociety;
                        track.Enabled = false;
                    }
                }
                else
                {
                    ThrowTrack.Value--;
                    HighestThrow--;
                }
            }



            // Calculate the total of the Strength Skills
            int totalValue = (int)CarryTrack.Value + (int)ThrowTrack.Value + (int)HoldTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            StrengthStat.Text = halvedValue.ToString();
        }

        // Throw Calculations
        private void button6_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = StrengthStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int StrengthScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = StrengthScore;

                // Apply the modifiers
                if (ThrowPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (ThrowPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (ThrowMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (ThrowMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += ThrowTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nThrow Skill: {ThrowTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }
            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Strength Stat.", "Error");
            }
        }

        // Hold Trackbar
        public void trackBar10_Scroll_1(object sender, EventArgs e)
        {

            // Compare prior maximum to current value
            if (HighestHold < HoldTrack.Value)
            {
                HighestHold++;
                HoldTrack.Value = HighestHold;

                // Spent Skill Points
                TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                DialogResult BoostHold = MessageBox.Show("Do you want to increase your Hold skill?", "Skill Increase", MessageBoxButtons.YesNo);
                if (BoostHold == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show("Hold skill increased!");
                    foreach (TrackBar track in tracks)
                    {
                        CarryTrack.Value = HighestCarry;
                        HoldTrack.Value = HighestHold;
                        ThrowTrack.Value = HighestThrow;
                        BalanceTrack.Value = HighestBalance;
                        ParkourTrack.Value = HighestParkour;
                        ReflexTrack.Value = HighestReflex;
                        PerformTrack.Value = HighestPerform;
                        IntimidateTrack.Value = HighestIntimidate;
                        PersuadeTrack.Value = HighestPersuade;
                        InvestigationTrack.Value = HighestInvestigation;
                        EmpathyTrack.Value = HighestEmpathy;
                        IngenuityTrack.Value = HighestIngenuity;
                        TechnologyTrack.Value = HighestTechnology;
                        OccultismTrack.Value = HighestOccultism;
                        SocietyTrack.Value = HighestSociety;
                        track.Enabled = false;
                    }
                }
                else
                {
                    HoldTrack.Value--;
                    HighestHold--;
                }
            }



            // Calculate the total of the Strength Skills
            int totalValue = (int)CarryTrack.Value + (int)ThrowTrack.Value + (int)HoldTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            StrengthStat.Text = halvedValue.ToString();
        }

        // Hold Calculations
        private void button7_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = StrengthStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int StrengthScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = StrengthScore;

                // Apply the modifiers
                if (HoldPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (HoldPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (HoldMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (HoldMinusTwo.Checked)
                {
                    NumberOfDice--;
                }

                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += HoldTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nHold Skill: {HoldTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }
            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Strength Stat.", "Error");
            }

        }

        // Agility Dice
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Balance Trackbar
        public void trackBar6_Scroll_1(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestBalance < BalanceTrack.Value)
                {
                    HighestBalance++;
                    BalanceTrack.Value = HighestBalance;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostBalance = MessageBox.Show("Do you want to increase your Balance skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostBalance == DialogResult.Yes)
                    {
                        // Perform actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Balance skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        BalanceTrack.Value--;
                        HighestBalance--;
                    }
                }



                // Calculate the total of the Agility Skills
                int totalValue = (int)BalanceTrack.Value + (int)ParkourTrack.Value + (int)ReflexTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                AgilityStat.Text = halvedValue.ToString();
            }
        }

        // Balance Calculations
        private void button10_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = AgilityStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int AgilityScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = AgilityScore;

                // Apply the modifiers
                if (BalancePlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (BalancePlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (BalanceMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (BalanceMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += BalanceTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nBalance Skill: {BalanceTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Agility Stat.", "Error");
            }
        }

        // Parkour Trackbar
        public void trackBar5_Scroll_1(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestParkour < ParkourTrack.Value)
                {
                    HighestParkour++;
                    ParkourTrack.Value = HighestParkour;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostParkour = MessageBox.Show("Do you want to increase your Parkour skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostParkour == DialogResult.Yes)
                    {
                        // Perform actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Parkour skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        ParkourTrack.Value--;
                        HighestParkour--;
                    }
                }



                // Calculate the total of the Agility Skills
                int totalValue = (int)BalanceTrack.Value + (int)ParkourTrack.Value + (int)ReflexTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                AgilityStat.Text = halvedValue.ToString();
            }
        }

        // Parkour Calculations
        private void button9_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = AgilityStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int AgilityScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = AgilityScore;

                // Apply the modifiers
                if (ParkourPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (ParkourPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (ParkourMinusTwo.Checked)
                {
                    NumberOfDice--;
                }
                if (ParkourMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += ParkourTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nParkour Skill: {ParkourTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }
            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Agility Stat.", "Error");
            }
        }

        // Reflex Trackbar
        public void trackBar4_Scroll_1(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestReflex < ReflexTrack.Value)
                {
                    HighestReflex++;
                    ReflexTrack.Value = HighestReflex;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostReflex = MessageBox.Show("Do you want to increase your Reflex skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostReflex == DialogResult.Yes)
                    {
                        // Perform actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Reflex skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        ReflexTrack.Value--;
                        HighestReflex--;
                    }
                }



                // Calculate the total of the Agility Skills
                int totalValue = (int)BalanceTrack.Value + (int)ParkourTrack.Value + (int)ReflexTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                AgilityStat.Text = halvedValue.ToString();
            }
        }

        // Reflex Calculations
        private void button8_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = AgilityStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int AgilityScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = AgilityScore;

                // Apply the modifiers
                if (ReflexPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (ReflexPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (ReflexMinusTwo.Checked)
                {
                    NumberOfDice--;
                }
                if (ReflexMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += ReflexTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nReflex Skill: {ReflexTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }
            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Agility Stat.", "Error");
            }
        }


        // Vibes Dice
        private void VibesStat_TextChanged(object sender, EventArgs e)
        {

        }

        // Perform Trackbar
        public void trackBar9_Scroll_1(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestPerform < PerformTrack.Value)
                {
                    HighestPerform++;
                    PerformTrack.Value = HighestPerform;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostPerform = MessageBox.Show("Do you want to increase your Perform skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostPerform == DialogResult.Yes)
                    {
                        // Perform actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Perform skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        PerformTrack.Value--;
                        HighestPerform--;
                    }
                }



                // Calculate the total of the Vibes Skills
                int totalValue = (int)PerformTrack.Value + (int)IntimidateTrack.Value + (int)PersuadeTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                VibesStat.Text = halvedValue.ToString();

            }
        }

        // Perform Calculations
        private void button13_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = VibesStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int VibesScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = VibesScore;

                // Apply the modifiers
                if (PerformPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (PerformPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (PerformMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (PerformMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += PerformTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nPerform Skill: {PerformTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Vibes Stat.", "Error");
            }
        }


        // Intimidate Trackbar
        public void trackBar8_Scroll_1(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestIntimidate < IntimidateTrack.Value)
                {
                    HighestIntimidate++;
                    IntimidateTrack.Value = HighestIntimidate;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostIntimidate = MessageBox.Show("Do you want to increase your Intimidate skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostIntimidate == DialogResult.Yes)
                    {
                        // Intimidate actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Intimidate skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        IntimidateTrack.Value--;
                        HighestIntimidate--;
                    }
                }



                // Calculate the total of the Vibes Skills
                int totalValue = (int)PerformTrack.Value + (int)IntimidateTrack.Value + (int)PersuadeTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                VibesStat.Text = halvedValue.ToString();
            }
        }

        // Intimidate Calculations
        private void button12_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = VibesStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int VibesScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = VibesScore;

                // Apply the modifiers
                if (IntimidatePlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (IntimidatePlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (IntimidateMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (IntimidateMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += IntimidateTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nIntimidate Skill: {IntimidateTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Vibes Stat.", "Error");
            }
        }

        // Persuade Trackbar
        public void trackBar7_Scroll_1(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestPersuade < PersuadeTrack.Value)
                {
                    HighestPersuade++;
                    PersuadeTrack.Value = HighestPersuade;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostPersuade = MessageBox.Show("Do you want to increase your Persuade skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostPersuade == DialogResult.Yes)
                    {
                        // Persuade actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Persuade skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        PersuadeTrack.Value--;
                        HighestPersuade--;
                    }
                }



                // Calculate the total of the Vibes Skills
                int totalValue = (int)PerformTrack.Value + (int)IntimidateTrack.Value + (int)PersuadeTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                VibesStat.Text = halvedValue.ToString();
            }
        }

        // Persuade Calculations
        private void button11_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = VibesStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int VibesScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = VibesScore;

                // Apply the modifiers
                if (PersuadePlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (PersuadePlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (PersuadeMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (PersuadeMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += PersuadeTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nPersuade Skill: {PersuadeTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Vibes Stat.", "Error");
            }
        }

        // Wits Dice
        private void WitsStat_TextChanged(object sender, EventArgs e)
        {

        }

        // Investigation Tracker
        public void InvestigatonTrack_Scroll(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestInvestigation < InvestigationTrack.Value)
                {
                    HighestInvestigation++;
                    InvestigationTrack.Value = HighestInvestigation;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostInvestigation = MessageBox.Show("Do you want to increase your Investigation skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostInvestigation == DialogResult.Yes)
                    {
                        // Investigation actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Investigation skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        InvestigationTrack.Value--;
                        HighestInvestigation--;
                    }
                }



                // Calculate the total of the Wits Skills
                int totalValue = (int)InvestigationTrack.Value + (int)EmpathyTrack.Value + (int)IngenuityTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                WitsStat.Text = halvedValue.ToString();

            }

        }

        // Investigation Calculations
        private void button16_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = WitsStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int WitsScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = WitsScore;

                // Apply the modifiers
                if (InvestigationPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (InvestigationPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (InvestigationMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (InvestigationMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += InvestigationTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nInvestigation Skill: {InvestigationTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Wits Stat.", "Error");
            }
        }

        // Empathy Tracker
        public void EmpathyTrack_Scroll(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestEmpathy < EmpathyTrack.Value)
                {
                    HighestEmpathy++;
                    EmpathyTrack.Value = HighestEmpathy;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostEmpathy = MessageBox.Show("Do you want to increase your Empathy skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostEmpathy == DialogResult.Yes)
                    {
                        // Empathy actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Empathy skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        EmpathyTrack.Value--;
                        HighestEmpathy--;
                    }
                }



                // Calculate the total of the Wits Skills
                int totalValue = (int)InvestigationTrack.Value + (int)EmpathyTrack.Value + (int)IngenuityTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                WitsStat.Text = halvedValue.ToString();

            }

        }

        // Empathy Calculations
        private void button15_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = WitsStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int WitsScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = WitsScore;

                // Apply the modifiers
                if (EmpathyPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (EmpathyPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (EmpathyMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (EmpathyMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += EmpathyTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nEmpathy Skill: {EmpathyTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Wits Stat.", "Error");
            }
        }

        // Ingenuity Tracker
        public void IngenuityTrack_Scroll(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestIngenuity < IngenuityTrack.Value)
                {
                    HighestIngenuity++;
                    IngenuityTrack.Value = HighestIngenuity;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostIngenuity = MessageBox.Show("Do you want to increase your Ingenuity skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostIngenuity == DialogResult.Yes)
                    {
                        // Ingenuity actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Ingenuity skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        IngenuityTrack.Value--;
                        HighestIngenuity--;
                    }
                }



                // Calculate the total of the Wits Skills
                int totalValue = (int)InvestigationTrack.Value + (int)EmpathyTrack.Value + (int)IngenuityTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                WitsStat.Text = halvedValue.ToString();

            }

        }

        // Ingenuity Calculations
        private void button14_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = WitsStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int WitsScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = WitsScore;

                // Apply the modifiers
                if (IngenuityPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (IngenuityPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (IngenuityMinusTwo.Checked)
                {
                    NumberOfDice--;
                }
                if (IngenuityMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += IngenuityTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nWits Skill: {IngenuityTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Wits Stat.", "Error");
            }
        }

        // Knowledge Dice
        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Technology Tracker
        public void TechnologyTrack_Scroll(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestTechnology < TechnologyTrack.Value)
                {
                    HighestTechnology++;
                    TechnologyTrack.Value = HighestTechnology;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostTechnology = MessageBox.Show("Do you want to increase your Technology skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostTechnology == DialogResult.Yes)
                    {
                        // Technology actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Technology skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        TechnologyTrack.Value--;
                        HighestTechnology--;
                    }
                }



                // Calculate the total of the Strength Skills
                int totalValue = (int)TechnologyTrack.Value + (int)OccultismTrack.Value + (int)SocietyTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                KnowledgeStat.Text = halvedValue.ToString();

            }
        }

        // Technology Calculatons
        private void button19_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = KnowledgeStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int KnowledgeScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = KnowledgeScore;

                // Apply the modifiers
                if (TechnologyPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (TechnologyPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (TechnologyMinusTwo.Checked)
                {
                    NumberOfDice--;
                }
                if (TechnologyMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += TechnologyTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nTechnology Skill: {TechnologyTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Education Stat.", "Error");
            }
        }

        // Occultism Tracker
        public void OccultismTrack_Scroll(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestOccultism < OccultismTrack.Value)
                {
                    HighestOccultism++;
                    OccultismTrack.Value = HighestOccultism;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostOccultism = MessageBox.Show("Do you want to increase your Occultism skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostOccultism == DialogResult.Yes)
                    {
                        // Occultism actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Occultism skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        OccultismTrack.Value--;
                        HighestOccultism--;
                    }
                }



                // Calculate the total of the Strength Skills
                int totalValue = (int)TechnologyTrack.Value + (int)OccultismTrack.Value + (int)SocietyTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                KnowledgeStat.Text = halvedValue.ToString();

            }
        }

        // Occultism Calculatons
        private void button18_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = KnowledgeStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int KnowledgeScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = KnowledgeScore;

                // Apply the modifiers
                if (OccultismPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (OccultismPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (OccultismMinusTwo.Checked)
                {
                    NumberOfDice--;
                }
                if (OccultismMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += OccultismTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nOccultism Skill: {OccultismTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Education Stat.", "Error");
            }
        }

        // Society Tracker
        public void SocietyTrack_Scroll(object sender, EventArgs e)
        {
            {

                // Compare prior maximum to current value
                if (HighestSociety < SocietyTrack.Value)
                {
                    HighestSociety++;
                    SocietyTrack.Value = HighestSociety;

                    // Spent Skill Points
                    TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

                    DialogResult BoostSociety = MessageBox.Show("Do you want to increase your Society skill?", "Skill Increase", MessageBoxButtons.YesNo);
                    if (BoostSociety == DialogResult.Yes)
                    {
                        // Society actions if user clicked Yes (e.g., display message, update skill points)
                        MessageBox.Show("Society skill increased!");
                        foreach (TrackBar track in tracks)
                        {
                            CarryTrack.Value = HighestCarry;
                            HoldTrack.Value = HighestHold;
                            ThrowTrack.Value = HighestThrow;
                            BalanceTrack.Value = HighestBalance;
                            ParkourTrack.Value = HighestParkour;
                            ReflexTrack.Value = HighestReflex;
                            PerformTrack.Value = HighestPerform;
                            IntimidateTrack.Value = HighestIntimidate;
                            PersuadeTrack.Value = HighestPersuade;
                            InvestigationTrack.Value = HighestInvestigation;
                            EmpathyTrack.Value = HighestEmpathy;
                            IngenuityTrack.Value = HighestIngenuity;
                            TechnologyTrack.Value = HighestTechnology;
                            OccultismTrack.Value = HighestOccultism;
                            SocietyTrack.Value = HighestSociety;
                            track.Enabled = false;
                        }
                    }
                    else
                    {
                        SocietyTrack.Value--;
                        HighestSociety--;
                    }
                }



                // Calculate the total of the Strength Skills
                int totalValue = (int)TechnologyTrack.Value + (int)OccultismTrack.Value + (int)SocietyTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                KnowledgeStat.Text = halvedValue.ToString();

            }
        }

        // Society Calculations
        private void button17_Click_1(object sender, EventArgs e)
        {
            // Read input from TextBox
            string userInput = KnowledgeStat.Text;

            // Try to convert to an integer
            if (int.TryParse(userInput, out int KnowledgeScore))
            {
                // Get the number of dice from the TrackBar
                int NumberOfDice = KnowledgeScore;

                // Apply the modifiers
                if (SocietyPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (SocietyPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (SocietyMinusTwo.Checked)
                {
                    NumberOfDice--;
                }
                if (SocietyMinusTwo.Checked)
                {
                    NumberOfDice--;
                }


                // Simulate rolling dice
                Random random = new Random();
                int TotalResult = 0;
                string IndividualRolls = "";
                string CoreRoll = "";

                for (int i = 0; i < NumberOfDice; i++)
                {
                    // Generates a random number between 1 and 10
                    int DiceResult = random.Next(1, 11);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Generates a random number between 1 and 20
                int D20Result = random.Next(1, 21);
                TotalResult += D20Result;
                // Collect individual rolls
                CoreRoll += D20Result + " ";

                TotalResult += SocietyTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nSociety Skill: {SocietyTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
            }

            else
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for Education Stat.", "Error");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void trackBar16_Scroll(object sender, EventArgs e)
        {
            // Calculate the total of the Strength Skills
            int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            DigiSoulStat.Text = halvedValue.ToString();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {

        }

        public void trackBar19_Scroll(object sender, EventArgs e)
        {
            // Calculate the total of the Strength Skills
            int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            DigiSoulStat.Text = halvedValue.ToString();
        }

        private void GigaSearch_Click(object sender, EventArgs e)
        {

        }

        private void InfoExtract_Click(object sender, EventArgs e)
        {

        }

        private void ErrorScan_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click_2(object sender, EventArgs e)
        {

        }

        private void TamerPowers_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click_3(object sender, EventArgs e)
        {
            int digiSoulScore;
            if (int.TryParse(DigiSoulStat.Text, out digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulScore -= 1; // Subtract 1 from the score
                DigiSoulStat.Text = digiSoulScore.ToString();
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            int digiSoulScore;
            if (int.TryParse(DigiSoulStat.Text, out digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulScore -= 1; // Subtract 1 from the score
                DigiSoulStat.Text = digiSoulScore.ToString();
            }
        }

        String LastMeal = "";

        private void button4_Click(object sender, EventArgs e)
        {
            int FoodBonding;
            int.TryParse(DigiBond.Text, out FoodBonding);
            if (FoodBonding < 4)
            {
                FoodBonding = FoodBonding + 2;
            } else
            {
                FoodBonding = 5;
            }
            DigiBond.Text = FoodBonding.ToString();
            StratPoints.Text = "";

            // Undo last boost
            if (LastMeal == "Strength")
            {
                int DigimonFeed;
                int.TryParse(DigimonStrength.Text, out DigimonFeed);
                DigimonFeed--;
                DigimonStrength.Text = DigimonFeed.ToString();
            }
            else if (LastMeal == "Agility")
            {
                int DigimonFeed;
                int.TryParse(DigimonAgility.Text, out DigimonFeed);
                DigimonFeed--;
                DigimonAgility.Text = DigimonFeed.ToString();
            }
            else if (LastMeal == "Vibes")
            {
                int DigimonFeed;
                int.TryParse(DigimonVibes.Text, out DigimonFeed);
                DigimonFeed--;
                DigimonVibes.Text = DigimonFeed.ToString();
            }
            else if (LastMeal == "Wits")
            {
                int DigimonFeed;
                int.TryParse(DigimonWits.Text, out DigimonFeed);
                DigimonFeed--;
                DigimonWits.Text = DigimonFeed.ToString();
            }
            else if (LastMeal == "Education")
            {
                int DigimonFeed;
                int.TryParse(DigimonEducation.Text, out DigimonFeed);
                DigimonFeed--;
                DigimonEducation.Text = DigimonFeed.ToString();
            }
            else
            {

            };


            // Count
            if (StrengthMeal.Checked == true)
            {
                int DigimonFed;
                int.TryParse(DigimonStrength.Text, out DigimonFed);
                DigimonFed++;
                DigimonStrength.Text = DigimonFed.ToString();

                LastMeal = "Strength";
                int DigimonAbsorbed;
                int.TryParse(StrengthDiet.Text, out DigimonAbsorbed);
                DigimonAbsorbed++;
                StrengthDiet.Text = DigimonAbsorbed.ToString();
            }
            else if (AgilityMeal.Checked == true)
            {
                int DigimonFed;
                int.TryParse(DigimonAgility.Text, out DigimonFed);
                DigimonFed++;
                DigimonAgility.Text = DigimonFed.ToString();

                LastMeal = "Agility";
                int DigimonAbsorbed;
                int.TryParse(AgilityDiet.Text, out DigimonAbsorbed);
                DigimonAbsorbed++;
                AgilityDiet.Text = DigimonAbsorbed.ToString();
            }
            else if (VibesMeal.Checked == true)
            {
                int DigimonFed;
                int.TryParse(DigimonVibes.Text, out DigimonFed);
                DigimonFed++;
                DigimonVibes.Text = DigimonFed.ToString();

                LastMeal = "Vibes";
                int DigimonAbsorbed;
                int.TryParse(VibesDiet.Text, out DigimonAbsorbed);
                DigimonAbsorbed++;
                VibesDiet.Text = DigimonAbsorbed.ToString();
            }
            else if (WitsMeal.Checked == true)
            {
                int DigimonFed;
                int.TryParse(DigimonWits.Text, out DigimonFed);
                DigimonFed++;
                DigimonWits.Text = DigimonFed.ToString();

                LastMeal = "Wits";
                int DigimonAbsorbed;
                int.TryParse(WitsDiet.Text, out DigimonAbsorbed);
                DigimonAbsorbed++;
                WitsDiet.Text = DigimonAbsorbed.ToString();
            }
            else if (EducationMeal.Checked == true)
            {
                int DigimonFed;
                int.TryParse(DigimonEducation.Text, out DigimonFed);
                DigimonFed++;
                DigimonEducation.Text = DigimonFed.ToString();

                LastMeal = "Education";
                int DigimonAbsorbed;
                int.TryParse(EducationDiet.Text, out DigimonAbsorbed);
                DigimonAbsorbed++;
                EducationDiet.Text = DigimonAbsorbed.ToString();
            }
            else
            {

            };


        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            PlayerName.AccessibleDefaultActionDescription = PlayerName.Text;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void DigimonMoves_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void DigimonStats_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click_1(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void label86_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label110_Click(object sender, EventArgs e)
        {

        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void label96_Click(object sender, EventArgs e)
        {

        }

        private void label97_Click(object sender, EventArgs e)
        {

        }

        private void label98_Click(object sender, EventArgs e)
        {

        }

        private void label99_Click(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void label106_Click(object sender, EventArgs e)
        {

        }

        private void label100_Click(object sender, EventArgs e)
        {

        }

        private void label102_Click(object sender, EventArgs e)
        {

        }

        private void label98_Click_1(object sender, EventArgs e)
        {

        }

        private void label106_Click_1(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void DigimonLifecycle_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label112_Click(object sender, EventArgs e)
        {

        }

        private void label116_Click(object sender, EventArgs e)
        {

        }

        private void label115_Click(object sender, EventArgs e)
        {

        }

        private void label127_Click(object sender, EventArgs e)
        {

        }

        private void label126_Click(object sender, EventArgs e)
        {

        }

        private void label124_Click(object sender, EventArgs e)
        {

        }

        private void label125_Click(object sender, EventArgs e)
        {

        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter_1(object sender, EventArgs e)
        {

        }

        private void label133_Click(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton16_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged_3(object sender, EventArgs e)
        {
            Digivolve.Enabled = true;
        }

        private void radioButton12_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label134_Click(object sender, EventArgs e)
        {

        }

        private void label135_Click(object sender, EventArgs e)
        {

        }

        private void label137_Click(object sender, EventArgs e)
        {

        }

        private void label136_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BruiseOne_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label170_Click(object sender, EventArgs e)
        {

        }

        private void Wound_Click(object sender, EventArgs e)
        {
            // If WoundFive is checked
            if (WoundFive.Checked)
            {
                // Click Wound
                MessageBox.Show($"You thought you were hot...\nGuess what? You're not!\nYou are dead...\ndead... dead...");
            }
            // If WoundFour is checked
            else if (WoundFour.Checked)
            {
                WoundFive.Checked = true;
                InjuryFive.Checked = true;
                BruiseFive.Checked = true;
            }
            // If WoundThree is checked
            else if (WoundThree.Checked)
            {
                WoundFour.Checked = true;
                InjuryFour.Checked = true;
                BruiseFour.Checked = true;
            }
            // If WoundTwo is checked
            else if (WoundTwo.Checked)
            {
                WoundThree.Checked = true;
                InjuryThree.Checked = true;
                BruiseThree.Checked = true;
            }
            // If InjuryOne is checked
            else if (WoundOne.Checked)
            {
                WoundTwo.Checked = true;
                InjuryTwo.Checked = true;
                BruiseTwo.Checked = true;
            }
            else
            {
                WoundOne.Checked = true;
                InjuryOne.Checked = true;
                BruiseOne.Checked = true;
            }

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void BruiseTwo_CheckedChanged(object sender, EventArgs e)
        {
            BruiseOne.Checked = true;
        }

        private void BruiseThree_CheckedChanged(object sender, EventArgs e)
        {
            BruiseTwo.Checked = true;
        }

        private void BruiseFour_CheckedChanged(object sender, EventArgs e)
        {
            BruiseThree.Checked = true;
        }

        private void BruiseFive_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFour.Checked = true;
        }


        private void InjuryOne_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseOne.Checked = true;
        }

        private void InjuryTwo_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseTwo.Checked = true;
            InjuryOne.Checked = true;
        }

        private void InjuryThree_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseThree.Checked = true;
            InjuryTwo.Checked = true;
        }

        private void InjuryFour_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFour.Checked = true;
            InjuryThree.Checked = true;
        }

        private void InjuryFive_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFive.Checked = true;
            InjuryFour.Checked = true;
        }

        private void WoundOne_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseOne.Checked = true;
            InjuryOne.Checked = true;
        }

        private void WoundTwo_CheckedChanged_2(object sender, EventArgs e)
        {
            BruiseTwo.Checked = true;
            InjuryTwo.Checked = true;
            WoundOne.Checked = true;
        }

        private void WoundThree_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseThree.Checked = true;
            InjuryThree.Checked = true;
            WoundTwo.Checked = true;
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            BruiseFour.Checked = true;
            InjuryFour.Checked = true;
            WoundThree.Checked = true;
        }

        private void WoundFive_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFive.Checked = true;
            InjuryFive.Checked = true;
            WoundFour.Checked = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void trackBar18_Scroll(object sender, EventArgs e)
        {
            // Calculate the total of the Strength Skills
            int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            DigiSoulStat.Text = halvedValue.ToString();
        }

        public void InfoExtractTrack_Scroll(object sender, EventArgs e)
        {
            // Calculate the total of the Strength Skills
            int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            DigiSoulStat.Text = halvedValue.ToString();
        }

        private void ActivateHD_Click(object sender, EventArgs e)
        {
            int digiSoulScore;
            if (int.TryParse(DigiSoulStat.Text, out digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulScore -= 1; // Subtract 1 from the score
                DigiSoulStat.Text = digiSoulScore.ToString();
            }
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            int digiSoulScore;
            if (int.TryParse(DigiSoulStat.Text, out digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulScore -= 1; // Subtract 1 from the score
                DigiSoulStat.Text = digiSoulScore.ToString();
            }
        }

        // Level Up System
        int TamerLevel = 1;
        // Press The Butoon
        private void button22_Click_4(object sender, EventArgs e)
        {
            // Get the Lifespan
            int RemainingLifespan;
            int.TryParse(RemainingLife.Text, out RemainingLifespan);
            RemainingLifespan = RemainingLifespan + 2;
            RemainingLife.Text = RemainingLifespan.ToString();
            int MaximumLifespan;
            int.TryParse(MaximumLife.Text, out MaximumLifespan);
            MaximumLifespan = MaximumLifespan + 2;
            MaximumLife.Text = MaximumLifespan.ToString();

            TamerLevel = TamerLevel + 1;
            CharacterLevel.Text = TamerLevel.ToString();
            int IncreaseHealth;
            int.TryParse(MaxHealth.Text, out IncreaseHealth);
            IncreaseHealth = 25 + ((TamerLevel - 1) * 5);
            MaxHealth.Text = IncreaseHealth.ToString();
            CurrentHealth.Text = MaxHealth.Text;
            CoreHPMax.Text = MaxHealth.Text;
            CoreHPNow.Text = MaxHealth.Text;
            TamersLevel.Text = CharacterLevel.Text;



            // Level Up Boon
            TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack };

            foreach (TrackBar track in tracks)
            {
                track.Enabled = true;
            }

        }

        private void CharacterLevel_Click(object sender, EventArgs e)
        {

        }

        private void CurrentHealth_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged_3(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        int GaurdPoints;

        private void label117_Click(object sender, EventArgs e)
        {
            StratPoints.Text = DigiBond.Text;
        }

        private void label111_Click(object sender, EventArgs e)
        {

        }

        private void SuperSkillGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                // Disable upon selection
                CrestSelection.Enabled = false;

                // Get selected Personality Crest
                string Crest = (string)CrestSelection.SelectedItem;

                if (Crest == "Courage")
                {
                    // Courage
                    Impulse.Text = "Rush-In";
                    Value.Text = "Unflinching";
                    Betrayal.Text = "Cowardice";
                    pictureBox1.Image = Properties.Resources.Courage;
                }
                else if (Crest == "Prudence")
                {
                    // Prudence
                    Impulse.Text = "Analyse";
                    Value.Text = "Planning";
                    Betrayal.Text = "Recklessness";
                    pictureBox1.Image = Properties.Resources.Prudence;
                }
                else if (Crest == "Friendship")
                {
                    // Friendship
                    Impulse.Text = "Protectiveness";
                    Value.Text = "Loyalty";
                    Betrayal.Text = "Desertion";
                    pictureBox1.Image = Properties.Resources.Friendship;
                }
                else if (Crest == "Independance")
                {
                    // Independance
                    Impulse.Text = "Withdraw";
                    Value.Text = "Self-Sufficiency";
                    Betrayal.Text = "Burden";
                    pictureBox1.Image = Properties.Resources.Independance;
                }
                else if (Crest == "Hope")
                {
                    // Hope
                    Impulse.Text = "Optimism";
                    Value.Text = "Relentlessness";
                    Betrayal.Text = "Despair";
                    pictureBox1.Image = Properties.Resources.Hope;
                }
                else if (Crest == "Clarity")
                {
                    // Clarity
                    Impulse.Text = "Realism";
                    Value.Text = "Insight";
                    Betrayal.Text = "Delusion";
                    pictureBox1.Image = Properties.Resources.Clarity;
                }
                else if (Crest == "Love")
                {
                    // Love
                    Impulse.Text = "Empathise";
                    Value.Text = "Supportiveness";
                    Betrayal.Text = "Hate";
                    pictureBox1.Image = Properties.Resources.Love;
                }
                else if (Crest == "Serenity")
                {
                    // Serenity
                    Impulse.Text = "Relax";
                    Value.Text = "Peacekeeping";
                    Betrayal.Text = "Stress";
                    pictureBox1.Image = Properties.Resources.Serenity;
                }
                else if (Crest == "Reliability")
                {
                    // Reliability
                    Impulse.Text = "Seriousness";
                    Value.Text = "Dependability";
                    Betrayal.Text = "Hypocrisy";
                    pictureBox1.Image = Properties.Resources.Reliability;
                }
                else if (Crest == "Levity")
                {
                    // Levity
                    Impulse.Text = "Joke";
                    Value.Text = "Uplift";
                    Betrayal.Text = "Dishearten";
                    pictureBox1.Image = Properties.Resources.Levity;
                }
                else if (Crest == "Sincerity")
                {
                    // Sincerity
                    Impulse.Text = "Honesty";
                    Value.Text = "Transparency";
                    Betrayal.Text = "Disingenuousness";
                    pictureBox1.Image = Properties.Resources.Sincerity;
                }
                else if (Crest == "Compromise")
                {
                    // Compromise
                    Impulse.Text = "Bargaining";
                    Value.Text = "Fairness";
                    Betrayal.Text = "Greed";
                    pictureBox1.Image = Properties.Resources.Compromise;
                }
                else if (Crest == "Knowledge")
                {
                    // Knowledge
                    Impulse.Text = "Curiosity";
                    Value.Text = "Insight";
                    Betrayal.Text = "Obstinance";
                    pictureBox1.Image = Properties.Resources.Knowledge;
                }
                else if (Crest == "Trust")
                {
                    // Trust
                    Impulse.Text = "Believe";
                    Value.Text = "Faith";
                    Betrayal.Text = "Cynicism";
                    pictureBox1.Image = Properties.Resources.Trust;
                }
                else if (Crest == "Kindness")
                {
                    // Kindness
                    Impulse.Text = "Generosity";
                    Value.Text = "Mercy";
                    Betrayal.Text = "Cruelty";
                    pictureBox1.Image = Properties.Resources.Kindness;
                }
                else if (Crest == "Justice")
                {
                    // Justice
                    Impulse.Text = "Fairness";
                    Value.Text = "Accountability";
                    Betrayal.Text = "Sentimentality";
                    pictureBox1.Image = Properties.Resources.Justice;
                }
                else if (Crest == "Pride")
                {
                    // Pride
                    Impulse.Text = "Strive";
                    Value.Text = "Self-Respect";
                    Betrayal.Text = "Insecurity";
                    pictureBox1.Image = Properties.Resources.Pride;
                }
                else if (Crest == "Humility")
                {
                    // Humility
                    Impulse.Text = "Modesty";
                    Value.Text = "Selflessness";
                    Betrayal.Text = "Arrogance";
                    pictureBox1.Image = Properties.Resources.Humility;
                }
                else
                {
                    // Humility
                    Impulse.Text = "____";
                    Value.Text = "____";
                    Betrayal.Text = "____";
                    pictureBox1.Image = null;
                }

            }
        }

        private void label28_Click_1(object sender, EventArgs e)
        {

        }

        private void SuperSkillGain_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            {
                // Get selected Personality Crest
                string DigimonPartner = (string)Partner.SelectedItem;
                // Disable selecting
                Partner.Enabled = false;

                // Rookies
                if (DigimonPartner == "Agumon")
                {
                    RecordRookie = "Agumon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Agumon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Agumon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Agumon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "2";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardDiceMin.Text = "3";
                    StandardDiceMax.Text = "5";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialDiceMin.Text = "6";
                    SpecialDiceMax.Text = "8";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperDiceMin.Text = "9";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Agumon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "Firewall Guard - Three points of damage to attackers on guard.";
                    InheritableQuirkTwo.Text = "Empathy - They can roll for Empathy Checks.";
                    InheritableQuirkThree.Text = "";

                }
                else if (DigimonPartner == "Dracomon")
                {
                    RecordRookie = "Dracomon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Dracomon
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Commandramon")
                {
                    // Commandramon Details
                    DigimonField.Text = "Metal Empire";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Virus";
                    WeaknessElement.Text = "Nature";
                    ResistanceElement.Text = "Pierce";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves
                    //Basic Move
                    BasicAttack.Text = "Helmet Bash";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "2";

                    //Standard Move
                    StandardAttack.Text = "M16 Assassin";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardDiceMin.Text = "3";
                    StandardDiceMax.Text = "5";

                    //Special Move
                    SpecialAttack.Text = "DCD Bomb";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialDiceMin.Text = "6";
                    SpecialDiceMax.Text = "8";

                    //Super Move
                    SuperAttack.Text = "Sniper Tag";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperDiceMin.Text = "9";
                    SuperDiceMax.Text = "10";

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "Cover-Fire Guard - Decrease all enemy attack rolls by one.";
                    InheritableQuirkTwo.Text = "Investigation - They can roll for investigation.";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Hagurumon")
                {
                    RecordRookie = "Hagurumon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Hagurumon
                    DigimonField.Text = "Metal Empire";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Terriermon")
                {
                    RecordRookie = "Terriermon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    //  Terriermon
                    DigimonField.Text = "Wind Gaurdians";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Hawkmon")
                {
                    RecordRookie = "Hawkmon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Hawkmon
                    DigimonField.Text = "Wind Gaurdians";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Impmon")
                {
                    RecordRookie = "Impmon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Impmon
                    DigimonField.Text = "Nightmare Soldiers";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";

                }
                else if (DigimonPartner == "Dracumon")
                {
                    RecordRookie = "Dracumon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Dracumon
                    DigimonField.Text = "Nightmare Soldiers";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "DemiDevimon")
                {
                    RecordRookie = "DemiDevimon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // DemiDevimon
                    DigimonField.Text = "Dark Area";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Soundbirdmon")
                {
                    RecordRookie = "Soundbirdmon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Soundbirdmon
                    DigimonField.Text = "Dark Area";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Gomamon")
                {
                    RecordRookie = "Gomamon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Gomamon
                    DigimonField.Text = "Deep Savers";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Shakomon")
                {
                    RecordRookie = "Shakomon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Shakomon
                    DigimonField.Text = "Deep Savers";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Tapirmon")
                {
                    RecordRookie = "Tapirmon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Tapirmon
                    DigimonField.Text = "Virus Busters";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Kotemon")
                {
                    RecordRookie = "Kotemon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Kotemon
                    DigimonField.Text = "Virus Busters";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Monmon")
                {
                    RecordRookie = "Monmon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Monmon
                    DigimonField.Text = "Nature Spirits";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Liollmon")
                {
                    RecordRookie = "Liollmon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Liollmon
                    DigimonField.Text = "Nature Spirits";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Wormmon")
                {
                    RecordRookie = "Wormmon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Wormmon
                    DigimonField.Text = "Jungle Trooper";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Floramon")
                {
                    RecordRookie = "Floramon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Floramon
                    DigimonField.Text = "Jungle Trooper";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Keramon")
                {
                    RecordRookie = "Keramon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Keramon
                    DigimonField.Text = "Unknown";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Bacomon")
                {
                    RecordRookie = "Bacomon";
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Bacomon
                    DigimonField.Text = "Unknown";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine/Virus/Vaccine";
                    WeaknessElement.Text = "type";
                    ResistanceElement.Text = "type";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                //Champions
                else if (DigimonPartner == "Numemon")
                {
                    RecordChampion = "Hawkmon";
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = true;

                    // Numemon
                    DigimonField.Text = "Dark Digivolved";
                    DigitalFrame.Text = "10";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Virus";
                    WeaknessElement.Text = "None";
                    ResistanceElement.Text = "None";

                    // Commandramon Stats
                    DigimonStrength.Text = "2";
                    DigimonAgility.Text = "2";
                    DigimonVibes.Text = "2";
                    DigimonWits.Text = "2";
                    DigimonEducation.Text = "2";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else
                {

                    DigimonField.Text = "____";
                    DigitalFrame.Text = "____";
                    CoreHPNow.Text = "____";
                    CoreHPMax.Text = "____";
                    MoveSpeed.Text = "____";
                    Attribute.Text = "____";
                    WeaknessElement.Text = "____";
                    ResistanceElement.Text = "____";

                    // ____ Stats
                    DigimonStrength.Text = "0";
                    DigimonAgility.Text = "0";
                    DigimonVibes.Text = "0";
                    DigimonWits.Text = "0";
                    DigimonEducation.Text = "0";
                    StrengthDiet.Text = "0";
                    AgilityDiet.Text = "0";
                    VibesDiet.Text = "0";
                    WitsDiet.Text = "0";
                    EducationDiet.Text = "0";

                    // ____ Moves

                    // ____ Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";

                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

            // Read input from TextBox
            string HealthNow = CoreHPNow.Text;
            string HealthMod = ModifyCoreHP.Text;
            string HealthMax = CoreHPMax.Text;

            // Try to convert to integers
            int HealthNowValue;
            int HealthModValue;
            int HealthMaxValue;
            int.TryParse(HealthMax, out HealthMaxValue);

            if (int.TryParse(HealthNow, out HealthNowValue) && int.TryParse(HealthMod, out HealthModValue) && HealthModValue > -1)
            {
                // Calculation
                HealthNowValue = HealthNowValue + HealthModValue;

                // Convert the calculated integer back to a string
                string updatedHealthString = HealthNowValue.ToString();

                // Update the text property
                CoreHPNow.Text = updatedHealthString;
            }
            else
            {
                // Handle the conversion failure (e.g., display an error message)
                MessageBox.Show("Please enter valid numbers for health  modification.");
            }

            if (HealthMaxValue < HealthNowValue)
            {
                CoreHPNow.Text = MaxHealth.Text;
            }


        }

        private void button25_Click(object sender, EventArgs e)
        {

            // Read input from TextBox
            string HealthNow = CoreHPNow.Text;
            string HealthMod = ModifyCoreHP.Text;

            // Try to convert to integers
            int HealthNowValue;
            int HealthModValue;

            if (int.TryParse(HealthNow, out HealthNowValue) && int.TryParse(HealthMod, out HealthModValue) && HealthModValue > -1)
            {

                // Calculation
                HealthNowValue = HealthNowValue - HealthModValue;

                // Convert the calculated integer back to a string
                string updatedHealthString = HealthNowValue.ToString();

                // Update the text property
                CoreHPNow.Text = updatedHealthString;
            }
            else
            {
                // Handle the conversion failure (e.g., display an error message)
                MessageBox.Show("Please enter valid numbers for health  modification.");
            }

            if (HealthNowValue < 0)
            {
                CoreHPNow.Text = "0";
            }

            if (HealthNowValue < 1)
            {
                // Lose current form
                Partner.SelectedIndex = -1;
                Partner.Enabled = true;
                RecordRookie = "________";
                RecordChampion = "________";
                RecordUltimate = "________";
                RecordMega = "________";
                Day.Text = "0";

                // Check if Dark-Digivolved, and if so do the same for personality
                if (DarkEvolution == true)
                {
                    CrestSelection.SelectedIndex = -1;
                    CrestSelection.Enabled = true;
                    DarkEvolution = false;
                }

                // Remove Evolution Options
                ChampionSelect.Enabled = false;
                ChampionSelect.Checked = false;
                ChampionLevel.Text = "________";
                UltimateSelect.Enabled = false;
                UltimateSelect.Checked = false;
                UltimateLevel.Text = "________";
                MegaSelect.Enabled = false;
                MegaSelect.Checked = false;
                MegaLevel.Text = "________";

                // Restart Lifespan
                RemainingLife.Text = MaximumLife.Text;
                Digivolve.Enabled = false;
            }

        }

        private void button29_Click(object sender, EventArgs e)
        {
            {
                // If CrapSeven is checked
                if (CrapSeven.Checked)
                {
                    MessageBox.Show("Inflict Dark Digivolution NOW.");
                }
                // If CrapSix is checked
                else if (CrapSix.Checked)
                {
                    CrapSeven.Checked = true;
                }
                // If CrapFive is checked
                else if (CrapFive.Checked)
                {
                    CrapSix.Checked = true;
                }
                // If CrapFour is checked
                else if (CrapFour.Checked)
                {
                    CrapFive.Checked = true;
                }
                // If CrapThree is checked
                else if (CrapThree.Checked)
                {
                    CrapFour.Checked = true;
                }
                // If CrapTwo is checked
                else if (CrapTwo.Checked)
                {
                    CrapThree.Checked = true;
                }
                // If CrapOne is checked
                else if (CrapOne.Checked)
                {
                    CrapTwo.Checked = true;
                }
                // If ToiletThree is checked
                else if (ToiletThree.Checked)
                {
                    CrapOne.Checked = true;
                }
                // If ToiletTwo is checked
                else if (ToiletTwo.Checked)
                {
                    ToiletThree.Checked = true;
                }
                // If ToiletOne is checked
                else if (ToiletOne.Checked)
                {
                    ToiletTwo.Checked = true;
                }
                else
                {
                    ToiletOne.Checked = true;
                }
            }
        }


        String RecordRookie = "";
        String RecordChampion = "";
        String RecordUltimate = "";
        String RecordMega = "";
        bool ChampionEvolution = false;
        bool UltimateEvolution = false;
        bool MegaEvolution = false;
        bool DarkEvolution = false;

        private void Digivolve_Click(object sender, EventArgs e)
        {
            int DarkCheck = 0;

            // Dice Simulation
            Random random = new Random();
            int DigivolutionRoll = random.Next(1, 21);

            // Check Dark Digivolution Odds
            {
                // If CrapSeven is checked
                if (CrapSeven.Checked)
                {
                    DarkCheck = 20;
                }
                // If CrapSix is checked
                else if (CrapSix.Checked)
                {
                    DarkCheck = 18;
                }
                // If CrapFive is checked
                else if (CrapFive.Checked)
                {
                    DarkCheck = 16;
                }
                // If CrapFour is checked
                else if (CrapFour.Checked)
                {
                    DarkCheck = 14;
                }
                // If CrapThree is checked
                else if (CrapThree.Checked)
                {
                    DarkCheck = 12;
                }
                // If CrapTwo is checked
                else if (CrapTwo.Checked)
                {
                    DarkCheck = 10;
                }
                // If CrapOne is checked
                else if (CrapOne.Checked)
                {
                    DarkCheck = 8;
                }
                // If no crap
                else
                {
                    DarkCheck = 0;
                }

                // Diet Check
                if (
                    !int.TryParse(StrengthDiet.Text, out int DietStrength) ||
                    !int.TryParse(AgilityDiet.Text, out int DietAgility) ||
                    !int.TryParse(VibesDiet.Text, out int DietVibes) ||
                    !int.TryParse(WitsDiet.Text, out int DietWits) ||
                    !int.TryParse(EducationDiet.Text, out int DietEducation)
                ) { return; }
                Diet maxDiet = (Diet)new int[] { DietStrength, DietAgility, DietVibes, DietWits, DietEducation }.Select((x, idx) => (x, idx)).Max().idx;

                if (ChampionSelect.Checked == true)
                {
                    int RemainingLifespan;
                    int.TryParse(RemainingLife.Text, out RemainingLifespan);
                    RemainingLifespan = RemainingLifespan - 1;
                    RemainingLife.Text = RemainingLifespan.ToString();

                    if (ChampionLevel.Text == "________")
                    {

                        if (DigivolutionRoll > DarkCheck)
                        {
                            // Agumon Evolution Systems
                            if (Partner.Text == "Agumon")
                            {
                                RecordRookie = "Agumon";

                                if (maxDiet == Diet.Strength)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Greymon");
                                    Partner.Text = "Greymon";
                                    ChampionLevel.Text = "Greymon";
                                }
                                else if (maxDiet == Diet.Agility)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tuskmon");
                                    Partner.Text = "Tuskmon";
                                    ChampionLevel.Text = "Tuskmon";
                                }
                                else if (maxDiet == Diet.Vibes)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Growlmon");
                                    Partner.Text = "Growlmon";
                                    ChampionLevel.Text = "Growlmon";
                                }
                                else if (maxDiet == Diet.Wits)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Flarizamon");
                                    Partner.Text = "Flarizamon";
                                    ChampionLevel.Text = "Flarizamon";
                                }
                                else if (maxDiet == Diet.Education)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tyrannomon");
                                    Partner.Text = "Tyrannomon";
                                    ChampionLevel.Text = "Tyrannomon";
                                }
                                else
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nDark Digivolution Triggered. \nEvolution Result: Numemon");
                                    Partner.Items.Add("Numemon");
                                    Partner.SelectedItem = "Numemon";
                                };
                            }

                            // Commandramon Evolution Systems
                            else if (Partner.Text == "Commandramon")
                            {
                                RecordRookie = "Commandramon";

                                if (maxDiet == Diet.Strength)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Hi-Commandramon");
                                    Partner.Text = "Hi-Commandramon";
                                    ChampionLevel.Text = "Hi-Commandramon";
                                }
                                else if (maxDiet == Diet.Agility)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Centarumon");
                                    Partner.Text = "Centarumon";
                                    ChampionLevel.Text = "Centarumon";
                                }
                                else if (maxDiet == Diet.Vibes)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Deputymon");
                                    Partner.Text = "Deputymon";
                                    ChampionLevel.Text = "Deputymon";
                                }
                                else if (maxDiet == Diet.Wits)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Sealsdramon");
                                    Partner.Text = "Sealsdramon";
                                    ChampionLevel.Text = "Sealsdramon";
                                }
                                else if (maxDiet == Diet.Education)
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Clockmon");
                                    Partner.Text = "Clockmon";
                                    ChampionLevel.Text = "Clockmon";
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nDark Digivolution Triggered. \nEvolution Result: Numemon");
                                Partner.Items.Add("Numemon");
                                Partner.SelectedItem = "Numemon";
                                DarkEvolution = true;
                            };
                        }
                    }
                    else
                    { }
                }

            }
            RecordChampion = ChampionLevel.Text;
            RecordUltimate = UltimateLevel.Text;
            RecordMega = MegaLevel.Text;
        }

        private void Value_Click(object sender, EventArgs e)
        {

            // Increment Days
            int DayCount;
            int LevelCount;
            int.TryParse(CharacterLevel.Text, out LevelCount);
            int.TryParse(Day.Text, out DayCount);


            // Unlock Champion Evolutions
            if (DayCount > 1 && LevelCount > 1)
            {
                ChampionSelect.Enabled = true;
            }

            // Unlock Ultmate Evolutions
            if (DayCount > 6 && LevelCount > 7)
            {
                UltimateSelect.Enabled = true;
            }

            // Unlock Mega Evolutions
            if (DayCount > 13 && LevelCount > 15)
            {
                MegaSelect.Enabled = true;
            }

            {
                // If CrapSeven is checked
                if (CrapSeven.Checked)
                {
                    CrapSix.Checked = true;
                }
                // If CrapSix is checked
                else if (CrapSix.Checked)
                {
                    CrapFive.Checked = true;
                }
                // If CrapFive is checked
                else if (CrapFive.Checked)
                {
                    CrapFour.Checked = true;
                }
                // If CrapFour is checked
                else if (CrapFour.Checked)
                {
                    CrapThree.Checked = true;
                }
                // If CrapThree is checked
                else if (CrapThree.Checked)
                {
                    CrapTwo.Checked = true;
                }
                // If CrapTwo is checked
                else if (CrapTwo.Checked)
                {
                    CrapOne.Checked = true;
                }
                // If CrapOne is checked
                else if (CrapOne.Checked)
                {
                    ToiletThree.Checked = true;
                }
                // If ToiletThree is checked
                else if (ToiletThree.Checked)
                {
                    ToiletTwo.Checked = true;
                }
                // If ToiletTwo is checked
                else if (ToiletTwo.Checked)
                {
                    ToiletOne.Checked = true;
                }
                // If ToiletOne is checked
                else
                {
                    ToiletOne.Checked = false;
                }

                // Digi-Bond Replenished
                DigiBond.Text = "5";
                
                // Strategy Points
                StratPoints.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Increment Days
            int DayCount;
            int.TryParse(Day.Text, out DayCount);
            DayCount = DayCount + 1;
            Day.Text = DayCount.ToString();

        }

        private void groupBox16_Enter(object sender, EventArgs e)
        {

        }

        private void DigimonStrengthRoll_Click(object sender, EventArgs e)
        {
            {
                // Read input from TextBox
                string userInput = DigimonStrength.Text;

                // Try to convert to an integer
                if (int.TryParse(userInput, out int StrengthScore) && DigimonStrength.Text != "0")
                {
                    // Get the number of dice from the TrackBar
                    int NumberOfDice = StrengthScore;

                    // Apply the modifiers
                    if (DigimonStrengthPlusOne.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonStrengthPlusTwo.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonStrengthMinusOne.Checked)
                    {
                        NumberOfDice--;
                    }
                    if (DigimonStrengthMinusTwo.Checked)
                    {
                        NumberOfDice--;
                    }


                    // Simulate rolling dice
                    Random random = new Random();
                    int TotalResult = 0;
                    string IndividualRolls = "";


                    for (int i = 0; i < NumberOfDice; i++)
                    {
                        // Generates a random number between 1 and 10
                        int DiceResult = random.Next(1, 11);
                        TotalResult += DiceResult;
                        // Collect individual rolls
                        IndividualRolls += DiceResult + " ";
                    }

                    // Display the result
                    MessageBox.Show($"Strength Roll: {IndividualRolls}");
                }

                else
                {
                    // Invalid input (not an integer)
                    MessageBox.Show("Please enter a valid integer for Strength Stat.", "Error");
                }
            }
        }

        private void DigimonAgilityRoll_Click(object sender, EventArgs e)
        {
            {
                // Read input from TextBox
                string userInput = DigimonAgility.Text;

                // Try to convert to an integer
                if (int.TryParse(userInput, out int AgilityScore) && DigimonAgility.Text != "0")
                {
                    // Get the number of dice from the TrackBar
                    int NumberOfDice = AgilityScore;

                    // Apply the modifiers
                    if (DigimonAgilityPlusOne.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonAgilityPlusTwo.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonAgilityMinusOne.Checked)
                    {
                        NumberOfDice--;
                    }
                    if (DigimonAgilityMinusTwo.Checked)
                    {
                        NumberOfDice--;
                    }


                    // Simulate rolling dice
                    Random random = new Random();
                    int TotalResult = 0;
                    string IndividualRolls = "";


                    for (int i = 0; i < NumberOfDice; i++)
                    {
                        // Generates a random number between 1 and 10
                        int DiceResult = random.Next(1, 11);
                        TotalResult += DiceResult;
                        // Collect individual rolls
                        IndividualRolls += DiceResult + " ";
                    }

                    // Display the result
                    MessageBox.Show($"Agility Roll: {IndividualRolls}");
                }

                else
                {
                    // Invalid input (not an integer)
                    MessageBox.Show("Please enter a valid integer for Agility Stat.", "Error");
                }
            }
        }

        private void DigimonVibesRoll_Click(object sender, EventArgs e)
        {
            {
                // Read input from TextBox
                string userInput = DigimonVibes.Text;

                // Try to convert to an integer
                if (int.TryParse(userInput, out int VibesScore) && DigimonVibes.Text != "0")
                {
                    // Get the number of dice from the TrackBar
                    int NumberOfDice = VibesScore;

                    // Apply the modifiers
                    if (DigimonVibesPlusOne.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonVibesPlusTwo.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonVibesMinusOne.Checked)
                    {
                        NumberOfDice--;
                    }
                    if (DigimonVibesMinusTwo.Checked)
                    {
                        NumberOfDice--;
                    }


                    // Simulate rolling dice
                    Random random = new Random();
                    int TotalResult = 0;
                    string IndividualRolls = "";


                    for (int i = 0; i < NumberOfDice; i++)
                    {
                        // Generates a random number between 1 and 10
                        int DiceResult = random.Next(1, 11);
                        TotalResult += DiceResult;
                        // Collect individual rolls
                        IndividualRolls += DiceResult + " ";
                    }

                    // Display the result
                    MessageBox.Show($"Vibes Roll: {IndividualRolls}");
                }

                else
                {
                    // Invalid input (not an integer)
                    MessageBox.Show("Please enter a valid integer for Vibes Stat.", "Error");
                }
            }
        }

        private void DigimonWitsRoll_Click(object sender, EventArgs e)
        {
            {
                // Read input from TextBox
                string userInput = DigimonWits.Text;

                // Try to convert to an integer
                if (int.TryParse(userInput, out int WitsScore) && DigimonWits.Text != "0")
                {
                    // Get the number of dice from the TrackBar
                    int NumberOfDice = WitsScore;

                    // Apply the modifiers
                    if (DigimonWitsPlusOne.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonWitsPlusTwo.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonWitsMinusOne.Checked)
                    {
                        NumberOfDice--;
                    }
                    if (DigimonWitsMinusTwo.Checked)
                    {
                        NumberOfDice--;
                    }


                    // Simulate rolling dice
                    Random random = new Random();
                    int TotalResult = 0;
                    string IndividualRolls = "";


                    for (int i = 0; i < NumberOfDice; i++)
                    {
                        // Generates a random number between 1 and 10
                        int DiceResult = random.Next(1, 11);
                        TotalResult += DiceResult;
                        // Collect individual rolls
                        IndividualRolls += DiceResult + " ";
                    }

                    // Display the result
                    MessageBox.Show($"Wits Roll: {IndividualRolls}");
                }

                else
                {
                    // Invalid input (not an integer)
                    MessageBox.Show("Please enter a valid integer for Wits Stat.", "Error");
                }
            }
        }

        private void DigimonEducationRoll_Click(object sender, EventArgs e)
        {
            {
                // Read input from TextBox
                string userInput = DigimonEducation.Text;

                // Try to convert to an integer
                if (int.TryParse(userInput, out int EducationScore) && DigimonEducation.Text != "0")
                {
                    // Get the number of dice from the TrackBar
                    int NumberOfDice = EducationScore;

                    // Apply the modifiers
                    if (DigimonEducationPlusOne.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonEducationPlusTwo.Checked)
                    {
                        NumberOfDice++;
                    }
                    if (DigimonEducationMinusOne.Checked)
                    {
                        NumberOfDice--;
                    }
                    if (DigimonEducationMinusTwo.Checked)
                    {
                        NumberOfDice--;
                    }


                    // Simulate rolling dice
                    Random random = new Random();
                    int TotalResult = 0;
                    string IndividualRolls = "";


                    for (int i = 0; i < NumberOfDice; i++)
                    {
                        // Generates a random number between 1 and 10
                        int DiceResult = random.Next(1, 11);
                        TotalResult += DiceResult;
                        // Collect individual rolls
                        IndividualRolls += DiceResult + " ";
                    }

                    // Display the result
                    MessageBox.Show($"Education Roll: {IndividualRolls}");
                }

                else
                {
                    // Invalid input (not an integer)
                    MessageBox.Show("Please enter a valid integer for Education Stat.", "Error");
                }
            }
        }

        private void textBox5_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void RemainingLife_Click(object sender, EventArgs e)
        {

        }

        private void ReadableInventory_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateInventory_Click(object sender, EventArgs e)
        {
            // Read in text, splitting it at ",", and put them into an array
            string InventoryItems = ReadableInventory.Text;
            string[] Items = InventoryItems.Split(',');

            // Split into two arrays, QualityItems and Quantity Items, based on whether they contain + or *
            string[] QualityItems = new string[Items.Length];
            string[] QuantityItems = new string[Items.Length];

            int QualityIndex = 0;
            int QuantityIndex = 0;

            // Loop through each inventory item
            foreach (string item in Items)
            {
                if (item.Contains("+"))
                {
                    QualityItems[QualityIndex++] = item;
                }
                else if (item.Contains("*"))
                {
                    QuantityItems[QuantityIndex++] = item;
                }
            }

            // Shorten arrays if necessary (optional)
            QualityItems = QualityItems.Take(QualityIndex).ToArray();
            QuantityItems = QuantityItems.Take(QuantityIndex).ToArray();

            int totalStrengthIncrease = 0;
            int totalAgilityIncrease = 0;

            // Assuming UpdateInventory_Click has already been called and categorized the items
            foreach (string item in QualityItems)
            {
                // Extract numerical value after "+" symbol
                string[] itemParts = item.Split(new[] { @"\s*+\s*" }, 2, StringSplitOptions.RemoveEmptyEntries);

                // Ensure there are at least two parts (name and value)
                if (itemParts.Length > 1)
                {
                    // Exclude last character
                    string valueString = itemParts[1].Substring(0, itemParts[1].Length - 1);
                    // Attempt to parse the value
                    int value = int.Parse(valueString);

                    if (itemParts[0].Contains("Strength"))
                    {
                        totalStrengthIncrease = totalStrengthIncrease + value;
                    }
                    else if (itemParts[0].Contains("Agility"))
                    {
                        totalAgilityIncrease = totalAgilityIncrease + value;
                    }
                }
                else
                {
                    // Handle cases where the item doesn't contain "+" or has an unexpected format
                    // (log an error, ignore the item, etc.)
                }

                // Constructing a String from the arrays
                StringBuilder inventoryText = new StringBuilder();

                // Append formatted content for quality items
                inventoryText.AppendLine("Total Strength Increase: " + totalStrengthIncrease);
                inventoryText.AppendLine("Total Agility Increase: " + totalAgilityIncrease);
                inventoryText.Append("");
                inventoryText.Append(string.Join(",", QualityItems.Where(itemPart => !string.IsNullOrEmpty(item))));
                inventoryText.Append(",");

                // Append formatted content for quantity items
                inventoryText.Append("");
                inventoryText.Append(string.Join(",", QuantityItems.Where(itemPart => !string.IsNullOrEmpty(item))));
                inventoryText.Append("");

                // Assign the final string to ReadableInventory.Text
                ReadableInventory.Text = "";
                ReadableInventory.Text = inventoryText.ToString();

            }
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            int StratBond;
            int.TryParse(DigiBond.Text, out StratBond);
            StratBond = StratBond + GaurdPoints;
            StratPoints.Text = StratBond.ToString();

            if (StratBond > 0)
            {
                ActBasicAttack.Enabled = true;
                ActStandardAttack.Enabled = true;
                ActSpecialAttack.Enabled = true;
                ActSuperAttack.Enabled = true;
            }
            if (StratBond < 1)
            {
                ActBasicAttack.Enabled = false;
                ActStandardAttack.Enabled = false;
                ActSpecialAttack.Enabled = false;
                ActSuperAttack.Enabled = false;
            }

        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            GaurdPoints++;
            StratPoints.Text = "";
        }

        private void BasicAttack_Click(object sender, EventArgs e)
        {
            GaurdPoints--;
            StratPoints.Text = "";

            // Get the number of dice from the TrackBar
            int NumberOfDice = 0;

            // Determine The Level
            if (MegaEvolution == true)
            {
                NumberOfDice = 12;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 8;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 4;
            }
            else
            {
                NumberOfDice = 2;
            }

            // Apply the modifiers
            if (DigiRollPlusOne.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollPlusTwo.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollMinusOne.Checked == true)
            {
                NumberOfDice--;
            }
            if (DigiRollMinusTwo.Checked == true)
            {
                NumberOfDice--;
            }

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
                StrikeInflicted = "Hard Fail" + BasicAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail" + BasicAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail" + BasicAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit" + BasicAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit" + BasicAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit" + BasicAttackHardHit.Text;
            }

            // Display the result
            MessageBox.Show($"\n{BasicAttack.Text}\nAttack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetDefense}\nResults: {StrikeInflicted}");
        }


    private void StandardAttack_Click(object sender, EventArgs e)
        {
            GaurdPoints--;
            StratPoints.Text = "";

            // Get the number of dice from the TrackBar
            int NumberOfDice = 0;

            // Determine The Level
            if (MegaEvolution == true)
            {
                NumberOfDice = 12;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 8;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 4;
            }
            else
            {
                NumberOfDice = 2;
            }

            // Apply the modifiers
            if (DigiRollPlusOne.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollPlusTwo.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollMinusOne.Checked == true)
            {
                NumberOfDice--;
            }
            if (DigiRollMinusTwo.Checked == true)
            {
                NumberOfDice--;
            }

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
                StrikeInflicted = "Hard Fail" + StandardAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail" + StandardAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail" + StandardAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit" + StandardAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit" + StandardAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit" + StandardAttackHardHit.Text;
            }

            // Display the result
            MessageBox.Show($"\n{StandardAttack.Text}\nAttack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetDefense}\nResults: {StrikeInflicted}");
        }

        private void SpecialAttack_Click(object sender, EventArgs e)
        {
            GaurdPoints--;
            StratPoints.Text = "";

            // Get the number of dice from the TrackBar
            int NumberOfDice = 0;

            // Determine The Level
            if (MegaEvolution == true)
            {
                NumberOfDice = 12;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 8;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 4;
            }
            else
            {
                NumberOfDice = 2;
            }

            // Apply the modifiers
            if (DigiRollPlusOne.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollPlusTwo.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollMinusOne.Checked == true)
            {
                NumberOfDice--;
            }
            if (DigiRollMinusTwo.Checked == true)
            {
                NumberOfDice--;
            }

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
                StrikeInflicted = "Hard Fail" + SpecialAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail" + SpecialAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail" + SpecialAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit" + SpecialAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit" + SpecialAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit" + SpecialAttackHardHit.Text;
            }

            // Display the result
            MessageBox.Show($"\n{SpecialAttack.Text}\nAttack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetDefense}\nResults: {StrikeInflicted}");
        }

        private void SuperAttack_Click(object sender, EventArgs e)
        {
            GaurdPoints--;
            StratPoints.Text = "";

            // Get the number of dice from the TrackBar
            int NumberOfDice = 0;

            // Determine The Level
            if (MegaEvolution == true)
            {
                NumberOfDice = 12;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 8;
            }
            else if (MegaEvolution == true)
            {
                NumberOfDice = 4;
            }
            else
            {
                NumberOfDice = 2;
            }

            // Apply the modifiers
            if (DigiRollPlusOne.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollPlusTwo.Checked == true)
            {
                NumberOfDice++;
            }
            if (DigiRollMinusOne.Checked == true)
            {
                NumberOfDice--;
            }
            if (DigiRollMinusTwo.Checked == true)
            {
                NumberOfDice--;
            }

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
                StrikeInflicted = "Hard Fail" + SuperAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail" + SuperAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail" + SuperAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit" + SuperAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit" + SuperAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit" + SuperAttackHardHit.Text;
            }

            // Display the result
            MessageBox.Show($"\n{SuperAttack.Text}\nAttack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetDefense}\nResults: {StrikeInflicted}");
        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            // Read in the dice ranges for the moves
            int MinBasic;
            int MaxBasic;
            int MinStandard;
            int MaxStandard;
            int MinSpecial;
            int MaxSpecial;
            int MinSuper;
            int MaxSuper;
            int TargetAcquired;
            int.TryParse(BasicDiceMin.Text, out MinBasic);
            int.TryParse(BasicDiceMax.Text, out MaxBasic);
            int.TryParse(StandardDiceMin.Text, out MinStandard);
            int.TryParse(StandardDiceMax.Text, out MaxStandard);
            int.TryParse(SpecialDiceMin.Text, out MinSpecial);
            int.TryParse(SpecialDiceMax.Text, out MaxSpecial);
            int.TryParse(SuperDiceMin.Text, out MinSuper);
            int.TryParse(SuperDiceMax.Text, out MaxSuper);

            GaurdPoints++;
            StratPoints.Text = "";

            // Try to convert to an integer
            if (!int.TryParse(TargetArmour.Text, out TargetAcquired))
            {
                // Invalid input (not an integer)
                MessageBox.Show("Please enter a valid integer for the Target.");

            }
            else
            {
                Random random = new Random();
                int DiceResult = random.Next(1, 11);

                if (DiceResult >= MinBasic && DiceResult <= MaxBasic)
                {
                    MessageBox.Show(BasicAttack.Text);
                    ActBasicAttack.PerformClick();
                }
                else if (DiceResult >= MinStandard && DiceResult <= MaxStandard)
                {
                    MessageBox.Show(StandardAttack.Text);
                    ActStandardAttack.PerformClick();
                }
                else if (DiceResult >= MinSpecial && DiceResult <= MaxSpecial)
                {
                    MessageBox.Show(SpecialAttack.Text);
                    ActSpecialAttack.PerformClick();
                }
                else if (DiceResult >= MinSuper && DiceResult <= MaxSuper)
                {
                    MessageBox.Show(SuperAttack.Text);
                    ActSuperAttack.PerformClick();
                }
            }
        }

        private void StandardAttack_Enter(object sender, EventArgs e)
        {

        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            int BondScore;
            int.TryParse(DigiBond.Text, out BondScore);
            if (BondScore > 0)
            {
                BondScore--;
            }
            DigiBond.Text = BondScore.ToString();
            StratPoints.Text = "";
        }

        private void GainBond_Click(object sender, EventArgs e)
        {
            int BondScore;
            int.TryParse(DigiBond.Text, out BondScore);
            if (BondScore < 5)
            {
                BondScore++;
            }
            DigiBond.Text = BondScore.ToString();
            StratPoints.Text = "";
        }

        private void SpecialDiceMax_Click(object sender, EventArgs e)
        {

        }

        private void label104_Click(object sender, EventArgs e)
        {

        }

        private void label122_Click(object sender, EventArgs e)
        {

        }
    }
}