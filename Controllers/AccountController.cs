using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgroControl.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgroControl.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserMngr { get; private set; }
        public SignInManager<AppUser> SignInMngr { get; private set; }

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            UserMngr = userManager;
            SignInMngr = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            SetViewBagMessages();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await SignInMngr.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                TempData["Message"] += "Pomyślnie zalogowano!";
                TempData["MessageType"] = "success";
                return RedirectToAction("Index", "Gospodarstwo");
            }
            else
            {
                ViewBag.Message += "Nieprawidłowa nazwa użytkownika lub hasło";
                ViewBag.MessageType = "error";
                
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await SignInMngr.SignOutAsync();

                TempData["Message"] += "Pomyślnie wylogowano!";
                TempData["MessageType"] = "success";
            }
            catch(Exception ex)
            {
                TempData["Message"] += ex.Message;
                TempData["MessageType"] = "error";
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                TempData["Message"] = "Użytkownik już istnieje!";
                TempData["MessageType"] = "error";

                if (!ModelState.IsValid)
                {
                    return View();
                }

                AppUser appUser = new AppUser();
                appUser.UserName = registerViewModel.UserName;
                appUser.Email = registerViewModel.Email;
                appUser.FirstName = "John";
                appUser.LastName = "Doe";

                IdentityResult result = await UserMngr.CreateAsync(appUser, registerViewModel.Password);

                if(result.Errors.Count() > 0)
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ViewBag.Message += error.Description + "\n";
                        ViewBag.MessageType = "error";
                    }
                    return View();
                }

                TempData["MessageType"] = "success";
                TempData["Message"] = "Stworzono użytkownika!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.MessageType = "error";
                return View();
            }

            return RedirectToAction("Login");
        }

        private void SetViewBagMessages()
        {
            ViewBag.Message += TempData["Message"];
            ViewBag.MessageType += TempData["MessageType"];
        }
    }
}
