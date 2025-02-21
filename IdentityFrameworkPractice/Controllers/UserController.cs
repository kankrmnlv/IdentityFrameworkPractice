using IdentityFrameworkPractice.Data;
using IdentityFrameworkPractice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityFrameworkPractice.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _user;

        public UserController(ApplicationDbContext db, UserManager<AppUser> user)
        {
            _db = db;
            _user = user;
        }
        public IActionResult Index()
        {
            var userList = _db.AppUser.ToList();
            var roleList = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach(var user in userList)
            {
                var role = roleList.FirstOrDefault(x => x.UserId == user.Id);
                if(role == null)
                {
                    user.Role = "None";
                }
                else
                {
                    user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
                }
            }

            return View(userList);
        }
    }
}
