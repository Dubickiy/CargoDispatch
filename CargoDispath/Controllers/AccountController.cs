using CargoDispath.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoDispath.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Account
        public ActionResult Register()
        {
            //TempData["register"] = model.Name;
            return View();
        }
        public ActionResult Login(string returnUrl, string errorMessage)
        {
            ViewBag.returnUrl = returnUrl;
            ViewBag.errorMessage = errorMessage;
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult ConfirmInfo(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            Session["UserName"] = model.Name;
            Session["UserSurname"] = model.Surname;
            Session["UserEmail"] = model.Email;
            var user_name = Session["UserName"].ToString();
            var user_surname = Session["UserSurname"].ToString();
            var user_email = Session["UserEmail"].ToString();
            ViewBag.Name = user_name;
            ViewBag.Surname = user_surname;
            ViewBag.Email = user_email;
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.Email;
                user.Email = model.Email;
                user.Surname = model.Surname;
                user.Name = model.Name;
                
                
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    Session.Clear();
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code },
                       protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Подтверждение электронной почты",
                       "Для завершения регистрации перейдите по ссылке:: <a href=\""
                                                       + callbackUrl + "\">завершить регистрацию</a>");
                    //return View("DisplayEmail");
                    return RedirectToAction("Index", "Home", new { message = "На указанный электронный адрес отправлены дальнейшие действия по завершению регистрации" });
                }
                else
                {
  
                    foreach (string error in result.Errors)
                    {
                        if (model.Password.Length < 6)
                        {
                            ModelState.AddModelError("Password", "Пароль должен состоять минимум из 6 символов");
                        }
                       else if (model.Email.Equals(user.Email))
                        {
                            ModelState.AddModelError("Email", "Указанный электронный адрес уже используется");
                        }
                       
                        

                    }
                }

            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            Session["UserEmail"] = model.Email;
            var user_email = Session["UserEmail"].ToString();
            ViewBag.Email = user_email;
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Password", "Неверный логин или пароль.");
                   
                }
                else
                {
                    if (user.EmailConfirmed == true)
                    {
                        if(user.PhoneNumber == null)
                        {
                            var usId = user.Id;
                            return Redirect("/Account/ConfirmInfo?id="+usId);
                            //
                            //return RedirectToAction("ConfirmInfo", "Account", new { userId = usId});
                        }
                        Session.Clear();
                        ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                                DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);
                        if (String.IsNullOrEmpty(returnUrl)) 
                            return RedirectToAction("Index", "Home");
                        return Redirect(returnUrl);

                    }
                    else
                    {
                    ModelState.AddModelError("Email", "Не подтвержден email.");
                    }

                    }
            }
            ViewBag.returnUrl = returnUrl;
            
            return View(model);
        }
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return RedirectToAction("Login", "Account");
            // return View();
        }
        [HttpPost]
        public async Task<ActionResult> ConfirmInfo(ConfirmInfoModel model, string Id)
        {

            if (ModelState.IsValid)
            {
                var result = await UserManager.FindByIdAsync(Id);
                ApplicationUser user = await UserManager.FindByIdAsync(Id);
                
                var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                var number = await UserManager.SetPhoneNumberAsync(Id, model.PhoneNumber);
                user.Adress = model.Adress;
                await UserManager.UpdateAsync(user);
                //result.Adress = model.Adress;
                //result.PhoneNumber = model.PhoneNumber;
                if (user.EmailConfirmed == true)
                {
                    
                    Session.Clear();
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    //if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    //return Redirect(returnUrl);

                }
                else
                {
                    ModelState.AddModelError("Email", "Не подтвержден email.");
                }

            }
            else
            {
                if(model.Adress == null)
                {
                    ModelState.AddModelError("Adress", "Поле обязательно для заполнения.");
                }
                if(model.PhoneNumber == null)
                {
                    ModelState.AddModelError("PhoneNumber", "Поле обязательно для заполнения.");
                }
                //ModelState.AddModelError("Password", "Неверный логин или пароль.");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    ModelState.AddModelError("Email", "Такого электронного адреса не существует в системе");
                    return View("ForgotPassword");
                }
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account",
                    new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Сброс пароля",
                    "Для сброса пароля, перейдите по ссылке <a href=\"" + callbackUrl + "\">сбросить</a>");
                return RedirectToAction("Index", "Home", new { message = "Проверьте электронную почту, чтобы сбросить пароль." });
            }
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPassword model, string code)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Не показывать, что пользователь не существует
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            //AddErrors(result);
            return View();
        }
    }

}