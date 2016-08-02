using System.Collections.Generic;

namespace TDD_Csharp.Domain
{
    public class Auction
    {
        public string Description { get; set; }
        public IList<Bid> Bids { get; set; }

        public Auction(string description)
        {
            this.Description = description;
            this.Bids = new List<Bid>();
        }

        public void Propose(Bid bid)
        {

            if (Bids.Count == 0 || CanBid(bid.User))
            {
                Bids.Add(bid);
            }
        }

        private bool CanBid(User user)
        {
            return (!LastBidProposed().User.Equals(user)) && CountUserBids(user) < 5;
        }

        private Bid LastBidProposed()
        {
            return Bids[Bids.Count - 1];
        }

        private int CountUserBids(User user)
        {
            int total = 0;

            foreach (var b in Bids)
            {
                if (b.User.Equals(user)) total++;

            }
            return total;
        }
    }
}
