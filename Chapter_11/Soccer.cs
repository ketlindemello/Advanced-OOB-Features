using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter_11.MatchOutcome;

namespace Chapter_11
{
    public class Soccer : Sporting_teams
    {
        protected const int _teamSize = 12;
        const double winReward = 10;
        const double lossPenalty = 5;

        public override int GetTeamParticipants()
        {
            return _teamSize;
        }

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
