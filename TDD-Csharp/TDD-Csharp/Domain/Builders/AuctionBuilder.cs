namespace TDD_Csharp.Domain.Builders
{
    public class AuctionBuilder
    {
        private Auction auction;

        public AuctionBuilder To(string description)
        {
            this.auction = new Auction(description);
            return this;
        }

        public AuctionBuilder Propose(User user, double value)
        {
            auction.Propose(new Bid(user,value));
            return this;
        }

        public Auction Build()
        {
            return auction;
        }

    }
}
