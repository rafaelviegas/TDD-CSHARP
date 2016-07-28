using NUnit.Framework;
using TDD_Csharp.Chap1;

namespace TDD_Csharp.Tests
{
    [TestFixture]
     public class ValuerTest
    {
        [Test]
        public void BidsInAscendingOrder()
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
    }
}
