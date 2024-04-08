public enum Diet
{
    Strength,
    Agility,
    Vibes,
    Wits,
    Education
}

                if (
                    !int.TryParse(StrengthDiet.Text, out int DietStrength) ||
                    !int.TryParse(AgilityDiet.Text, out int DietAgility) ||
                    !int.TryParse(VibesDiet.Text, out int DietVibes) ||
                    !int.TryParse(WitsDiet.Text, out int DietWits) ||
                    !int.TryParse(EducationDiet.Text, out int DietEducation)
                ) { return; }