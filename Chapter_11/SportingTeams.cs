﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter_11.MatchOutcome;

namespace Chapter_11
{
    public abstract class SportingTeams
    {
        protected List<MatchOutcome> matchOutcomes = new List<MatchOutcome>();

        public List<MatchOutcome> MatchOutcomes { get { return this.matchOutcomes; } }

        public string SportCategory { get; set; }
        public string Coach { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Sport Type: {0} \nCoach: {1}", SportCategory, Coach, Name);
        }

        public virtual int GetTeamParticipants()
        {
            return 11;
        }

        public virtual void RecordMatchOutcome(MatchOutcomes matchWin)
        {
            this.RecordMatchOutcome(matchWin, 0);
        }

        protected virtual void RecordMatchOutcome(MatchOutcomes matchWin, double rewardPenalty)
        {
            matchOutcomes.Add(new MatchOutcome() { MatchResult = matchWin, RewardPenalty = rewardPenalty });
        }

        public double AccountBalance { get; set; }

        //virtual method can be override by classes that derive from SportingTeams

        //public virtual int Some_number()
        //{
        //    return 3;
        //}

    }
}
