﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Resources;
using Summoners_War_Statistics.Properties;

namespace Summoners_War_Statistics
{
    public partial class Monsters : UserControl, IMonstersView
    {
        #region Properties

        /// <summary>
        /// Size of the window
        /// </summary>
        public Size SizeWindow => Size;
        /// <summary>
        /// List of the controls used in Dynamic UI
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Control> Cntrls => new List<Control>()
                {
                    labelNat5s,
                    labelLDNat4sPlus,
                    labelDark,
                    labelDaysLDLightning,
                    labelDaysNat5,
                    labelFire,
                    labelLDNat4Plus,
                    labelLight,
                    labelMonsterStats,
                    labelNat5,
                    labelStarsFiveAmount,
                    labelStarsFourAmount,
                    labelStarsOneAmount,
                    labelStarsSixAmount,
                    labelStarsThreeAmount,
                    labelStarsTwoAmount,
                    labelWater,
                    labelWind,
                    pictureBoxStarFives,
                    pictureBoxElementalNat5,
                    pictureBoxElementalNat5Clock,
                    pictureBoxStarsFourPlus,
                    pictureBoxLDNat4Plus,
                    pictureBoxLDNat4PlusClock,
                    pictureBoxWater,
                    pictureBoxFire,
                    pictureBoxWind,
                    pictureBoxLight,
                    pictureBoxDark,
                    pictureBoxStars6,
                    pictureBoxStars5,
                    pictureBoxStars4,
                    pictureBoxStars3,
                    pictureBoxStars2,
                    pictureBoxStars1,
                    panelHeader,
                    panelHeaderLeft,
                    panelHeaderMid,
                    panelHeaderRight,
                    labelCollectionStars,
                    checkedListBoxCollectionStars,
                    labelCollectionAttribute,
                    checkedListBoxCollectionAttribute,
                    labelCollection,
                    labelCollectionSummoner,
                    labelCollectionSlash,
                    labelCollectionWhole,
                    checkBoxRunes
                };

        /// <summary>
        /// Amount of monsters with Water attribute
        /// </summary>
        public ushort MonsterAttributeWater
        {
            get => ushort.Parse(labelWater.Text);
            set => labelWater.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters withFire attribute
        /// </summary>
        public ushort MonsterAttributeFire
        {
            get => ushort.Parse(labelFire.Text);
            set => labelFire.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with Wind attribute
        /// </summary>
        public ushort MonsterAttributeWind
        {
            get => ushort.Parse(labelWind.Text);
            set => labelWind.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with Light attribute
        /// </summary>
        public ushort MonsterAttributeLight
        {
            get => ushort.Parse(labelLight.Text);
            set => labelLight.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with Dark attribute
        /// </summary>
        public ushort MonsterAttributeDark
        {
            get => ushort.Parse(labelDark.Text);
            set => labelDark.Text = value.ToString();
        }

        /// <summary>
        /// Amount of monsters with 6 stars
        /// </summary>
        public ushort MonsterStarsSix
        {
            get => ushort.Parse(labelStarsSixAmount.Text);
            set => labelStarsSixAmount.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with 5 stars
        /// </summary>
        public ushort MonsterStarsFive
        {
            get => ushort.Parse(labelStarsFiveAmount.Text);
            set => labelStarsFiveAmount.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with 4 stars
        /// </summary>
        public ushort MonsterStarsFour
        {
            get => ushort.Parse(labelStarsFourAmount.Text);
            set => labelStarsFourAmount.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with 3 stars
        /// </summary>
        public ushort MonsterStarsThree
        {
            get => ushort.Parse(labelStarsThreeAmount.Text);
            set => labelStarsThreeAmount.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with 2 stars
        /// </summary>
        public ushort MonsterStarsTwo
        {
            get => ushort.Parse(labelStarsTwoAmount.Text);
            set => labelStarsTwoAmount.Text = value.ToString();
        }
        /// <summary>
        /// Amount of monsters with 1 star
        /// </summary>
        public ushort MonsterStarsOne
        {
            get => ushort.Parse(labelStarsOneAmount.Text);
            set => labelStarsOneAmount.Text = value.ToString();
        }

        /// <summary>
        /// Amount of non-fusable, non-dupe nat5's
        /// </summary>
        public ushort MonstersNat5Amount
        {
            get => ushort.Parse(labelNat5.Text);
            set => labelNat5.Text = value.ToString();
        }
        /// <summary>
        /// Amount of non-fusable, non-dupe, non-hoh LD nat4's+
        /// </summary>
        public ushort MonstersLDNat4PlusAmount
        {
            get => ushort.Parse(labelLDNat4Plus.Text);
            set => labelLDNat4Plus.Text = value.ToString();
        }
        /// <summary>
        /// Days since last non-fusable, non-dupe nat5's
        /// </summary>
        public ushort DaysSinceNat5
        {
            get
            {
                try
                {
                    return ushort.Parse(labelDaysNat5.Text.Remove(labelDaysNat5.Text.Length - 6));
                }
                catch (FormatException) { return 0; }
            }
            set => labelDaysNat5.Text = value.ToString() + " days";
        }
        /// <summary>
        /// Days since last non-fusable, non-dupe, non-hoh LD nat4's+
        /// </summary>
        public ushort DaysSinceLastLDLightning
        {
            get
            {
                try
                {
                    return ushort.Parse(labelDaysLDLightning.Text.Remove(labelDaysLDLightning.Text.Length - 6));
                }
                catch (FormatException) { return 0; }
            }
            set => labelDaysLDLightning.Text = value.ToString() + " days";
        }

        #region MonstersList (no physical field in designer)
        /// <summary>
        /// List of the monsters owned by Summoner
        /// </summary>
        public List<Monster> MonstersList { get; set; } = new List<Monster>();
        /// <summary>
        /// List of locked monsters owned by Summoner
        /// </summary>
        public List<long> MonstersLocked { get; set; } = new List<long>();

        public List<Monster> MonstersListAffectedByCollection { get; set; } = new List<Monster>();
        #endregion

        #region FlowLayoutPanel MonstersListView
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FlowLayoutPanel MonstersListView
        {
            get => flowLayoutPanelMonsters;
            set => flowLayoutPanelMonsters = value;
        }
        #endregion

        /// <summary>
        /// List of stars checked in Monster Collection filters
        /// </summary>
        public List<int> MonstersCollectionCheckedStars
        {
            get {
                List<int> checkedStars = new List<int>();
                if(checkedListBoxCollectionStars.CheckedItems.Count > 0)
                foreach(var item in checkedListBoxCollectionStars.CheckedItems)
                {
                        checkedStars.Add(int.Parse(item.ToString()));
                }

                return checkedStars;
            }
        }
        /// <summary>
        /// List of sattributes checked in Monster Collection filters
        /// </summary>
        public List<string> MonstersCollectionCheckedAttributes
        {
            get
            {
                List<string> checkedAttribute = new List<string>();
                if (checkedListBoxCollectionAttribute.CheckedItems.Count > 0)
                    foreach (var item in checkedListBoxCollectionAttribute.CheckedItems)
                    {
                        checkedAttribute.Add(item.ToString());
                    }

                return checkedAttribute;
            }
        }
        /// <summary>
        /// Amount of Summoner's monsters that meet the filter requirements
        /// </summary>
        public int MonstersCollectionSummoner
        {
            get => int.Parse(labelCollectionSummoner.Text);
            set => labelCollectionSummoner.Text = value.ToString();
        }
        /// <summary>
        /// Amount of ALL monsters in the game that meet the filter requirements
        /// </summary>
        public int MonstersCollectionWhole
        {
            get => int.Parse(labelCollectionWhole.Text);
            set => labelCollectionWhole.Text = value.ToString();
        }

        /// <summary>
        /// Header of the Monsters List panel
        /// </summary>
        public string MonstersListHeader
        {
            set => labelMonsters.Text = value;
        }

        public bool MonstersWithRunes => checkBoxRunes.Checked;
        #endregion

        #region Events
        /// <summary>
        /// Initialize whole Monster Tab
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event Action<List<long>> InitMonsters;
        /// <summary>
        /// Triggers when window ends resizing
        /// </summary>
        public event Action Resized;
        /// <summary>
        /// Makes sure user sees what he should see
        /// </summary>
        public event Action CanSeeMonstersTab;
        /// <summary>
        /// Triggers when some combobox from Monster Collection section is being changed
        /// </summary>
        public event Action MonstersCollectionItemChecked;
        #endregion

        public Monsters()
        {
            InitializeComponent();
        }

        #region Methods
        /// <summary>
        /// Initialize the whole Monster Tab
        /// </summary>
        public void Init(List<Monster> monsters, List<long> monstersLocked)
        {
            MonstersList = monsters;
            InitMonsters?.Invoke(monstersLocked);

        }

        /// <summary>
        /// Resets the monster stats when reloading JSON file
        /// </summary>
        public void ResetMonstersStats()
        {
            MonsterAttributeWater = MonsterAttributeFire = MonsterAttributeWind = MonsterAttributeLight = MonsterAttributeDark =
                MonsterStarsSix = MonsterStarsFive = MonsterStarsFour = MonsterStarsThree = MonsterStarsTwo = MonsterStarsOne =
                MonstersNat5Amount = MonstersLDNat4PlusAmount = DaysSinceNat5 = DaysSinceLastLDLightning = 0;
        }

        /// <summary>
        /// Moves the Monster Tab to the front
        /// </summary>
        public void Front()
        {
            BringToFront();
        }

        /// <summary>
        /// Resets everything on fail (when the JSON file, that was given, is invalid)
        /// </summary>
        public void ResetOnFail()
        {
            ResetMonstersStats();
            MonstersCollectionSummoner = MonstersCollectionWhole = 0;
            MonstersListHeader = "Monsters";
            MonstersListView.Controls.Clear();
        }

        public void Monsters_Resize(object sender, EventArgs e)
        {
            Resized?.Invoke();
        }

        private void Monsters_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                Resized?.Invoke();
                CanSeeMonstersTab?.Invoke();
            }
        }

        /// <summary>
        /// Sets the tooltip over provided control
        /// </summary>
        public void SetInfoOnHover(Control control, string info)
        {
            toolTip1.SetToolTip(control, info);
        }
        #endregion

        private void CheckedListBoxCollectionStars_ItemCheck(object sender, EventArgs e)
        {
            MonstersCollectionItemChecked?.Invoke();
        }

        private void CheckBoxRunes_CheckStateChanged(object sender, EventArgs e)
        {
            MonstersCollectionItemChecked?.Invoke();
        }
    }
}
