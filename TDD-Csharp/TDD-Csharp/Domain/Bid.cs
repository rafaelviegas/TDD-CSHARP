
namespace TDD_Csharp.Domain
{
    public class Bid
    {
        public User User { get; private set; }
        public double Value { get; private set; }

        public Bid(User user, double value)
        {
            this.User = user;
            this.Value = value;
        }
    }
}
