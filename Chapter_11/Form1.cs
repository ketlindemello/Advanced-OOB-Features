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

        //TODO: Make a UI for sports team budget, need to incorporate budget stuff into Sporting_team base class so inherited classes can use it
    }
}
