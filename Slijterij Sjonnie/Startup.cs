using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Slijterij_Sjonnie.Models;

[assembly: OwinStartupAttribute(typeof(Slijterij_Sjonnie.Startup))]
namespace Slijterij_Sjonnie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                try
                {
                    var User = userManager.FindByEmail("admin@admin.nl");
                    userManager.AddToRole(User.Id, "Admin");
                }
                catch (System.Exception)
                {
                    var User = new ApplicationUser();
                    User.UserName = "admin@admin.nl";
                    User.Email = "admin@admin.nl";
                    string pwd = "Admin1!";
                    var checkUser = userManager.Create(User, pwd);
                    if (checkUser.Succeeded)
                    {
                        userManager.AddToRole(User.Id, "Admin");
                    }
                    else
                    {
                        throw;
                    }
                }
            }

        }
    }
}
