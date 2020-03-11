using MachShop.Users.Domain.Models;
using MachShop.Users.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Users.Infrastructure
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options) : base(options) { }
        #region Entites
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
