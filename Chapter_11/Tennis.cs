using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11
{
    public class Tennis : Sporting_teams
    {
        //Auto-property
        public string RacketRestringerName { get; set; }



        public override int GetTeamParticipants()
        {
            return 2;
        }

        //TODO: ToString method
        public override string ToString()
        {
            //Do some different stuff
            return base.ToString();
        }
    }
}
