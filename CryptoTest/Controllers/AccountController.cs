using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Account;

namespace CryptoTest.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser user =
                    await userManager.FindByNameAsync(model.Email);
                    if (user != null)
                    {
                        await signInManager.SignOutAsync();
                        if ((await signInManager.PasswordSignInAsync(user,
                        model.Password, false, false)).Succeeded)
                        {
                            return new JsonResult(new
                            {
                                ok = true
                            });
                        }
                    }
                    return new JsonResult(new
                    {
                        message = "Invalid name or password"
                    });
                }
                return new JsonResult(new
                {
                    message = "invalid input data"
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    message = "an error occurred"
                });
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser user =
                    await userManager.FindByNameAsync(model.Email);
                    if (user != null)
                    {
                        return new JsonResult(new
                        {
                            message = "an account with this email address already exists"
                        });
                    }
                    else
                    {
                        user = new IdentityUser(model.Email);
                        user.Email = model.Email;
                        await userManager.CreateAsync(user, model.Password);
                        return new JsonResult(new
                        {
                            ok = true
                        });
                    }

                }
                return new JsonResult(new
                {
                    message = "invalid input data"
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    message = "an error occurred"
                });
            }            
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
