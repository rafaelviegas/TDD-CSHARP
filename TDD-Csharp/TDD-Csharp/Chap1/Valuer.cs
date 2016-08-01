using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Csharp.Chap1
{
    public class Valuer
    {
        private double highestofAll = Double.MinValue;
        private double lowestOfAll = Double.MaxValue;
        private List<Bid> higher;
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
            getHigher(auction);
        }

        private void getHigher(Auction auction)
        {
            this.higher = new List<Bid>(auction.Bids.OrderByDescending(x => x.Value));
            this.higher = higher.GetRange(0, higher.Count >= 3 ? 3 : higher.Count);
        }
        public List<Bid> ThreeHighers { get { return this.higher; } }
        public double HighestBid { get { return highestofAll; } }
        public double LowestBid { get { return lowestOfAll; } }
    }
}
