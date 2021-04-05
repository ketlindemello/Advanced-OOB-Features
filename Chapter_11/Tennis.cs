using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter_11.MatchOutcome;

namespace Chapter_11
{
    public class Tennis : SportingTeams, IBalance
    {
        const double winReward = 50;
        const double lossPenalty = 25;

        //Auto-property
        public string RacketRestringerName { get; set; }

        

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
            retval.Append("Sport Type:").Append('\t').Append(nameof(Tennis));
            retval.Append(Environment.NewLine);
            retval.Append("Team Coach:").Append('\t').Append(this.Coach);
            retval.Append(Environment.NewLine);
            retval.Append("Racket Restringer:").Append('\t').Append(this.RacketRestringerName);
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

        /*public double DeductAmount(double amount)
        {
            throw new NotImplementedException();
        }

        public void AddAmountToBudget(double amount)
        {
            throw new NotImplementedException();
        }*/
    }
}
