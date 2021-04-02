using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_11
{

    //Form 1 is the derived class.
    // Form is the base class.
    public partial class Form1 : Form
    {

        public Sporting_teams selectedSport;
        private List<Sporting_teams> all_sports = new List<Sporting_teams>();

        public Form1()
        {
            InitializeComponent();

            

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

            if(selectedObject.ToString() == "Soccer")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Soccer")).FirstOrDefault();

                

                Soccer soccer = new Soccer();
                soccer.Name = "Lightning";
                soccer.Coach = "Damien Braun";
                soccer.Sport_Category = "Football";
                all_sports.Add(soccer);

                Team_add(soccer.Name);
            }
            else if(selectedObject.ToString() == "Tennis")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Tennis")).FirstOrDefault();
                Tennis tennis = new Tennis();
                tennis.Name = "Amigos";
                tennis.Coach = "Thomas Crane";
                tennis.Sport_Category = "Racket Sports";
                tennis.RacketRestringerName = "Bradford Vega";
                all_sports.Add(tennis);

                Team_add(tennis.Name);
            }
            else if (selectedObject.ToString() == "Cricket")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Cricket")).FirstOrDefault();
                Cricket cricket = new Cricket();
                cricket.Name = "Dominators";
                cricket.Coach = "Pierre Cox";
                cricket.Sport_Category = "Bat-and-Ball";
                all_sports.Add(cricket);

                Team_add(cricket.Name);

            }


            else if (selectedObject.ToString() == "Golf")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Golf")).FirstOrDefault();
                Golf golf = new Golf();
                golf.Name = "Heatwave";
                golf.Coach = "Enrique West";
                golf.Sport_Category = "Club-and-Ball";
                golf.Membership_Required = true;
                golf.GetTeamParticipants();
                golf.players.Add("Barbara Vaughan", true);
                golf.players.Add("William Ibarra", true);
                golf.players.Add("Aydan Rush", false);
                golf.players.Add("Charlie Jordan", true);

                all_sports.Add(golf);

                Team_add(golf.Name);

            }

            else if (selectedObject.ToString() == "Hockey")
            {
                selectedSport = all_sports.Where(x => x.Name.Equals("Hockey")).FirstOrDefault();
                Hockey hockey = new Hockey();
                hockey.Name = "Hustle";
                hockey.Coach = "Cierra Vega";
                hockey.Sport_Category = "Ice Hockey";
                all_sports.Add(hockey);

                Team_add(hockey.Name);

            }

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

            if (selected_teams.ToString() == "Amigos")
            {
                var result = all_sports.Where(x => x.Name.Equals("Amigos")).FirstOrDefault();

                Clear_form();

                richTextBox1.Text = ("Team Name: " + ((Tennis)result).Name);
                richTextBox1.Text += ("\nSport Category: " + ((Tennis)result).Sport_Category);
                richTextBox1.Text += $"\nSport Type: {nameof(Tennis)}";
                richTextBox1.Text += ("\nTeam Coach: " + ((Tennis)result).Coach);
                richTextBox1.Text += ("\nRacket Restringer: " + ((Tennis)result).RacketRestringerName);
            }
            else if (selected_teams.ToString() == "Lightning")
            {
                var result = all_sports.Where(x => x.Name.Equals("Lightning")).FirstOrDefault();

                Clear_form();

                richTextBox1.Text = ("Team Name: " + ((Soccer)result).Name);
                richTextBox1.Text += ("\nSport Category: " + ((Soccer)result).Sport_Category);
                richTextBox1.Text += $"\nSport Type: {nameof(Soccer)}";
                richTextBox1.Text += ("\nTeam Coach: " + ((Soccer)result).Coach);
            }
            else if (selected_teams.ToString() == "Dominators")
            {
                var result = all_sports.Where(x => x.Name.Equals("Dominators")).FirstOrDefault();

                Clear_form();

                richTextBox1.Text = ("Team Name: " + ((Cricket)result).Name);
                richTextBox1.Text += ("\nSport Category: " + ((Cricket)result).Sport_Category);
                richTextBox1.Text += $"\nSport Type: {nameof(Cricket)}";
                richTextBox1.Text += ("\nTeam Coach: " + ((Cricket)result).Coach);
            }

            else if (selected_teams.ToString() == "Hustle")
            {
                var result = all_sports.Where(x => x.Name.Equals("Hustle")).FirstOrDefault();

                Clear_form();

                richTextBox1.Text = ("Team Name: " + ((Hockey)result).Name);
                richTextBox1.Text += ("\nSport Category: " + ((Hockey)result).Sport_Category);
                richTextBox1.Text += $"\nSport Type: {nameof(Hockey)}";
                richTextBox1.Text += ("\nTeam Coach: " + ((Hockey)result).Coach);
            }

            else if (selected_teams.ToString() == "Heatwave")
            {
                var result = all_sports.Where(x => x.Name.Equals("Heatwave")).FirstOrDefault();

                Clear_form();

                richTextBox1.Text = ("Team Name:\t\t" + ((Golf)result).Name);
                richTextBox1.Text += ("\nSport Category:\t\t" + ((Golf)result).Sport_Category);
                richTextBox1.Text += $"\nSport Type:\t\t {nameof(Golf)}";
                richTextBox1.Text += ("\nTeam Coach:\t\t" + ((Golf)result).Coach);
                richTextBox1.Text += ("\nMembership Required:\t" + ((Golf)result).Membership_Required);

                foreach (KeyValuePair<string, bool> player in ((Golf)result).players)
                {
                    richTextBox1.Text += $"\nPlayer: {player.Key} \tActive Membership: {player.Value}";
                }



            }
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

            IBudgeting hockey = new Hockey();
            hockey.AddAmountToBudget(50);
            
        }

        //TODO: Make a UI for sports team budget, need to incorporate budget stuff into Sporting_team base class so inherited classes can use it


        //



    }
}
