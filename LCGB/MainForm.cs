using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCGB
{

    public partial class MainForm : Form
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        int prevServerIndex = 0;
        Client client = new Client();
        List<LCGBSummoner> summoners = new List<LCGBSummoner>();
        public MainForm()
        {
            InitializeComponent();
            client.InitializeClient();
            DeclareServers();
        }
        public void DeclareServers()
        {
            Dictionary<string, string> Servers = new Dictionary<string, string>();
            Servers.Add("EUW1", "EU West");
            Servers.Add("RU", "Russia");
            Servers.Add("EUN1", "EU Nordic & East");
            Servers.Add("NA1", "North America");
            Servers.Add("BR1", "Brazil");
            Servers.Add("KR", "Korea");
            Servers.Add("JP1", "Japan");
            Servers.Add("LA1", "LA North");
            Servers.Add("LA2", "LA South");
            Servers.Add("OC1", "Oceania");
            Servers.Add("TR1", "Turkey");
            cbServer.DataSource = new BindingSource(Servers, null);
            cbServer.DisplayMember = "Value";
            cbServer.ValueMember = "Key";
        }
        public void AddSummoner(string nickname, string server)
        {
            Summoner summoner = client.GetSummoner(nickname, server);
            if (summoner == null)
                return;
            foreach (LCGBSummoner sum in summoners)
            {
                if (sum.nickname == summoner.Name)
                {
                    MessageBox.Show("Player is already in pool.", "Warning");
                    return;
                }
            }
            string iconurl = "https://opgg-static.akamaized.net/images/profile_icons/profileIcon" + summoner.ProfileIconId + ".jpg";
            LeaguePosition league = client.GetLeaguePosition(summoner.Id, server);


            if (league != null)
            {
                string formattedRank = textInfo.ToTitleCase(league.Tier.ToLower()) + " " + league.Rank;
                int points = Balancer.RankToPoints(league.Tier + " " + Balancer.RomanToArabic(league.Rank)) + league.LeaguePoints;
                string rankurl = Balancer.GetRankIcon(league.Tier + " " + Balancer.RomanToArabic(league.Rank));
                summoners.Add(new LCGBSummoner(summoner.Name, formattedRank, points, iconurl, rankurl));
                DisplaySummoners();
            }
            else
            {
                string lastRank = client.LastRank(summoner.AccountId, server);
                if (lastRank != null && lastRank != "UNRANKED")
                {
                    string formattedRank = "=*" + textInfo.ToTitleCase(lastRank.ToLower()) + "*=";
                    int points = Balancer.RankToPoints(lastRank + " 2");
                    string rankurl = Balancer.GetRankIcon(lastRank + " 2");
                    summoners.Add(new LCGBSummoner(summoner.Name, formattedRank, points, iconurl, rankurl));
                    DisplaySummoners();
                }
                else
                {
                    string rankurl = "https://opgg-static.akamaized.net/images/medals/default.png";
                    summoners.Add(new LCGBSummoner(summoner.Name, "Unranked", 1050, iconurl, rankurl));
                    DisplaySummoners();
                }
            }
        }
        public void DisplaySummoners()
        {

            for (int i = 0; i < 10; i++)
            {
                PictureBox pb = (PictureBox)pSummoners.Controls.Find("P" + i + "Icon", false)[0];
                Label lName = (Label)pSummoners.Controls.Find("P" + i + "Name", false)[0];
                Button bDel = (Button)pSummoners.Controls.Find("bDel" + i, false)[0];

                if (i < summoners.Count)
                {
                    lName.BackColor = SystemColors.Control;
                    bDel.Enabled = true; bDel.Visible = true;
                    pb.ImageLocation = summoners[i].iconurl;
                    lName.Size = new Size(164, lName.Size.Height);
                    lName.Text = summoners[i].nickname;
                }
                else
                {
                    lName.BackColor = SystemColors.ControlDark;
                    bDel.Enabled = false; bDel.Visible = false;

                    pb.ImageLocation = "";
                    lName.Size = new Size(188, lName.Size.Height);
                    lName.Text = "";
                }

            }

        }
        private void cbServer_DropDownClosed(object sender, EventArgs e)
        {
            tbNickname.Focus();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string server = cbServer.SelectedValue.ToString();
            string nickname = tbNickname.Text;
            tbNickname.Focus();
            tbNickname.SelectAll();
            AddSummoner(nickname, server);
            if (summoners.Count == 10)
            {
                bAdd.Enabled = false;
                bBalance.Enabled = true;
            }
        }

        private void bDel0_Click(object sender, EventArgs e)
        {
            summoners.RemoveAt(0);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel1_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(1);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel2_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(2);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel3_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(3);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel4_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(4);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel5_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(5);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel6_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(6);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel7_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(7);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel8_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(8);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void bDel9_Click(object sender, EventArgs e)
        {

            summoners.RemoveAt(9);
            bAdd.Enabled = true;
            bBalance.Enabled = false;
            DisplaySummoners();
        }

        private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (summoners.Count > 0 && cbServer.SelectedIndex != prevServerIndex)
            {
                DialogResult dialogResult = MessageBox.Show("Changing the server will remove all players in pool. Continue?", "WARNING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    summoners.Clear();
                    DisplaySummoners();
                    bAdd.Enabled = true;
                    bBalance.Enabled = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    cbServer.SelectedIndex = prevServerIndex;
                }
            }
            else
                prevServerIndex = cbServer.SelectedIndex;
        }

        private void bBalance_Click(object sender, EventArgs e)
        {
            DisplayTeams(Balancer.TeamBalancer(summoners));
        }

        private void DisplayTeams(List<LCGBSummoner>[] teams)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                Panel panel = (Panel)this.Controls.Find("pT" + i, false)[0];
                foreach (Control c in panel.Controls)
                {
                    if (c.Name.Contains("Ring") && c is OvalPictureBox)
                    {
                        c.Visible = true;
                    }
                    for (int j = 0; j < teams[i].Count; j++)
                    {
                        Label lName = (Label)panel.Controls.Find("T" + i + "P" + j + "Name", false)[0];
                        Label lRank = (Label)panel.Controls.Find("T" + i + "P" + j + "Rank", false)[0];
                        OvalPictureBox opbIcon = (OvalPictureBox)panel.Controls.Find("T" + i + "P" + j + "Icon", false)[0];
                        PictureBox pbRankPic = (PictureBox)panel.Controls.Find("T" + i + "P" + j + "RankPic", false)[0];

                        lName.Text = teams[i][j].nickname;
                        lName.Visible = true;

                        lRank.Text = teams[i][j].rank;
                        lRank.Visible = true;

                        opbIcon.ImageLocation = teams[i][j].iconurl;
                        opbIcon.Visible = true;

                        pbRankPic.ImageLocation = teams[i][j].rankurl;
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.reddit.com/user/TheFizz94");
        }
    }
}
