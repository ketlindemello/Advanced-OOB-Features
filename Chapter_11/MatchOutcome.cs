using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11
{
    public class MatchOutcome
    {
        public enum MatchOutcomes
        {
            Win,
            Loss,
            Tie
        }

        public MatchOutcomes MatchResult { get; set; }
        public double RewardPenalty { get; set; }
    }
}
