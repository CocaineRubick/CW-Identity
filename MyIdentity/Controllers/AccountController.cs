using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyIdentity.Models;

namespace MyIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newuser = new IdentityUser() { UserName = model.UserName, Email = model.Email};
            var result = await userManager.CreateAsync(newuser, model.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            //email confirmation needed

            return RedirectToAction("SignIn");
        }

        public IActionResult SignIn()
        {
            //now allowing sign in view to person who signed in
            //if (signInManager.IsSignedIn(User))
            //{

            //}

            // how to use return url???
                
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.UserName, model.PassWord, model.RememberMe, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "The password or username is incorrect");
                return View(model);
            }

            if (result.IsLockedOut)
            {
                ViewData["ErrorMessage"] = "Your account has been locked for 5 minunts due to too many failures";
                return View(model);
            }

            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        // remote check : ???
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> IsEmailInUse(string email)
        //{
        //    var user = await userManager.FindByEmailAsync(email);
        //    if (user == null) return Json(true);
        //    return Json("The email address entered already exists");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> IsUserNameInUse(string username)
        //{
        //    var user = await userManager.FindByNameAsync(username);
        //    if (user == null) return Json(true);
        //    return Json("The username entered already exists");
        //}


        //email confirmation :
        //public async Task<IActionResult> ConfirmEmail(string username, string token)
        //{
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(token))
        //        return NotFound();
        //    var user = await userManager.FindByNameAsync(username);
        //    if (user == null) return NotFound();
        //    var result = await userManager.ConfirmEmailAsync(user, token);

        //    return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");
        //}
    }
}
