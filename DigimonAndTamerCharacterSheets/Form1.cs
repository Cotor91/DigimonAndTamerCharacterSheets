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
using System.Text.Json;
using DigimonAndTamerCharacterSheets.Models;
using System.Text.RegularExpressions;

namespace DigimonAndTamerCharacterSheets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadCharacterInformation(); // Load data when the form initializes


            StrengthStat.Text = "";
            DigimonStrength.Text = "";
            AgilityStat.Text = "";
            DigimonAgility.Text = "";
            VibesStat.Text = "";
            DigimonVibes.Text = "";
            WitsStat.Text = "";
            DigimonWits.Text = "";
            KnowledgeStat.Text = "";
            DigimonEducation.Text = "";

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCharacterInformation(); // Save data when the form is closing
        }

        private void LoadCharacterInformation()
        {
            if (!File.Exists("form.json"))
            {
                SaveCharacterInformation();
                return;
            }

            try
            {
                SaveForm? loadedForm = JsonSerializer.Deserialize<SaveForm>(File.ReadAllText("form.json"));
                if (loadedForm == null)
                {
                    MessageBox.Show("Could not load character information!");
                    return;
                }
                // Populate textboxes
                PlayerName.Text = loadedForm.PlayerName;
                CharacterName.Text = loadedForm.CharacterName;
                CharacterGender.Text = loadedForm.CharacterGender;
                ReadableInventory.Text = loadedForm.ReadableInventory;
                Partner.Text = loadedForm.Partner;
                CrestSelection.Text = loadedForm.CrestSelection;
                MaxHealth.Text = loadedForm.MaxHealth;
                CurrentHealth.Text = loadedForm.CurrentHealth;
                CoreHPMax.Text = loadedForm.CoreHPMax;
                CoreHPNow.Text = loadedForm.CoreHPNow;
                MaximumLife.Text = loadedForm.MaximumLife;
                RemainingLife.Text = loadedForm.RemainingLife;
                Day.Text = loadedForm.Day;
                TamersLevel.Text = loadedForm.Level;
                CharacterLevel.Text = loadedForm.Level;
                RecordRookie = loadedForm.RecordsRookie;
                RecordChampion = loadedForm.RecordsChampion;
                RecordUltimate = loadedForm.RecordsUltimate;
                RecordMega = loadedForm.RecordsMega;
                RecordChampion = loadedForm.RecordsChampion;
                RecordUltimate = loadedForm.RecordsUltimate;
                RecordMega = loadedForm.RecordsMega;
                CarryTrack.Value = loadedForm.CarryTrack;
                ThrowTrack.Value = loadedForm.ThrowTrack;
                HoldTrack.Value = loadedForm.HoldTrack;
                BalanceTrack.Value = loadedForm.BalanceTrack;
                ParkourTrack.Value = loadedForm.ParkourTrack;
                ReflexTrack.Value = loadedForm.ReflexTrack;
                PerformTrack.Value = loadedForm.PerformTrack;
                PersuadeTrack.Value = loadedForm.PersuadeTrack;
                IntimidateTrack.Value = loadedForm.IntimidateTrack;
                InvestigationTrack.Value = loadedForm.InvestigationTrack;
                EmpathyTrack.Value = loadedForm.EmpathyTrack;
                IngenuityTrack.Value = loadedForm.IngenuityTrack;
                SocietyTrack.Value = loadedForm.SocietyTrack;
                TechnologyTrack.Value = loadedForm.TechnologyTrack;
                OccultismTrack.Value = loadedForm.OccultismTrack;
                HighestCarry = loadedForm.CarryTrack;
                HighestThrow = loadedForm.ThrowTrack;
                HighestHold = loadedForm.HoldTrack;
                HighestBalance = loadedForm.BalanceTrack;
                HighestParkour = loadedForm.ParkourTrack;
                HighestReflex = loadedForm.ReflexTrack;
                HighestPerform = loadedForm.PerformTrack;
                HighestPersuade = loadedForm.PersuadeTrack;
                HighestIntimidate = loadedForm.IntimidateTrack;
                HighestInvestigation = loadedForm.InvestigationTrack;
                HighestEmpathy = loadedForm.EmpathyTrack;
                HighestIngenuity = loadedForm.IngenuityTrack;
                HighestSociety = loadedForm.SocietyTrack;
                HighestTechnology = loadedForm.TechnologyTrack;
                HighestOccultism = loadedForm.OccultismTrack;
                BruiseOne.Checked = loadedForm.BruiseOne;
                BruiseTwo.Checked = loadedForm.BruiseTwo;
                BruiseThree.Checked = loadedForm.BruiseThree;
                BruiseFour.Checked = loadedForm.BruiseFour;
                BruiseFive.Checked = loadedForm.BruiseFive;
                InjuryOne.Checked = loadedForm.InjuryOne;
                InjuryTwo.Checked = loadedForm.InjuryTwo;
                InjuryThree.Checked = loadedForm.InjuryThree;
                InjuryFour.Checked = loadedForm.InjuryFour;
                InjuryFive.Checked = loadedForm.InjuryFive;
                WoundOne.Checked = loadedForm.WoundOne;
                WoundTwo.Checked = loadedForm.WoundTwo;
                WoundThree.Checked = loadedForm.WoundThree;
                WoundFour.Checked = loadedForm.WoundFour;
                WoundFive.Checked = loadedForm.WoundFive;
                MealStrength = loadedForm.MealStrength;
                MealAgility = loadedForm.MealAgility;
                MealVibes = loadedForm.MealVibes;
                MealWits = loadedForm.MealWits;
                MealEducation = loadedForm.MealEducation;
                ChampionLevel.Text = loadedForm.ChampionLevel;
                UltimateLevel.Text = loadedForm.UltimateLevel;
                MegaLevel.Text = loadedForm.MegaLevel;
                ChampionSelect.Enabled = loadedForm.ChampionSelect;
                UltimateSelect.Enabled = loadedForm.UltimateSelect;
                MegaSelect.Enabled = loadedForm.MegaSelect;
            }
            catch (Exception ex)
            {

            }


            if (Partner.Text != "")
            {
                if (!Partner.Items.Contains(Partner.Text))
                {
                    Partner.Items.Add(Partner.Text);
                }

                Partner.SelectedItem = Partner.Text;
            }

            if (CrestSelection.Text != "")
            {
                if (!CrestSelection.Items.Contains(CrestSelection.Text))
                {
                    CrestSelection.Items.Add(CrestSelection.Text);
                }

                CrestSelection.SelectedItem = CrestSelection.Text;
            }

            StrengthStat.Text = "";
            AgilityStat.Text = "";
            VibesStat.Text = "";
            WitsStat.Text = "";
            KnowledgeStat.Text = "";

            SaveCharacterInformation();

        }

        private void SaveCharacterInformation()
        {
            try
            {
                File.WriteAllText("form.json", JsonSerializer.Serialize(new SaveForm
                {
                    PlayerName = PlayerName.Text,
                    CharacterName = CharacterName.Text,
                    CharacterGender = CharacterGender.Text,
                    ReadableInventory = ReadableInventory.Text,
                    Partner = Partner.Text,
                    CrestSelection = CrestSelection.Text,
                    MaxHealth = MaxHealth.Text,
                    CurrentHealth = CurrentHealth.Text,
                    CoreHPMax = CoreHPMax.Text,
                    CoreHPNow = CoreHPNow.Text,
                    MaximumLife = MaximumLife.Text,
                    RemainingLife = RemainingLife.Text,
                    Level = CharacterLevel.Text,
                    Day = Day.Text,
                    RecordsRookie = RecordRookie,
                    RecordsChampion = RecordChampion,
                    RecordsUltimate = RecordUltimate,
                    RecordsMega = RecordMega,
                    CarryTrack = CarryTrack.Value,
                    ThrowTrack = ThrowTrack.Value,
                    HoldTrack = HoldTrack.Value,
                    BalanceTrack = BalanceTrack.Value,
                    ParkourTrack = ParkourTrack.Value,
                    ReflexTrack = ReflexTrack.Value,
                    PerformTrack = PerformTrack.Value,
                    PersuadeTrack = PersuadeTrack.Value,
                    IntimidateTrack = IntimidateTrack.Value,
                    InvestigationTrack = InvestigationTrack.Value,
                    EmpathyTrack = EmpathyTrack.Value,
                    IngenuityTrack = IngenuityTrack.Value,
                    SocietyTrack = SocietyTrack.Value,
                    TechnologyTrack = TechnologyTrack.Value,
                    OccultismTrack = OccultismTrack.Value,
                    BruiseOne = BruiseOne.Checked,
                    BruiseTwo = BruiseTwo.Checked,
                    BruiseThree = BruiseThree.Checked,
                    BruiseFour = BruiseFour.Checked,
                    BruiseFive = BruiseFive.Checked,
                    InjuryOne = InjuryOne.Checked,
                    InjuryTwo = InjuryTwo.Checked,
                    InjuryThree = InjuryThree.Checked,
                    InjuryFour = InjuryFour.Checked,
                    InjuryFive = InjuryFive.Checked,
                    WoundOne = WoundOne.Checked,
                    WoundTwo = WoundTwo.Checked,
                    WoundThree = WoundThree.Checked,
                    WoundFour = WoundFour.Checked,
                    WoundFive = WoundFive.Checked,
                    MealStrength = MealStrength,
                    MealAgility = MealAgility,
                    MealVibes = MealVibes,
                    MealWits = MealWits,
                    MealEducation = MealEducation,
                    ChampionSelect = ChampionSelect.Enabled,
                    UltimateSelect = UltimateSelect.Enabled,
                    MegaSelect = MegaSelect.Enabled,
                }));

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

            int.TryParse(RemainingLife.Text, out int LifeOver);
            if (LifeOver < 1)
            {
                TamerDigimon.SelectedIndex = 3;
                CoreHPNow.Text = "0";
                ModifyCoreHP.Text = "1";
                MinusDigicoreHP.PerformClick();
                ModifyCoreHP.Text = "";
            }

            if (ChampionEvolution == true || UltimateEvolution == true || MegaEvolution == true)
            {
                if (DarkEvolution == true)
                {

                    TamerDigimon.SelectedIndex = 3;
                    CoreHPNow.Text = "0";
                    ModifyCoreHP.Text = "1";
                    MinusDigicoreHP.PerformClick();
                    ModifyCoreHP.Text = "";
                }
                else
                {
                    Partner.SelectedItem = RecordRookie;
                }

                Partner.Items.Remove(RecordChampion);
                Partner.Items.Remove(RecordUltimate);
                Partner.Items.Remove(RecordMega);

            }

            // Calculate the total of the Strength Skills
            int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            DigiSoulStat.Text = halvedValue.ToString();

            SaveCharacterInformation();

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

            SaveCharacterInformation();
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

            SaveCharacterInformation();
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
            int SkillStrength = CarryTrack.Value + HoldTrack.Value + ThrowTrack.Value;
            int TotalStrength = (int)Math.Ceiling(SkillStrength / 2.0);
            TotalStrength = TotalStrength + StrengthIncrease;
            StrengthStat.Text = TotalStrength.ToString();

            SaveCharacterInformation();
        }

        // Maximum Skills
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

        // Maximum Super Skills
        int HighestErrorScan = 0;
        int HighestInfoExtract = 0;
        int HighestGigaSearch = 0;
        int HighestWaybackTrack = 0;


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

            // Update Stat-Boxes
            StrengthStat.Text = "";
            AgilityStat.Text = "";
            VibesStat.Text = "";
            WitsStat.Text = "";
            KnowledgeStat.Text = "";
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
                TotalResult += CarryTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nCarry Skill: {CarryTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

            // Update Stat-Boxes
            StrengthStat.Text = "";
            AgilityStat.Text = "";
            VibesStat.Text = "";
            WitsStat.Text = "";
            KnowledgeStat.Text = "";
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

                TotalResult += ThrowTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nThrow Skill: {ThrowTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

            // Update Stat-Boxes
            StrengthStat.Text = "";
            AgilityStat.Text = "";
            VibesStat.Text = "";
            WitsStat.Text = "";
            KnowledgeStat.Text = "";
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

                TotalResult += HoldTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nHold Skill: {HoldTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int SkillAgility = BalanceTrack.Value + ParkourTrack.Value + ReflexTrack.Value;
            int TotalAgility = (int)Math.Ceiling(SkillAgility / 2.0);
            TotalAgility = TotalAgility + AgilityIncrease;
            AgilityStat.Text = TotalAgility.ToString();

            SaveCharacterInformation();
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += BalanceTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nBalance Skill: {BalanceTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += ParkourTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nParkour Skill: {ParkourTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += ReflexTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nReflex Skill: {ReflexTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int SkillVibes = PerformTrack.Value + PersuadeTrack.Value + IntimidateTrack.Value;
            int TotalVibes = (int)Math.Ceiling(SkillVibes / 2.0);
            VibesStat.Text = TotalVibes.ToString();
            TotalVibes = TotalVibes + VibesIncrease;
            SaveCharacterInformation();
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += PerformTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nPerform Skill: {PerformTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += IntimidateTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nIntimidate Skill: {IntimidateTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += PersuadeTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nPersuade Skill: {PersuadeTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int SkillWits = InvestigationTrack.Value + EmpathyTrack.Value + IngenuityTrack.Value;
            int TotalWits = (int)Math.Ceiling(SkillWits / 2.0);
            TotalWits = TotalWits + WitsIncrease;
            WitsStat.Text = TotalWits.ToString();

            SaveCharacterInformation();
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += InvestigationTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nInvestigation Skill: {InvestigationTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += EmpathyTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nEmpathy Skill: {EmpathyTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += IngenuityTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nWits Skill: {IngenuityTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int SkillEducation = SocietyTrack.Value + TechnologyTrack.Value + OccultismTrack.Value;
            int TotalEducation = (int)Math.Ceiling(SkillEducation / 2.0);
            TotalEducation = TotalEducation + EducationIncrease;
            KnowledgeStat.Text = TotalEducation.ToString();

            SaveCharacterInformation();
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += TechnologyTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nTechnology Skill: {TechnologyTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += OccultismTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nOccultism Skill: {OccultismTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                // Update Stat-Boxes
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";
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

                TotalResult += SocietyTrack.Value * 3;

                // Display the result
                MessageBox.Show($"Character Roll: {CoreRoll}\nSociety Skill: {SocietyTrack.Value * 3}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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


            // Compare prior maximum to current value
            if (HighestGigaSearch < GigaSearchTrack.Value)
            {
                HighestGigaSearch++;
                GigaSearchTrack.Value = HighestGigaSearch;

                // Spent Skill Points
                TrackBar[] tracks = new TrackBar[] { ErrorScanTrack, InfoExtractTrack, GigaSearchTrack, WaybackTrackTrack };

                DialogResult BoostCarry = MessageBox.Show("Do you want to increase your Giga Search power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show("Giga Search power increased!");
                    foreach (TrackBar track in tracks)
                    {
                        ErrorScanTrack.Value = HighestErrorScan;
                        InfoExtractTrack.Value = HighestInfoExtract;
                        GigaSearchTrack.Value = HighestGigaSearch;
                        WaybackTrackTrack.Value = HighestWaybackTrack;
                        track.Enabled = false;
                    }
                }
                else
                {
                    GigaSearchTrack.Value--;
                    HighestGigaSearch--;
                }


                // Calculate the total of the Strength Skills
                int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                DigiSoulStat.Text = halvedValue.ToString();

            }
        }




        public void trackBar19_Scroll(object sender, EventArgs e)
        {


            // Compare prior maximum to current value
            if (HighestWaybackTrack < WaybackTrackTrack.Value)
            {
                HighestWaybackTrack++;
                WaybackTrackTrack.Value = HighestWaybackTrack;

                // Spent Skill Points
                TrackBar[] tracks = new TrackBar[] { ErrorScanTrack, InfoExtractTrack, GigaSearchTrack, WaybackTrackTrack };

                DialogResult BoostCarry = MessageBox.Show("Do you want to increase your Wayback Track power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show("Wayback Track power increased!");
                    foreach (TrackBar track in tracks)
                    {
                        ErrorScanTrack.Value = HighestErrorScan;
                        InfoExtractTrack.Value = HighestInfoExtract;
                        GigaSearchTrack.Value = HighestGigaSearch;
                        WaybackTrackTrack.Value = HighestWaybackTrack;
                        track.Enabled = false;
                    }
                }
                else
                {
                    WaybackTrackTrack.Value--;
                    HighestWaybackTrack--;
                }


                // Calculate the total of the Strength Skills
                int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                DigiSoulStat.Text = halvedValue.ToString();

            }
        }

        private void ErrorScan_Click(object sender, EventArgs e)
        {
            // Get the number of dice from the TrackBar
            int NumberOfDice = ErrorScanTrack.Value;


            // Simulate rolling dice
            Random random = new Random();
            int TotalResult = 0;
            int.TryParse(DigiSoulStat.Text, out int DigiSoulScore);
            string IndividualRolls = "";


            for (int i = 0; i < NumberOfDice; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }

            // Final result
            DigiSoulScore = DigiSoulScore * 3;
            TotalResult += DigiSoulScore;

            // Display the result
            MessageBox.Show($"Digi-Soul Bonus: {DigiSoulScore}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");

        }

        private void InfoExtract_Click(object sender, EventArgs e)
        {
            // Get the number of dice from the TrackBar
            int NumberOfDice = InfoExtractTrack.Value;


            // Simulate rolling dice
            Random random = new Random();
            int TotalResult = 0;
            int.TryParse(DigiSoulStat.Text, out int DigiSoulScore);
            string IndividualRolls = "";


            for (int i = 0; i < NumberOfDice; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }

            // Final result
            DigiSoulScore = DigiSoulScore * 3;
            TotalResult += DigiSoulScore;

            // Display the result
            MessageBox.Show($"Digi-Soul Bonus: {DigiSoulScore}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");

        }

        private void GigaSearch_Click(object sender, EventArgs e)
        {
            // Get the number of dice from the TrackBar
            int NumberOfDice = GigaSearchTrack.Value;


            // Simulate rolling dice
            Random random = new Random();
            int TotalResult = 0;
            int.TryParse(DigiSoulStat.Text, out int DigiSoulScore);
            string IndividualRolls = "";


            for (int i = 0; i < NumberOfDice; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }

            // Final result
            DigiSoulScore = DigiSoulScore * 3;
            TotalResult += DigiSoulScore;

            // Display the result
            MessageBox.Show($"Digi-Soul Bonus: {DigiSoulScore}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");

        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            // Get the number of dice from the TrackBar
            int NumberOfDice = WaybackTrackTrack.Value;


            // Simulate rolling dice
            Random random = new Random();
            int TotalResult = 0;
            int.TryParse(DigiSoulStat.Text, out int DigiSoulScore);
            string IndividualRolls = "";


            for (int i = 0; i < NumberOfDice; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }

            // Final result
            DigiSoulScore = DigiSoulScore * 3;
            TotalResult += DigiSoulScore;

            // Display the result
            MessageBox.Show($"Digi-Soul Bonus: {DigiSoulScore}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");

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

        bool MealStrength = false;
        bool MealAgility = false;
        bool MealVibes = false;
        bool MealWits = false;
        bool MealEducation = false;
        bool AutoMeal = false;

        private void button4_Click(object sender, EventArgs e)
        {
            int ReduceMax = 0;
            int HighestQuantity = -1;



            // Feed the meal type
            if (StrengthMeal.Checked == true)
            {
                MealStrength = true;
                MealAgility = false;
                MealVibes = false;
                MealWits = false;
                MealEducation = false;

                int.TryParse(StrengthDiet.Text, out int DietBoost);
                DietBoost = DietBoost + 1;
                StrengthDiet.Text = DietBoost.ToString();


                // Check if automated reduction
                DialogResult ConsumeFood = MessageBox.Show("Do you want to automatically feed your partner the Meat Meal you have the most instances of?", "Tasty Food!", MessageBoxButtons.YesNo);

                if (ConsumeFood == DialogResult.Yes)
                {
                    AutoMeal = true;
                    foreach (string item in MeatQuantity)
                    {
                        // Trim the front to remove "*" and everything before it
                        string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                        // Trim the back to remove ")" and everything after it
                        int BracketPlace = ExistHolster.IndexOf(')');
                        ExistHolster = ExistHolster.Substring(0, BracketPlace);

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(MeatQuantity, item);
                        }

                    }

                    String RewriteValue = MeatQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    int ClosingBracket = RewriteValue.IndexOf(')');
                    RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = MeatQuantity[HighestQuantity].IndexOf('*') + 2;
                        String StartValue = MeatQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        String EndValue = MeatQuantity[HighestQuantity].Substring(MeatQuantity[HighestQuantity].IndexOf(')'));

                        // Build the string anew
                        StringBuilder NewValue = new StringBuilder();

                        NewValue.Append(StartValue);
                        NewValue.Append(RewriteValue);
                        NewValue.Append(EndValue);

                        MeatQuantity[HighestQuantity] = "";
                        MeatQuantity[HighestQuantity] = NewValue.ToString();
                    }
                    else
                    {
                        MeatQuantity[HighestQuantity] = "";
                    }
                }

            }
            else if (AgilityMeal.Checked == true)
            {
                MealStrength = false;
                MealAgility = true;
                MealVibes = false;
                MealWits = false;
                MealEducation = false;

                int.TryParse(AgilityDiet.Text, out int DietBoost);
                DietBoost = DietBoost + 1;
                AgilityDiet.Text = DietBoost.ToString();


                // Check if automated reduction
                DialogResult ConsumeFood = MessageBox.Show("Do you want to automatically feed your partner the Veggies Meal you have the most instances of?", "Tasty Food!", MessageBoxButtons.YesNo);

                if (ConsumeFood == DialogResult.Yes)
                {
                    AutoMeal = true;
                    foreach (string item in VeggiesQuantity)
                    {
                        // Trim the front to remove "*" and everything before it
                        string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                        // Trim the back to remove ")" and everything after it
                        int BracketPlace = ExistHolster.IndexOf(')');
                        ExistHolster = ExistHolster.Substring(0, BracketPlace);

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(VeggiesQuantity, item);
                        }

                    }

                    String RewriteValue = VeggiesQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    int ClosingBracket = RewriteValue.IndexOf(')');
                    RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = VeggiesQuantity[HighestQuantity].IndexOf('*') + 2;
                        String StartValue = VeggiesQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        String EndValue = VeggiesQuantity[HighestQuantity].Substring(VeggiesQuantity[HighestQuantity].IndexOf(')'));

                        // Build the string anew
                        StringBuilder NewValue = new StringBuilder();

                        NewValue.Append(StartValue);
                        NewValue.Append(RewriteValue);
                        NewValue.Append(EndValue);

                        VeggiesQuantity[HighestQuantity] = "";
                        VeggiesQuantity[HighestQuantity] = NewValue.ToString();
                    }
                    else
                    {
                        VeggiesQuantity[HighestQuantity] = "";
                    }
                }

            }
            else if (VibesMeal.Checked == true)
            {
                MealStrength = false;
                MealAgility = false;
                MealVibes = true;
                MealWits = false;
                MealEducation = false;

                int.TryParse(VibesDiet.Text, out int DietBoost);
                DietBoost = DietBoost + 1;
                VibesDiet.Text = DietBoost.ToString();

                // Check if automated reduction
                DialogResult ConsumeFood = MessageBox.Show("Do you want to automatically feed your partner the Bread Meal you have the most instances of?", "Tasty Food!", MessageBoxButtons.YesNo);

                if (ConsumeFood == DialogResult.Yes)
                {
                    AutoMeal = true;
                    foreach (string item in BreadQuantity)
                    {
                        // Trim the front to remove "*" and everything before it
                        string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                        // Trim the back to remove ")" and everything after it
                        int BracketPlace = ExistHolster.IndexOf(')');
                        ExistHolster = ExistHolster.Substring(0, BracketPlace);

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(BreadQuantity, item);
                        }

                    }

                    String RewriteValue = BreadQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    int ClosingBracket = RewriteValue.IndexOf(')');
                    RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = BreadQuantity[HighestQuantity].IndexOf('*') + 2;
                        String StartValue = BreadQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        String EndValue = BreadQuantity[HighestQuantity].Substring(BreadQuantity[HighestQuantity].IndexOf(')'));

                        // Build the string anew
                        StringBuilder NewValue = new StringBuilder();

                        NewValue.Append(StartValue);
                        NewValue.Append(RewriteValue);
                        NewValue.Append(EndValue);

                        BreadQuantity[HighestQuantity] = "";
                        BreadQuantity[HighestQuantity] = NewValue.ToString();
                    }
                    else
                    {
                        BreadQuantity[HighestQuantity] = "";
                    }
                }

            }
            else if (WitsMeal.Checked == true)
            {
                MealStrength = false;
                MealAgility = false;
                MealVibes = false;
                MealWits = true;
                MealEducation = false;

                int.TryParse(WitsDiet.Text, out int DietBoost);
                DietBoost = DietBoost + 1;
                WitsDiet.Text = DietBoost.ToString();

                // Check if automated reduction
                DialogResult ConsumeFood = MessageBox.Show("Do you want to automatically feed your partner the Fruit Meal you have the most instances of?", "Tasty Food!", MessageBoxButtons.YesNo);

                if (ConsumeFood == DialogResult.Yes)
                {
                    AutoMeal = true;
                    foreach (string item in FruitQuantity)
                    {
                        // Trim the front to remove "*" and everything before it
                        string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                        // Trim the back to remove ")" and everything after it
                        int BracketPlace = ExistHolster.IndexOf(')');
                        ExistHolster = ExistHolster.Substring(0, BracketPlace);

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(FruitQuantity, item);
                        }

                    }

                    String RewriteValue = FruitQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    int ClosingBracket = RewriteValue.IndexOf(')');
                    RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = FruitQuantity[HighestQuantity].IndexOf('*') + 2;
                        String StartValue = FruitQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        String EndValue = FruitQuantity[HighestQuantity].Substring(FruitQuantity[HighestQuantity].IndexOf(')'));

                        // Build the string anew
                        StringBuilder NewValue = new StringBuilder();

                        NewValue.Append(StartValue);
                        NewValue.Append(RewriteValue);
                        NewValue.Append(EndValue);

                        FruitQuantity[HighestQuantity] = "";
                        FruitQuantity[HighestQuantity] = NewValue.ToString();
                    }
                    else
                    {
                        FruitQuantity[HighestQuantity] = "";
                    }
                }

            }
            else if (EducationMeal.Checked == true)
            {
                MealStrength = false;
                MealAgility = false;
                MealVibes = false;
                MealWits = false;
                MealEducation = true;

                int.TryParse(EducationDiet.Text, out int DietBoost);
                DietBoost = DietBoost + 1;
                EducationDiet.Text = DietBoost.ToString();

                // Check if automated reduction
                DialogResult ConsumeFood = MessageBox.Show("Do you want to automatically feed your partner the Fish Meal you have the most instances of?", "Tasty Food!", MessageBoxButtons.YesNo);

                if (ConsumeFood == DialogResult.Yes)
                {
                    AutoMeal = true;
                    foreach (string item in FishQuantity)
                    {
                        // Trim the front to remove "*" and everything before it
                        string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                        // Trim the back to remove ")" and everything after it
                        int BracketPlace = ExistHolster.IndexOf(')');
                        ExistHolster = ExistHolster.Substring(0, BracketPlace);

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(FishQuantity, item);
                        }

                    }

                    String RewriteValue = FishQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    int ClosingBracket = RewriteValue.IndexOf(')');
                    RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = FishQuantity[HighestQuantity].IndexOf('*') + 2;
                        String StartValue = FishQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        String EndValue = FishQuantity[HighestQuantity].Substring(FishQuantity[HighestQuantity].IndexOf(')'));

                        // Build the string anew
                        StringBuilder NewValue = new StringBuilder();

                        NewValue.Append(StartValue);
                        NewValue.Append(RewriteValue);
                        NewValue.Append(EndValue);

                        FishQuantity[HighestQuantity] = "";
                        FishQuantity[HighestQuantity] = NewValue.ToString();


                    }
                    else
                    {
                        FishQuantity[HighestQuantity] = "";
                    }
                }

            }
            else
            {
                MealStrength = false;
                DigimonStrength.Text = "";
                MealAgility = false;
                DigimonAgility.Text = "";
                MealVibes = false;
                DigimonVibes.Text = "";
                MealWits = false;
                DigimonWits.Text = "";
                MealEducation = false;
                DigimonEducation.Text = "";
                TamerDigimon.SelectedIndex = 5;
                CareMistakeButton.PerformClick();
            };

            if (AutoMeal == true)
            {
                AutoMeal = false;

                // Constructing a String from the arrays
                StringBuilder inventoryText = new StringBuilder();

                // Append formatted content for quality items
                if (StrengthQuality.Length > 0)
                {
                    inventoryText.Append(string.Join(",", StrengthQuality.Where(StrengthItem => !string.IsNullOrEmpty(StrengthItem))));
                    inventoryText.Append(", ");
                }
                if (AgilityQuality.Length > 0)
                {
                    inventoryText.Append(string.Join(",", AgilityQuality.Where(AgilityItem => !string.IsNullOrEmpty(AgilityItem))));
                    inventoryText.Append(", ");
                }
                if (VibesQuality.Length > 0)
                {
                    inventoryText.Append(string.Join(",", VibesQuality.Where(VibesItem => !string.IsNullOrEmpty(VibesItem))));
                    inventoryText.Append(", ");
                }
                if (WitsQuality.Length > 0)
                {
                    inventoryText.Append(string.Join(",", WitsQuality.Where(WitsItem => !string.IsNullOrEmpty(WitsItem))));
                    inventoryText.Append(", ");
                }
                if (EducationQuality.Length > 0)
                {
                    inventoryText.Append(string.Join(",", EducationQuality.Where(EducationItem => !string.IsNullOrEmpty(EducationItem))));
                    inventoryText.Append(", ");
                }
                if (AlternativeQuality.Length > 0)
                {
                    inventoryText.Append(string.Join(",", AlternativeQuality.Where(AlternativeItem => !string.IsNullOrEmpty(AlternativeItem))));
                    inventoryText.Append(", ");
                }

                // Append formatted content for quality items
                if (MeatQuantity.Length > 0)
                {
                    inventoryText.Append(string.Join(",", MeatQuantity.Where(MeatItem => !string.IsNullOrEmpty(MeatItem))));
                    inventoryText.Append(", ");
                }
                if (VeggiesQuantity.Length > 0)
                {
                    inventoryText.Append(string.Join(",", VeggiesQuantity.Where(VeggiesItem => !string.IsNullOrEmpty(VeggiesItem))));
                    inventoryText.Append(", ");
                }
                if (BreadQuantity.Length > 0)
                {
                    inventoryText.Append(string.Join(",", BreadQuantity.Where(BreadItem => !string.IsNullOrEmpty(BreadItem))));
                    inventoryText.Append(", ");
                }
                if (FruitQuantity.Length > 0)
                {
                    inventoryText.Append(string.Join(",", FruitQuantity.Where(FruitItem => !string.IsNullOrEmpty(FruitItem))));
                    inventoryText.Append(", ");
                }
                if (FishQuantity.Length > 0)
                {
                    inventoryText.Append(string.Join(",", FishQuantity.Where(FishItem => !string.IsNullOrEmpty(FishItem))));
                    inventoryText.Append(", ");
                }
                if (AlternativeQuantity.Length > 0)
                {
                    inventoryText.Append(string.Join(",", AlternativeQuantity.Where(AlternativeItem => !string.IsNullOrEmpty(AlternativeItem))));
                    inventoryText.Append(", ");
                }

                // Append non-useful items
                if (AlternativeItems.Length > 0)
                {
                    inventoryText.Append(string.Join(",", AlternativeItems.Where(itemPart => !string.IsNullOrEmpty(itemPart))));
                    inventoryText.Append(", ");
                }

                // Condense to String
                String FinalisedInventory = inventoryText.ToString();

                // Remove leading/trailing spaces
                FinalisedInventory = FinalisedInventory.Trim();

                // Replace multiple spaces with single space
                FinalisedInventory = Regex.Replace(FinalisedInventory, @"\s+", " ");


                // Assign the final string to ReadableInventory.Text
                ReadableInventory.Text = "";
                ReadableInventory.Text = FinalisedInventory;

                // Update The Inventory
                UpdateInventory.PerformClick();

                // Unselect the meals
                StrengthMeal.Checked = false;
                AgilityMeal.Checked = false;
                VibesMeal.Checked = false;
                WitsMeal.Checked = false;
                EducationMeal.Checked = false;


                // Heal during meal-time
                if (BruiseFive.Checked == true)
                {
                    if (InjuryFive.Checked != true)
                    {
                        BruiseFive.Checked = false;
                    }
                }
                else if (BruiseFour.Checked == true)
                {
                    if (InjuryFour.Checked != true)
                    {
                        BruiseFour.Checked = false;
                    }
                }
                else if (BruiseThree.Checked == true)
                {
                    if (InjuryThree.Checked != true)
                    {
                        BruiseThree.Checked = false;
                    }
                }
                else if (BruiseTwo.Checked == true)
                {
                    if (InjuryTwo.Checked != true)
                    {
                        BruiseTwo.Checked = false;
                    }
                }
                else if (BruiseOne.Checked == true)
                {
                    if (InjuryOne.Checked != true)
                    {
                        BruiseOne.Checked = false;
                    }
                }



                // Update stat block
                DigimonStrength.Text = "";
                DigimonAgility.Text = "";
                DigimonVibes.Text = "";
                DigimonWits.Text = "";
                DigimonEducation.Text = "";

                DigiAttackRoll.Text = "";
                SaveCharacterInformation();

            }
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

            SaveCharacterInformation();
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
            SaveCharacterInformation();
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
            SaveCharacterInformation();
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

            if (ChampionEvolution == true && ChampionSelect.Checked == true)
            {
                Digivolve.Text = "De-Digivolve";
            }
            else
            {
                Digivolve.Text = "Digivolve";
            }

        }

        private void radioButton12_CheckedChanged_2(object sender, EventArgs e)
        {
            Digivolve.Enabled = true;

            if (UltimateEvolution == true && UltimateSelect.Checked == true)
            {
                Digivolve.Text = "De-Digivolve";
            }
            else
            {
                Digivolve.Text = "Digivolve";
            }
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            Digivolve.Enabled = true;

            if (MegaEvolution == true && MegaSelect.Checked == true)
            {
                Digivolve.Text = "De-Digivolve";
            }
            else
            {
                Digivolve.Text = "Digivolve";
            }
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

            SaveCharacterInformation();

        }

        private void BruiseTwo_CheckedChanged(object sender, EventArgs e)
        {
            BruiseOne.Checked = true;

            SaveCharacterInformation();

        }

        private void BruiseThree_CheckedChanged(object sender, EventArgs e)
        {
            BruiseTwo.Checked = true;

            SaveCharacterInformation();

        }

        private void BruiseFour_CheckedChanged(object sender, EventArgs e)
        {
            BruiseThree.Checked = true;

            SaveCharacterInformation();

        }

        private void BruiseFive_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFour.Checked = true;

            SaveCharacterInformation();

        }


        private void InjuryOne_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseOne.Checked = true;

            SaveCharacterInformation();

        }

        private void InjuryTwo_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseTwo.Checked = true;
            InjuryOne.Checked = true;

            SaveCharacterInformation();

        }

        private void InjuryThree_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseThree.Checked = true;
            InjuryTwo.Checked = true;

            SaveCharacterInformation();

        }

        private void InjuryFour_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFour.Checked = true;
            InjuryThree.Checked = true;

            SaveCharacterInformation();

        }

        private void InjuryFive_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFive.Checked = true;
            InjuryFour.Checked = true;

            SaveCharacterInformation();

        }

        private void WoundOne_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseOne.Checked = true;
            InjuryOne.Checked = true;

            SaveCharacterInformation();

        }

        private void WoundTwo_CheckedChanged_2(object sender, EventArgs e)
        {
            BruiseTwo.Checked = true;
            InjuryTwo.Checked = true;
            WoundOne.Checked = true;

            SaveCharacterInformation();

        }

        private void WoundThree_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseThree.Checked = true;
            InjuryThree.Checked = true;
            WoundTwo.Checked = true;

            SaveCharacterInformation();

        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            BruiseFour.Checked = true;
            InjuryFour.Checked = true;
            WoundThree.Checked = true;

            SaveCharacterInformation();

        }

        private void WoundFive_CheckedChanged_1(object sender, EventArgs e)
        {
            BruiseFive.Checked = true;
            InjuryFive.Checked = true;
            WoundFour.Checked = true;

            SaveCharacterInformation();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void trackBar18_Scroll(object sender, EventArgs e)
        {


            // Compare prior maximum to current value
            if (HighestErrorScan < ErrorScanTrack.Value)
            {
                HighestErrorScan++;
                ErrorScanTrack.Value = HighestErrorScan;

                // Spent Skill Points
                TrackBar[] tracks = new TrackBar[] { ErrorScanTrack, InfoExtractTrack, GigaSearchTrack, WaybackTrackTrack };

                DialogResult BoostCarry = MessageBox.Show("Do you want to increase your Error Scan power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show("Error Scan power increased!");
                    foreach (TrackBar track in tracks)
                    {
                        ErrorScanTrack.Value = HighestErrorScan;
                        InfoExtractTrack.Value = HighestInfoExtract;
                        GigaSearchTrack.Value = HighestGigaSearch;
                        WaybackTrackTrack.Value = HighestWaybackTrack;
                        track.Enabled = false;
                    }
                }
                else
                {
                    ErrorScanTrack.Value--;
                    HighestErrorScan--;
                }


                // Calculate the total of the Strength Skills
                int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                DigiSoulStat.Text = halvedValue.ToString();

            }
        }

        public void InfoExtractTrack_Scroll(object sender, EventArgs e)
        {


            // Compare prior maximum to current value
            if (HighestInfoExtract < InfoExtractTrack.Value)
            {
                HighestInfoExtract++;
                InfoExtractTrack.Value = HighestInfoExtract;

                // Spent Skill Points
                TrackBar[] tracks = new TrackBar[] { ErrorScanTrack, InfoExtractTrack, GigaSearchTrack, WaybackTrackTrack };

                DialogResult BoostCarry = MessageBox.Show("Do you want to increase your Info Extract power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show("Info Extract power increased!");
                    foreach (TrackBar track in tracks)
                    {
                        ErrorScanTrack.Value = HighestErrorScan;
                        InfoExtractTrack.Value = HighestInfoExtract;
                        GigaSearchTrack.Value = HighestGigaSearch;
                        WaybackTrackTrack.Value = HighestWaybackTrack;
                        track.Enabled = false;
                    }
                }
                else
                {
                    InfoExtractTrack.Value--;
                    HighestInfoExtract--;
                }


                // Calculate the total of the Strength Skills
                int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

                // Halve the totalValue and round up
                int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

                // Output the halvedValue to the text box
                DigiSoulStat.Text = halvedValue.ToString();

            }
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
        int TamerLevel;
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

            int.TryParse(TamersLevel.Text, out TamerLevel);
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
            TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack, ErrorScanTrack, InfoExtractTrack, GigaSearchTrack, WaybackTrackTrack };

            foreach (TrackBar track in tracks)
            {
                track.Enabled = true;
            };

            SaveCharacterInformation();

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

            if (CrestSelection.Text == "")
            {
                LoseBond.Enabled = false;
                GainBond.Enabled = false;
                Value.Enabled = false;
                CareMistakeButton.Enabled = false;
            }
            else if (CrestSelection.Text != "")
            {
                LoseBond.Enabled = true;
                GainBond.Enabled = true;
                Value.Enabled = true;
                CareMistakeButton.Enabled = true;
            }
        }

        private void label28_Click_1(object sender, EventArgs e)
        {

        }

        String RookieInheritOne = "";
        String RookieInheritTwo = "";
        String RookieInheritThree = "";
        String ChampionInheritOne = "";
        String ChampionInheritTwo = "";
        String ChampionInheritThree = "";
        String UltimateInheritOne = "";
        String UltimateInheritTwo = "";
        String UltimateInheritThree = "";


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
                    RookieEvolution = true;
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;
                    HaveMeal.Enabled = true;

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
                    BasicAttackHardFail.Text = "User can't attack next turn. (stunned)";
                    BasicAttackFail.Text = "No effect.";
                    BasicAttackPartFail.Text = "Mutually unable to attack next turn. (stunned)";
                    BasicAttackPartHit.Text = "-2HP on target.";
                    BasicAttackHit.Text = "Mutually stunned. -2HP on target.";
                    BasicAttackHardHit.Text = "Target stunned. -5HP on target.";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "2";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "-3HP on user.";
                    StandardAttackFail.Text = "No effect.";
                    StandardAttackPartFail.Text = "Next attack on user is nerfed. (blocks)";
                    StandardAttackPartHit.Text = "-3HP on target.";
                    StandardAttackHit.Text = "Blocks once. -3HP on target.";
                    StandardAttackHardHit.Text = "Blocks twice. -6HP on target.";
                    StandardDiceMin.Text = "3";
                    StandardDiceMax.Text = "5";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "-3HP on user.";
                    SpecialAttackFail.Text = "No effect.";
                    SpecialAttackPartHit.Text = "-3HP on target.";
                    SpecialAttackPartFail.Text = "3 turn recurring -1HP on target.";
                    SpecialAttackHit.Text = "-3HP on target. 3 turn recurring -1HP.";
                    SpecialAttackHardHit.Text = "-6HP on target. 3 turn recurring -2HP.";
                    SpecialDiceMin.Text = "6";
                    SpecialDiceMax.Text = "8";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "2 recurring damage on user for 3 turns.";
                    SuperAttackFail.Text = "No effect.";
                    SuperAttackPartFail.Text = "-3HP to target and 1 user ally near them.";
                    SuperAttackPartHit.Text = "-3HP to target.";
                    SuperAttackHit.Text = "-3HP to target and 1 target ally near them.";
                    SuperAttackHardHit.Text = "-6HP to target and 2 target ally near them.";
                    SuperDiceMin.Text = "9";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Agumon Quirks
                    CurrentQuirkOne.Text = "Light In Darkness - Spend a point of Bond to illuminate the scene";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "Firewall Guard - 1 damage to failed attackers on guard.";
                    InheritableQuirkTwo.Text = "Empathy and Carry - Roll for Empathy or Carry Checks.";
                    InheritableQuirkThree.Text = "Reinforcing Rage - If Tamer wounded, buff attack roll.";

                    RookieInheritOne = InheritableQuirkOne.Text;
                    RookieInheritTwo = InheritableQuirkTwo.Text;
                    RookieInheritThree = InheritableQuirkThree.Text;

                    // Get Inheritables
                    RookieInheritOne = InheritableQuirkOne.Text;
                    RookieInheritTwo = InheritableQuirkTwo.Text;
                    RookieInheritThree = InheritableQuirkThree.Text;
                }
                else if (DigimonPartner == "Commandramon")
                {
                    RecordRookie = "Commandramon";
                    RookieEvolution = true;
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;
                    HaveMeal.Enabled = true;

                    // Commandramon Details
                    DigimonField.Text = "Metal Empire";
                    DigitalFrame.Text = "8";
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
                    BasicAttackHardFail.Text = "User can't attack next turn. (stunned)";
                    BasicAttackFail.Text = "No effect.";
                    BasicAttackPartFail.Text = "Mutually unable to attack next turn. (stunned)";
                    BasicAttackPartHit.Text = "-2HP on target.";
                    BasicAttackHit.Text = "Mutually stunned. -2HP on target.";
                    BasicAttackHardHit.Text = "Target stunned. -5HP on target.";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "2";

                    //Standard Move
                    StandardAttack.Text = "M16 Assassin";
                    StandardAttackHardFail.Text = "User can't attack next turn. (stunned)";
                    StandardAttackFail.Text = "No effect.";
                    StandardAttackPartFail.Text = "Nearby enemies target user next turn. (baited)";
                    StandardAttackPartHit.Text = "-1HP to target and 2 target allies near them.";
                    StandardAttackHit.Text = "Nearby enemies baited. -1HP to target and 2 allies.";
                    StandardAttackHardHit.Text = "All enemies baited. -2HP to target and all allies.";
                    StandardDiceMin.Text = "3";
                    StandardDiceMax.Text = "5";

                    //Special Move
                    SpecialAttack.Text = "DCD Bomb";
                    SpecialAttackHardFail.Text = "-3HP to user and 1 user ally near them.";
                    SpecialAttackFail.Text = "No effect.";
                    SpecialAttackPartFail.Text = "-3HP to target and 1 user ally near them.";
                    SpecialAttackPartHit.Text = "-3HP to target.";
                    SpecialAttackHit.Text = "-3HP to target and 1 target ally near them.";
                    SpecialAttackHardHit.Text = "-6HP to target and -3HP to 2 nearby allies.";
                    SpecialDiceMin.Text = "6";
                    SpecialDiceMax.Text = "8";

                    //Super Move
                    SuperAttack.Text = "Sniper Tag";
                    SuperAttackHardFail.Text = "User's next attack roll is nerfed.";
                    SuperAttackFail.Text = "No effect.";
                    SuperAttackPartFail.Text = "Next attack on target is buffed.";
                    SuperAttackPartHit.Text = "-3HP to target.";
                    SuperAttackHit.Text = "-3HP to target. Next attack on target is buffed.";
                    SuperAttackHardHit.Text = "-6HP to target. Buff attacks on target this round.";
                    SuperDiceMin.Text = "9";
                    SuperDiceMax.Text = "10";

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "Bomber Buddy - Spend a point of Bond to borrow a DCD Bomb.";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "Cover-Fire Guard - All nearby enemy attack rolls are nerfed.";
                    InheritableQuirkTwo.Text = "Investigation and Reflex - Roll for Investigation or Reflex Checks.";
                    InheritableQuirkThree.Text = "Iron Spirit - Increase Digital Frame by 1, then each evolution";

                    // Get Inheritables
                    RookieInheritOne = InheritableQuirkOne.Text;
                    RookieInheritTwo = InheritableQuirkTwo.Text;
                    RookieInheritThree = InheritableQuirkThree.Text;
                }
                //Champions
                else if (DigimonPartner == "Numemon")
                {
                    RecordChampion = "Numemon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = true;
                    CrestSelection.SelectedIndex = -1;
                    CrestSelection.Enabled = true;

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
                    DigimonStrength.Text = "3";
                    DigimonAgility.Text = "3";
                    DigimonVibes.Text = "3";
                    DigimonWits.Text = "3";
                    DigimonEducation.Text = "3";

                    // Commandramon Moves

                    // Commandramon Quirks
                    CurrentQuirkOne.Text = "____";
                    CurrentQuirkTwo.Text = "____";
                    InheritableQuirkOne.Text = "____";
                    InheritableQuirkTwo.Text = "____";
                    InheritableQuirkThree.Text = "____";
                }
                else if (DigimonPartner == "Greymon")
                {
                    RecordChampion = "Greymon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Greymon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Greymon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Greymon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Greymon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";

                }
                else if (DigimonPartner == "Tyrannomon")
                {
                    RecordChampion = "Tyrannomon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Tyrannomon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Tyrannomon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Tyrannomon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Tyrannomon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Tuskmon")
                {
                    RecordChampion = "Tuskmon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Tuskmon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Tuskmon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Tuskmon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Tuskmon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Flarizamon")
                {
                    RecordChampion = "Flarizamon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Flarizamon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Flarizamon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Flarizamon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Flarizamon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Growlmon")
                {
                    RecordChampion = "Growlmon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Growlmon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Growlmon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Growlmon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Growlmon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Hi-Commandramon")
                {
                    RecordChampion = "Hi-Commandramon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Hi-Commandramon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Hi-Commandramon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Hi-Commandramon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Hi-Commandramon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";

                }
                else if (DigimonPartner == "Centarumon")
                {
                    RecordChampion = "Centarumon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Centarumon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Centarumon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Centarumon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Centarumon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Deputymon")
                {
                    RecordChampion = "Deputymon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Deputymon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Deputymon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Deputymon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Deputymon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Sealsdramon")
                {
                    RecordChampion = "Sealsdramon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Sealsdramon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Sealsdramon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Sealsdramon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Sealsdramon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else if (DigimonPartner == "Clockmon")
                {
                    RecordChampion = "Clockmon";
                    RookieEvolution = false;
                    ChampionEvolution = true;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

                    // Clockmon Details
                    DigimonField.Text = "Dragon's Roar";
                    DigitalFrame.Text = "7";
                    CoreHPNow.Text = MaxHealth.Text;
                    CoreHPMax.Text = MaxHealth.Text;
                    MoveSpeed.Text = "5";
                    Attribute.Text = "Vaccine";
                    WeaknessElement.Text = "Ice";
                    ResistanceElement.Text = "Filth";

                    // Clockmon Stats
                    DigimonStrength.Text = "4";
                    DigimonAgility.Text = "4";
                    DigimonVibes.Text = "4";
                    DigimonWits.Text = "4";
                    DigimonEducation.Text = "4";

                    // Clockmon Moves
                    //Basic Move
                    BasicAttack.Text = "Headbutt";
                    BasicAttackHardFail.Text = "";
                    BasicAttackFail.Text = "";
                    BasicAttackPartFail.Text = "";
                    BasicAttackPartHit.Text = "";
                    BasicAttackHit.Text = "";
                    BasicAttackHardHit.Text = "";
                    BasicDiceMin.Text = "1";
                    BasicDiceMax.Text = "3";
                    BasicElement.Text = "Slamming";

                    //Standard Move
                    StandardAttack.Text = "Claw Attack";
                    StandardAttackHardFail.Text = "";
                    StandardAttackFail.Text = "";
                    StandardAttackPartFail.Text = "";
                    StandardAttackPartHit.Text = "";
                    StandardAttackHit.Text = "";
                    StandardAttackHardHit.Text = "";
                    StandardDiceMin.Text = "4";
                    StandardDiceMax.Text = "6";
                    StandardElement.Text = "Slashing";

                    //Special Move
                    SpecialAttack.Text = "Pepper Breath";
                    SpecialAttackHardFail.Text = "";
                    SpecialAttackFail.Text = "";
                    SpecialAttackPartHit.Text = "";
                    SpecialAttackPartFail.Text = "";
                    SpecialAttackHit.Text = "";
                    SpecialAttackHardHit.Text = "";
                    SpecialDiceMin.Text = "7";
                    SpecialDiceMax.Text = "9";
                    SpecialElement.Text = "Fire";

                    //Super Move
                    SuperAttack.Text = "Spitfire Blast";
                    SuperAttackHardFail.Text = "";
                    SuperAttackFail.Text = "";
                    SuperAttackPartFail.Text = "";
                    SuperAttackPartHit.Text = "";
                    SuperAttackHit.Text = "";
                    SuperAttackHardHit.Text = "";
                    SuperDiceMin.Text = "10";
                    SuperDiceMax.Text = "10";
                    SuperElement.Text = "Fire";

                    // Clockmon Quirks
                    CurrentQuirkOne.Text = "";
                    CurrentQuirkTwo.Text = "";
                    InheritableQuirkOne.Text = "";
                    InheritableQuirkTwo.Text = "";
                    InheritableQuirkThree.Text = "";
                }
                else
                {
                    RookieEvolution = false;
                    ChampionEvolution = false;
                    UltimateEvolution = false;
                    MegaEvolution = false;
                    DarkEvolution = false;

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
                    //Basic Move
                    BasicAttack.Text = "____";
                    BasicAttackHardFail.Text = "____";
                    BasicAttackFail.Text = "____";
                    BasicAttackPartFail.Text = "____";
                    BasicAttackPartHit.Text = "____";
                    BasicAttackHit.Text = "____";
                    BasicAttackHardHit.Text = "____";
                    BasicDiceMin.Text = "_";
                    BasicDiceMax.Text = "_";
                    BasicElement.Text = "____";

                    //Standard Move
                    StandardAttack.Text = "____";
                    StandardAttackHardFail.Text = "____";
                    StandardAttackFail.Text = "____";
                    StandardAttackPartFail.Text = "____";
                    StandardAttackPartHit.Text = "____";
                    StandardAttackHit.Text = "____";
                    StandardAttackHardHit.Text = "____";
                    StandardDiceMin.Text = "_";
                    StandardDiceMax.Text = "_";
                    StandardElement.Text = "____";

                    //Special Move
                    SpecialAttack.Text = "____";
                    SpecialAttackHardFail.Text = "____";
                    SpecialAttackFail.Text = "____";
                    SpecialAttackPartFail.Text = "____";
                    SpecialAttackPartHit.Text = "____";
                    SpecialAttackHit.Text = "____";
                    SpecialAttackHardHit.Text = "____";
                    SpecialDiceMin.Text = "_";
                    SpecialDiceMax.Text = "_";
                    SpecialElement.Text = "____";

                    //Super Move
                    SuperAttack.Text = "____";
                    SuperAttackHardFail.Text = "____";
                    SuperAttackFail.Text = "____";
                    SuperAttackPartFail.Text = "____";
                    SuperAttackPartHit.Text = "____";
                    SuperAttackHit.Text = "____";
                    SuperAttackHardHit.Text = "____";
                    SuperDiceMin.Text = "_";
                    SuperDiceMax.Text = "_";
                    SuperElement.Text = "____";


                    // ____ Quirks
                    CurrentQuirkOne.Text = "_";
                    CurrentQuirkTwo.Text = "_";
                    InheritableQuirkOne.Text = "_";
                    InheritableQuirkTwo.Text = "_";
                    InheritableQuirkThree.Text = "_";

                }




                if (RookieEvolution == true)
                {
                    RookieInheritOne = InheritableQuirkOne.Text;
                    RookieInheritTwo = InheritableQuirkTwo.Text;
                    RookieInheritThree = InheritableQuirkThree.Text;
                }
                else if (ChampionEvolution == true)
                {
                    InheritedQuirkOne.Text = RookieInheritOne;
                    InheritedQuirkTwo.Text = RookieInheritTwo;
                    InheritedQuirkThree.Text = RookieInheritThree;

                    ChampionInheritOne = InheritableQuirkOne.Text;
                    ChampionInheritTwo = InheritableQuirkTwo.Text;
                    ChampionInheritThree = InheritableQuirkThree.Text;
                }
                else if (UltimateEvolution == true)
                {
                    InheritedQuirkFour.Text = ChampionInheritOne;
                    InheritedQuirkFive.Text = ChampionInheritTwo;
                    InheritedQuirkSix.Text = ChampionInheritThree;

                    UltimateInheritOne = InheritableQuirkOne.Text;
                    UltimateInheritTwo = InheritableQuirkTwo.Text;
                    UltimateInheritThree = InheritableQuirkThree.Text;
                }
                else if (MegaEvolution == true)
                {
                    InheritedQuirkFour.Text = UltimateInheritOne;
                    InheritedQuirkFive.Text = UltimateInheritTwo;
                    InheritedQuirkSix.Text = UltimateInheritThree;
                }

            }
            if (Partner.Text == "")
            {
                ActBasicAttack.Enabled = false;
                ActStandardAttack.Enabled = false;
                ActSpecialAttack.Enabled = false;
                ActSuperAttack.Enabled = false;
                AutoSelect.Enabled = false;
                AutoSelect.Enabled = false;
                GaurdAction.Enabled = false;
                DigimonStrengthRoll.Enabled = false;
                DigimonAgilityRoll.Enabled = false;
                DigimonVibesRoll.Enabled = false;
                DigimonWitsRoll.Enabled = false;
                DigimonEducationRoll.Enabled = false;
                StrengthMeal.Enabled = false;
                AgilityMeal.Enabled = false;
                VibesMeal.Enabled = false;
                WitsMeal.Enabled = false;
                EducationMeal.Enabled = false;
                HaveMeal.Enabled = false;
                RookieInheritOne = "";
                RookieInheritTwo = "";
                RookieInheritThree = "";
                ChampionInheritOne = "";
                ChampionInheritTwo = "";
                ChampionInheritThree = "";
                UltimateInheritOne = "";
                UltimateInheritTwo = "";
                UltimateInheritThree = "";
                InheritedQuirkOne.Text = "_";
                InheritedQuirkTwo.Text = "_";
                InheritedQuirkThree.Text = "_";
                InheritedQuirkFour.Text = "_";
                InheritedQuirkFive.Text = "_";
                InheritedQuirkSix.Text = "_";
                InheritedQuirkSeven.Text = "_";
                InheritedQuirkEight.Text = "_";
                InheritedQuirkNine.Text = "_";
            }
            else if (Partner.Text != "")
            {
                ActBasicAttack.Enabled = true;
                ActStandardAttack.Enabled = true;
                ActSpecialAttack.Enabled = true;
                ActSuperAttack.Enabled = true;
                AutoSelect.Enabled = true;
                GaurdAction.Enabled = true;
                DigimonStrengthRoll.Enabled = true;
                DigimonAgilityRoll.Enabled = true;
                DigimonVibesRoll.Enabled = true;
                DigimonWitsRoll.Enabled = true;
                DigimonEducationRoll.Enabled = true;

                int NextPage = TamerDigimon.SelectedIndex;
                TamerDigimon.SelectedIndex = 0;
                UpdateInventory.PerformClick();
                TamerDigimon.SelectedIndex = NextPage;
            }


            DigiAttackRoll.Text = "";
            SaveCharacterInformation();
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
                Partner.Items.Remove(RecordChampion);
                Partner.Items.Remove(RecordUltimate);
                Partner.Items.Remove(RecordMega);
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
                    Partner.Items.Remove("Numemon");
                    Partner.SelectedIndex = -1;
                    Partner.Enabled = true;
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


                SaveCharacterInformation();
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
        bool RookieEvolution = false;
        bool ChampionEvolution = false;
        bool UltimateEvolution = false;
        bool MegaEvolution = false;
        bool DarkEvolution = false;

        private void Digivolve_Click(object sender, EventArgs e)
        {
            if (Digivolve.Text == "De-Digivolve")
            {
                Digivolve.Text = "Digivolve";

                Partner.SelectedItem = RecordRookie;
                Partner.Items.Remove(RecordChampion);
                Partner.Items.Remove(RecordUltimate);
                Partner.Items.Remove(RecordMega);
            }
            else
            {

                Digivolve.Text = "De-Digivolve";
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


                        if (DigivolutionRoll > DarkCheck)
                        {

                            if (ChampionLevel.Text == "________")
                            {

                                // Agumon Evolution Systems
                                if (Partner.Text == "Agumon")
                                {
                                    RecordRookie = "Agumon";

                                    if (maxDiet == Diet.Strength)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Greymon");
                                        Partner.Items.Add("Greymon");
                                        Partner.SelectedItem = "Greymon";
                                        ChampionLevel.Text = "Greymon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                    else if (maxDiet == Diet.Agility)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tuskmon");
                                        Partner.Items.Add("Tuskmon");
                                        Partner.SelectedItem = "Tuskmon";
                                        ChampionLevel.Text = "Tuskmon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                    else if (maxDiet == Diet.Vibes)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Growlmon");
                                        Partner.Items.Add("Growlmon");
                                        Partner.SelectedItem = "Growlmon";
                                        ChampionLevel.Text = "Growlmon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                    else if (maxDiet == Diet.Wits)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Flarizamon");
                                        Partner.Items.Add("Flarizamon");
                                        Partner.SelectedItem = "Flarizamon";
                                        ChampionLevel.Text = "Flarizamon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                    else if (maxDiet == Diet.Education)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tyrannomon");
                                        Partner.Items.Add("Tyrannomon");
                                        Partner.SelectedItem = "Tyrannomon";
                                        ChampionLevel.Text = "Tyrannomon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                }

                                // Commandramon Evolution Systems
                                else if (Partner.Text == "Commandramon")
                                {
                                    RecordRookie = "Commandramon";

                                    if (maxDiet == Diet.Strength)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Hi-Commandramon");
                                        Partner.Items.Add("Hi-Commandramon");
                                        Partner.SelectedItem = "Hi-Commandramon";
                                        ChampionLevel.Text = "Hi-Commandramon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;

                                    }
                                    else if (maxDiet == Diet.Agility)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Centarumon");
                                        Partner.Items.Add("Centarumon");
                                        Partner.SelectedItem = "Centarumon";
                                        ChampionLevel.Text = "Centarumon";
                                        ChampionEvolution = true;
                                    }
                                    else if (maxDiet == Diet.Vibes)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Deputymon");
                                        Partner.Items.Add("Deputymon");
                                        Partner.SelectedItem = "Deputymon";
                                        ChampionLevel.Text = "Deputymon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                    else if (maxDiet == Diet.Wits)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Sealsdramon");
                                        Partner.Items.Add("Sealsdramon");
                                        Partner.SelectedItem = "Sealsdramon";
                                        ChampionLevel.Text = "Sealsdramon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                    else if (maxDiet == Diet.Education)
                                    {
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Clockmon");
                                        Partner.Items.Add("Clockmon");
                                        Partner.SelectedItem = "Clockmon";
                                        ChampionLevel.Text = "Clockmon";
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: {ChampionLevel.Text}");
                                Partner.Items.Add(ChampionLevel.Text);
                                Partner.SelectedItem = ChampionLevel.Text;
                                ChampionLevel.Text = ChampionLevel.Text;
                                RookieEvolution = false;
                                ChampionEvolution = true;
                            }

                        }
                        else
                        {
                            MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nDark Digivolution Triggered. \nEvolution Result: Numemon");
                            Partner.Items.Add("Numemon");
                            Partner.SelectedItem = "Numemon";
                            DarkEvolution = true;
                            RookieEvolution = false;
                            ChampionEvolution = true;
                            CrestSelection.SelectedIndex = -1;
                            CrestSelection.Enabled = true;
                        }
                    }


                }
                RecordChampion = ChampionLevel.Text;
                RecordUltimate = UltimateLevel.Text;
                RecordMega = MegaLevel.Text;

                SaveCharacterInformation();

            }
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

            // Unlock Ultimate Evolutions
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

            SaveCharacterInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Partner.Text != "")
            {
                // Increment Days
                int DayCount;
                int.TryParse(Day.Text, out DayCount);
                DayCount = DayCount + 1;
                Day.Text = DayCount.ToString();
            };


            if (InjuryFive.Checked == true)
            {
                if (WoundFive.Checked != true)
                {
                    InjuryFive.Checked = false;
                }
            }
            else if (InjuryFour.Checked == true)
            {
                if (WoundFour.Checked != true)
                {
                    InjuryFour.Checked = false;
                }
            }
            else if (InjuryThree.Checked == true)
            {
                if (WoundThree.Checked != true)
                {
                    InjuryThree.Checked = false;
                }
            }
            else if (InjuryTwo.Checked == true)
            {
                if (WoundTwo.Checked != true)
                {
                    InjuryTwo.Checked = false;
                }
            }
            else if (InjuryOne.Checked == true)
            {
                if (WoundOne.Checked != true)
                {
                    InjuryOne.Checked = false;
                }
            }

            SaveCharacterInformation();

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
                    MessageBox.Show($"Strength Roll: {IndividualRolls}\n Total Roll: {TotalResult}");
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
                    MessageBox.Show($"Agility Roll: {IndividualRolls}\n Total Roll: {TotalResult}");
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
                    MessageBox.Show($"Vibes Roll: {IndividualRolls}\n Total Roll: {TotalResult}");
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
                    MessageBox.Show($"Wits Roll: {IndividualRolls}\n Total Roll: {TotalResult}");
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
                    MessageBox.Show($"Education Roll: {IndividualRolls}\n Total Roll: {TotalResult}");
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



        // Get stat increases
        int StrengthIncrease;
        int AgilityIncrease;
        int VibesIncrease;
        int WitsIncrease;
        int EducationIncrease;

        int MeatSupply;
        int VeggiesSupply;
        int BreadSupply;
        int FruitSupply;
        int FishSupply;

        // Split QualityItems into the stat groups
        string[] StrengthQuality;
        string[] AgilityQuality;
        string[] WitsQuality;
        string[] VibesQuality;
        string[] EducationQuality;
        string[] AlternativeQuality;

        // Split QuantityItems into the stat groups
        string[] MeatQuantity;
        string[] VeggiesQuantity;
        string[] FruitQuantity;
        string[] BreadQuantity;
        string[] FishQuantity;
        string[] AlternativeQuantity;

        // Retain AlternativeItems for the inventory
        string[] AlternativeItems;

        private void UpdateInventory_Click(object sender, EventArgs e)
        {
            // Read in text, splitting it at ",", and put them into an array
            string InventoryItems = ReadableInventory.Text;
            string[] Items = InventoryItems.Split(',');

            // Split into two arrays, QualityItems and Quantity Items, based on whether they contain + or *
            string[] QualityItems = new string[Items.Length];
            string[] QuantityItems = new string[Items.Length];
            AlternativeItems = new string[Items.Length];

            int QualityIndex = 0;
            int QuantityIndex = 0;
            int AlternativeIndex = 0;

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
                else
                {
                    AlternativeItems[AlternativeIndex++] = item;
                }
            }

            // Shorten arrays if necessary (optional)
            QualityItems = QualityItems.Take(QualityIndex).ToArray();
            QuantityItems = QuantityItems.Take(QuantityIndex).ToArray();
            AlternativeItems = AlternativeItems.Take(QuantityIndex).ToArray();

            // Split QualityItems into the stat groups
            StrengthQuality = new string[QualityItems.Length];
            AgilityQuality = new string[QualityItems.Length];
            WitsQuality = new string[QualityItems.Length];
            VibesQuality = new string[QualityItems.Length];
            EducationQuality = new string[QualityItems.Length];
            AlternativeQuality = new string[QualityItems.Length];


            // Getting array lengths
            int StrengthQualityIndex = 0;
            int AgilityQualityIndex = 0;
            int WitsQualityIndex = 0;
            int VibesQualityIndex = 0;
            int EducationQualityIndex = 0;
            int AlternativeQualityIndex = 0;

            // Loop through each inventory item
            foreach (string item in QualityItems)
            {
                if (item.Contains("Strength"))
                {
                    StrengthQuality[StrengthQualityIndex++] = item;
                }
                else if (item.Contains("Agility"))
                {
                    AgilityQuality[AgilityQualityIndex++] = item;
                }
                else if (item.Contains("Wits"))
                {
                    WitsQuality[WitsQualityIndex++] = item;
                }
                else if (item.Contains("Vibes"))
                {
                    VibesQuality[VibesQualityIndex++] = item;
                }
                else if (item.Contains("Education"))
                {
                    EducationQuality[EducationQualityIndex++] = item;
                }
                else
                {
                    AlternativeQuality[AlternativeQualityIndex++] = item;
                }
            }

            // Shorten arrays if necessary (optional)
            StrengthQuality = StrengthQuality.Take(StrengthQualityIndex).ToArray();
            AgilityQuality = AgilityQuality.Take(AgilityQualityIndex).ToArray();
            WitsQuality = WitsQuality.Take(WitsQualityIndex).ToArray();
            VibesQuality = VibesQuality.Take(VibesQualityIndex).ToArray();
            EducationQuality = EducationQuality.Take(EducationQualityIndex).ToArray();
            AlternativeQuality = AlternativeQuality.Take(AlternativeQualityIndex).ToArray();

            int StrengthBoost = 0;
            int AgilityBoost = 0;
            int WitsBoost = 0;
            int VibesBoost = 0;
            int EducationBoost = 0;

            // using the smaller arrays
            foreach (string item in StrengthQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = BoostHolster.IndexOf(')');
                BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                StrengthBoost = StrengthBoost + StatBoost;
            }
            foreach (string item in AgilityQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = BoostHolster.IndexOf(')');
                BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                AgilityBoost = AgilityBoost + StatBoost;
            }
            foreach (string item in VibesQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = BoostHolster.IndexOf(')');
                BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                VibesBoost = VibesBoost + StatBoost;
            }
            foreach (string item in WitsQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = BoostHolster.IndexOf(')');
                BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                WitsBoost = WitsBoost + StatBoost;
            }
            foreach (string item in EducationQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = BoostHolster.IndexOf(')');
                BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                EducationBoost = EducationBoost + StatBoost;
            }

            StrengthIncrease = StrengthBoost;
            AgilityIncrease = AgilityBoost;
            VibesIncrease = VibesBoost;
            WitsIncrease = WitsBoost;
            EducationIncrease = EducationBoost;


            // Constructing a String from the arrays
            StringBuilder inventoryText = new StringBuilder();

            // Append formatted content for quality items
            if (StrengthQuality.Length > 0)
            {
                inventoryText.Append(string.Join(",", StrengthQuality.Where(StrengthItem => !string.IsNullOrEmpty(StrengthItem))));
                inventoryText.Append(", ");
            }
            if (AgilityQuality.Length > 0)
            {
                inventoryText.Append(string.Join(",", AgilityQuality.Where(AgilityItem => !string.IsNullOrEmpty(AgilityItem))));
                inventoryText.Append(", ");
            }
            if (VibesQuality.Length > 0)
            {
                inventoryText.Append(string.Join(",", VibesQuality.Where(VibesItem => !string.IsNullOrEmpty(VibesItem))));
                inventoryText.Append(", ");
            }
            if (WitsQuality.Length > 0)
            {
                inventoryText.Append(string.Join(",", WitsQuality.Where(WitsItem => !string.IsNullOrEmpty(WitsItem))));
                inventoryText.Append(", ");
            }
            if (EducationQuality.Length > 0)
            {
                inventoryText.Append(string.Join(",", EducationQuality.Where(EducationItem => !string.IsNullOrEmpty(EducationItem))));
                inventoryText.Append(", ");
            }
            if (AlternativeQuality.Length > 0)
            {
                inventoryText.Append(string.Join(",", AlternativeQuality.Where(AlternativeItem => !string.IsNullOrEmpty(AlternativeItem))));
                inventoryText.Append(", ");
            }



            // Split QuantityItems into the stat groups
            MeatQuantity = new string[QuantityItems.Length];
            VeggiesQuantity = new string[QuantityItems.Length];
            FruitQuantity = new string[QuantityItems.Length];
            BreadQuantity = new string[QuantityItems.Length];
            FishQuantity = new string[QuantityItems.Length];
            AlternativeQuantity = new string[QuantityItems.Length];


            // Getting array lengths
            int MeatQuantityIndex = 0;
            int VeggiesQuantityIndex = 0;
            int FruitQuantityIndex = 0;
            int BreadQuantityIndex = 0;
            int FishQuantityIndex = 0;
            int AlternativeQuantityIndex = 0;


            // Loop through each inventory item
            foreach (string item in QuantityItems)
            {
                if (item.Contains("Meat"))
                {
                    MeatQuantity[MeatQuantityIndex++] = item;
                }
                else if (item.Contains("Veggies"))
                {
                    VeggiesQuantity[VeggiesQuantityIndex++] = item;
                }
                else if (item.Contains("Fruit"))
                {
                    FruitQuantity[FruitQuantityIndex++] = item;
                }
                else if (item.Contains("Bread"))
                {
                    BreadQuantity[BreadQuantityIndex++] = item;
                }
                else if (item.Contains("Fish"))
                {
                    FishQuantity[FishQuantityIndex++] = item;
                }
                else
                {
                    AlternativeQuantity[AlternativeQuantityIndex++] = item;
                }
            }



            // Shorten arrays if necessary (optional)
            MeatQuantity = MeatQuantity.Take(MeatQuantityIndex).ToArray();
            VeggiesQuantity = VeggiesQuantity.Take(VeggiesQuantityIndex).ToArray();
            FruitQuantity = FruitQuantity.Take(FruitQuantityIndex).ToArray();
            BreadQuantity = BreadQuantity.Take(BreadQuantityIndex).ToArray();
            FishQuantity = FishQuantity.Take(FishQuantityIndex).ToArray();
            AlternativeQuantity = AlternativeQuantity.Take(AlternativeQuantityIndex).ToArray();


            int MeatExist = 0;
            int VeggiesExist = 0;
            int FruitExist = 0;
            int BreadExist = 0;
            int FishExist = 0;

            // using the smaller arrays
            foreach (string item in MeatQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = ExistHolster.IndexOf(')');
                ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);

                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                MeatExist = MeatExist + StatExist;
            }
            foreach (string item in VeggiesQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = ExistHolster.IndexOf(')');
                ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);

                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                VeggiesExist = VeggiesExist + StatExist;
            }
            foreach (string item in BreadQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = ExistHolster.IndexOf(')');
                ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);

                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                BreadExist = BreadExist + StatExist;
            }
            foreach (string item in FruitQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = ExistHolster.IndexOf(')');
                ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);

                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                FruitExist = FruitExist + StatExist;
            }
            foreach (string item in FishQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 2);

                // Trim the back to remove ")" and everything after it
                int indexOfClosingBracket = ExistHolster.IndexOf(')');
                ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);

                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                FishExist = FishExist + StatExist;
            }

            MeatSupply = MeatExist;
            VeggiesSupply = VeggiesExist;
            BreadSupply = BreadExist;
            FruitSupply = FruitExist;
            FishSupply = FishExist;


            // Append formatted content for Quantity items
            if (MeatQuantity.Length > 0)
            {
                inventoryText.Append(string.Join(",", MeatQuantity.Where(MeatItem => !string.IsNullOrEmpty(MeatItem))));
                inventoryText.Append(", ");
            }
            if (VeggiesQuantity.Length > 0)
            {
                inventoryText.Append(string.Join(",", VeggiesQuantity.Where(VeggiesItem => !string.IsNullOrEmpty(VeggiesItem))));
                inventoryText.Append(", ");
            }
            if (BreadQuantity.Length > 0)
            {
                inventoryText.Append(string.Join(",", BreadQuantity.Where(BreadItem => !string.IsNullOrEmpty(BreadItem))));
                inventoryText.Append(", ");
            }
            if (FruitQuantity.Length > 0)
            {
                inventoryText.Append(string.Join(",", FruitQuantity.Where(FruitItem => !string.IsNullOrEmpty(FruitItem))));
                inventoryText.Append(", ");
            }
            if (FishQuantity.Length > 0)
            {
                inventoryText.Append(string.Join(",", FishQuantity.Where(FishItem => !string.IsNullOrEmpty(FishItem))));
                inventoryText.Append(", ");
            }
            if (AlternativeQuantity.Length > 0)
            {
                inventoryText.Append(string.Join(",", AlternativeQuantity.Where(AlternativeItem => !string.IsNullOrEmpty(AlternativeItem))));
                inventoryText.Append(", ");
            }

            // Append non-useful items
            if (AlternativeItems.Length > 0)
            {
                inventoryText.Append(string.Join(",", AlternativeItems.Where(itemPart => !string.IsNullOrEmpty(itemPart))));
                inventoryText.Append(", ");
            }

            // Condense to String
            String FinalisedInventory = inventoryText.ToString();

            // Remove leading/trailing spaces
            FinalisedInventory = FinalisedInventory.Trim();

            // Replace multiple spaces with single space
            FinalisedInventory = Regex.Replace(FinalisedInventory, @"\s+", " ");


            // Assign the final string to ReadableInventory.Text
            ReadableInventory.Text = "";
            ReadableInventory.Text = FinalisedInventory;


            // Update stats from this
            StrengthStat.Text = "";
            AgilityStat.Text = "";
            VibesStat.Text = "";
            WitsStat.Text = "";
            KnowledgeStat.Text = "";

            if (MeatSupply > 0)
            {
                StrengthMeal.Enabled = true;
            }
            else
            {
                StrengthMeal.Enabled = false;
            }

            if (VeggiesSupply > 0)
            {
                AgilityMeal.Enabled = true;
            }
            else
            {
                AgilityMeal.Enabled = false;
            }

            if (BreadSupply > 0)
            {
                VibesMeal.Enabled = true;
            }
            else
            {
                VibesMeal.Enabled = false;
            }

            if (FruitSupply > 0)
            {
                WitsMeal.Enabled = true;
            }
            else
            {
                WitsMeal.Enabled = false;
            }

            if (FishSupply > 0)
            {
                EducationMeal.Enabled = true;
            }
            else
            {
                EducationMeal.Enabled = false;
            }


            SaveCharacterInformation();
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
                StrikeInflicted = "Hard Fail - " + StandardAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail - " + StandardAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail - " + StandardAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit - " + StandardAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit - " + StandardAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit - " + StandardAttackHardHit.Text;
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
                StrikeInflicted = "Hard Fail - " + SpecialAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail - " + SpecialAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail - " + SpecialAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit - " + SpecialAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit - " + SpecialAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit - " + SpecialAttackHardHit.Text;
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
                StrikeInflicted = "Hard Fail - " + SuperAttackHardFail.Text;
            }
            else if (TotalResult < TargetDefense - 5)
            {
                StrikeInflicted = "Fail - " + SuperAttackFail.Text;
            }
            else if (TotalResult < TargetDefense)
            {
                StrikeInflicted = "Part Fail - " + SuperAttackPartFail.Text;
            }
            else if (TotalResult < TargetDefense + 5)
            {
                StrikeInflicted = "Part Hit - " + SuperAttackPartHit.Text;
            }
            else if (TotalResult < TargetDefense + 15)
            {
                StrikeInflicted = "Hit - " + SuperAttackHit.Text;
            }
            else
            {
                StrikeInflicted = "Hard Hit - " + SuperAttackHardHit.Text;
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

        private void label31_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter_1(object sender, EventArgs e)
        {

        }

        private void CharacterName_TextChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void MaximumLife_Click(object sender, EventArgs e)
        {

        }

        private void TamersLevel_Click(object sender, EventArgs e)
        {

        }

        private void Day_Click(object sender, EventArgs e)
        {

        }

        private void DigimonStrength_TextChanged(object sender, EventArgs e)
        {
            int DigitalStrength;

            if (RookieEvolution == true)
            {
                DigitalStrength = 2;
            }
            else if (ChampionEvolution == true)
            {
                DigitalStrength = 4;
            }
            else if (UltimateEvolution == true)
            {
                DigitalStrength = 7;
            }
            else
            {
                DigitalStrength = 10;
            }

            if (MealStrength == true)
            {
                DigitalStrength++;
            }

            DigimonStrength.Text = DigitalStrength.ToString();

        }

        private void DigimonAgility_TextChanged(object sender, EventArgs e)
        {
            int DigitalAgility;

            if (RookieEvolution == true)
            {
                DigitalAgility = 2;
            }
            else if (ChampionEvolution == true)
            {
                DigitalAgility = 4;
            }
            else if (UltimateEvolution == true)
            {
                DigitalAgility = 7;
            }
            else
            {
                DigitalAgility = 10;
            }

            if (MealAgility == true)
            {
                DigitalAgility++;
            }

            DigimonAgility.Text = DigitalAgility.ToString();

        }

        private void DigimonVibes_TextChanged(object sender, EventArgs e)
        {
            int DigitalVibes;

            if (RookieEvolution == true)
            {
                DigitalVibes = 2;
            }
            else if (ChampionEvolution == true)
            {
                DigitalVibes = 4;
            }
            else if (UltimateEvolution == true)
            {
                DigitalVibes = 7;
            }
            else
            {
                DigitalVibes = 10;
            }

            if (MealVibes == true)
            {
                DigitalVibes++;
            }

            DigimonVibes.Text = DigitalVibes.ToString();

        }

        private void DigimonWits_TextChanged(object sender, EventArgs e)
        {
            int DigitalWits;

            if (RookieEvolution == true)
            {
                DigitalWits = 2;
            }
            else if (ChampionEvolution == true)
            {
                DigitalWits = 4;
            }
            else if (UltimateEvolution == true)
            {
                DigitalWits = 7;
            }
            else
            {
                DigitalWits = 10;
            }

            if (MealWits == true)
            {
                DigitalWits++;
            }

            DigimonWits.Text = DigitalWits.ToString();

        }

        private void DigimonEducation_TextChanged(object sender, EventArgs e)
        {
            int DigitalEducation;

            if (RookieEvolution == true)
            {
                DigitalEducation = 2;
            }
            else if (ChampionEvolution == true)
            {
                DigitalEducation = 4;
            }
            else if (UltimateEvolution == true)
            {
                DigitalEducation = 7;
            }
            else
            {
                DigitalEducation = 10;
            }

            if (MealEducation == true)
            {
                DigitalEducation++;
            }

            DigimonEducation.Text = DigitalEducation.ToString();

        }

        private void EducationMeal_CheckedChanged(object sender, EventArgs e)
        {
        }

        bool FirstTime = true;

        private void TamerDigimon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                int NextPage = TamerDigimon.SelectedIndex;

                // Update The Inventory
                TamerDigimon.SelectedIndex = 0;
                UpdateInventory.PerformClick();

                TamerDigimon.SelectedIndex = NextPage;
                FirstTime = false;
            }

            UpdateInventory.PerformClick();

        }

        private void DigiAttackRoll_TextChanged(object sender, EventArgs e)
        {
            int DigitalStrike;

            if (RookieEvolution == true)
            {
                DigitalStrike = 2;
            }
            else if (ChampionEvolution == true)
            {
                DigitalStrike = 4;
            }
            else if (UltimateEvolution == true)
            {
                DigitalStrike = 7;
            }
            else
            {
                DigitalStrike = 10;
            }

            if (DigiRollPlusOne.Checked == true)
            {
                DigitalStrike++;
            }

            if (DigiRollPlusTwo.Checked == true)
            {
                DigitalStrike++;
            }

            if (DigiRollMinusOne.Checked == true)
            {
                DigitalStrike--;
            }

            if (DigiRollMinusTwo.Checked == true)
            {
                DigitalStrike--;
            }

            if (MealStrength == true)
            {
                DigitalStrike++;
            }

            DigiAttackRoll.Text = DigitalStrike.ToString();
        }

        private void DigiRollPlusOne_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void DigiRollPlusTwo_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void DigiRollMinusOne_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void DigiRollMinusTwo_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int NumberOfDice = 0;

            DialogResult InitiativeCheck = MessageBox.Show("Is this an Initiative Roll?", "Initiative", MessageBoxButtons.YesNo);
            if (InitiativeCheck == DialogResult.Yes)
            {
                if (MealAgility == true)
                {
                    NumberOfDice++;
                }
            }
            else
            {
                // Apply the modifiers
                if (TamerRollPlusOne.Checked)
                {
                    NumberOfDice++;
                }
                if (TamerRollPlusTwo.Checked)
                {
                    NumberOfDice++;
                }
                if (TamerRollMinusOne.Checked)
                {
                    NumberOfDice--;
                }
                if (TamerRollMinusTwo.Checked)
                {
                    NumberOfDice--;
                }
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
                    TotalResult += CarryTrack.Value * 3;

                    // Display the result
                    MessageBox.Show($"Character Roll: {CoreRoll}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
               
            }
    }
}