﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summoners_War_Statistics
{
    public partial class Other : UserControl, IOtherView
    {
        #region Properties
        public ListView SummonerFriendsList
        {
            get => listViewFriendsList;
            set => listViewFriendsList = value;
        }

        public ListView GuildMembersList
        {
            get => listViewGuildMembersList;
            set => listViewGuildMembersList = value;
        }
        public string GuildName
        {
            get => labelGuildName.Text;
            set => labelGuildName.Text = value;
        }
        public string GuildLeaderName
        {
            get => labelLeaderName.Text;
            set => labelLeaderName.Text = value;
        }
        public string GuildBestRanking
        {
            get => labelRanking.Text;
            set => labelRanking.Text = value;
        }
        public byte GuildMembers
        {
            get => byte.Parse(labelMembers.Text);
            set => labelMembers.Text = value.ToString();
        }
        public byte GuildMembersMax
        {
            get => byte.Parse(labelMembersMax.Text);
            set => labelMembersMax.Text = value.ToString();
        }
        public byte GuildMembersDefenses
        {
            get => byte.Parse(labelDefenseUnits.Text);
            set => labelDefenseUnits.Text = value.ToString();
        }
        public byte GuildMembersDefensesMax
        {
            get => byte.Parse(labelDefenseUnitsMax.Text);
            set => labelDefenseUnitsMax.Text = value.ToString();
        }
        #endregion

        #region Events
        public event Action<List<Friend>, Guild, GuildWarParticipationInfo, List<GuildWarMember>, List<GuildMemberDefense>, GuildWarRankingStat> InitOther;
        #endregion

        public Other()
        {
            InitializeComponent();
        }

        #region Methods
        public void Init(List<Friend> friendsList, Guild guild, GuildWarParticipationInfo guildwarParticipationInfo, List<GuildWarMember> guildwarMemberList, List<GuildMemberDefense> guildMemberDefenseList, GuildWarRankingStat guildwarRanking)
        {
            InitOther?.Invoke(friendsList, guild, guildwarParticipationInfo, guildwarMemberList, guildMemberDefenseList, guildwarRanking);
        }
        #endregion
    }
}
