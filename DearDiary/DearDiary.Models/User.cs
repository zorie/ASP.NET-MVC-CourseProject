using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace DearDiary.Models
{
    public class User : IdentityUser
    {
        private ICollection<Aim> futureAims;
        private ICollection<Aim> accomplishedAims;
        public User()
        {
            this.futureAims = new HashSet<Aim>();
            this.accomplishedAims = new HashSet<Aim>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Aim> FutureAims
        {
            get { return this.futureAims; }
            set { this.futureAims = value; }
        }

        public virtual ICollection<Aim> AccomplishedAims
        {
            get { return this.accomplishedAims; }
            set { this.accomplishedAims = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
