using Microsoft.AspNet.Identity.EntityFramework;

namespace CatalogApp.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}