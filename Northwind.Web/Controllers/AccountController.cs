using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Northwind.Contracts.Dto.Authencation;
using Northwind.Domain.Models;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Login(UserLoginDto userLoginDto,string  returnUrl=null)

        {
            if(!ModelState.IsValid)
            {
                return View(userLoginDto);

            }
            //check  valid email & password
            var result = await _signInManager.PasswordSignInAsync(
                userLoginDto.Email,
                userLoginDto.Password,
                userLoginDto.RememberMe,
                false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid  username or password");
                return View();
            }
        }
        private IActionResult RedirectToLocal (string returnUrl)
        {
            if(Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
        }
        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegistrationDto);
            }
            //maping user dto

            var userModel = _mapper.Map<User>(userRegistrationDto);

            //insert user to dto
            var result = await _userManager.CreateAsync(userModel, userRegistrationDto.Password);

            if (!result.Succeeded)
            {
                foreach (var eror in result.Errors)
                {
                    ModelState.TryAddModelError(eror.Code, eror.Description);
                }
                return View(userRegistrationDto);
            }
            else
            {
                await _userManager.AddToRoleAsync(userModel, "Manager");
            }
            return RedirectToAction(nameof(AccountController.Login), "Account");  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task <IActionResult> Logout ()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }
    }
}
