using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11
{
    public abstract class Sporting_teams
    {
        private string primary_coach;
        private string sport_type;

        public Sporting_teams()
        {

        }

        public Sporting_teams(
            string primary_coach,
            string sport_type,
            double accountBalance)
        {
            this.primary_coach = primary_coach;
            this.sport_type = sport_type;
            this.AccountBalance = accountBalance;
        }

        public string Sport_Type { get { return sport_type; } }
        public string Coach { get { return primary_coach; } }

        public override string ToString()
        {
            return string.Format("Sport Type: {0} \nCoach: {1}", sport_type, primary_coach) ;
        }

        public virtual int GetTeamParticipants()
        {
            return 10;
        }

        public double AccountBalance { get; set; }

        //virtual method can be override by classes that derive from Sporting_teams

        //public virtual int Some_number()
        //{
        //    return 3;
        //}

    }
}
