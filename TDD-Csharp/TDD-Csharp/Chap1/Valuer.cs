using System;

namespace TDD_Csharp.Chap1
{
    public class Valuer
    {
        private double highestofAll = Double.MinValue;
        private double lowestOfAll = Double.MaxValue;

        public void Valuation(Auction auction)
        {
            foreach (var bid in auction.Bids)
            {
                if (bid.Value > highestofAll)
                {
                    highestofAll = bid.Value;
                }
                if (bid.Value < lowestOfAll)
                {
                    lowestOfAll = bid.Value;
                }
            }
        }
        public double HighestBid { get { return highestofAll; } }
        public double LowestBid { get { return lowestOfAll; } }
    }
}
