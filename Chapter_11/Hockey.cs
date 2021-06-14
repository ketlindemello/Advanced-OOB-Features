using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter_11.MatchOutcome;

namespace Chapter_11
{
    public class Hockey : SportingTeams, IBalance
    {
        protected const int _teamSize = 6;
        const double winReward = 50;
        const double lossPenalty = 25;

        public override int GetTeamParticipants()
        {
            return _teamSize;
        }

        public Dictionary<string, string> players = new Dictionary<string, string>();
        public List<string> positions = new List<string> { "Right Defence", "Left Defence", "Right Wing", "Left Wing", "Centre", "Goalie" };
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
            retval.Append("Sport Type:").Append('\t').Append(nameof(Hockey));
            retval.Append(Environment.NewLine);
            retval.Append("Team Coach:").Append('\t').Append(this.Coach);
            retval.Append(Environment.NewLine);
            retval.Append(Environment.NewLine);
            retval.Append("Player").Append('\t').Append('\t').Append("Position");
            foreach (KeyValuePair<string, string> player in players)
            {
                retval.Append($"\n{player.Key}\t{player.Value}");
            }
            retval.Append(Environment.NewLine);
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
                //TODO: x => lamba
                return (double)((double)matchOutcomes.Count(x => x.MatchResult.Equals(MatchOutcome.MatchOutcomes.Win)) /
                    ((double)matchOutcomes.Count(x => x.MatchResult.Equals(MatchOutcome.MatchOutcomes.Loss))));
            }
            return 0;
        }
    }
}
