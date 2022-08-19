using FlowerPlanet.Data;
using FlowerPlanet.Models;
using FlowerPlanet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowerPlanet.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDB _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDB context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
    
        public IActionResult Login() //Get
        {
            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]        
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) //Post
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if(user != null)
            {
                //User is found, check pass
              var passwordcheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if(passwordcheck)
                {
                    //Password correct
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Shows");
                    }
                }
                //Wrong pass
                TempData["Error"] = "Wrong Password. Please enter correct password";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Wrong Password. Please enter correct password";
            return View(loginViewModel);

        }
        public IActionResult Register() //Get
        {
            var response = new RegisterViewModel();
            return View(response);
        }


        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if(user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }
            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);
            
            if(newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Shows");
        }

    }
}
