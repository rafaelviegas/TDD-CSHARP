using System;
using NUnit.Framework;
using TDD_Csharp.Domain;
using TDD_Csharp.Domain.Builders;

namespace TDD_Csharp.Tests
{
    [TestFixture]
    public class ValuerTest
    {
        private Valuer valuer;
        private User joao;
        private User jose;
        private User maria;


        [SetUp]
        public void Setup()
        {
            this.valuer = new Valuer();

            this.joao = new User("Joao");
            this.jose = new User("Jose");
            this.maria = new User("Maria");

        }

        [Test]
        public void MustUnderstandAuctionWithBidsInAscendingOrder()
        {
            //1a parte: cenário
            var auction = new AuctionBuilder()
                .To("Xbox One")
                .Propose(maria, 250)
                .Propose(joao, 300)
                .Propose(jose, 400)
                .Build();

            //2a parte: ação
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
            var auction = new AuctionBuilder()
                .To("Xbox One")
                .Propose(joao, 1000.0)
                .Build();

            valuer.Valuation(auction);

            Assert.AreEqual(1000, valuer.HighestBid, 0.00001);
            Assert.AreEqual(1000, valuer.LowestBid, 0.00001);
        }

        [Test]
        public void MustFindThreeHigher()
        {
            var auction = new AuctionBuilder()
                .To("Xbox One")
                .Propose(joao, 100.0)
                .Propose(maria, 200.0)
                .Propose(joao, 300.0)
                .Propose(maria, 400.0)
                .Build();

            valuer.Valuation(auction);

            var higher = valuer.ThreeHighers;

            Assert.AreEqual(3, higher.Count);
            Assert.AreEqual(400, higher[0].Value, 0.0001);
            Assert.AreEqual(300, higher[1].Value, 0.0001);
            Assert.AreEqual(200, higher[2].Value, 0.0001);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("End");
        }
    }
}
