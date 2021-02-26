namespace Xdl.Internship.Authentication.DTOs
{
    public class UserCredentials
    {
        public string Login { get;  }

        public string Password { get; }

        public UserCredentials(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
