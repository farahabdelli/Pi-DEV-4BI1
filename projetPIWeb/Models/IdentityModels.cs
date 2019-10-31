using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace projetPIWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Domaine.Store> Stores { get; set; }

        public System.Data.Entity.DbSet<Domaine.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Domaine.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<projetPIWeb.Models.ProduitModel> ProduitModels { get; set; }

        public System.Data.Entity.DbSet<Domaine.Brand> Brands { get; set; }

        public System.Data.Entity.DbSet<Domaine.Network> Networks { get; set; }

        public System.Data.Entity.DbSet<projetPIWeb.Models.StoreModel> StoreModels { get; set; }
    }
}