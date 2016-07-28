using System.Collections.Generic;

namespace TDD_Csharp.Chap1
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
            Bids.Add(bid);
        }
    }
}
