
namespace TDD_Csharp.Domain
{
    public class User
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }

        public User(string name)
            : this(0, name)
        {
        }

        public User(int userId, string name)
        {
            this.UserId = userId;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != obj.GetType()) return false;

            var other = (User) obj;

            return other.UserId == this.UserId && other.Name.Equals(this.Name);
        }
    }
}
