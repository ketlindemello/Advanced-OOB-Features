using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11
{
    class Golf : Sporting_teams
    {
        public bool Membership_Required { get; set; }

        
        public Dictionary<string, bool> players = new Dictionary<string, bool>();




    }
}
