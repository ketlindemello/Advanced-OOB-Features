using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chapter_11
{

    //Form 1 is the derived class.
    // Form is the base class.
    public partial class Form1 : Form
    {

        public SportingTeams selectedSport;
        private List<SportingTeams> allSports = new List<SportingTeams>();
        private List<string> randomTeamNames;
        private List<string> firstNames;
        private List<string> lastNames;

        public Form1()
        {
            InitializeComponent();

            //Gets the full path of the executing assembly (.exe)
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //takes the above full file path and returns the directory portion
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);

            label1.Text = string.Empty;
            label1.ForeColor = Color.Black;

            //Reads the TeamNames.txt file and converts it to a List<string>
            //For the text file, don't forget to right click --> Properties --> Copy To Output Directory : Copy Always
            randomTeamNames = File.ReadLines($"{strWorkPath}\\Configs\\TeamNames.txt").ToList();
            firstNames = File.ReadLines($"{strWorkPath}\\Configs\\FirstNames.txt").ToList();
            lastNames = File.ReadLines($"{strWorkPath}\\Configs\\LastNames.txt").ToList();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            var selectedObject = listBox1.SelectedItem;
            if (selectedObject == null || string.IsNullOrEmpty((string)selectedObject))
            {
                return;
            }

            if (firstNames == null || lastNames == null || randomTeamNames == null)
            {
                label1.Text = "FirstNames, LastNames, or RandomTeamNames were not set!";
                label1.ForeColor = Color.Red;
                return;
            }

            Random r = new Random();

            if (selectedObject.ToString() == "Soccer")
            {
                selectedSport = allSports.Where(x => x.Name.Equals("Soccer")).FirstOrDefault();

                Soccer soccer = new Soccer();
                soccer.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                soccer.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                soccer.SportCategory = "Football";
                allSports.Add(soccer);

                Team_add(soccer.Name);
            }
            else if (selectedObject.ToString() == "Tennis")
            {
                selectedSport = allSports.Where(x => x.Name.Equals("Tennis")).FirstOrDefault();
                Tennis tennis = new Tennis();
                tennis.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                tennis.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                tennis.SportCategory = "Racket Sport";
                tennis.RacketRestringerName = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                allSports.Add(tennis);

                Team_add(tennis.Name);
            }
            else if (selectedObject.ToString() == "Cricket")
            {
                selectedSport = allSports.Where(x => x.Name.Equals("Cricket")).FirstOrDefault();
                Cricket cricket = new Cricket();
                cricket.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                cricket.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                cricket.SportCategory = "Bat-and-Ball";
                for (int i = 0; i < cricket.GetTeamParticipants(); i++)
                {

                    var positionIndex = r.Next(0, cricket.jerseyNo.Count - 1);
                    var jersey = cricket.jerseyNo[positionIndex];

                    cricket.players.Add($"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}", jersey);
                    cricket.jerseyNo.Remove(jersey);
                }
                allSports.Add(cricket);

                Team_add(cricket.Name);
            }
            else if (selectedObject.ToString() == "Golf")
            {
                selectedSport = allSports.Where(x => x.Name.Equals("Golf")).FirstOrDefault();
                Golf golf = new Golf();
                golf.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                golf.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                golf.SportCategory = "Club-and-Ball";

                for (int i = 0; i < golf.GetTeamParticipants(); i++)
                {

                    var positionIndex = r.Next(0, golf.positions.Count - 1);
                    var registration = golf.positions[positionIndex];

                    golf.players.Add($"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}", registration);
                    golf.positions.Remove(registration);
                }
                allSports.Add(golf);

                Team_add(golf.Name);
            }
            else if (selectedObject.ToString() == "Hockey")
            {
                selectedSport = allSports.Where(x => x.Name.Equals("Hockey")).FirstOrDefault();
                Hockey hockey = new Hockey();
                hockey.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                hockey.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                hockey.SportCategory = "Ice Hockey";

                for (int i = 0; i < hockey.GetTeamParticipants(); i++)
                {

                    var positionIndex = r.Next(0, hockey.positions.Count - 1);
                    var position_name = hockey.positions[positionIndex];

                    hockey.players.Add($"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}", position_name);
                    hockey.positions.Remove(position_name);
                }
                allSports.Add(hockey);
                Team_add(hockey.Name);
            }

            label1.Text = string.Empty;
        }

        private void Team_add(string team_name)
        {
            listBox2.Items.Add(team_name);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selectedTeams = listBox2.SelectedItem;
            if (selectedTeams == null || string.IsNullOrEmpty((string)selectedTeams))
            {
                return;
            }

            var result = allSports.Where(x => x.Name.Equals(selectedTeams.ToString())).FirstOrDefault();
            Clear_form();

            switch (result.GetType().Name)
            {
                case nameof(Tennis):
                    richTextBox1.Text = result.ToString();
                    break;
                case nameof(Soccer):
                    richTextBox1.Text = result.ToString();
                    break;
                case nameof(Cricket):
                    richTextBox1.Text = result.ToString();
                    break;
                case nameof(Hockey):
                    richTextBox1.Text = result.ToString();
                    break;
                case nameof(Golf):
                    richTextBox1.Text = result.ToString();
                    break;
                default:
                    throw new Exception("Unsupported Sport Type encountered!");
            }

            PopulateDataGridView(result.MatchOutcomes);
        }

        private void Clear_form()
        {
            richTextBox1.Clear();
            richTextBox1.Update();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            Random r = new Random();
            int outcome = r.Next(0, 3);


            var selected_teams = listBox2.SelectedItem;

            if(selected_teams == null || string.IsNullOrEmpty((string)selected_teams))
            {
                return;
            }
            var result = allSports.Where(x => x.Name.Equals(selected_teams.ToString())).FirstOrDefault();

            if (outcome == 0)
            {
                result.RecordMatchOutcome(Chapter_11.MatchOutcome.MatchOutcomes.Loss);
            }
            else if (outcome == 1)
            {
                result.RecordMatchOutcome(Chapter_11.MatchOutcome.MatchOutcomes.Win);
            }
            else
            {
                result.RecordMatchOutcome(Chapter_11.MatchOutcome.MatchOutcomes.Tie);
            }

            PopulateDataGridView(result.MatchOutcomes);

        }

        private void PopulateDataGridView(List<MatchOutcome> matchOutcomes)
        {
            dataGridView1.Rows.Clear();
            foreach (MatchOutcome matchOutcome in matchOutcomes)
            {
                int row = dataGridView1.Rows.Add(
                            matchOutcome.MatchResult,
                            matchOutcome.RewardPenalty);

                //Color row green if win, Color row red if loss
                if (matchOutcome.MatchResult == Chapter_11.MatchOutcome.MatchOutcomes.Loss)
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (matchOutcome.MatchResult == Chapter_11.MatchOutcome.MatchOutcomes.Win)
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

    }
}
