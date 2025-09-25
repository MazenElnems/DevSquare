using DevSquare.Core.Domain;
using DevSquare.UI.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevSquare.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, isPersistent: loginViewModel.RemeberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = registerViewModel.UserName,
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
            return View(registerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [ActionName("reset-password")]  
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ActionName("confirm-reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity?.Name ?? string.Empty;
                
                User? user = await _userManager.FindByNameAsync(userName);

                if(user == null)
                {
                    // TODO: Log Warning
                    return RedirectToAction(nameof(Login));
                }

                var result = await _userManager.ChangePasswordAsync(user, resetPasswordViewModel.CurrentPassword, resetPasswordViewModel.NewPassword);

                if(result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction(nameof(Login));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
            return View(resetPasswordViewModel);
        }
    }
}
