using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter_11.MatchOutcome;

namespace Chapter_11
{
    public class Soccer : SportingTeams
    {
        protected const int teamSize = 11;
        const double winReward = 10;
        const double lossPenalty = 5;

        public override int GetTeamParticipants()
        {
            return teamSize;
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


        public override string ToString()
        {
            //Some say StringBuilder is better than string concatenation
            StringBuilder retval = new StringBuilder("Team Name:").Append('\t').Append(this.Name);
            retval.Append(Environment.NewLine);     // /r/n --> windows \n --> *nix
            retval.Append("Sport Category:").Append('\t').Append(this.SportCategory);
            retval.Append(Environment.NewLine);
            retval.Append("Sport Type:").Append('\t').Append(nameof(Soccer));
            retval.Append(Environment.NewLine);
            retval.Append("Team Coach:").Append('\t').Append(this.Coach);
            retval.Append(Environment.NewLine);
            retval.Append("Points Balance:").Append('\t').Append(GetAccountBalance());
            retval.Append(Environment.NewLine);
            retval.Append("Win/Loss Ratio:").Append('\t').Append(GetWinLossRatio());
            retval.Append(Environment.NewLine);
            return retval.ToString();
        }

        public double GetAccountBalance()
        {
            return matchOutcomes.Sum(x => x.RewardPenalty);
        }

        private double GetWinLossRatio()
        {
            if (matchOutcomes.Count > 2)
            {
                //TODO: Fix this for where there are no losses to prevent divide by zero exception
                return (double)((double)matchOutcomes.Count(x => x.MatchResult.Equals(MatchOutcome.MatchOutcomes.Win)) /
                    ((double)matchOutcomes.Count(x => x.MatchResult.Equals(MatchOutcome.MatchOutcomes.Loss))));
            }
            return 0;
        }
    }
}
