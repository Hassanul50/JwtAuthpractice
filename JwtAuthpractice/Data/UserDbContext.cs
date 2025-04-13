using JwtAuthpractice.Entity;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthpractice.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<TokenResponseDto> LoginAsync { get; set; }

    }
}
