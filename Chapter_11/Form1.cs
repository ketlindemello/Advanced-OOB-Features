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

        public Sporting_teams selectedSport;
        private List<Sporting_teams> all_sports = new List<Sporting_teams>();
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


        private void button1_Click(object sender, EventArgs e)
        {
            //Select an item and generate it with the button
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var selectedObject = listBox1.SelectedItem;
            if (selectedObject == null || string.IsNullOrEmpty((string)selectedObject))
            {
                return;
            }

            if(firstNames == null || lastNames == null || randomTeamNames == null)
            {
                label1.Text = "FirstNames, LastNames, or RandomTeamNames were not set!";
                label1.ForeColor = Color.Red;
                return;
            }

            Random r = new Random();

            if (selectedObject.ToString() == "Soccer")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Soccer")).FirstOrDefault();

                Soccer soccer = new Soccer();
                soccer.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                soccer.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                soccer.Sport_Category = "Football";
                all_sports.Add(soccer);

                Team_add(soccer.Name);
            }
            else if (selectedObject.ToString() == "Tennis")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Tennis")).FirstOrDefault();
                Tennis tennis = new Tennis();
                tennis.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                tennis.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                tennis.Sport_Category = "Racket Sports";
                tennis.RacketRestringerName = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                all_sports.Add(tennis);

                Team_add(tennis.Name);
            }
            else if (selectedObject.ToString() == "Cricket")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Cricket")).FirstOrDefault();
                Cricket cricket = new Cricket();
                cricket.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                cricket.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                cricket.Sport_Category = "Bat-and-Ball";
                all_sports.Add(cricket);

                Team_add(cricket.Name);
            }
            else if (selectedObject.ToString() == "Golf")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Golf")).FirstOrDefault();
                Golf golf = new Golf();
                golf.Name = randomTeamNames[r.Next(0, randomTeamNames.Count)];
                golf.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                golf.Sport_Category = "Club-and-Ball";
                golf.Membership_Required = true;
                golf.GetTeamParticipants();
                golf.players.Add($"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}", true);
                golf.players.Add($"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}", true);
                golf.players.Add($"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}", false);
                golf.players.Add($"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}", true);

                all_sports.Add(golf);

                Team_add(golf.Name);
            }
            else if (selectedObject.ToString() == "Hockey")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Hockey")).FirstOrDefault();
                Hockey hockey = new Hockey();
                hockey.Name = "Hustle";
                hockey.Coach = $"{firstNames[r.Next(0, firstNames.Count)]} {lastNames[r.Next(0, lastNames.Count)]}";
                hockey.Sport_Category = "Ice Hockey";
                all_sports.Add(hockey);

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
            var selected_teams = listBox2.SelectedItem;
            if (selected_teams == null || string.IsNullOrEmpty((string)selected_teams))
            {
                return;
            }

            var result = all_sports.Where(x => x.Name.Equals(selected_teams.ToString())).FirstOrDefault();
            Clear_form();

            switch (result.GetType().Name)
            {
                case nameof(Tennis):
                    richTextBox1.Text = result.ToString();
                    break;
                case nameof(Soccer):
                    richTextBox1.Text = ("Team Name: " + ((Soccer)result).Name);
                    richTextBox1.Text += ("\nSport Category: " + ((Soccer)result).Sport_Category);
                    richTextBox1.Text += $"\nSport Type: {nameof(Soccer)}";
                    richTextBox1.Text += ("\nTeam Coach: " + ((Soccer)result).Coach);
                    break;
                case nameof(Cricket):
                    richTextBox1.Text = ("Team Name: " + ((Cricket)result).Name);
                    richTextBox1.Text += ("\nSport Category: " + ((Cricket)result).Sport_Category);
                    richTextBox1.Text += $"\nSport Type: {nameof(Cricket)}";
                    richTextBox1.Text += ("\nTeam Coach: " + ((Cricket)result).Coach);
                    break;
                case nameof(Hockey):
                    richTextBox1.Text = ("Team Name: " + ((Hockey)result).Name);
                    richTextBox1.Text += ("\nSport Category: " + ((Hockey)result).Sport_Category);
                    richTextBox1.Text += $"\nSport Type: {nameof(Hockey)}";
                    richTextBox1.Text += ("\nTeam Coach: " + ((Hockey)result).Coach);
                    break;
                case nameof(Golf):
                    richTextBox1.Text = ("Team Name:\t\t" + ((Golf)result).Name);
                    richTextBox1.Text += ("\nSport Category:\t\t" + ((Golf)result).Sport_Category);
                    richTextBox1.Text += $"\nSport Type:\t\t {nameof(Golf)}";
                    richTextBox1.Text += ("\nTeam Coach:\t\t" + ((Golf)result).Coach);
                    richTextBox1.Text += ("\nMembership Required:\t" + ((Golf)result).Membership_Required);

                    foreach (KeyValuePair<string, bool> player in ((Golf)result).players)
                    {
                        richTextBox1.Text += $"\nPlayer: {player.Key} \tActive Membership: {player.Value}";
                    }
                    break;
                default:
                    throw new Exception("Unsupported Sport Type encountered!");
            }

            PopulateDataGridView(result.MatchOutcomes);
        }


        //private void View_budget()
        //{
        //    Button dynamicButton = new Button();
        //    // Set Button properties

        //    dynamicButton.Height = 40;
        //    dynamicButton.Width = 100;
        //    dynamicButton.BackColor = Color.Gray;
        //    dynamicButton.ForeColor = Color.Blue;
        //    dynamicButton.Location = new Point(320, 300);
        //    dynamicButton.Text = "I am Dynamic Button";
        //    dynamicButton.Name = "DynamicButton";
        //    dynamicButton.Font = new Font("Georgia", 16);

        //    // Add a Button Click Event handler
        //    dynamicButton.Click += new EventHandler(DynamicButton_Click);
        //    Controls.Add(dynamicButton);

        //}

        //private void DynamicButton_Click(object sender, EventArgs e)

        //{

        //    MessageBox.Show("Dynamic button is clicked");

        //}

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
            var result = all_sports.Where(x => x.Name.Equals(selected_teams.ToString())).FirstOrDefault();

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
            foreach(MatchOutcome matchOutcome in matchOutcomes)
            {
                int row = dataGridView1.Rows.Add(
                            matchOutcome.MatchResult,
                            matchOutcome.RewardPenalty);

                //Color row green if win, Color row red if loss
                //(dataGridView1.Rows[row].Cells as IList<DataGridViewRow>).ToList().ForEach(x => x.DefaultCellStyle.BackColor = Color.Red);
                if (matchOutcome.MatchResult == Chapter_11.MatchOutcome.MatchOutcomes.Loss)
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                }
                else if(matchOutcome.MatchResult == Chapter_11.MatchOutcome.MatchOutcomes.Win)
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //TODO: Make a UI for sports team budget, need to incorporate budget stuff into Sporting_team base class so inherited classes can use it


        //



    }
}
