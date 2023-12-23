using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Project.Models;

namespace Project.TagHelpers
{
    [HtmlTargetElement("td", Attributes ="Asp-role-users")]
    public class RoleUserTagHelper : TagHelper
    {

        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleUserTagHelper(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager){
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HtmlAttributeName("Asp-role-users")]
        public string RoleID{get; set;} = null!;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output){

            var userNames = new List<string>();
            var role = await _roleManager.FindByIdAsync(RoleID);
            if (role != null && role.Name != null)
            {
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        
                        userNames.Add(user.UserName ?? "");
                    }
                }
                output.Content.SetContent(userNames.Count == 0 ? "No User" : string.Join(",", userNames));

            }
        }


    }
    

}