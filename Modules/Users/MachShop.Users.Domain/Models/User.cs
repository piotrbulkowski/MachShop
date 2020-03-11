using System.Collections.Generic;

namespace MachShop.Users.Domain.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }
        public IEnumerable<UserRole> Roles { get; set; }
    }
}
