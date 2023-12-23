using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager){
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult RoleList(){
            return View(_userManager.Users);
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(UserViewModel model){

            if (ModelState.IsValid)
            {
                var user = new AppUser{UserName = model.UserName, Email = model.Email, FullName = model.FullName};
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("",err.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> EditUser(string id){
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();

                return View(new EditViewModel{
                    UserID = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    SelectedRole = await _userManager.GetRolesAsync(user)
                }

                );
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditViewModel model){
            if (id != model.UserID)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserID);
                if(user != null){
                    user.Email = model.Email;
                    user.FullName = model.FullName;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, model.Password);
                    }
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRolesAsync(user , await _userManager.GetRolesAsync(user));
                        if (model.SelectedRole != null)
                        {
                            await _userManager.AddToRolesAsync(user, model.SelectedRole);
                        }
                        return RedirectToAction("Index");
                    }
                    foreach (IdentityError err in result.Errors)
                    {
                        ModelState.AddModelError("",err.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id){
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}