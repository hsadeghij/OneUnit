using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Account")]
    public class AccountController: Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<StoreUser> _signInManager;
        private readonly UserManager<StoreUser> _userManager;

        public AccountController(ILogger<AccountController> logger,
            SignInManager<StoreUser> signInManager, UserManager<StoreUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Shop", "App", new { area = "" });
            }
            return View();
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = await _signInManager.PasswordSignInAsync(model.UserName,
            //        model.Password, model.RememberMe,
            //        false);
            //    if (result.Succeeded)
            //    {
            //        if (Request.Query.Keys.Contains("ReturnUrl"))
            //        {
            //            Redirect(Request.Query["ReturnUrl"].First());
            //        }
            //        else
            //        {

            //            RedirectToAction("Shop", "App", new { area = "" });
            //        }

            //    }
            //}
            //ModelState.AddModelError("", "Username/password not found");
            //return View(model);
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return RedirectToAction("Shop", "App", new { area = "" });

                    return Redirect(model.ReturnUrl);
                }
            }

            ModelState.AddModelError("", "Username/password not found");
            return View(model);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Shop", "App", new { area = "" });
        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new StoreUser() { UserName = loginViewModel.UserName };
                var result = await _userManager.CreateAsync(user, loginViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }
        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
