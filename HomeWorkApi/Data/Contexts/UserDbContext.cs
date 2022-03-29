using Homework.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework.Api.Data.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public virtual DbSet<UserModel> Users { get; set; }  
    }
}
