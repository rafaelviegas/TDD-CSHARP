
namespace TDD_Csharp.Chap1
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
    }
}
