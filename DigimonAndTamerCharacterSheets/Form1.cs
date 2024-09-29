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
using static System.Runtime.InteropServices.JavaScript.JSType;
using DigimonAndTamerCharacterSheets.Properties;
namespace DigimonAndTamerCharacterSheets
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            LoadCharacterInformation(); // Load data when the form initializes

            //Reset the options to default
            Partner.Items.Clear();
            ClassBox.Items.Clear();

            try
            {
                // Get all directories containing "mon" in their name
                var DigimonFolders = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Digi"), "*mon", SearchOption.TopDirectoryOnly).Select(Path.GetFileNameWithoutExtension);

                // Get all directories 
                var ClassFolders = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Class"), "*", SearchOption.TopDirectoryOnly).Select(Path.GetFileNameWithoutExtension);

                // Add options to Partner Selection options
                Partner.Items.AddRange(DigimonFolders.ToArray());

                // Add options to Class Selection options
                ClassBox.Items.AddRange(ClassFolders.ToArray());
            }
            catch (Exception ex)
            {
                // Handle potential exceptions
                MessageBox.Show("Error: " + ex.Message);
            }


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
                StrengthDiet.Text = loadedForm.StrengthDiet;
                AgilityDiet.Text = loadedForm.AgilityDiet;
                VibesDiet.Text = loadedForm.VibesDiet;
                WitsDiet.Text = loadedForm.WitsDiet;
                EducationDiet.Text = loadedForm.EducationDiet;
                ErrorScanTrack.Value = loadedForm.ErrorScanTrack;
                InfoExtractTrack.Value = loadedForm.InfoExtractTrack;
                GigaSearchTrack.Value = loadedForm.GigaSearchTrack;
                WaybackTrackTrack.Value = loadedForm.WaybackTrackTrack;
                HighestErrorScan = loadedForm.ErrorScanTrack;
                HighestInfoExtract = loadedForm.InfoExtractTrack;
                HighestGigaSearch = loadedForm.GigaSearchTrack;
                HighestWaybackTrack = loadedForm.WaybackTrackTrack;
                ToiletOne.Checked = loadedForm.ToiletOne;
                ToiletTwo.Checked = loadedForm.ToiletTwo;
                ToiletThree.Checked = loadedForm.ToiletThree;
                CrapOne.Checked = loadedForm.CrapOne;
                CrapTwo.Checked = loadedForm.CrapTwo;
                CrapThree.Checked = loadedForm.CrapThree;
                CrapFour.Checked = loadedForm.CrapFour;
                CrapFive.Checked = loadedForm.CrapFive;
                CrapSix.Checked = loadedForm.CrapSix;
                CrapSeven.Checked = loadedForm.CrapSeven;
                DigiBond.Text = loadedForm.DigiBond;
                GaurdPoints = loadedForm.GaurdPoints;
                EvolutionFilePath = loadedForm.EvolutionFilePath;
                ChampionPath = loadedForm.ChampionPath;
                UltimatePath = loadedForm.UltimatePath;
                MegaPath = loadedForm.MegaPath;
                ClassPath = loadedForm.ClassPath;
                ClassName = loadedForm.ClassName;
                RookieInheritOne = loadedForm.RookieInheritOne;
                RookieInheritTwo = loadedForm.RookieInheritTwo;
                RookieInheritThree = loadedForm.RookieInheritThree;
                ChampionInheritOne = loadedForm.ChampionInheritOne;
                ChampionInheritTwo = loadedForm.ChampionInheritTwo;
                ChampionInheritThree = loadedForm.ChampionInheritThree;
                UltimateInheritOne = loadedForm.UltimateInheritOne;
                UltimateInheritTwo = loadedForm.UltimateInheritTwo;
                UltimateInheritThree = loadedForm.UltimateInheritThree;
                CarryTrack.Enabled = loadedForm.UpgradeSkills;
                ThrowTrack.Enabled = loadedForm.UpgradeSkills;
                HoldTrack.Enabled = loadedForm.UpgradeSkills;
                BalanceTrack.Enabled = loadedForm.UpgradeSkills;
                ParkourTrack.Enabled = loadedForm.UpgradeSkills;
                ReflexTrack.Enabled = loadedForm.UpgradeSkills;
                PerformTrack.Enabled = loadedForm.UpgradeSkills;
                IntimidateTrack.Enabled = loadedForm.UpgradeSkills;
                PersuadeTrack.Enabled = loadedForm.UpgradeSkills;
                InvestigationTrack.Enabled = loadedForm.UpgradeSkills;
                EmpathyTrack.Enabled = loadedForm.UpgradeSkills;
                IngenuityTrack.Enabled = loadedForm.UpgradeSkills;
                TechnologyTrack.Enabled = loadedForm.UpgradeSkills;
                OccultismTrack.Enabled = loadedForm.UpgradeSkills;
                SocietyTrack.Enabled = loadedForm.UpgradeSkills;
                ErrorScanTrack.Enabled = loadedForm.UpgradePowers;
                InfoExtractTrack.Enabled = loadedForm.UpgradePowers;
                GigaSearchTrack.Enabled = loadedForm.UpgradePowers;
                WaybackTrackTrack.Enabled = loadedForm.UpgradePowers;
                FreshEvolution = loadedForm.FreshEvolution;
                ReincarnationTime = loadedForm.ReincarnationTime;
                digiSoulCost = loadedForm.DigiSoulCost;
                ExpCurrent.Text = loadedForm.ExpNow;
                ExpNext.Text = loadedForm.ExpNext;
                RandomOne = loadedForm.RandomOne;
                RandomTwo = loadedForm.RandomTwo;
                RandomThree = loadedForm.RandomThree;
                RandomFour = loadedForm.RandomFour;
                ExpCurrent.Text = loadedForm.ExpCurrent;


                if (ExpCurrent.Text == ExpNext.Text)
                {
                    LevelUp.Enabled = true;
                }

                ClassAssignment();

                if (PowerRollOne.Text == "---")
                {
                    ClassBox.Enabled = true;
                }
                else
                {
                    ClassBox.Enabled = false;
                }

                EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                Partner.Items.Add(EvolutionAddress.DigimonName);
                Partner.SelectedItem = EvolutionAddress.DigimonName;

                DigivolutionDetails();


                if (CardClass)
                {
                    if (RandomOne == 1)
                    {
                        SuperOne.Text = ClassAddress.PowerOne;
                        SuperOneLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomOne == 2)
                    {
                        SuperOne.Text = ClassAddress.PowerTwo;
                        SuperOneLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomOne == 3)
                    {
                        SuperOne.Text = ClassAddress.PowerThree;
                        SuperOneLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomOne == 4)
                    {
                        SuperOne.Text = ClassAddress.PowerFour;
                        SuperOneLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomOne == 5)
                    {
                        SuperOne.Text = ClassAddress.PowerFive;
                        SuperOneLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomOne == 6)
                    {
                        SuperOne.Text = ClassAddress.PowerSix;
                        SuperOneLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomOne == 7)
                    {
                        SuperOne.Text = ClassAddress.PowerOne;
                        SuperOneLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomOne == 8)
                    {
                        SuperOne.Text = ClassAddress.PowerEight;
                        SuperOneLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                    if (ClassBox.Text == "Mystic Artist")

                    if (RandomTwo == 1)
                    {
                        SuperTwo.Text = ClassAddress.PowerOne;
                        SuperTwoLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomTwo == 2)
                    {
                        SuperTwo.Text = ClassAddress.PowerTwo;
                        SuperTwoLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomTwo == 3)
                    {
                        SuperTwo.Text = ClassAddress.PowerThree;
                        SuperTwoLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomTwo == 4)
                    {
                        SuperTwo.Text = ClassAddress.PowerFour;
                        SuperTwoLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomTwo == 5)
                    {
                        SuperTwo.Text = ClassAddress.PowerFive;
                        SuperTwoLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomTwo == 6)
                    {
                        SuperTwo.Text = ClassAddress.PowerSix;
                        SuperTwoLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomTwo == 7)
                    {
                        SuperTwo.Text = ClassAddress.PowerOne;
                        SuperTwoLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomTwo == 8)
                    {
                        SuperTwo.Text = ClassAddress.PowerEight;
                        SuperTwoLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }

                if (ClassBox.Text == "Mystic Artist")
                { 

                    if (RandomThree == 1)
                    {
                        SuperThree.Text = ClassAddress.PowerOne;
                        SuperThreeLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomThree == 2)
                    {
                        SuperThree.Text = ClassAddress.PowerTwo;
                        SuperThreeLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomThree == 3)
                    {
                        SuperThree.Text = ClassAddress.PowerThree;
                        SuperThreeLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomThree == 4)
                    {
                        SuperThree.Text = ClassAddress.PowerFour;
                        SuperThreeLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomThree == 5)
                    {
                        SuperThree.Text = ClassAddress.PowerFive;
                        SuperThreeLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomThree == 6)
                    {
                        SuperThree.Text = ClassAddress.PowerSix;
                        SuperThreeLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomThree == 7)
                    {
                        SuperThree.Text = ClassAddress.PowerOne;
                        SuperThreeLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomThree == 8)
                    {
                        SuperThree.Text = ClassAddress.PowerEight;
                        SuperThreeLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }

                if (ClassBox.Text == "Mystic Artist")
                {

                    if (RandomThree == 1)
                    {
                        SuperFour.Text = ClassAddress.PowerOne;
                        SuperFourLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomFour == 2)
                    {
                        SuperFour.Text = ClassAddress.PowerTwo;
                        SuperFourLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomFour == 3)
                    {
                        SuperFour.Text = ClassAddress.PowerThree;
                        SuperFourLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomFour == 4)
                    {
                        SuperFour.Text = ClassAddress.PowerFour;
                        SuperFourLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomFour == 5)
                    {
                        SuperFour.Text = ClassAddress.PowerFive;
                        SuperFourLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomFour == 6)
                    {
                        SuperFour.Text = ClassAddress.PowerSix;
                        SuperFourLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomFour == 7)
                    {
                        SuperFour.Text = ClassAddress.PowerOne;
                        SuperFourLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomFour == 8)
                    {
                        SuperFour.Text = ClassAddress.PowerEight;
                        SuperFourLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerEightLineFour;
                    }
                }


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
            DigiSoulStat.Text = "";
            StratPoints.Text = "";

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
                    ChampionLevel = ChampionLevel.Text,
                    UltimateLevel = UltimateLevel.Text,
                    MegaLevel = MegaLevel.Text,
                    ChampionSelect = ChampionSelect.Enabled,
                    UltimateSelect = UltimateSelect.Enabled,
                    MegaSelect = MegaSelect.Enabled,
                    StrengthDiet = StrengthDiet.Text,
                    AgilityDiet = AgilityDiet.Text,
                    VibesDiet = VibesDiet.Text,
                    WitsDiet = WitsDiet.Text,
                    EducationDiet = EducationDiet.Text,
                    ErrorScanTrack = ErrorScanTrack.Value,
                    InfoExtractTrack = InfoExtractTrack.Value,
                    GigaSearchTrack = GigaSearchTrack.Value,
                    WaybackTrackTrack = WaybackTrackTrack.Value,
                    ToiletOne = ToiletOne.Checked,
                    ToiletTwo = ToiletTwo.Checked,
                    ToiletThree = ToiletThree.Checked,
                    CrapOne = CrapOne.Checked,
                    CrapTwo = CrapTwo.Checked,
                    CrapThree = CrapThree.Checked,
                    CrapFour = CrapFour.Checked,
                    CrapFive = CrapFive.Checked,
                    CrapSix = CrapSix.Checked,
                    CrapSeven = CrapSeven.Checked,
                    DigiBond = DigiBond.Text,
                    GaurdPoints = GaurdPoints,
                    EvolutionFilePath = EvolutionFilePath,
                    ChampionPath = ChampionPath,
                    UltimatePath = UltimatePath,
                    MegaPath = MegaPath,
                    ClassPath = ClassPath,
                    RookieInheritOne = RookieInheritOne,
                    RookieInheritTwo = RookieInheritTwo,
                    RookieInheritThree = RookieInheritThree,
                    ChampionInheritOne = ChampionInheritOne,
                    ChampionInheritTwo = ChampionInheritTwo,
                    ChampionInheritThree = ChampionInheritThree,
                    UltimateInheritOne = UltimateInheritOne,
                    UltimateInheritTwo = UltimateInheritTwo,
                    UltimateInheritThree = UltimateInheritThree,
                    FreshEvolution = FreshEvolution,
                    TrainingEvolution = TrainingEvolution,
                    RookieEvolution = TrainingEvolution,
                    ChampionEvolution = ChampionEvolution,
                    UltimateEvolution = UltimateEvolution,
                    MegaEvolution = MegaEvolution,
                    UpgradeSkills = CarryTrack.Enabled,
                    UpgradePowers = InfoExtractTrack.Enabled,
                    ReincarnationTime = ReincarnationTime,
                    DigiSoulCost = digiSoulCost,
                    ExpNow = ExpCurrent.Text,
                    ExpNext = ExpNext.Text,
                    RandomOne = RandomOne,
                    RandomTwo = RandomTwo,
                    RandomThree = RandomThree,
                    RandomFour = RandomFour,
                    ClassName = ClassBox.Text,
                    ExpCurrent = ExpCurrent.Text,

                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving character information: {ex.Message}");
            }



        }

        int RandomOne = 1;
        int RandomTwo = 2;
        int RandomThree = 3;
        int RandomFour = 4;


        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("A new scene fades in...");

            GaurdPoints = 0;
            StratPoints.Text = "";

            // Increase Digi-Soul
            if (digiSoulCost != 0 && SceneClass == true)
            {
                digiSoulCost -= 1;
            }
            DigiSoulStat.Text = "";


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


                MessageBox.Show($"New scene, a short time later!");

            }

            // Calculate the total of the Strength Skills
            int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

            // Halve the totalValue and round up
            int halvedValue = (int)Math.Ceiling(totalValue / 2.0);

            // Output the halvedValue to the text box
            DigiSoulStat.Text = halvedValue.ToString();


            // Replenish One Spent Card

            if (ClassBox.SelectedIndex > -1)
            {
                string TamerFilePath = $"Resources/Class/{ClassBox.Text}/{ClassBox.Text}.json";
                TamerInfo ClassAddress = JsonSerializer.Deserialize<TamerInfo>(File.ReadAllText(TamerFilePath));


                Random random = new Random();

                if (SuperOne.Text == "---")
                {
                    RandomOne = random.Next(1, 9);

                    if (RandomOne == 1)
                    {
                        SuperOne.Text = ClassAddress.PowerOne;
                        SuperOneLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomOne == 2)
                    {
                        SuperOne.Text = ClassAddress.PowerTwo;
                        SuperOneLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomOne == 3)
                    {
                        SuperOne.Text = ClassAddress.PowerThree;
                        SuperOneLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomOne == 4)
                    {
                        SuperOne.Text = ClassAddress.PowerFour;
                        SuperOneLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomOne == 5)
                    {
                        SuperOne.Text = ClassAddress.PowerFive;
                        SuperOneLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomOne == 6)
                    {
                        SuperOne.Text = ClassAddress.PowerSix;
                        SuperOneLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomOne == 7)
                    {
                        SuperOne.Text = ClassAddress.PowerOne;
                        SuperOneLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomOne == 8)
                    {
                        SuperOne.Text = ClassAddress.PowerEight;
                        SuperOneLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerEightLineFour;
                    }


                }
                else if (SuperTwo.Text == "---")
                {
                    RandomTwo = random.Next(1, 9);

                    if (RandomTwo == 1)
                    {
                        SuperTwo.Text = ClassAddress.PowerOne;
                        SuperTwoLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomTwo == 2)
                    {
                        SuperTwo.Text = ClassAddress.PowerTwo;
                        SuperTwoLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomTwo == 3)
                    {
                        SuperTwo.Text = ClassAddress.PowerThree;
                        SuperTwoLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomTwo == 4)
                    {
                        SuperTwo.Text = ClassAddress.PowerFour;
                        SuperTwoLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomTwo == 5)
                    {
                        SuperTwo.Text = ClassAddress.PowerFive;
                        SuperTwoLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomTwo == 6)
                    {
                        SuperTwo.Text = ClassAddress.PowerSix;
                        SuperTwoLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomTwo == 7)
                    {
                        SuperTwo.Text = ClassAddress.PowerOne;
                        SuperTwoLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomTwo == 8)
                    {
                        SuperTwo.Text = ClassAddress.PowerEight;
                        SuperTwoLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }
                else if (SuperThree.Text == "---")
                {
                    RandomThree = random.Next(1, 9);

                    if (RandomThree == 1)
                    {
                        SuperThree.Text = ClassAddress.PowerOne;
                        SuperThreeLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomThree == 2)
                    {
                        SuperThree.Text = ClassAddress.PowerTwo;
                        SuperThreeLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomThree == 3)
                    {
                        SuperThree.Text = ClassAddress.PowerThree;
                        SuperThreeLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomThree == 4)
                    {
                        SuperThree.Text = ClassAddress.PowerFour;
                        SuperThreeLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomThree == 5)
                    {
                        SuperThree.Text = ClassAddress.PowerFive;
                        SuperThreeLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomThree == 6)
                    {
                        SuperThree.Text = ClassAddress.PowerSix;
                        SuperThreeLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomThree == 7)
                    {
                        SuperThree.Text = ClassAddress.PowerOne;
                        SuperThreeLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomThree == 8)
                    {
                        SuperThree.Text = ClassAddress.PowerEight;
                        SuperThreeLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }
                else if (SuperFour.Text == "---")
                {
                    int RandomFour = random.Next(1, 9);

                    if (RandomFour == 1)
                    {
                        SuperFour.Text = ClassAddress.PowerOne;
                        SuperFourLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomFour == 2)
                    {
                        SuperFour.Text = ClassAddress.PowerTwo;
                        SuperFourLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomFour == 3)
                    {
                        SuperFour.Text = ClassAddress.PowerThree;
                        SuperFourLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomFour == 4)
                    {
                        SuperFour.Text = ClassAddress.PowerFour;
                        SuperFourLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomFour == 5)
                    {
                        SuperFour.Text = ClassAddress.PowerFive;
                        SuperFourLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomFour == 6)
                    {
                        SuperFour.Text = ClassAddress.PowerSix;
                        SuperFourLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomFour == 7)
                    {
                        SuperFour.Text = ClassAddress.PowerOne;
                        SuperFourLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomFour == 8)
                    {
                        SuperFour.Text = ClassAddress.PowerEight;
                        SuperFourLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }
            }

            SaveCharacterInformation();

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
            int TotalStrength = (int)Math.Ceiling(SkillStrength / 3.0);
            TotalStrength = TotalStrength + StrengthIncrease + 3;
            StrengthStat.Text = TotalStrength.ToString();
            TamerStrengthSave.Text = (((int)Math.Floor(TotalStrength * 3.5)) - 3).ToString();

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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                // Final result
                TotalResult += CarryTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Carry Skill: {CarryTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += ThrowTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Throw Skill: {ThrowTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += HoldTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Hold Skill: {HoldTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int TotalAgility = (int)Math.Ceiling(SkillAgility / 3.0);
            TotalAgility = TotalAgility + AgilityIncrease + 3;
            AgilityStat.Text = TotalAgility.ToString();
            TamerAgilitySave.Text = (((int)Math.Floor(TotalAgility * 3.5)) - 3).ToString();

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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += BalanceTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Balance Skill: {BalanceTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += ParkourTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Parkour Skill: {ParkourTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += ReflexTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Reflex Skill: {ReflexTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int TotalVibes = (int)Math.Ceiling(SkillVibes / 3.0);
            TotalVibes = TotalVibes + VibesIncrease + 3;

            if (MealVibes == true)
            {
                TotalVibes++;
            }

            if (InheritableQuirkTwo.Text.Contains("Vibes") || InheritedQuirkFive.Text.Contains("Vibes"))
            {
                TotalVibes++;
            }

            VibesStat.Text = TotalVibes.ToString();
            TamerVibesSave.Text = (((int)Math.Floor(TotalVibes * 3.5)) - 3).ToString();

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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += PerformTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Perform Skill: {PerformTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += IntimidateTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Intimidate Skill: {IntimidateTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += PersuadeTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Persuade Skill: {PersuadeTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int TotalWits = (int)Math.Ceiling(SkillWits / 3.0);
            TotalWits = TotalWits + WitsIncrease + 3;
            WitsStat.Text = TotalWits.ToString();
            TamerWitsSave.Text = (((int)Math.Floor(TotalWits * 3.5)) - 3).ToString();

            SaveCharacterInformation();
        }

        // Investigation Tracker
        public void InvestigationTrack_Scroll(object sender, EventArgs e)
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += InvestigationTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Investigation Skill: {InvestigationTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += EmpathyTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Empathy Skill: {EmpathyTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += IngenuityTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Wits Skill: {IngenuityTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
            int TotalEducation = (int)Math.Ceiling(SkillEducation / 3.0);
            TotalEducation = TotalEducation + EducationIncrease + 3;

            if (MealEducation == true)
            {
                TotalEducation++;
            }

            if (InheritableQuirkTwo.Text.Contains("Education") || InheritedQuirkFive.Text.Contains("Education"))
            {
                TotalEducation++;
            }


            KnowledgeStat.Text = TotalEducation.ToString();
            TamerEducationSave.Text = (((int)Math.Floor(TotalEducation * 3.5)) - 3).ToString();

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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += TechnologyTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Technology Skill: {TechnologyTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += OccultismTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Occultism Skill: {OccultismTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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
                    int DiceResult = random.Next(1, 5);
                    TotalResult += DiceResult;
                    // Collect individual rolls
                    IndividualRolls += DiceResult + " ";
                }

                TotalResult += SocietyTrack.Value * 2;

                // Display the result
                MessageBox.Show($"Society Skill: {SocietyTrack.Value * 2}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");
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

                DialogResult BoostCarry = MessageBox.Show($"Do you want to increase your {PowerRollThree.Text} power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show($"{PowerRollThree.Text} power increased!");
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


                // Update Stat-Box
                DigiSoulStat.Text = "";

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

                DialogResult BoostCarry = MessageBox.Show($"Do you want to increase your {PowerRollFour.Text} power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show($"{PowerRollFour.Text} power increased!");
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


                // Update Stat-Box
                DigiSoulStat.Text = "";

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
            DigiSoulScore = DigiSoulScore * SoulRollMod;
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
            DigiSoulScore = DigiSoulScore * SoulRollMod;
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
            DigiSoulScore = DigiSoulScore * SoulRollMod;
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
            DigiSoulScore = DigiSoulScore * SoulRollMod;
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




        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

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


            if (digiSoulCost > 0)
            {
                digiSoulCost -= 1;
                DigiSoulStat.Text = "";
            };

            if (FreshEvolution == true)
            {
                EvolutionFilePath = EvolutionFilePath.Replace("/Fresh/", "/Train/");
                EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                Partner.Items.Add(EvolutionAddress.DigimonName);
                Partner.SelectedItem = EvolutionAddress.DigimonName;
                DigivolutionDetails();

                MessageBox.Show($"Your partner has reached In-Training level successfully and become {Partner.Text}.");
            }

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
                        string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                        // Trim the back to remove ")" and everything after it
                        if (ExistHolster.Contains(')'))
                        {
                            int BracketPlace = ExistHolster.IndexOf(')');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }
                        else if (ExistHolster.Contains(','))
                        {
                            int BracketPlace = ExistHolster.IndexOf(',');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(MeatQuantity, item);
                        }

                    }

                    string RewriteValue = MeatQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    if (RewriteValue.Contains(')'))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(')');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    else if (RewriteValue.Contains(','))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(',');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = MeatQuantity[HighestQuantity].IndexOf('*') + 2;
                        string StartValue = MeatQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        string EndValue = "),";

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
                        string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                        // Trim the back to remove ")" and everything after it
                        if (ExistHolster.Contains(')'))
                        {
                            int BracketPlace = ExistHolster.IndexOf(')');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }
                        else if (ExistHolster.Contains(','))
                        {
                            int BracketPlace = ExistHolster.IndexOf(',');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(VeggiesQuantity, item);
                        }

                    }

                    string RewriteValue = VeggiesQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 1);
                    // Trim the back to remove ")" and everything after it
                    if (RewriteValue.Contains(')'))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(')');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    else if (RewriteValue.Contains(','))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(',');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = VeggiesQuantity[HighestQuantity].IndexOf('*') + 2;
                        string StartValue = VeggiesQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        string EndValue = "),";

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
                        string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                        // Trim the back to remove ")" and everything after it
                        if (ExistHolster.Contains(')'))
                        {
                            int BracketPlace = ExistHolster.IndexOf(')');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }
                        else if (ExistHolster.Contains(','))
                        {
                            int BracketPlace = ExistHolster.IndexOf(',');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(BreadQuantity, item);
                        }

                    }

                    string RewriteValue = BreadQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 1);
                    // Trim the back to remove ")" and everything after it
                    if (RewriteValue.Contains(')'))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(')');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    else if (RewriteValue.Contains(','))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(',');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = BreadQuantity[HighestQuantity].IndexOf('*') + 2;
                        string StartValue = BreadQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        string EndValue = "),";

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
                        string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                        // Trim the back to remove ")" and everything after it
                        if (ExistHolster.Contains(')'))
                        {
                            int BracketPlace = ExistHolster.IndexOf(')');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }
                        else if (ExistHolster.Contains(','))
                        {
                            int BracketPlace = ExistHolster.IndexOf(',');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(FruitQuantity, item);
                        }

                    }

                    string RewriteValue = FruitQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    if (RewriteValue.Contains(')'))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(')');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    else if (RewriteValue.Contains(','))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(',');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = FruitQuantity[HighestQuantity].IndexOf('*') + 2;
                        string StartValue = FruitQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        string EndValue = "),";

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
                        string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                        // Trim the back to remove ")" and everything after it
                        if (ExistHolster.Contains(')'))
                        {
                            int BracketPlace = ExistHolster.IndexOf(')');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }
                        else if (ExistHolster.Contains(','))
                        {
                            int BracketPlace = ExistHolster.IndexOf(',');
                            ExistHolster = ExistHolster.Substring(0, BracketPlace);
                        }

                        // Get the Quantity
                        int.TryParse(ExistHolster, out int TheQuantity);

                        // Record the item with the largest quantity
                        if (TheQuantity > ReduceMax)
                        {
                            ReduceMax = TheQuantity;
                            HighestQuantity = Array.IndexOf(FishQuantity, item);
                        }

                    }

                    string RewriteValue = FishQuantity[HighestQuantity];


                    // Extract the number
                    // Trim the front to remove "*" and everything before it
                    RewriteValue = RewriteValue.Substring(RewriteValue.IndexOf("*") + 2);
                    // Trim the back to remove ")" and everything after it
                    if (RewriteValue.Contains(')'))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(')');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    else if (RewriteValue.Contains(','))
                    {
                        int ClosingBracket = RewriteValue.IndexOf(',');
                        RewriteValue = RewriteValue.Substring(0, ClosingBracket);
                    }
                    // Convert to numeric value and reduce
                    int.TryParse(RewriteValue, out int Reduction);

                    if (Reduction > 0)
                    {
                        Reduction = Reduction - 1;
                        RewriteValue = Reduction.ToString();

                        // Extract everything before the number
                        int indexOfClosingBracket = FishQuantity[HighestQuantity].IndexOf('*') + 2;
                        string StartValue = FishQuantity[HighestQuantity].Substring(0, indexOfClosingBracket);

                        // Extract everything after the number
                        string EndValue = "),";

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

                MessageBox.Show($"Please stop let your partner starve, that was a big care-mistake.");
            };

            if (AutoMeal == true)
            {
                AutoMeal = false;

                // Constructing a string from the arrays
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
                string FinalisedInventory = inventoryText.ToString();

                // Remove leading/trailing spaces
                FinalisedInventory = FinalisedInventory.Trim();

                // Replace multiple spaces with single space
                FinalisedInventory = Regex.Replace(FinalisedInventory, @"\s+", " ");


                // Assign the final string to ReadableInventory.Text
                ReadableInventory.Text = "";
                ReadableInventory.Text = FinalisedInventory;

                // Update The Inventory
                InventoryUpdate();

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



        private void label36_Click(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void radioButton14_CheckedChanged_3(object sender, EventArgs e)
        {
            if (DarkEvolution == true)
            {
                Digivolve.Enabled = false;
            }
            else
            {
                Digivolve.Enabled = true;
            }

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
            if (DarkEvolution == true)
            {
                Digivolve.Enabled = false;
            }
            else
            {
                Digivolve.Enabled = true;
            }

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
            if (DarkEvolution == true)
            {
                Digivolve.Enabled = false;
            }
            else
            {
                Digivolve.Enabled = true;
            }

            if (MegaEvolution == true && MegaSelect.Checked == true)
            {
                Digivolve.Text = "De-Digivolve";
            }
            else
            {
                Digivolve.Text = "Digivolve";
            }
        }


        private void Wound_Click(object sender, EventArgs e)
        {
            // If WoundFive is checked
            if (WoundFive.Checked)
            {
                // Click Wound
                MessageBox.Show($"You thought you were hot...\nGuess what? You're not!\nYou are dead...\ndead... dead...");


                DialogResult ReadyToDie = MessageBox.Show("Are you ready to accept your death?", "New Character", MessageBoxButtons.YesNo);

                if (ReadyToDie == DialogResult.Yes)
                {
                    File.WriteAllText("form.json", JsonSerializer.Serialize(new SaveForm
                    {
                        PlayerName = "Player Name",
                        CharacterName = "Character Name",
                        CharacterGender = "Character Gender",
                        ReadableInventory = null!,
                        Partner = null!,
                        CrestSelection = null!,
                        MaxHealth = "25",
                        CurrentHealth = "25",
                        CoreHPMax = "25",
                        CoreHPNow = "25",
                        MaximumLife = "1",
                        RemainingLife = "1",
                        Level = "1",
                        Day = "0",
                        RecordsRookie = null!,
                        RecordsChampion = null!,
                        RecordsUltimate = null!,
                        RecordsMega = null!,
                        CarryTrack = 0!,
                        ThrowTrack = 0!,
                        HoldTrack = 0!,
                        BalanceTrack = 0!,
                        ParkourTrack = 0!,
                        ReflexTrack = 0!,
                        PerformTrack = 0!,
                        PersuadeTrack = 0!,
                        IntimidateTrack = 0!,
                        InvestigationTrack = 0!,
                        EmpathyTrack = 0!,
                        IngenuityTrack = 0!,
                        SocietyTrack = 0!,
                        TechnologyTrack = 0!,
                        OccultismTrack = 0!,
                        BruiseOne = false!,
                        BruiseTwo = false!,
                        BruiseThree = false!,
                        BruiseFour = false!,
                        BruiseFive = false!,
                        InjuryOne = false!,
                        InjuryTwo = false!,
                        InjuryThree = false!,
                        InjuryFour = false!,
                        InjuryFive = false!,
                        WoundOne = false!,
                        WoundTwo = false!,
                        WoundThree = false!,
                        WoundFour = false!,
                        WoundFive = false!,
                        MealStrength = false!,
                        MealAgility = false!,
                        MealVibes = false!,
                        MealWits = false!,
                        MealEducation = false!,
                        ChampionLevel = "________",
                        UltimateLevel = "________",
                        MegaLevel = "________",
                        ChampionSelect = false!,
                        UltimateSelect = false!,
                        MegaSelect = false!,
                        StrengthDiet = "0",
                        AgilityDiet = "0",
                        VibesDiet = "0",
                        WitsDiet = "0",
                        EducationDiet = "0",
                        ErrorScanTrack = 0!,
                        InfoExtractTrack = 0!,
                        GigaSearchTrack = 0!,
                        WaybackTrackTrack = 0!,
                        ToiletOne = false!,
                        ToiletTwo = false!,
                        ToiletThree = false!,
                        CrapOne = false!,
                        CrapTwo = false!,
                        CrapThree = false!,
                        CrapFour = false!,
                        CrapFive = false!,
                        CrapSix = false!,
                        CrapSeven = false!,
                        DigiBond = "3",
                        GaurdPoints = 0,
                        FreshEvolution = false,
                        TrainingEvolution = false,
                        RookieEvolution = false,
                        ChampionEvolution = false,
                        UltimateEvolution = false,
                        MegaEvolution = false,
                        ChampionPath = null!,
                        UltimatePath = null!,
                        MegaPath = null!,
                        ClassPath = null,
                        ClassName = null,
                        EvolutionFilePath = null!,
                        UpgradeSkills = true,
                        UpgradePowers = true,
                        DigiSoulCost = 0,
                        ExpNow = "0",
                        ExpNext = "3",
                        RandomOne = 1,
                        RandomTwo = 2,
                        RandomThree = 3,
                        RandomFour = 4,
                        ExpCurrent = "0",

                    }));


                    this.Close();
                }

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

                DialogResult BoostCarry = MessageBox.Show($"Do you want to increase your {PowerRollOne.Text} power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show($"{PowerRollOne.Text} power increased!");
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


                // Update Stat-Box
                DigiSoulStat.Text = "";

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

                DialogResult BoostCarry = MessageBox.Show($"Do you want to increase your {PowerRollTwo.Text} power?", "Power Increase", MessageBoxButtons.YesNo);
                if (BoostCarry == DialogResult.Yes)
                {
                    // Perform actions if user clicked Yes (e.g., display message, update skill points)
                    MessageBox.Show($"{PowerRollTwo.Text} power increased!");
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


                // Update Stat-Box
                DigiSoulStat.Text = "";

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
        // Press The Button
        private void button22_Click_4(object sender, EventArgs e)
        {
            // Level Up Code
            int.TryParse(TamersLevel.Text, out TamerLevel);
            ExpCurrent.Text = "0";
            ExpNext.Text = (((TamerLevel + 1) * 2) + 1).ToString();
            LevelUp.Enabled = false;

            if (TamerLevel < 20)
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
                int IncreaseTamerHealth;
                int IncreaseDigimonHealth;
                int.TryParse(MaxHealth.Text, out IncreaseTamerHealth);
                int.TryParse(CoreHPMax.Text, out IncreaseDigimonHealth);

                if (TamerLevel < 11)
                {
                    IncreaseTamerHealth = 25 + ((TamerLevel - 1) * 2);
                }
                else if (TamerLevel < 19)
                {
                    IncreaseTamerHealth = 43 + ((TamerLevel - 10));
                }

                MaxHealth.Text = IncreaseTamerHealth.ToString();
                CurrentHealth.Text = MaxHealth.Text;
                int.TryParse(CoreHPMax.Text, out IncreaseDigimonHealth);
                IncreaseDigimonHealth = 25 + ((TamerLevel - 1) * 6);
                CoreHPMax.Text = IncreaseDigimonHealth.ToString();
                CoreHPNow.Text = CoreHPMax.Text;
                TamersLevel.Text = CharacterLevel.Text;



                // Level Up Boon
                TrackBar[] tracks = new TrackBar[] { CarryTrack, ThrowTrack, HoldTrack, BalanceTrack, ParkourTrack, ReflexTrack, PerformTrack, IntimidateTrack, PersuadeTrack, InvestigationTrack, EmpathyTrack, IngenuityTrack, TechnologyTrack, OccultismTrack, SocietyTrack, ErrorScanTrack, InfoExtractTrack, GigaSearchTrack, WaybackTrackTrack };

                foreach (TrackBar track in tracks)
                {
                    track.Enabled = true;
                };

                MessageBox.Show($"Level Up!");

                SaveCharacterInformation();
            }
        }

        private void radioButton13_CheckedChanged_3(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }


        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }


        private void radioButton10_CheckedChanged_2(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        int GaurdPoints;

        private void label117_Click(object sender, EventArgs e)
        {
            StratPoints.Text = DigiBond.Text;
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

        string RookieInheritOne = "";
        string RookieInheritTwo = "";
        string RookieInheritThree = "";
        string ChampionInheritOne = "";
        string ChampionInheritTwo = "";
        string ChampionInheritThree = "";
        string UltimateInheritOne = "";
        string UltimateInheritTwo = "";
        string UltimateInheritThree = "";


        public void DigivolutionDetails()
        {

            // Details
            DigimonField.Text = EvolutionAddress.DigimonField;
            DigitalFrame.Text = EvolutionAddress.DigitalFrame;
            int.TryParse(CharacterLevel.Text, out int Level);
            int.TryParse(EvolutionAddress.CoreHPMax, out int CalculatedHealth);
            CalculatedHealth = CalculatedHealth + (Level * EvolutionAddress.HPLevelMod);
            CoreHPMax.Text = CalculatedHealth.ToString();
            CoreHPNow.Text = CoreHPMax.Text;
            MoveSpeed.Text = EvolutionAddress.MoveSpeed;
            Attribute.Text = EvolutionAddress.Attribute;
            WeaknessElement.Text = EvolutionAddress.WeaknessElement;
            ResistanceElement.Text = EvolutionAddress.ResistanceElement;

            // Reincarnation Required
            if (ReincarnationTime == true)
            {
                EvolutionFilePath = $"Resources/Digi/Pre/Fresh/{DigimonField.Text.Substring(0, DigimonField.Text.IndexOf(" "))}.json";
                EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                Partner.Items.Add(EvolutionAddress.DigimonName);
                Partner.SelectedItem = EvolutionAddress.DigimonName;

                // Details
                DigimonField.Text = EvolutionAddress.DigimonField;
                DigitalFrame.Text = EvolutionAddress.DigitalFrame;
                int.TryParse(CharacterLevel.Text, out Level);
                int.TryParse(EvolutionAddress.CoreHPMax, out CalculatedHealth);
                CalculatedHealth = CalculatedHealth + (Level * EvolutionAddress.HPLevelMod);
                CoreHPMax.Text = CalculatedHealth.ToString();
                CoreHPNow.Text = CoreHPMax.Text;
                MoveSpeed.Text = EvolutionAddress.MoveSpeed;
                Attribute.Text = EvolutionAddress.Attribute;
                WeaknessElement.Text = EvolutionAddress.WeaknessElement;
                ResistanceElement.Text = EvolutionAddress.ResistanceElement;

                // Turn off reincarnation mode
                ReincarnationTime = false;
            }


            // Form Booleans
            FreshEvolution = EvolutionAddress.FreshEvolution;
            TrainingEvolution = EvolutionAddress.TrainingEvolution;
            RookieEvolution = EvolutionAddress.RookieEvolution;
            ChampionEvolution = EvolutionAddress.ChampionEvolution;
            UltimateEvolution = EvolutionAddress.UltimateEvolution;
            MegaEvolution = EvolutionAddress.MegaEvolution;
            DarkEvolution = EvolutionAddress.DarkEvolution;
            HaveMeal.Enabled = true;


            if (DarkEvolution == true)
            {
                if (RookieEvolution == true)
                {
                    RecordRookie = EvolutionAddress.DigimonName;
                }
                else if (ChampionEvolution == true)
                {
                    RecordChampion = EvolutionAddress.DigimonName;
                }
                else if (UltimateEvolution == true)
                {
                    RecordUltimate = EvolutionAddress.DigimonName;
                }
                else if (MegaEvolution == true)
                {
                    RecordMega = EvolutionAddress.DigimonName;
                }
            }
            else
            {
                if (RookieEvolution == true)
                {
                    RecordRookie = EvolutionAddress.DigimonName;
                }
                else if (ChampionEvolution == true)
                {
                    RecordChampion = EvolutionAddress.DigimonName;
                }
                else if (UltimateEvolution == true)
                {
                    RecordUltimate = EvolutionAddress.DigimonName;
                }
                else if (MegaEvolution == true)
                {
                    RecordMega = EvolutionAddress.DigimonName;
                }
            }


            // Basic Move
            BasicAttack.Text = EvolutionAddress.BasicAttack;

            BasicConcept.Text = EvolutionAddress.BasicConcept;
            BasicAttackStat.Text = EvolutionAddress.BasicAttackStat;
            BasicDefendStat.Text = EvolutionAddress.BasicDefendStat;
            BasicCritFail.Text = EvolutionAddress.BasicCritFail;
            BasicCritSuccess.Text = EvolutionAddress.BasicCritSuccess;
            BasicEffect.Text = EvolutionAddress.BasicEffect;
            BasicBonus.Text = EvolutionAddress.BasicBonus;
            BasicPenalty.Text = EvolutionAddress.BasicPenalty;

            BasicDiceMin.Text = EvolutionAddress.BasicDiceMin;
            BasicDiceMax.Text = EvolutionAddress.BasicDiceMax;
            BasicElement.Text = EvolutionAddress.BasicElement;

            //Standard Move
            StandardAttack.Text = EvolutionAddress.StandardAttack;

            StandardConcept.Text = EvolutionAddress.StandardConcept;
            StandardAttackStat.Text = EvolutionAddress.StandardAttackStat;
            StandardDefendStat.Text = EvolutionAddress.StandardDefendStat;
            StandardCritFail.Text = EvolutionAddress.StandardCritFail;
            StandardCritSuccess.Text = EvolutionAddress.StandardCritSuccess;
            StandardEffect.Text = EvolutionAddress.StandardEffect;
            StandardBonus.Text = EvolutionAddress.StandardBonus;
            StandardPenalty.Text = EvolutionAddress.StandardPenalty;

            StandardDiceMin.Text = EvolutionAddress.StandardDiceMin;
            StandardDiceMax.Text = EvolutionAddress.StandardDiceMax;
            StandardElement.Text = EvolutionAddress.StandardElement;

            //Special Move
            SpecialAttack.Text = EvolutionAddress.SpecialAttack;

            SpecialConcept.Text = EvolutionAddress.SpecialConcept;
            SpecialAttackStat.Text = EvolutionAddress.SpecialAttackStat;
            SpecialDefendStat.Text = EvolutionAddress.SpecialDefendStat;
            SpecialCritFail.Text = EvolutionAddress.SpecialCritFail;
            SpecialCritSuccess.Text = EvolutionAddress.SpecialCritSuccess;
            SpecialEffect.Text = EvolutionAddress.SpecialEffect;
            SpecialBonus.Text = EvolutionAddress.SpecialBonus;
            SpecialPenalty.Text = EvolutionAddress.SpecialPenalty;

            SpecialDiceMin.Text = EvolutionAddress.SpecialDiceMin;
            SpecialDiceMax.Text = EvolutionAddress.SpecialDiceMax;
            SpecialElement.Text = EvolutionAddress.SpecialElement;

            //Super Move
            SuperAttack.Text = EvolutionAddress.SuperAttack;

            SuperConcept.Text = EvolutionAddress.SuperConcept;
            SuperAttackStat.Text = EvolutionAddress.SuperAttackStat;
            SuperDefendStat.Text = EvolutionAddress.SuperDefendStat;
            SuperCritFail.Text = EvolutionAddress.SuperCritFail;
            SuperCritSuccess.Text = EvolutionAddress.SuperCritSuccess;
            SuperEffect.Text = EvolutionAddress.SuperEffect;
            SuperBonus.Text = EvolutionAddress.SuperBonus;
            SuperPenalty.Text = EvolutionAddress.SuperPenalty;

            SuperDiceMin.Text = EvolutionAddress.SuperDiceMin;
            SuperDiceMax.Text = EvolutionAddress.SuperDiceMax;
            SuperElement.Text = EvolutionAddress.SuperElement;

            // Quirks
            CurrentQuirkOne.Text = EvolutionAddress.CurrentQuirkOne;
            CurrentQuirkTwo.Text = EvolutionAddress.CurrentQuirkTwo;
            InheritableQuirkOne.Text = EvolutionAddress.InheritableQuirkOne;
            InheritableQuirkTwo.Text = EvolutionAddress.InheritableQuirkTwo;
            InheritableQuirkThree.Text = EvolutionAddress.InheritableQuirkThree;

            // Get Inheritables
            if (RookieEvolution == true)
            {
                RecordRookie = EvolutionAddress.DigimonName;

                RookieInheritOne = InheritableQuirkOne.Text;
                RookieInheritTwo = InheritableQuirkTwo.Text;
                RookieInheritThree = InheritableQuirkThree.Text;

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
            else if (ChampionEvolution == true)
            {
                ChampionInheritOne = InheritableQuirkOne.Text;
                ChampionInheritTwo = InheritableQuirkTwo.Text;
                ChampionInheritThree = InheritableQuirkThree.Text;

                InheritedQuirkOne.Text = RookieInheritOne;
                InheritedQuirkTwo.Text = RookieInheritTwo;
                InheritedQuirkThree.Text = RookieInheritThree;
                InheritedQuirkFour.Text = "_";
                InheritedQuirkFive.Text = "_";
                InheritedQuirkSix.Text = "_";
                InheritedQuirkSeven.Text = "_";
                InheritedQuirkEight.Text = "_";
                InheritedQuirkNine.Text = "_";
            }
            else if (UltimateEvolution == true)
            {

                UltimateInheritOne = InheritableQuirkOne.Text;
                UltimateInheritTwo = InheritableQuirkTwo.Text;
                UltimateInheritThree = InheritableQuirkThree.Text;

                InheritedQuirkOne.Text = RookieInheritOne;
                InheritedQuirkTwo.Text = RookieInheritTwo;
                InheritedQuirkThree.Text = RookieInheritThree;
                InheritedQuirkFour.Text = ChampionInheritOne;
                InheritedQuirkFive.Text = ChampionInheritTwo;
                InheritedQuirkSix.Text = ChampionInheritThree;
                InheritedQuirkSeven.Text = "_";
                InheritedQuirkEight.Text = "_";
                InheritedQuirkNine.Text = "_";
            }
            else if (MegaEvolution == true)
            {
                InheritedQuirkOne.Text = RookieInheritOne;
                InheritedQuirkTwo.Text = RookieInheritTwo;
                InheritedQuirkThree.Text = RookieInheritThree;
                InheritedQuirkFour.Text = ChampionInheritOne;
                InheritedQuirkFive.Text = ChampionInheritTwo;
                InheritedQuirkSix.Text = ChampionInheritThree;
                InheritedQuirkFour.Text = UltimateInheritOne;
                InheritedQuirkFive.Text = UltimateInheritTwo;
                InheritedQuirkSix.Text = UltimateInheritThree;
            }

            // Digimon Stats
            DigimonStrength.Text = "";
            DigimonAgility.Text = "";
            DigimonVibes.Text = "";
            DigimonWits.Text = "";
            DigimonEducation.Text = "";
            DigiAttackRoll.Text = "";

            // Darkest Consequences
            if (DarkEvolution == true)
            {
                CrestSelection.SelectedIndex = -1;
                CrestSelection.Enabled = true;
                Digivolve.Enabled = false;
            }
        }

        DigimonInfo EvolutionAddress;
        TamerInfo ClassAddress;


        private void SuperSkillGain_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var DigimonFolders = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Digi"), "*mon", SearchOption.TopDirectoryOnly).Select(Path.GetFileNameWithoutExtension);

            // Add options to Partner Selection options
            Partner.Items.AddRange(DigimonFolders.ToArray());

            {

                // Get selected Personality Crest
                string DigimonPartner = (string)Partner.SelectedItem;
                // Disable selecting
                Partner.Enabled = false;

                if (DigimonPartner == "")
                {
                    Partner.Enabled = true;
                    Partner.Items.Remove("");
                }

                // Rookies
                if (DigimonFolders.Contains(DigimonPartner))
                {
                    RecordRookie = Partner.Text;
                    EvolutionFilePath = $"Resources/Digi/{Partner.Text}/{Partner.Text}.json";
                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                    Partner.Items.Add(EvolutionAddress.DigimonName);
                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                    DigivolutionDetails();
                }
                else
                {
                    FreshEvolution = false;
                    TrainingEvolution = false;
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

                    if (!Partner.Text.Contains("mon"))
                    {
                        StrengthDiet.Text = "0";
                        AgilityDiet.Text = "0";
                        VibesDiet.Text = "0";
                        WitsDiet.Text = "0";
                        EducationDiet.Text = "0";
                    }



                    // ____ Moves
                    //Basic Move
                    BasicAttack.Text = "____";
                    BasicConcept.Text = "___";
                    BasicAttackStat.Text = "___";
                    BasicDefendStat.Text = "___";
                    BasicCritFail.Text = "___";
                    BasicCritSuccess.Text = "___";
                    BasicEffect.Text = "___";
                    BasicBonus.Text = "___";
                    BasicPenalty.Text = "___";
                    BasicDiceMin.Text = "_";
                    BasicDiceMax.Text = "_";
                    BasicElement.Text = "____";

                    //Standard Move
                    StandardAttack.Text = "____";
                    StandardConcept.Text = "___";
                    StandardAttackStat.Text = "___";
                    StandardDefendStat.Text = "___";
                    StandardCritFail.Text = "___";
                    StandardCritSuccess.Text = "___";
                    StandardEffect.Text = "___";
                    StandardBonus.Text = "___";
                    StandardPenalty.Text = "___";
                    StandardDiceMin.Text = "_";
                    StandardDiceMax.Text = "_";
                    StandardElement.Text = "____";

                    //Special Move
                    SpecialAttack.Text = "____";
                    SpecialConcept.Text = "___";
                    SpecialAttackStat.Text = "___";
                    SpecialDefendStat.Text = "___";
                    SpecialCritFail.Text = "___";
                    SpecialCritSuccess.Text = "___";
                    SpecialEffect.Text = "___";
                    SpecialBonus.Text = "___";
                    SpecialPenalty.Text = "___";
                    SpecialDiceMin.Text = "_";
                    SpecialDiceMax.Text = "_";
                    SpecialElement.Text = "____";

                    //Super Move
                    SuperAttack.Text = "____";
                    SuperConcept.Text = "___";
                    SuperAttackStat.Text = "___";
                    SuperDefendStat.Text = "___";
                    SuperCritFail.Text = "___";
                    SuperCritSuccess.Text = "___";
                    SuperEffect.Text = "___";
                    SuperBonus.Text = "___";
                    SuperPenalty.Text = "___";
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
                InventoryUpdate();
                TamerDigimon.SelectedIndex = NextPage;
            }

            StrengthStat.Text = "";
            AgilityStat.Text = "";
            VibesStat.Text = "";
            WitsStat.Text = "";
            KnowledgeStat.Text = "";
            DigiSoulStat.Text = "";
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

            ModifyCoreHP.Text = "";

            SaveCharacterInformation();
        }


        bool ReincarnationTime = false;

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
                Partner.Text = "";
                Partner.SelectedIndex = -1;
                Partner.Enabled = true;
                Partner.Items.Remove(RecordChampion);
                Partner.Items.Remove(RecordUltimate);
                Partner.Items.Remove(RecordMega);

                FreshEvolution = true;
                TrainingEvolution = false;
                RecordRookie = "________";
                RookieEvolution = false;
                RecordChampion = "________";
                ChampionEvolution = false;
                RecordUltimate = "________";
                UltimateEvolution = false;
                RecordMega = "________";
                MegaEvolution = false;
                Day.Text = "0";

                // End Meal
                MealStrength = false;
                MealAgility = false;
                MealVibes = false;
                MealWits = false;
                MealEducation = false;
                AutoMeal = false;
                StrengthDiet.Text = "0";
                AgilityDiet.Text = "0";
                VibesDiet.Text = "0";
                WitsDiet.Text = "0";
                EducationDiet.Text = "0";

                SaveCharacterInformation();

                // Check if Dark-Digivolved, and if so do the same for personality
                if (DarkEvolution == true)
                {
                    CrestSelection.SelectedIndex = -1;
                    CrestSelection.Enabled = true;
                    DarkEvolution = false;
                    Partner.SelectedIndex = -1;
                    Partner.Enabled = true;
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

                // Refresh stats
                DigimonStrength.Text = "";
                DigimonAgility.Text = "";
                DigimonVibes.Text = "";
                DigimonWits.Text = "";
                DigimonEducation.Text = "";
                DigiAttackRoll.Text = "";
                StrengthStat.Text = "";
                AgilityStat.Text = "";
                VibesStat.Text = "";
                WitsStat.Text = "";
                KnowledgeStat.Text = "";

                // Refresh Care Mistakes
                ToiletOne.Checked = false;
                ToiletTwo.Checked = false;
                ToiletThree.Checked = false;
                CrapOne.Checked = false;
                CrapTwo.Checked = false;
                CrapThree.Checked = false;
                CrapFour.Checked = false;
                CrapFive.Checked = false;
                CrapSix.Checked = false;
                CrapSeven.Checked = false;

                //Reset the options to default
                Partner.Items.Clear();

                try
                {
                    // Get all directories containing "mon" in their name
                    var DigimonFolders = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Digi"), "*mon", SearchOption.TopDirectoryOnly).Select(Path.GetFileNameWithoutExtension);

                    // Add options to Partner Selection options
                    Partner.Items.AddRange(DigimonFolders.ToArray());
                }
                catch (Exception ex)
                {
                    // Handle potential exceptions
                    MessageBox.Show("Error: " + ex.Message);
                }

                ReincarnationTime = true;

                EvolutionFilePath = "null.json";

                SaveCharacterInformation();
            }

            ModifyCoreHP.Text = "";

            SaveCharacterInformation();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            {
                // If CrapSeven is checked
                if (CrapSeven.Checked)
                {
                    MessageBox.Show($"Massive Care Failure. Failure Evolution Initiated...\n\nError... Error... \n\nError Overload! \n\n{Partner.Text} Fail Digivolve To Numemon.");
                    EvolutionFilePath = "Resources/Digi/Fail/Numemon.json";
                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                    Partner.Items.Add(EvolutionAddress.DigimonName);
                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                    ChampionLevel.Text = EvolutionAddress.DigimonName;
                    DigivolutionDetails();

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


        string RecordRookie = "";
        string RecordChampion = "";
        string RecordUltimate = "";
        string RecordMega = "";
        bool FreshEvolution = false;
        bool TrainingEvolution = false;
        bool RookieEvolution = false;
        bool ChampionEvolution = false;
        bool UltimateEvolution = false;
        bool MegaEvolution = false;
        bool DarkEvolution = false;

        string EvolutionFilePath;
        string ChampionPath;
        string UltimatePath;
        string MegaPath;


        private void Digivolve_Click(object sender, EventArgs e)
        {
            if (MegaSelect.Checked == true)
            {

                MessageBox.Show("That is not within the scope of this Demo, so it was not included.\nIf you want to do more sessions with me, or to use this game personally, reach out and we can talk about it.\n\nThere might even be other features added over-time (such as Armour or Spirit Evolution) when I'm not working on other stuff. So if you want to use this system further its definitely worth asking occasionally about any upgrades.\n\nPlease do not share either version to the public, as despite the abysmal odds I would love to pitch an improved version of this to Bandai Namco someday.\n\n    - Twilord");
            }
            else
            {
                if (Digivolve.Text == "De-Digivolve")
                {
                    Digivolve.Text = "Digivolve";

                    EvolutionFilePath = $"Resources/Digi/{RecordRookie}/{RecordRookie}.json";
                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                    Partner.Items.Add(EvolutionAddress.DigimonName);
                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                    Partner.Items.Remove(RecordChampion);
                    Partner.Items.Remove(RecordUltimate);
                    Partner.Items.Remove(RecordMega);
                    DigivolutionDetails();

                    MessageBox.Show($"Reverted to {Partner.Text} successfully.");
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


                            StringBuilder EvolutionPath = new StringBuilder();
                            EvolutionPath.Append("Resources/Digi");

                            if (DigivolutionRoll > DarkCheck)
                            {

                                if (ChampionLevel.Text == "________")
                                {

                                    EvolutionPath.Append("/");
                                    EvolutionPath.Append(Partner.Text);
                                    EvolutionPath.Append("/");
                                    EvolutionPath.Append("Champion/");

                                    if (maxDiet == Diet.Strength)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Greymon");
                                        Partner.Items.Add("Greymon");
                                        Partner.SelectedItem = "Greymon";
                                        ChampionLevel.Text = "Greymon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Strength");

                                    }
                                    else if (maxDiet == Diet.Agility)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tuskmon");
                                        Partner.Items.Add("Tuskmon");
                                        Partner.SelectedItem = "Tuskmon";
                                        ChampionLevel.Text = "Tuskmon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Agility");
                                    }
                                    else if (maxDiet == Diet.Vibes)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Growlmon");
                                        Partner.Items.Add("Growlmon");
                                        Partner.SelectedItem = ";
                                        ChampionLevel.Text = "Growlmon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Vibes");
                                    }
                                    else if (maxDiet == Diet.Wits)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Flarizamon");
                                        Partner.Items.Add("Flarizamon");
                                        Partner.SelectedItem = "Flarizamon";
                                        ChampionLevel.Text = "Flarizamon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Wits");
                                    }
                                    else if (maxDiet == Diet.Education)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tyrannomon");
                                        Partner.Items.Add("Tyrannomon");
                                        Partner.SelectedItem = "Tyrannomon";
                                        ChampionLevel.Text = "Tyrannomon"; 
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        ChampionEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Education");
                                    }




                                    EvolutionPath.Append(".json");
                                    EvolutionFilePath = EvolutionPath.ToString();
                                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                                    Partner.Items.Add(EvolutionAddress.DigimonName);
                                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                                    if (RookieEvolution == false)
                                    {
                                        ChampionLevel.Text = EvolutionAddress.DigimonName;
                                    }
                                    DigivolutionDetails();

                                    ChampionPath = EvolutionPath.ToString();


                                    MessageBox.Show($"New Evolution Unlocked!\n Digivolution to {Partner.Text} successful.");
                                }
                                else
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: {ChampionLevel.Text}");
                                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(ChampionPath));
                                    Partner.Items.Add(EvolutionAddress.DigimonName);
                                    EvolutionFilePath = ChampionPath;
                                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                                    DigivolutionDetails();

                                }

                            }
                            else
                            {
                                EvolutionFilePath = $"Resources/Digi/Fail/Champion/{EvolutionAddress.DigimonField.Substring(0, DigimonField.Text.IndexOf(" "))}.json";
                                EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                                Partner.Items.Add(EvolutionAddress.DigimonName);
                                Partner.SelectedItem = EvolutionAddress.DigimonName;
                                ChampionLevel.Text = "________";
                                DigivolutionDetails();

                                MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nDark Digivolution Triggered. \nEvolution Result: {Partner.Text}.");

                            }
                        }

                        else if (UltimateSelect.Checked == true)
                        {
                            int RemainingLifespan;
                            int.TryParse(RemainingLife.Text, out RemainingLifespan);
                            RemainingLifespan = RemainingLifespan - 1;
                            RemainingLife.Text = RemainingLifespan.ToString();


                            StringBuilder EvolutionPath = new StringBuilder();
                            EvolutionPath.Append("Resources/Digi");

                            if (DigivolutionRoll > DarkCheck)
                            {

                                if (UltimateLevel.Text == "________")
                                {

                                    EvolutionPath.Append("/");
                                    EvolutionPath.Append(Partner.Text);
                                    EvolutionPath.Append("/");
                                    EvolutionPath.Append("Ultimate/");

                                    if (maxDiet == Diet.Strength)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Greymon");
                                        Partner.Items.Add("Greymon");
                                        Partner.SelectedItem = "Greymon";
                                        UltimateLevel.Text = "Greymon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        UltimateEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Strength");

                                    }
                                    else if (maxDiet == Diet.Agility)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tuskmon");
                                        Partner.Items.Add("Tuskmon");
                                        Partner.SelectedItem = "Tuskmon";
                                        UltimateLevel.Text = "Tuskmon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        UltimateEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Agility");
                                    }
                                    else if (maxDiet == Diet.Vibes)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Growlmon");
                                        Partner.Items.Add("Growlmon");
                                        Partner.SelectedItem = ";
                                        UltimateLevel.Text = "Growlmon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        UltimateEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Vibes");
                                    }
                                    else if (maxDiet == Diet.Wits)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Flarizamon");
                                        Partner.Items.Add("Flarizamon");
                                        Partner.SelectedItem = "Flarizamon";
                                        UltimateLevel.Text = "Flarizamon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        UltimateEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Wits");
                                    }
                                    else if (maxDiet == Diet.Education)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tyrannomon");
                                        Partner.Items.Add("Tyrannomon");
                                        Partner.SelectedItem = "Tyrannomon";
                                        UltimateLevel.Text = "Tyrannomon"; 
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        UltimateEvolution = true;
                                        UltimateEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Education");
                                    }




                                    EvolutionPath.Append(".json");
                                    EvolutionFilePath = EvolutionPath.ToString();
                                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                                    Partner.Items.Add(EvolutionAddress.DigimonName);
                                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                                    if (RookieEvolution == false)
                                    {
                                        UltimateLevel.Text = EvolutionAddress.DigimonName;
                                    }
                                    DigivolutionDetails();

                                    UltimatePath = EvolutionPath.ToString();


                                    MessageBox.Show($"New Evolution Unlocked!\n Digivolution to {Partner.Text} successful.");
                                }
                                else
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: {UltimateLevel.Text}");
                                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(UltimatePath));
                                    Partner.Items.Add(EvolutionAddress.DigimonName);
                                    EvolutionFilePath = UltimatePath;
                                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                                    DigivolutionDetails();

                                }

                            }
                            else
                            {
                                EvolutionFilePath = $"Resources/Digi/Fail/Ultimate/{EvolutionAddress.DigimonField.Substring(0, DigimonField.Text.IndexOf(" "))}.json";
                                EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                                Partner.Items.Add(EvolutionAddress.DigimonName);
                                Partner.SelectedItem = EvolutionAddress.DigimonName;
                                UltimateLevel.Text = "________";
                                DigivolutionDetails();

                                MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nDark Digivolution Triggered. \nEvolution Result: {Partner.Text}.");

                            }
                        }



                        else if (MegaSelect.Checked == true)
                        {
                            int RemainingLifespan;
                            int.TryParse(RemainingLife.Text, out RemainingLifespan);
                            RemainingLifespan = RemainingLifespan - 1;
                            RemainingLife.Text = RemainingLifespan.ToString();


                            StringBuilder EvolutionPath = new StringBuilder();
                            EvolutionPath.Append("Resources/Digi");

                            if (DigivolutionRoll > DarkCheck)
                            {

                                if (MegaLevel.Text == "________")
                                {

                                    EvolutionPath.Append("/");
                                    EvolutionPath.Append(Partner.Text);
                                    EvolutionPath.Append("/");
                                    EvolutionPath.Append("Mega/");

                                    if (maxDiet == Diet.Strength)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Greymon");
                                        Partner.Items.Add("Greymon");
                                        Partner.SelectedItem = "Greymon";
                                        MegaLevel.Text = "Greymon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        MegaEvolution = true;
                                        MegaEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Strength");

                                    }
                                    else if (maxDiet == Diet.Agility)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tuskmon");
                                        Partner.Items.Add("Tuskmon");
                                        Partner.SelectedItem = "Tuskmon";
                                        MegaLevel.Text = "Tuskmon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        MegaEvolution = true;
                                        MegaEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Agility");
                                    }
                                    else if (maxDiet == Diet.Vibes)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Growlmon");
                                        Partner.Items.Add("Growlmon");
                                        Partner.SelectedItem = ";
                                        MegaLevel.Text = "Growlmon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        MegaEvolution = true;
                                        MegaEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Vibes");
                                    }
                                    else if (maxDiet == Diet.Wits)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Flarizamon");
                                        Partner.Items.Add("Flarizamon");
                                        Partner.SelectedItem = "Flarizamon";
                                        MegaLevel.Text = "Flarizamon";
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        MegaEvolution = true;
                                        MegaEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Wits");
                                    }
                                    else if (maxDiet == Diet.Education)
                                    {
                                        /*
                                        MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: Tyrannomon");
                                        Partner.Items.Add("Tyrannomon");
                                        Partner.SelectedItem = "Tyrannomon";
                                        MegaLevel.Text = "Tyrannomon"; 
                                        */
                                        FreshEvolution = false;
                                        TrainingEvolution = false;
                                        RookieEvolution = false;
                                        MegaEvolution = true;
                                        MegaEvolution = false;
                                        MegaEvolution = false;
                                        EvolutionPath.Append("Education");
                                    }




                                    EvolutionPath.Append(".json");
                                    EvolutionFilePath = EvolutionPath.ToString();
                                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                                    Partner.Items.Add(EvolutionAddress.DigimonName);
                                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                                    if (RookieEvolution == false)
                                    {
                                        MegaLevel.Text = EvolutionAddress.DigimonName;
                                    }
                                    DigivolutionDetails();

                                    MegaPath = EvolutionPath.ToString();


                                    MessageBox.Show($"New Evolution Unlocked!\n Digivolution to {Partner.Text} successful.");
                                }
                                else
                                {
                                    MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nSuccessful Digivolution. \nEvolution Result: {MegaLevel.Text}");
                                    EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(MegaPath));
                                    Partner.Items.Add(EvolutionAddress.DigimonName);
                                    EvolutionFilePath = MegaPath;
                                    Partner.SelectedItem = EvolutionAddress.DigimonName;
                                    DigivolutionDetails();

                                }

                            }
                            else
                            {
                                EvolutionFilePath = $"Resources/Digi/Fail/Mega/{EvolutionAddress.DigimonField.Substring(0, DigimonField.Text.IndexOf(" "))}.json";
                                EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                                Partner.Items.Add(EvolutionAddress.DigimonName);
                                Partner.SelectedItem = EvolutionAddress.DigimonName;
                                MegaLevel.Text = "________";
                                DigivolutionDetails();

                                MessageBox.Show($"Inner Darkness: {DarkCheck} \nDigivolution Light: {DigivolutionRoll} \n \nDark Digivolution Triggered. \nEvolution Result: {Partner.Text}.");

                            }
                        }

                    }
                    RecordChampion = ChampionLevel.Text;
                    RecordUltimate = UltimateLevel.Text;
                    RecordMega = MegaLevel.Text;

                    SaveCharacterInformation();

                }
            }
        }

        /*
        public void Evolve()
        {
            StringBuilder EvolutionPath = new StringBuilder();

            string SelectedEvolutionStage;
            string EvolutionForm;
            
            if (ChampionSelect.Checked == true)
            {
                SelectedEvolutionStage = "Champion";

                    if (ChampionStats = "Strength")
                    {
                        EvolutionForm = "StrengthForm";
                    }
                    else if (ChampionStats = "Agility")
                    {
                        EvolutionForm = "AgilityForm";
                    }
                    else if (ChampionStats = "Vibes")
                    {
                        EvolutionForm = "VibesForm";
                    }
                    else if (ChampionStats = "Wits")
                    {
                        EvolutionForm = "WitsForm";
                    }
                    else
                    {
                        EvolutionForm = "EducationForm";
                    }

            }
            else if (UltimateSelect.Checked == true)
            {
                SelectedEvolutionStage = "Ultimate";

                    if (UltimateStats = "Strength")
                    {
                        EvolutionForm = "StrengthForm";
                    }
                    else if (UltimateStats = "Agility")
                    {
                        EvolutionForm = "AgilityForm";
                    }
                    else if (UltimateStats = "Vibes")
                    {
                        EvolutionForm = "VibesForm";
                    }
                    else if (UltimateStats = "Wits")
                    {
                        EvolutionForm = "WitsForm";
                    }
                    else
                    {
                        EvolutionForm = "EducationForm";
                    }
            }

            // Build evolution path based on user selections
            EvolutionPath.Append(RecordRookie);
            EvolutionPath.Append("/");
            EvolutionPath.Append(SelectedEvolutionStage);
            EvolutionPath.Append("/");
            EvolutionPath.Append(EvolutionForm);
            EvolutionPath.Append(".json");

            string EvolutionFilePath = EvolutionPath.ToString();

            // Load data from JSON file
            SaveForm loadedForm = JsonSerializer.Deserialize<SaveForm>(File.ReadAllText(EvolutionFilePath));

            DigimonName.Text = loadedForm.DigimonName;
        }
        */

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
                if (ChampionSelect.Enabled == false)
                {
                    MessageBox.Show($"You unlocked the ability to evolve your partner to Champion!");
                }

                ChampionSelect.Enabled = true;
            }

            // Unlock Ultimate Evolutions
            if (DayCount > 6 && LevelCount > 7)
            {
                if (UltimateSelect.Enabled == false)
                {
                    MessageBox.Show($"You unlocked the ability to evolve your partner to Ultimate!");
                }

                UltimateSelect.Enabled = true;
            }

            // Unlock Mega Evolutions
            if (DayCount > 13 && LevelCount > 15)
            {
                if (MegaSelect.Enabled == false)
                {
                    MessageBox.Show($"You unlocked the ability to evolve your partner to Mega!");
                }

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


            MessageBox.Show($"Your bond with your partner has strengthened!");

            SaveCharacterInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Reflect on the day you've had, and earn your experience points.");

            // Daily Healing
            CoreHPNow.Text = CoreHPMax.Text;
            CurrentHealth.Text = MaxHealth.Text;

            digiSoulCost = 0;
            DigiSoulStat.Text = "";

            if (TrainingEvolution == true || FreshEvolution == true)
            {
                if (FreshEvolution == true)
                {
                    CareMistakeButton.PerformClick();

                    MessageBox.Show($"Please stop let your baby starve, that was a big care-mistake.");
                }

                EvolutionFilePath = $"Resources/Digi/{RecordRookie}/{RecordRookie}.json";
                EvolutionAddress = JsonSerializer.Deserialize<DigimonInfo>(File.ReadAllText(EvolutionFilePath));
                Partner.Items.Add(EvolutionAddress.DigimonName);
                Partner.SelectedItem = EvolutionAddress.DigimonName;
                DigivolutionDetails();

                MessageBox.Show($"Your partner has reached Rookie level successfully and become {Partner.Text}.");
            }

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


            // Replenish One Spent Card

            if (ClassBox.SelectedIndex > -1)
            {
                string TamerFilePath = $"Resources/Class/{ClassBox.Text}/{ClassBox.Text}.json";
                TamerInfo ClassAddress = JsonSerializer.Deserialize<TamerInfo>(File.ReadAllText(TamerFilePath));


                Random random = new Random();

                if (SuperOne.Text == "---")
                {
                    RandomOne = random.Next(1, 9);

                    if (RandomOne == 1)
                    {
                        SuperOne.Text = ClassAddress.PowerOne;
                        SuperOneLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomOne == 2)
                    {
                        SuperOne.Text = ClassAddress.PowerTwo;
                        SuperOneLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomOne == 3)
                    {
                        SuperOne.Text = ClassAddress.PowerThree;
                        SuperOneLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomOne == 4)
                    {
                        SuperOne.Text = ClassAddress.PowerFour;
                        SuperOneLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomOne == 5)
                    {
                        SuperOne.Text = ClassAddress.PowerFive;
                        SuperOneLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomOne == 6)
                    {
                        SuperOne.Text = ClassAddress.PowerSix;
                        SuperOneLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomOne == 7)
                    {
                        SuperOne.Text = ClassAddress.PowerOne;
                        SuperOneLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomOne == 8)
                    {
                        SuperOne.Text = ClassAddress.PowerEight;
                        SuperOneLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperOneLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperOneLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperOneLineFour.Text = ClassAddress.PowerEightLineFour;
                    }


                }
                if (SuperTwo.Text == "---")
                {
                    RandomTwo = random.Next(1, 9);

                    if (RandomTwo == 1)
                    {
                        SuperTwo.Text = ClassAddress.PowerOne;
                        SuperTwoLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomTwo == 2)
                    {
                        SuperTwo.Text = ClassAddress.PowerTwo;
                        SuperTwoLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomTwo == 3)
                    {
                        SuperTwo.Text = ClassAddress.PowerThree;
                        SuperTwoLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomTwo == 4)
                    {
                        SuperTwo.Text = ClassAddress.PowerFour;
                        SuperTwoLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomTwo == 5)
                    {
                        SuperTwo.Text = ClassAddress.PowerFive;
                        SuperTwoLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomTwo == 6)
                    {
                        SuperTwo.Text = ClassAddress.PowerSix;
                        SuperTwoLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomTwo == 7)
                    {
                        SuperTwo.Text = ClassAddress.PowerOne;
                        SuperTwoLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomTwo == 8)
                    {
                        SuperTwo.Text = ClassAddress.PowerEight;
                        SuperTwoLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperTwoLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperTwoLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperTwoLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }
                if (SuperThree.Text == "---")
                {
                    RandomThree = random.Next(1, 9);

                    if (RandomThree == 1)
                    {
                        SuperThree.Text = ClassAddress.PowerOne;
                        SuperThreeLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomThree == 2)
                    {
                        SuperThree.Text = ClassAddress.PowerTwo;
                        SuperThreeLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomThree == 3)
                    {
                        SuperThree.Text = ClassAddress.PowerThree;
                        SuperThreeLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomThree == 4)
                    {
                        SuperThree.Text = ClassAddress.PowerFour;
                        SuperThreeLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomThree == 5)
                    {
                        SuperThree.Text = ClassAddress.PowerFive;
                        SuperThreeLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomThree == 6)
                    {
                        SuperThree.Text = ClassAddress.PowerSix;
                        SuperThreeLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomThree == 7)
                    {
                        SuperThree.Text = ClassAddress.PowerOne;
                        SuperThreeLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomThree == 8)
                    {
                        SuperThree.Text = ClassAddress.PowerEight;
                        SuperThreeLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperThreeLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperThreeLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperThreeLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }
                if (SuperFour.Text == "---")
                {
                    RandomFour = random.Next(1, 9);

                    if (RandomFour == 1)
                    {
                        SuperFour.Text = ClassAddress.PowerOne;
                        SuperFourLineOne.Text = ClassAddress.PowerOneLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerOneLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerOneLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerOneLineFour;
                    }
                    else if (RandomFour == 2)
                    {
                        SuperFour.Text = ClassAddress.PowerTwo;
                        SuperFourLineOne.Text = ClassAddress.PowerTwoLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerTwoLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerTwoLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerTwoLineFour;
                    }
                    else if (RandomFour == 3)
                    {
                        SuperFour.Text = ClassAddress.PowerThree;
                        SuperFourLineOne.Text = ClassAddress.PowerThreeLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerThreeLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerThreeLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerThreeLineFour;
                    }
                    else if (RandomFour == 4)
                    {
                        SuperFour.Text = ClassAddress.PowerFour;
                        SuperFourLineOne.Text = ClassAddress.PowerFourLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerFourLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerFourLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerFourLineFour;
                    }
                    else if (RandomFour == 5)
                    {
                        SuperFour.Text = ClassAddress.PowerFive;
                        SuperFourLineOne.Text = ClassAddress.PowerFiveLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerFiveLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerFiveLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerFiveLineFour;
                    }
                    else if (RandomFour == 6)
                    {
                        SuperFour.Text = ClassAddress.PowerSix;
                        SuperFourLineOne.Text = ClassAddress.PowerSixLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerSixLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerSixLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerSixLineFour;
                    }
                    else if (RandomFour == 7)
                    {
                        SuperFour.Text = ClassAddress.PowerOne;
                        SuperFourLineOne.Text = ClassAddress.PowerSevenLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerSevenLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerSevenLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerSevenLineFour;
                    }
                    else if (RandomFour == 8)
                    {
                        SuperFour.Text = ClassAddress.PowerEight;
                        SuperFourLineOne.Text = ClassAddress.PowerEightLineOne;
                        SuperFourLineTwo.Text = ClassAddress.PowerEightLineTwo;
                        SuperFourLineThree.Text = ClassAddress.PowerEightLineThree;
                        SuperFourLineFour.Text = ClassAddress.PowerEightLineFour;
                    }

                }
            }


            ExperienceQuestions LevelSheet = new ExperienceQuestions(this);
            LevelSheet.Show();

            SaveCharacterInformation();

        }

        public string ExperienceModify
        {
            get { return ExpCurrent.Text; }
            set { int.TryParse(ExpCurrent.Text, out int ExpGrab); int.TryParse(value, out int ExpGrowth); ExpCurrent.Text = (ExpGrowth + ExpGrab).ToString(); }
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



            FirstTime = true;
            ReadableInventory.Text.ToLower().Replace("strength", "(Strength");

            /*
        public void RewordInventory()
        {
            // Read in text, splitting it at ",", and put them into an array
            string InventoryItems = ReadableInventory.Text;
            InventoryItems = InventoryItems.Replace("Strength", "(Strength");
            InventoryItems = InventoryItems.Replace("Agility", "(Agility");
            InventoryItems = InventoryItems.Replace("Vibes", "(Vibes");
            InventoryItems = InventoryItems.Replace("Wits", "(Wits");
            InventoryItems = InventoryItems.Replace("Education", "(Education");
            InventoryItems = InventoryItems.Replace("Meat", "(Meat");
            InventoryItems = InventoryItems.Replace("Veg", "(Veg");
            InventoryItems = InventoryItems.Replace("Bread", "(Bread");
            InventoryItems = InventoryItems.Replace("Fruit", "(Fruit");
            InventoryItems = InventoryItems.Replace("Fish", "(Fish");
            InventoryItems = InventoryItems.Replace("((", "(");
            InventoryItems = InventoryItems.Replace("0 ", "0), ");
            InventoryItems = InventoryItems.Replace("0,", "0),");
            InventoryItems = InventoryItems.Replace("1 ", "1), ");
            InventoryItems = InventoryItems.Replace("1,", "1),");
            InventoryItems = InventoryItems.Replace("2 ", "2), ");
            InventoryItems = InventoryItems.Replace("2,", "2),");
            InventoryItems = InventoryItems.Replace("3 ", "3), ");
            InventoryItems = InventoryItems.Replace("3,", "3),");
            InventoryItems = InventoryItems.Replace("4 ", "4), ");
            InventoryItems = InventoryItems.Replace("4,", "4),");
            InventoryItems = InventoryItems.Replace("5 ", "5), ");
            InventoryItems = InventoryItems.Replace("5,", "5),");
            InventoryItems = InventoryItems.Replace("6 ", "6), ");
            InventoryItems = InventoryItems.Replace("6,", "6),");
            InventoryItems = InventoryItems.Replace("7 ", "7), ");
            InventoryItems = InventoryItems.Replace("7,", "7),");
            InventoryItems = InventoryItems.Replace("8 ", "8), ");
            InventoryItems = InventoryItems.Replace("8,", "8),");
            InventoryItems = InventoryItems.Replace("9 ", "9), ");
            InventoryItems = InventoryItems.Replace("9,", "9),");
            InventoryItems = InventoryItems.Replace("))", ")");
            ReadableInventory.Text = InventoryItems;
        }
        */
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
            InventoryUpdate();
        }


        public void InventoryUpdate()
        {
            // Read in text, splitting it at ",", and put them into an array
            string InventoryItems = ReadableInventory.Text;
            InventoryItems = InventoryItems.Replace(" Strength", " (Strength", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Agility".ToLower(), " (Agility", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Vibes".ToLower(), " (Vibes", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Wits".ToLower(), " (Wits", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Education".ToLower(), " (Education", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Meat".ToLower(), " (Meat", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Veg".ToLower(), " (Veg", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Bread".ToLower(), " (Bread", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Fruit".ToLower(), " (Fruit", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace(" Fish".ToLower(), " (Fish", StringComparison.OrdinalIgnoreCase);
            InventoryItems = InventoryItems.Replace("0 ", "0), ");
            InventoryItems = InventoryItems.Replace("0,", "0),");
            InventoryItems = InventoryItems.Replace("*0", "* 0");
            InventoryItems = InventoryItems.Replace("+0", "+ 0");
            InventoryItems = InventoryItems.Replace("1 ", "1), ");
            InventoryItems = InventoryItems.Replace("1,", "1),");
            InventoryItems = InventoryItems.Replace("*1", "* 1");
            InventoryItems = InventoryItems.Replace("+1", "+ 1");
            InventoryItems = InventoryItems.Replace("2 ", "2), ");
            InventoryItems = InventoryItems.Replace("2,", "2),");
            InventoryItems = InventoryItems.Replace("*2", "* 2");
            InventoryItems = InventoryItems.Replace("+2", "+ 2");
            InventoryItems = InventoryItems.Replace("3 ", "3), ");
            InventoryItems = InventoryItems.Replace("3,", "3),");
            InventoryItems = InventoryItems.Replace("*3", "* 3");
            InventoryItems = InventoryItems.Replace("+3", "+ 3");
            InventoryItems = InventoryItems.Replace("4 ", "4), ");
            InventoryItems = InventoryItems.Replace("4,", "4),");
            InventoryItems = InventoryItems.Replace("*4", "* 4");
            InventoryItems = InventoryItems.Replace("+4", "+ 4");
            InventoryItems = InventoryItems.Replace("5 ", "5), ");
            InventoryItems = InventoryItems.Replace("5,", "5),");
            InventoryItems = InventoryItems.Replace("*5", "* 5");
            InventoryItems = InventoryItems.Replace("+5", "+ 5");
            InventoryItems = InventoryItems.Replace("6 ", "6), ");
            InventoryItems = InventoryItems.Replace("6,", "6),");
            InventoryItems = InventoryItems.Replace("*6", "* 6");
            InventoryItems = InventoryItems.Replace("+6", "+ 6");
            InventoryItems = InventoryItems.Replace("7 ", "7), ");
            InventoryItems = InventoryItems.Replace("7,", "7),");
            InventoryItems = InventoryItems.Replace("*7", "* 7");
            InventoryItems = InventoryItems.Replace("+7", "+ 7");
            InventoryItems = InventoryItems.Replace("8 ", "8), ");
            InventoryItems = InventoryItems.Replace("8,", "8),");
            InventoryItems = InventoryItems.Replace("*8", "* 8");
            InventoryItems = InventoryItems.Replace("+8", "+ 8");
            InventoryItems = InventoryItems.Replace("9 ", "9), ");
            InventoryItems = InventoryItems.Replace("9,", "9),");
            InventoryItems = InventoryItems.Replace("*9", "* 9");
            InventoryItems = InventoryItems.Replace("+9", "+ 9");
            ReadableInventory.Text = InventoryItems;


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
                if (item.ToLower().Contains("strength"))
                {
                    item.ToLower().Replace("strength", "(Strength");
                    item.ToLower().Replace("((", "(");
                    StrengthQuality[StrengthQualityIndex++] = item;
                }
                else if (item.ToLower().Contains("agility"))
                {
                    item.ToLower().Replace("agility", "(Agility");
                    item.ToLower().Replace("((", "(");
                    AgilityQuality[AgilityQualityIndex++] = item;
                }
                else if (item.ToLower().Contains("wits"))
                {
                    item.ToLower().Replace("wits", "(Wits");
                    item.ToLower().Replace("((", "(");
                    WitsQuality[WitsQualityIndex++] = item;
                }
                else if (item.ToLower().Contains("vibes"))
                {
                    item.ToLower().Replace("vibes", "(Vibes");
                    item.ToLower().Replace("((", "(");
                    VibesQuality[VibesQualityIndex++] = item;
                }
                else if (item.ToLower().Contains("education"))
                {
                    item.ToLower().Replace("education", "(Education");
                    item.ToLower().Replace("((", "(");
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
            int indexOfClosingBracket = 0;

            // using the smaller arrays
            foreach (string item in StrengthQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(')');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(',');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                StrengthBoost = StrengthBoost + StatBoost;
            }
            foreach (string item in AgilityQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(')');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(',');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                AgilityBoost = AgilityBoost + StatBoost;
            }
            foreach (string item in VibesQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(')');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(',');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                VibesBoost = VibesBoost + StatBoost;
            }
            foreach (string item in WitsQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(')');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(',');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                WitsBoost = WitsBoost + StatBoost;
            }
            foreach (string item in EducationQuality)
            {
                // Trim the front to remove "+" and everything before it
                string BoostHolster = item.Substring(item.IndexOf("+") + 2);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(')');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = BoostHolster.IndexOf(',');
                    BoostHolster = BoostHolster.Substring(0, indexOfClosingBracket);
                }

                // Get the stat boost
                int.TryParse(BoostHolster, out int StatBoost);
                EducationBoost = EducationBoost + StatBoost;
            }

            StrengthIncrease = StrengthBoost;
            AgilityIncrease = AgilityBoost;
            VibesIncrease = VibesBoost;
            WitsIncrease = WitsBoost;
            EducationIncrease = EducationBoost;


            // Constructing a string from the arrays
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
                if (item.ToLower().Contains("meat"))
                {
                    item.ToLower().Replace("meat", "(Meat");
                    item.ToLower().Replace("((", "(");
                    MeatQuantity[MeatQuantityIndex++] = item;
                }
                else if (item.ToLower().Contains("veggies") || item.ToLower().Contains("vegetables"))
                {
                    item.ToLower().Replace("veg", "(Veg");
                    item.ToLower().Replace("((", "(");
                    VeggiesQuantity[VeggiesQuantityIndex++] = item;
                }
                else if (item.ToLower().Contains("fruit"))
                {
                    item.ToLower().Replace("fruit", "(Fruit");
                    item.ToLower().Replace("((", "(");
                    FruitQuantity[FruitQuantityIndex++] = item;
                }
                else if (item.ToLower().Contains("bread"))
                {
                    item.ToLower().Replace("bread", "(Bread");
                    item.ToLower().Replace("((", "(");
                    BreadQuantity[BreadQuantityIndex++] = item;
                }
                else if (item.ToLower().Contains("fish"))
                {
                    item.ToLower().Replace("fish", "(Fish");
                    item.ToLower().Replace("((", "(");
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
                string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(')');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(',');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                MeatExist = MeatExist + StatExist;
            }
            foreach (string item in VeggiesQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(')');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(',');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                VeggiesExist = VeggiesExist + StatExist;
            }
            foreach (string item in BreadQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(')');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(',');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                BreadExist = BreadExist + StatExist;
            }
            foreach (string item in FruitQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(')');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(',');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                // Get the stat Exist
                int.TryParse(ExistHolster, out int StatExist);
                FruitExist = FruitExist + StatExist;
            }
            foreach (string item in FishQuantity)
            {
                // Trim the front to remove "*" and everything before it
                string ExistHolster = item.Substring(item.IndexOf("*") + 1);

                // Trim the back to remove ")" and everything after it
                if (item.Contains(")"))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(')');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
                else if (item.Contains(","))
                {
                    indexOfClosingBracket = ExistHolster.IndexOf(',');
                    ExistHolster = ExistHolster.Substring(0, indexOfClosingBracket);
                }
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
            string FinalisedInventory = inventoryText.ToString();

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


            string CommaControl = ReadableInventory.Text;

            CommaControl = CommaControl.Replace(" ,", "");

            ReadableInventory.Text = CommaControl;

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
            // Check the details for the math
            bool MultiCrit = BasicCritSuccess.Text.Contains("x");
            bool MultiFail = BasicCritFail.Text.Contains("x");
            int.TryParse(BasicCritSuccess.Text.Replace("x", ""), out int CritRequire);
            int.TryParse(BasicCritFail.Text.Replace("x", ""), out int FailRequire);


            // Get the individual dice set-up
            Random random = new Random();
            string IndividualRolls = null;
            int TotalResult = 0;
            int DiceRolling = 0;
            int DiceScore = 0;


            // Find the attacking stat
            if (BasicAttackStat.Text == "Attack")
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (BasicAttackStat.Text == "Strength")
            {
                int.TryParse(DigimonStrength.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (BasicAttackStat.Text == "Agility")
            {
                int.TryParse(DigimonAgility.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (BasicAttackStat.Text == "Vibes")
            {
                int.TryParse(DigimonVibes.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (BasicAttackStat.Text == "Wits")
            {
                int.TryParse(DigimonWits.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (BasicAttackStat.Text == "Education")
            {
                int.TryParse(DigimonEducation.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }


            // Do The Rolls
            for (int i = 0; i < DiceRolling; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }


            // Get the target score
            int.TryParse(TargetArmour.Text, out int TargetDefense);
            int TargetDice = TotalResult;

            string StrikeInflicted = null;

            MessageBox.Show($"Attack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetArmour.Text}\nResults: {StrikeInflicted}");

            if (TargetDefense < TotalResult - 1)
            {
                if (TotalResult - TargetDefense > CritRequire -1)
                {
                    if (MultiCrit)
                    {
                        string MultiPoint = ((TargetDice - DiceScore) / CritRequire).ToString();
                        MessageBox.Show($"{BasicEffect.Text}\n{BasicBonus.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{BasicEffect.Text}\n{BasicBonus.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"{BasicEffect.Text}");
                }
            }
            else
            {
                if (TotalResult - TargetDefense < (-1 * (FailRequire -1)))
                {
                    if (MultiFail)
                    {
                        string MultiPoint = ((TargetDice - DiceScore) / FailRequire).ToString();
                        MessageBox.Show($"{BasicPenalty.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{BasicPenalty.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"Nothing happened...");
                }
            }

            GaurdPoints--;
            StratPoints.Text = "";
        }



        private void StandardAttack_Click(object sender, EventArgs e)
        {
            // Check the details for the math
            bool MultiCrit = StandardCritSuccess.Text.Contains("x");
            bool MultiFail = StandardCritFail.Text.Contains("x");
            int.TryParse(StandardCritSuccess.Text.Replace("x", ""), out int CritRequire);
            int.TryParse(StandardCritFail.Text.Replace("x", ""), out int FailRequire);


            // Get the individual dice set-up
            Random random = new Random();
            string IndividualRolls = null;
            int TotalResult = 0;
            int DiceRolling = 0;
            int DiceScore = 0;


            // Find the attacking stat
            if (StandardAttackStat.Text == "Attack")
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (StandardAttackStat.Text == "Strength")
            {
                int.TryParse(DigimonStrength.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (StandardAttackStat.Text == "Agility")
            {
                int.TryParse(DigimonAgility.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (StandardAttackStat.Text == "Vibes")
            {
                int.TryParse(DigimonVibes.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (StandardAttackStat.Text == "Wits")
            {
                int.TryParse(DigimonWits.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (StandardAttackStat.Text == "Education")
            {
                int.TryParse(DigimonEducation.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }


            // Do The Rolls
            for (int i = 0; i < DiceRolling; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }


            // Get the target score
            int.TryParse(TargetArmour.Text, out int TargetDefense);
            int TargetDice = TotalResult;

            string StrikeInflicted = null;

            MessageBox.Show($"Attack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetArmour.Text}\nResults: {StrikeInflicted}");

            if (TargetDefense < TotalResult - 1)
            {
                if (TotalResult - TargetDefense > CritRequire - 1)
                {
                    if (MultiCrit)
                    {
                        string MultiPoint = ((TargetDice - DiceScore) / CritRequire).ToString();
                        MessageBox.Show($"{StandardEffect.Text}\n{StandardBonus.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{StandardEffect.Text}\n{StandardBonus.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"{StandardEffect.Text}");
                }
            }
            else
            {
                if (TotalResult - TargetDefense < (-1 * (FailRequire - 1)))
                {
                    if (MultiFail)
                    {
                        string MultiPoint = ((TargetDice - DiceScore) / FailRequire).ToString();
                        MessageBox.Show($"{StandardPenalty.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{StandardPenalty.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"Nothing happened...");
                }
            }

            GaurdPoints--;
            StratPoints.Text = "";
        }


        private void SpecialAttack_Click(object sender, EventArgs e)
        {
            // Check the details for the math
            bool MultiCrit = SpecialCritSuccess.Text.Contains("x");
            bool MultiFail = SpecialCritFail.Text.Contains("x");
            int.TryParse(SpecialCritSuccess.Text.Replace("x", ""), out int CritRequire);
            int.TryParse(SpecialCritFail.Text.Replace("x", ""), out int FailRequire);


            // Get the individual dice set-up
            Random random = new Random();
            string IndividualRolls = null;
            int TotalResult = 0;
            int DiceRolling = 0;
            int DiceScore = 0;


            // Find the attacking stat
            if (SpecialAttackStat.Text == "Attack")
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SpecialAttackStat.Text == "Strength")
            {
                int.TryParse(DigimonStrength.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SpecialAttackStat.Text == "Agility")
            {
                int.TryParse(DigimonAgility.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SpecialAttackStat.Text == "Vibes")
            {
                int.TryParse(DigimonVibes.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SpecialAttackStat.Text == "Wits")
            {
                int.TryParse(DigimonWits.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SpecialAttackStat.Text == "Education")
            {
                int.TryParse(DigimonEducation.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }


            // Do The Rolls
            for (int i = 0; i < DiceRolling; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }


            // Get the target score
            int.TryParse(TargetArmour.Text, out int TargetDefense);
            int TargetDice = TotalResult;

            string StrikeInflicted = null;

            MessageBox.Show($"Attack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetArmour.Text}\nResults: {StrikeInflicted}");

            if (TargetDefense < TotalResult - 1)
            {
                if (TotalResult - TargetDefense > CritRequire - 1)
                {
                    if (MultiCrit)
                    {
                        string MultiPoint = ((TotalResult - TargetDefense) / CritRequire).ToString();
                        MessageBox.Show($"{SpecialEffect.Text}\n{SpecialBonus.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{SpecialEffect.Text}\n{SpecialBonus.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"{SpecialEffect.Text}");
                }
            }
            else
            {
                if (TotalResult - TargetDefense < (-1 * (FailRequire - 1)))
                {
                    if (MultiFail)
                    {
                        string MultiPoint = ((TargetDefense - TotalResult) / FailRequire).ToString();
                        MessageBox.Show($"{SpecialPenalty.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{SpecialPenalty.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"Nothing happened...");
                }
            }

            GaurdPoints--;
            StratPoints.Text = "";
        }

        private void SuperAttack_Click(object sender, EventArgs e)
        {
            // Check the details for the math
            bool MultiCrit = SuperCritSuccess.Text.Contains("x");
            bool MultiFail = SuperCritFail.Text.Contains("x");
            int.TryParse(SuperCritSuccess.Text.Replace("x", ""), out int CritRequire);
            int.TryParse(SuperCritFail.Text.Replace("x", ""), out int FailRequire);


            // Get the individual dice set-up
            Random random = new Random();
            string IndividualRolls = null;
            int TotalResult = 0;
            int DiceRolling = 0;
            int DiceScore = 0;


            // Find the attacking stat
            if (SuperAttackStat.Text == "Attack")
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SuperAttackStat.Text == "Strength")
            {
                int.TryParse(DigimonStrength.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SuperAttackStat.Text == "Agility")
            {
                int.TryParse(DigimonAgility.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SuperAttackStat.Text == "Vibes")
            {
                int.TryParse(DigimonVibes.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SuperAttackStat.Text == "Wits")
            {
                int.TryParse(DigimonWits.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else if (SuperAttackStat.Text == "Education")
            {
                int.TryParse(DigimonEducation.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }
            else
            {
                int.TryParse(DigiAttackRoll.Text, out int DiceRoller);
                DiceRolling = DiceRoller;
            }



            // Modified Roll Counter
            if (SuperAttackStat.Text == "Education" || SuperAttackStat.Text == "Agility" || SuperAttackStat.Text == "Vibes" || SuperAttackStat.Text == "Wits" || SuperAttackStat.Text == "Education")
            {
                if (DigiRollPlusOne.Checked) { DiceRolling++; };
                if (DigiRollPlusTwo.Checked) { DiceRolling++; };
                if (DigiRollPlusThree.Checked) { DiceRolling++; };
                if (DigiRollPlusFour.Checked) { DiceRolling++; };
                if (DigiRollPlusFive.Checked) { DiceRolling++; };

                if (DigiRollMinusOne.Checked) { DiceRolling--; };
                if (DigiRollMinusTwo.Checked) { DiceRolling--; };
                if (DigiRollMinusThree.Checked) { DiceRolling--; };
                if (DigiRollMinusFour.Checked) { DiceRolling--; };
                if (DigiRollMinusFive.Checked) { DiceRolling--; };

                if (DiceRolling < 0) { DiceRolling = 0; };
            }


            // Do The Rolls
            for (int i = 0; i < DiceRolling; i++)
            {
                // Generates a random number between 1 and 10
                int DiceResult = random.Next(1, 11);
                TotalResult += DiceResult;
                // Collect individual rolls
                IndividualRolls += DiceResult + " ";
            }


            // Get the target score
            int.TryParse(TargetArmour.Text, out int TargetDefense);
            int TargetDice = TotalResult;

            string StrikeInflicted = null;

            MessageBox.Show($"Attack Rolls: {IndividualRolls}\nTotal Attack: {TotalResult} VS Target Defense: {TargetArmour.Text}\nResults: {StrikeInflicted}");

            if (TargetDefense < TotalResult - 1)
            {
                if (TotalResult - TargetDefense > CritRequire - 1)
                {
                    if (MultiCrit)
                    {
                        string MultiPoint = ((TotalResult - TargetDefense) / CritRequire).ToString();
                        MessageBox.Show($"{SuperEffect.Text}\n{SuperBonus.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{SuperEffect.Text}\n{SuperBonus.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"{SuperEffect.Text}");
                }
            }
            else
            {
                if (TotalResult - TargetDefense < (-1 * (FailRequire - 1)))
                {
                    if (MultiFail)
                    {
                        string MultiPoint = ((TargetDefense - TotalResult) / FailRequire).ToString();
                        MessageBox.Show($"{SuperPenalty.Text.Replace(" x ", " " + MultiPoint + " ")}");
                    }
                    else
                    {
                        MessageBox.Show($"{SuperPenalty.Text}");
                    }

                }
                else
                {
                    MessageBox.Show($"Nothing happened...");
                }
            }
        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        bool BasicAttackNow = false;
        bool StandardAttackNow = false;
        bool SpecialAttackNow = false;
        bool SuperAttackNow = false;
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
                    ActBasicAttack.Text = "ACTIVATE";
                    ActBasicAttack.Enabled = true;
                    BasicAttackNow = true;
                }
                else if (DiceResult >= MinStandard && DiceResult <= MaxStandard)
                {
                    MessageBox.Show(StandardAttack.Text);
                    ActStandardAttack.Text = "ACTIVATE";
                    ActStandardAttack.Enabled = true;
                    StandardAttackNow = true;
                }
                else if (DiceResult >= MinSpecial && DiceResult <= MaxSpecial)
                {
                    MessageBox.Show(SpecialAttack.Text);
                    ActSpecialAttack.Text = "ACTIVATE";
                    ActSpecialAttack.Enabled = true;
                    SpecialAttackNow = true;
                }
                else if (DiceResult >= MinSuper && DiceResult <= MaxSuper)
                {
                    MessageBox.Show(SuperAttack.Text);
                    ActSuperAttack.Text = "ACTIVATE";
                    ActSuperAttack.Enabled = true;
                    SuperAttackNow = true;
                }
            }

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

            SaveCharacterInformation();

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

            SaveCharacterInformation();

        }

        private void CharacterName_TextChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void DigimonStrength_TextChanged(object sender, EventArgs e)
        {
            int DigitalStrength;

            if (FreshEvolution == true)
            {
                DigitalStrength = 0;
            }
            else if (TrainingEvolution == true)
            {
                DigitalStrength = 1;
            }
            else if (RookieEvolution == true)
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

            if (InheritableQuirkTwo.Text.Contains("Strength Champion") || InheritedQuirkFive.Text.Contains("Strength"))
            {
                DigitalStrength++;
            }

            if (InheritableQuirkTwo.Text.Contains("Strength Ultimate") || InheritedQuirkSeven.Text.Contains("Strength"))
            {
                DigitalStrength++;
                DigitalStrength++;
            }

            if (InheritableQuirkTwo.Text.Contains("Strength Mega"))
            {
                DigitalStrength++;
                DigitalStrength++;
                DigitalStrength++;
            }

            DigimonStrength.Text = DigitalStrength.ToString();

            if (MealWits == true)
            {
                DigitalStrength++;
            }

            DigiStrengthSave.Text = ((int)Math.Floor(DigitalStrength * 3.5)).ToString();

        }

        private void DigimonAgility_TextChanged(object sender, EventArgs e)
        {
            int DigitalAgility;

            if (FreshEvolution == true)
            {
                DigitalAgility = 0;
            }
            else if (TrainingEvolution == true)
            {
                DigitalAgility = 1;
            }
            else if (RookieEvolution == true)
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

            if (InheritableQuirkTwo.Text.Contains("Agility Champion") || InheritedQuirkFive.Text.Contains("Agility"))
            {
                DigitalAgility++;
            }

            if (InheritableQuirkTwo.Text.Contains("Agility Ultimate") || InheritedQuirkSeven.Text.Contains("Agility"))
            {
                DigitalAgility++;
                DigitalAgility++;
            }

            if (InheritableQuirkTwo.Text.Contains("Agility Mega"))
            {
                DigitalAgility++;
                DigitalAgility++;
                DigitalAgility++;
            }

            DigimonAgility.Text = DigitalAgility.ToString();



            if (MealWits == true)
            {
                DigitalAgility++;
            }

            DigiAgilitySave.Text = ((int)Math.Floor(DigitalAgility * 3.5)).ToString();

        }

        private void DigimonVibes_TextChanged(object sender, EventArgs e)
        {
            int DigitalVibes;

            if (FreshEvolution == true)
            {
                DigitalVibes = 0;
            }
            else if (TrainingEvolution == true)
            {
                DigitalVibes = 1;
            }
            else if (RookieEvolution == true)
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

            if (InheritableQuirkTwo.Text.Contains("Vibes Champion") || InheritedQuirkFive.Text.Contains("Vibes"))
            {
                DigitalVibes++;
            }

            if (InheritableQuirkTwo.Text.Contains("Vibes Ultimate") || InheritedQuirkSeven.Text.Contains("Vibes"))
            {
                DigitalVibes++;
                DigitalVibes++;
            }

            if (InheritableQuirkTwo.Text.Contains("Vibes Mega"))
            {
                DigitalVibes++;
                DigitalVibes++;
                DigitalVibes++;
            }

            DigimonVibes.Text = DigitalVibes.ToString();

            if (MealWits == true)
            {
                DigitalVibes++;
            }

            DigiVibesSave.Text = ((int)Math.Floor(DigitalVibes * 3.5)).ToString();

        }

        private void DigimonWits_TextChanged(object sender, EventArgs e)
        {
            int DigitalWits;

            if (FreshEvolution == true)
            {
                DigitalWits = 0;
            }
            else if (TrainingEvolution == true)
            {
                DigitalWits = 1;
            }
            else if (RookieEvolution == true)
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

            if (InheritableQuirkTwo.Text.Contains("Wits Champion") || InheritedQuirkFive.Text.Contains("Wits"))
            {
                DigitalWits++;
            }

            if (InheritableQuirkTwo.Text.Contains("Wits Ultimate") || InheritedQuirkSeven.Text.Contains("Wits"))
            {
                DigitalWits++;
                DigitalWits++;
            }

            if (InheritableQuirkTwo.Text.Contains("Wits Mega"))
            {
                DigitalWits++;
                DigitalWits++;
                DigitalWits++;
            }

            DigimonWits.Text = DigitalWits.ToString();

            DigiWitsSave.Text = ((int)Math.Floor(DigitalWits * 3.5)).ToString();

        }

        private void DigimonEducation_TextChanged(object sender, EventArgs e)
        {
            int DigitalEducation;

            if (FreshEvolution == true)
            {
                DigitalEducation = 0;
            }
            else if (TrainingEvolution == true)
            {
                DigitalEducation = 1;
            }
            else if (RookieEvolution == true)
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

            if (InheritableQuirkTwo.Text.Contains("Education Champion") || InheritedQuirkFive.Text.Contains("Education"))
            {
                DigitalEducation++;
            }

            if (InheritableQuirkTwo.Text.Contains("Education Ultimate") || InheritedQuirkSeven.Text.Contains("Education"))
            {
                DigitalEducation++;
                DigitalEducation++;
            }

            if (InheritableQuirkTwo.Text.Contains("Education Mega"))
            {
                DigitalEducation++;
                DigitalEducation++;
                DigitalEducation++;
            }

            DigimonEducation.Text = DigitalEducation.ToString();


            if (MealWits == true)
            {
                DigitalEducation++;
            }

            DigiEducationSave.Text = ((int)Math.Floor(DigitalEducation * 3.5)).ToString();

        }

        private void EducationMeal_CheckedChanged(object sender, EventArgs e)
        {
        }

        bool FirstTime = true;

        private void TamerDigimon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                InventoryUpdate();
            }

            if (TamerDigimon.SelectedIndex == 3 && Partner.Text.Contains("mon"))
            {
                HaveMeal.Enabled = true;
            }
            else
            {
                HaveMeal.Enabled = false;
            }

            SaveCharacterInformation();
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

            if (DigiRollPlusThree.Checked == true)
            {
                DigitalStrike++;
            }

            if (DigiRollPlusFour.Checked == true)
            {
                DigitalStrike++;
            }

            if (DigiRollPlusFive.Checked == true)
            {
                DigitalStrike++;
            }

            if (DigiRollMinusOne.Checked == true)
            {
                DigitalStrike--;
            }


            if (DigiRollMinusTwo.Checked == true)
            {
                if (DigiRollMinusTwo.Checked == true)


                    DigitalStrike--;
            }

            if (DigiRollMinusThree.Checked == true)
            {
                DigitalStrike--;
            }

            if (DigiRollMinusFour.Checked == true)
            {
                DigitalStrike--;
            }

            if (DigiRollMinusFive.Checked == true)
            {
                DigitalStrike--;
            }

            if (MealStrength == true)
            {
                DigitalStrike++;
            }

            if (InheritableQuirkTwo.Text.Contains("Strength Champion") || InheritableQuirkOne.Text.Contains("Strength Champion"))
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

                if (InheritableQuirkTwo.Text.Contains("Agility Champion") || InheritableQuirkOne.Text.Contains("Agility Champion"))
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
            MessageBox.Show($"Main Roll: {CoreRoll}\nAdditional Rolls: {IndividualRolls}\nTotal Result: {TotalResult}");

        }

        private void DigiSoulStat_TextChanged(object sender, EventArgs e)
        {
            // Calculate the total of the Strength Skills
            int totalValue = (int)ErrorScanTrack.Value + (int)InfoExtractTrack.Value + (int)GigaSearchTrack.Value + (int)WaybackTrackTrack.Value;

            // Halve the totalValue and round up
            totalValue = totalValue / SoulGrowthRate;
            int halvedValue = (int)Math.Ceiling(totalValue / 1.0);

            // Modify for the classes
            halvedValue += SoulStartCount;
            

            // Subtract used points
            halvedValue = halvedValue - digiSoulCost;

            // Output the halvedValue to the text box
            DigiSoulStat.Text = halvedValue.ToString();

            if (DigiSoulStat.Text == "0")
            {
                ActivatePowerOne.Enabled = false;
                ActivatePowerTwo.Enabled = false;
                ActivatePowerThree.Enabled = false;
                ActivatePowerFour.Enabled = false;
            }
            else if (DigiSoulStat.Text != "0" && ClassBox.SelectedIndex > -1)
            {
                ActivatePowerOne.Enabled = true;
                ActivatePowerTwo.Enabled = true;
                ActivatePowerThree.Enabled = true;
                ActivatePowerFour.Enabled = true;
            }



            if (PowerRollOne.Text != "---" && DigiSoulStat.Text != "0")
            {
                ActivatePowerOne.Enabled = true;
                ActivatePowerTwo.Enabled = true;
                ActivatePowerThree.Enabled = true;
                ActivatePowerFour.Enabled = true;
            }

            SaveCharacterInformation();
        }

        private void ToiletOne_CheckedChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void ToiletTwo_CheckedChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void CrapTwo_CheckedChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void CrapThree_CheckedChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }

        private void CrapFour_CheckedChanged(object sender, EventArgs e)
        {
            SaveCharacterInformation();
        }


        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void checkBox2_CheckedChanged_2(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void checkBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void DigiRollPlusThree_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void DigiRollPlusFive_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void DigiRollMinusThree_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void fs_CheckedChanged(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }

        private void fs_CheckedChanged_1(object sender, EventArgs e)
        {
            DigiAttackRoll.Text = "";
        }



        int digiSoulCost = 0;
        private void button22_Click_3(object sender, EventArgs e)
        {

            if (ClassBox.SelectedIndex > -1)
            {
                string TamerFilePath = $"Resources/Class/{ClassBox.Text}/{ClassBox.Text}.json";
                TamerInfo ClassAddress = JsonSerializer.Deserialize<TamerInfo>(File.ReadAllText(TamerFilePath));

                if (ClassAddress.MysticArtist)
                {
                    SuperOne.Text = "---";

                    SuperOneLineOne.Text = "---";

                    SuperOneLineTwo.Text = "---";

                    SuperOneLineThree.Text = "---";

                    SuperOneLineFour.Text = "---";

                    digiSoulCost -= 1;
                }
            }

            if (int.TryParse(DigiSoulStat.Text, out int digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulCost += 1; // Subtract 1 from the score
            }

            DigiSoulStat.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            if (ClassBox.SelectedIndex > -1)
            {
                string TamerFilePath = $"Resources/Class/{ClassBox.Text}/{ClassBox.Text}.json";
                TamerInfo ClassAddress = JsonSerializer.Deserialize<TamerInfo>(File.ReadAllText(TamerFilePath));

                if (ClassAddress.MysticArtist)
                {
                    SuperTwo.Text = "---";

                    SuperTwoLineOne.Text = "---";

                    SuperTwoLineTwo.Text = "---";

                    SuperTwoLineThree.Text = "---";

                    SuperTwoLineFour.Text = "---";

                    digiSoulCost -= 1;
                }
            }

            if (int.TryParse(DigiSoulStat.Text, out int digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulCost += 1; // Subtract 1 from the score
            }

            DigiSoulStat.Text = "";
        }

        private void button5_Click_4(object sender, EventArgs e)
        {

            if (ClassBox.SelectedIndex > -1)
            {
                string TamerFilePath = $"Resources/Class/{ClassBox.Text}/{ClassBox.Text}.json";
                TamerInfo ClassAddress = JsonSerializer.Deserialize<TamerInfo>(File.ReadAllText(TamerFilePath));

                if (ClassAddress.MysticArtist)
                {
                    SuperThree.Text = "---";

                    SuperThreeLineOne.Text = "---";

                    SuperThreeLineTwo.Text = "---";

                    SuperThreeLineThree.Text = "---";

                    SuperThreeLineFour.Text = "---";

                    digiSoulCost -= 1;
                }
            }

            if (int.TryParse(DigiSoulStat.Text, out int digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulCost += 1; // Subtract 1 from the score
            }

            DigiSoulStat.Text = "";
        }

        private void button24_Click(object sender, EventArgs e)
        {

            if (ClassBox.SelectedIndex > -1)
            {
                string TamerFilePath = $"Resources/Class/{ClassBox.Text}/{ClassBox.Text}.json";
                TamerInfo ClassAddress = JsonSerializer.Deserialize<TamerInfo>(File.ReadAllText(TamerFilePath));

                if (ClassAddress.MysticArtist)
                {
                    SuperFour.Text = "---";

                    SuperFourLineOne.Text = "---";

                    SuperFourLineTwo.Text = "---";

                    SuperFourLineThree.Text = "---";

                    SuperFourLineFour.Text = "---";

                    digiSoulCost -= 1;
                }
            }

            if (int.TryParse(DigiSoulStat.Text, out int digiSoulScore) && digiSoulScore > 0)
            {
                digiSoulCost += 1; // Subtract 1 from the score
            }

            DigiSoulStat.Text = "";
        }



        string ClassPath;
        string ClassName;
        bool CardClass = false;
        bool SceneClass = false;
        int SoulGrowthRate = 1;
        int SoulStartCount = 1;
        int SoulRollMod = 1;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ClassBox.Text == "")
            {
                ClassBox.Enabled = true;
            }
            else
            {
                ClassBox.Enabled = false;
            };

            ClassPath = $"Resources/Class/{ClassBox.Text}/{ClassBox.Text}.json";
            ClassName = ClassBox.Text;
            ClassAssignment();
        }

        private void ClassAssignment()
        {
        TamerInfo ClassAddress = JsonSerializer.Deserialize<TamerInfo>(File.ReadAllText(ClassPath));
            ClassBox.Text = ClassName;

            CardClass = ClassAddress.CardClass;
            SceneClass = ClassAddress.SceneClass;
            SoulGrowthRate = ClassAddress.SoulGrowthRate;
            SoulStartCount = ClassAddress.SoulStartCount;
            SoulRollMod = ClassAddress.SoulRollMod;

            PowerRollOne.Text = ClassAddress.RollOne;
            PowerRollTwo.Text = ClassAddress.RollTwo;
            PowerRollThree.Text = ClassAddress.RollThree;
            PowerRollFour.Text = ClassAddress.RollFour;

            SuperOne.Text = ClassAddress.PowerOne;
            SuperOneLineOne.Text = ClassAddress.PowerOneLineOne;
            SuperOneLineTwo.Text = ClassAddress.PowerOneLineTwo;
            SuperOneLineThree.Text = ClassAddress.PowerOneLineThree;
            SuperOneLineFour.Text = ClassAddress.PowerOneLineFour;

            SuperTwo.Text = ClassAddress.PowerTwo;
            SuperTwoLineOne.Text = ClassAddress.PowerTwoLineOne;
            SuperTwoLineTwo.Text = ClassAddress.PowerTwoLineTwo;
            SuperTwoLineThree.Text = ClassAddress.PowerTwoLineThree;
            SuperTwoLineFour.Text = ClassAddress.PowerTwoLineFour;

            SuperThree.Text = ClassAddress.PowerThree;
            SuperThreeLineOne.Text = ClassAddress.PowerThreeLineOne;
            SuperThreeLineTwo.Text = ClassAddress.PowerThreeLineTwo;
            SuperThreeLineThree.Text = ClassAddress.PowerThreeLineThree;
            SuperThreeLineFour.Text = ClassAddress.PowerThreeLineFour;

            SuperFour.Text = ClassAddress.PowerFour;
            SuperFourLineOne.Text = ClassAddress.PowerFourLineOne;
            SuperFourLineTwo.Text = ClassAddress.PowerFourLineTwo;
            SuperFourLineThree.Text = ClassAddress.PowerFourLineThree;
            SuperFourLineFour.Text = ClassAddress.PowerFourLineFour;

            DigiSoulStat.Text = "";

            SaveCharacterInformation();
        }

        private void TamerStats_Click(object sender, EventArgs e)
        {

        }

        private void ExpCurrent_Changed(object sender, EventArgs e)
        {
            int.TryParse(ExpCurrent.Text, out int ExpNow);
            int.TryParse(ExpNext.Text, out int ExpMax);

            if (ExpNow > ExpMax - 1)
            {
                LevelUp.Enabled = true;
                ExpCurrent.Text = ExpNext.Text;
            }


            SaveCharacterInformation();
        }

        private void DigimonMoves_Click(object sender, EventArgs e)
        {

        }

        private void BasicCritSuccess_Click(object sender, EventArgs e)
        {

        }

        private void BasicCritFail_Click(object sender, EventArgs e)
        {

        }

        private void BasicAttackStat_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void SpecialAttack_Enter(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void SpecialElement_Click(object sender, EventArgs e)
        {

        }

        private void BasicDefendStat_Click(object sender, EventArgs e)
        {

        }

        private void BasicPenalty_Click(object sender, EventArgs e)
        {

        }
    }
}