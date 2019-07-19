﻿using Summoners_War_Statistics.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Summoners_War_Statistics
{
    public partial class Summary : UserControl, ISummaryView
    {
        #region Properties
        public Image SummonerCountry
        {
            get => pictureBoxCountry.Image;
            set => pictureBoxCountry.Image = value;
        }
        public Image SummonerLastCountry
        {
            get => pictureBoxLastCountry.Image;
            set => pictureBoxLastCountry.Image = value;
        }
        public Image SummonerLastLanguage
        {
            get => pictureBoxLastLanguage.Image;
            set => pictureBoxLastLanguage.Image = value;
        }

        public string SummonerName
        {
            get => labelSummonerName.Text;
            set => labelSummonerName.Text = value;
        }
        public byte SummonerLevel
        {
            get => byte.Parse(labelLevel.Text);
            set => labelLevel.Text = value.ToString();
        }

        public ulong SummonerMana
        {
            get => ulong.Parse(labelMana.Text);
            set => labelMana.Text = value.ToString("N0");
        }
        public uint SummonerCrystals
        {
            get => uint.Parse(labelCrystals.Text);
            set => labelCrystals.Text = value.ToString("N0");
        }
        public byte SummonerEnergy
        {
            get => byte.Parse(labelEnergy.Text);
            set => labelEnergy.Text = value.ToString();
        }
        public byte SummonerEnergyMax
        {
            get => byte.Parse(labelEnergyMax.Text);
            set => labelEnergyMax.Text = value.ToString();
        }
        public byte SummonerArenaEnergy
        {
            get => byte.Parse(labelArenaWings.Text);
            set => labelArenaWings.Text = value.ToString();
        }
        public byte SummonerArenaEnergyMax
        {
            get => byte.Parse(labelArenaWingsMax.Text);
            set => labelArenaWingsMax.Text = value.ToString();
        }
        public byte SummonerDimensionalCrystals
        {
            get => byte.Parse(labelDimensionalCrystals.Text);
            set => labelDimensionalCrystals.Text = value.ToString();
        }
        public byte SummonerDimensionalCrystalsMax
        {
            get => byte.Parse(labelDimensionalCrystalsMax.Text);
            set => labelDimensionalCrystalsMax.Text = value.ToString();
        }

        public uint SummonerGloryPoints
        {
            get => uint.Parse(labelGloryPoints.Text);
            set => labelGloryPoints.Text = value.ToString("N0");
        }
        public uint SummonerGuildPoints
        {
            get => uint.Parse(labelGuildPoints.Text);
            set => labelGuildPoints.Text = value.ToString("N0");
        }
        public ushort SummonerShapeshiftingStones
        {
            get => ushort.Parse(labelShapeshiftingStones.Text);
            set => labelShapeshiftingStones.Text = value.ToString("N0");
        }
        public uint SummonerRTAMedals
        {
            get => uint.Parse(labelRTAMedals.Text);
            set => labelRTAMedals.Text = value.ToString("N0");
        }

        public byte SummonerDimensionalHoleEnergy
        {
            get => byte.Parse(labelDimensionalHoleEnergy.Text);
            set => labelDimensionalHoleEnergy.Text = value.ToString();
        }
        public byte SummonerDimensionalHoleEnergyMax
        {
            get => byte.Parse(labelDimensionalHoleEnergyMax.Text);
            set => labelDimensionalHoleEnergyMax.Text = value.ToString();
        }
        public ushort SummonerMonstersAmount
        {
            get => ushort.Parse(labelMonsters.Text);
            set => labelMonsters.Text = value.ToString("N0");
        }
        public ushort SummonerMonstersLocked
        {
            get => ushort.Parse(labelMonstersLocked.Text);
            set => labelMonstersLocked.Text = value.ToString("N0");
        }

        public ushort SummonerRunes
        {
            get => ushort.Parse(labelRunes.Text);
            set => labelRunes.Text = value.ToString("N0");
        }
        public ushort SummonerRunesLocked
        {
            get => ushort.Parse(labelRunesLocked.Text);
            set => labelRunesLocked.Text = value.ToString("N0");
        }

        public ushort SummonerSocialPoints
        {
            get => ushort.Parse(labelSocialPoints.Text);
            set => labelSocialPoints.Text = value.ToString("N0");
        }
        public ushort SummonerAncientCoins
        {
            get => ushort.Parse(labelAncientCoins.Text);
            set => labelAncientCoins.Text = value.ToString("N0");
        }
        public string JsonModifcationDate
        {
            get => labelJsonModified.Text;
            set => labelJsonModified.Text = value;
        }
        #endregion

        #region Events
        public event Action<WizardInfo, DimensionHoleInfo, List<PurpleUnitList>, List<long>, List<Rune>, DateTime, string> InitSummary;
        #endregion

        public Summary()
        {
            InitializeComponent();
        }

        #region Methods
        public void Init(WizardInfo wizardInfo, DimensionHoleInfo dimensionHoleInfo, List<PurpleUnitList> monsters, List<long> monstersLocked, List<Rune> runes, DateTime jsonModificationTime, string country)
        {
            InitSummary?.Invoke(wizardInfo, dimensionHoleInfo, monsters, monstersLocked, runes, jsonModificationTime, country);
        }
        #endregion
    }
}