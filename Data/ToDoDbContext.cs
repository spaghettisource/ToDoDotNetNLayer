using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace ToDoDotNet.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ToDoDbContext : IdentityDbContext<ApplicationUser>
    {
        public ToDoDbContext()
            : base("name=ToDoDbContext", throwIfV1Schema: false)
        {
        }

        public static ToDoDbContext Create()
        {
            return new ToDoDbContext();
        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
