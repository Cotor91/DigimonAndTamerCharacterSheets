﻿using System.Security.Cryptography.Pkcs;

namespace DigimonAndTamerCharacterSheets.Models;

internal class DigimonInfo
{
    public string DigimonName { get; set; } = null!;
    public string DigimonField { get; set; } = null!;
    public string DigitalFrame { get; set; } = null!;
    public int HPLevelMod { get; set; } = 0!;
    public string CoreHPMax { get; set; } = null!;
    public string MoveSpeed { get; set; } = null!;
    public string Attribute { get; set; } = null!;
    public string WeaknessElement { get; set; } = null!;
    public string ResistanceElement { get; set; } = null!;
    public bool RookieEvolution { get; set; } = false!;
    public bool ChampionEvolution { get; set; } = false!;
    public bool UltimateEvolution { get; set; } = false!;
    public bool MegaEvolution { get; set; } = false!;
    public bool DarkEvolution { get; set; } = false!;
    public string CurrentQuirkOne { get; set; } = null!;
    public string CurrentQuirkTwo { get; set; } = null!;
    public string InheritableQuirkOne { get; set; } = null!;
    public string InheritableQuirkTwo { get; set; } = null!;
    public string InheritableQuirkThree { get; set; } = null!;
    public string BasicAttack { get; set; } = null!;
    public string StandardAttack { get; set; } = null!;
    public string SpecialAttack { get; set; } = null!;
    public string SuperAttack { get; set; } = null!;
    public string BasicDiceMin { get; set; } = null!;
    public string BasicDiceMax { get; set; } = null!;
    public string StandardDiceMin { get; set; } = null!;
    public string StandardDiceMax { get; set; } = null!;
    public string SpecialDiceMin { get; set; } = null!;
    public string SpecialDiceMax { get; set; } = null!;
    public string SuperDiceMin { get; set; } = null!;
    public string SuperDiceMax { get; set; } = null!;
    public string BasicElement { get; set; } = null!;
    public string StandardElement { get; set; } = null!;
    public string SpecialElement { get; set; } = null!;
    public string SuperElement { get; set; } = null!;
    public string BasicHardFail { get; set; } = null!;
    public string BasicFail { get; set; } = null!;
    public string BasicPartFail { get; set; } = null!;
    public string BasicPartHit { get; set; } = null!;
    public string BasicHit { get; set; } = null!;
    public string BasicHardHit { get; set; } = null!;
    public string StandardHardFail { get; set; } = null!;
    public string StandardFail { get; set; } = null!;
    public string StandardPartFail { get; set; } = null!;
    public string StandardPartHit { get; set; } = null!;
    public string StandardHit { get; set; } = null!;
    public string StandardHardHit { get; set; } = null!;
    public string SpecialHardFail { get; set; } = null!;
    public string SpecialFail { get; set; } = null!;
    public string SpecialPartFail { get; set; } = null!;
    public string SpecialPartHit { get; set; } = null!;
    public string SpecialHit { get; set; } = null!;
    public string SpecialHardHit { get; set; } = null!;
    public string SuperHardFail { get; set; } = null!;
    public string SuperFail { get; set; } = null!;
    public string SuperPartFail { get; set; } = null!;
    public string SuperPartHit { get; set; } = null!;
    public string SuperHit { get; set; } = null!;
    public string SuperHardHit { get; set; } = null!;
}
