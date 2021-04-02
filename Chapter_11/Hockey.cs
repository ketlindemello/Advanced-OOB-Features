using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11
{
    public class Hockey : Sporting_teams, IBudgeting
    {
        public void montly_budget()
        {
            double some = 12.3;           
        }


        /// <summary>
        /// This adds a reward amount to the teams' account balance.
        /// </summary>
        /// <param name="amount"></param>
        public void AddAmountToBudget(double amount)
        {
            this.AccountBalance += amount;
        }

        public double DeductAmount(double amount)
        {
            throw new NotImplementedException();
        }

        public double GetAccountBalance()
        {
            throw new NotImplementedException();
        }
    }
}
