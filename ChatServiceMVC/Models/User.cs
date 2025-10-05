using Microsoft.AspNetCore.Identity;

namespace ChatServiceMVC.Models
{
    public class User: IdentityUser
    {
        private string _name = null!;
        private readonly string _id;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string UserId
        {
            get => _id;
        }

        public User()
        {
            _id = Id;
        }
    }
}
