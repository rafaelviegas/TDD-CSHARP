using NUnit.Framework;

using TDD_Csharp.Chap1;

namespace TDD_Csharp.Tests
{
    [TestFixture]
     public class ValuerTest
    {
        [Test]
        public void MustUnderstandAuctionWithBidsInAscendingOrder()
        {
            //1a parte: cenário
            User joao = new User("Joao");
            User jose = new User("Jose");
            User maria = new User("Maria");

            Auction auction = new Auction("Xbox One");

            auction.Propose(new Bid(maria, 250.0));
            auction.Propose(new Bid(joao,300.0));
            auction.Propose(new Bid(jose, 400.0));
          

            //2a parte: ação
            Valuer valuer = new Valuer();
            valuer.Valuation(auction);
            
            //3a parte: validação
            double highestBid = 400.0;
            double lowestBid = 250.0;

            Assert.AreEqual(highestBid, valuer.HighestBid, 0.00001);
            Assert.AreEqual(lowestBid, valuer.LowestBid, 0.00001);

        }

        [Test]
        public void MustUnderstandAuctionWithJustOneBid()
        {
            User joao = new User("João");
            Auction auction = new Auction("Xbox One");

            auction.Propose(new Bid(joao, 1000.0));

            Valuer valuer = new Valuer();
            valuer.Valuation(auction);

            Assert.AreEqual(1000, valuer.HighestBid, 0.00001);
            Assert.AreEqual(1000, valuer.LowestBid, 0.00001);
        }

        [Test]
        public void MustFindThreeHigher()
        {
            User joao = new User("João");
            User maria = new User("Maria");
            Auction auction = new Auction("Xbox One");

            auction.Propose(new Bid(joao,100.0));
            auction.Propose(new Bid(maria, 200.0));
            auction.Propose(new Bid(joao, 300.0));
            auction.Propose(new Bid(maria, 400.0));

            Valuer valuer = new Valuer();
            valuer.Valuation(auction);

            var higher = valuer.ThreeHighers;

            Assert.AreEqual(3,higher.Count);
            Assert.AreEqual(400,higher[0].Value, 0.0001);
            Assert.AreEqual(300, higher[1].Value, 0.0001);
            Assert.AreEqual(200, higher[2].Value, 0.0001);
        }
    }
}
