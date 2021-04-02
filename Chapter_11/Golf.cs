using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter_11.MatchOutcome;

namespace Chapter_11
{
    public class Golf : Sporting_teams
    {
        const double winReward = 100;
        const double lossPenalty = 50;

        public bool Membership_Required { get; set; }

        
        public Dictionary<string, bool> players = new Dictionary<string, bool>();

        public override void RecordMatchOutcome(MatchOutcomes matchWin)
        {
            switch (matchWin)
            {
                case MatchOutcome.MatchOutcomes.Win:
                    this.RecordMatchOutcome(matchWin, winReward);
                    break;
                case MatchOutcome.MatchOutcomes.Loss:
                    this.RecordMatchOutcome(matchWin, -lossPenalty);
                    break;
                case MatchOutcome.MatchOutcomes.Tie:
                    this.RecordMatchOutcome(matchWin, 0);
                    break;
                default:
                    //set label?
                    break;
            }
        }

        protected override void RecordMatchOutcome(MatchOutcomes matchWin, double rewardPenalty)
        {
            matchOutcomes.Add(new MatchOutcome() { MatchResult = matchWin, RewardPenalty = rewardPenalty });
        }


    }
}
