using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using CIS420NewWebsite.Models;

[assembly: OwinStartup(typeof(CIS420NewWebsite.Startup))]
namespace CIS420NewWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //If Admin role doesn't exist, create first Super Admin Role and a default Super Admin User    
            if (!roleManager.RoleExists("SuperAdmin"))
            {
                //First we create Admin role   
                var role = new IdentityRole();
                role.Name = "SuperAdmin";
                roleManager.Create(role);

                //Then we create a Admin user                
                var user = new ApplicationUser();
                user.UserName = "admin@email.com"; //Use same UserName and Email for simplicity. 
                user.Email = "admin@email.com";    //Else you will need to modify the login action in the AccountController
                string userPWD = "Welcome1";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "SuperAdmin");
                }
            }
            //// creating Creating Manager role    
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin1@email.com"; //Use same UserName and Email for simplicity. 
                user.Email = "admin1@email.com";    //Else you will need to modify the login action in the AccountController
                string userPWD = "Welcome1";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }

            }

            //// creating Creating Employee role    
            if (!roleManager.RoleExists("Member"))
            {
                var role = new IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "member@email.com"; //Use same UserName and Email for simplicity. 
                user.Email = "member@email.com";    //Else you will need to modify the login action in the AccountController
                string userPWD = "Welcome1";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Member");
                }

            }

        }
    }

}

