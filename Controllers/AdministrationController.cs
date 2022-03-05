using Library.Areas.Identity.Data;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Library.Controllers
{
    public class AdministrationController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<LibraryUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
            UserManager<LibraryUser> userManager)
        {

            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUsers(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("CreateRole", "Administration");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult ListRoles() 
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
        var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} can not be found";
                return View("Index");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
            };
            foreach (var user in userManager.Users) 
            {
                if (await userManager.IsInRoleAsync(user, role.Name)) 
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    model.User.Add(user.UserName);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} can not be found";
                return View("Index");
            }
            else 
            {
            role.Name = model.RoleName;
            var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded) 
                {
                return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError("", error.Description);                }
            }
            
            
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} can not be found";
                return View("Index");
            }
            var model = new List<UserRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);

            }
            return View(model);

        }
       
            [HttpPost]
            public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
            {
            ViewBag.roleId = roleId;
                var role = await roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {roleId} can not be found";
                    return View("Index");
                }
                for (int i = 0; i < model.Count; i++)
                {
                    var user = await userManager.FindByIdAsync(model[i].UserId);
                    IdentityResult result = null;
                    if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.AddToRoleAsync(user, role.Name);
                    }

                else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }
                    if (result.Succeeded)
                    {
                        if (i < (model.Count - 1))
                            continue;
                        else
                            return RedirectToAction("EditRole", "Administration", new { Id = roleId });

                    }


                }

                return RedirectToAction("EditRole", "Administration", new { Id = roleId });
            }
        }
       
        }

    

