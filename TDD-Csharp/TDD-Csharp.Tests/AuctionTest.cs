

using NUnit.Framework;
using TDD_Csharp.Domain;

namespace TDD_Csharp.Tests
{
    [TestFixture]
    public class AuctionTest
    {
        [Test]
        public void MustReceiveOneBid()
        {
            Auction auction = new Auction("MacBook Pro 15");

            Assert.AreEqual(0,auction.Bids.Count);

            auction.Propose(new Bid(new User("Steve Jobs"),2000));

            Assert.AreEqual(1, auction.Bids.Count);

            Assert.AreEqual(2000, auction.Bids[0].Value,0.00001);
        }

        [Test]
        public void MustReceiveMultipleBids()
        {
            Auction auction = new Auction("MacBook Pro 15");

            auction.Propose(new Bid(new User("Steve Jobs"), 2000));
            auction.Propose(new Bid(new User("Steve Wozniak"), 3000));

            Assert.AreEqual(2, auction.Bids.Count);
            Assert.AreEqual(2000,auction.Bids[0].Value,0.00001);
            Assert.AreEqual(3000, auction.Bids[1].Value, 0.00001);
        }

        [Test]
        public void MustNotAcceptTwoFollowedTheSameUserBids()
        {
            Auction auction = new Auction("MacBook Pro 15");

            auction.Propose(new Bid(new User("Steve Jobs"), 2000));
            auction.Propose(new Bid(new User("Steve Jobs"), 3000));

            Assert.AreEqual(1, auction.Bids.Count);
            Assert.AreEqual(2000, auction.Bids[0].Value, 0.00001);
        }

        [Test]
        public void MustNotAcceptMoreThanFiveOfTheSameUserbids()
        {
            Auction auction = new Auction("MacBook Pro 15");
            User steveJobs = new User("Steve Jobs");
            User billGates = new User("Bill Gates");

            auction.Propose(new Bid(steveJobs, 2000));
            auction.Propose(new Bid(billGates, 3000));

            auction.Propose(new Bid(steveJobs, 4000));
            auction.Propose(new Bid(billGates, 5000));

            auction.Propose(new Bid(steveJobs, 6000));
            auction.Propose(new Bid(billGates, 7000));

            auction.Propose(new Bid(steveJobs, 8000));
            auction.Propose(new Bid(billGates, 9000));

            auction.Propose(new Bid(steveJobs, 10000));
            auction.Propose(new Bid(billGates, 11000));

            
            auction.Propose(new Bid(steveJobs, 12000));

            Assert.AreEqual(10,auction.Bids.Count);
            var lastBid = auction.Bids[auction.Bids.Count - 1];

            Assert.AreEqual(11000,lastBid.Value,0.00001);
        }

    }
}
