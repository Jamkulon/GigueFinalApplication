
namespace SharedPreferences
{
    public class UserList
    {
        public UserList(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public override string ToString()
        {
            return UserName;
        }
    }
}