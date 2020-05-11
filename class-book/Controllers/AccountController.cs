using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Data.Repositories;
using Data.Entities;
using class_book.ViewModel;

namespace class_book.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public void SignIn(string ReturnUrl = "/", string type = "")
        {
            if (!Request.IsAuthenticated)
            {
                if (type == "Google")
                {
                    HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "Account/GoogleLoginCallback" }, "Google");
                }
            }
        }

		public ActionResult SignOut()
		{
			HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
			return Redirect("~/");
		}

		[AllowAnonymous]
		public ActionResult GoogleLoginCallback()
		{
			var claimsPrincipal = HttpContext.User.Identity as ClaimsIdentity;

			var loginInfo = GoogleLoginViewModel.GetLoginInfo(claimsPrincipal);
			if (loginInfo == null)
			{
				return RedirectToAction("Index");
			}

			AccountRepository acdb = new AccountRepository();
			UserAccount user = acdb.GetByMail(loginInfo.EmailAddress);

			if (user == null)
			{
				user = new UserAccount
				{
					Id = Guid.NewGuid(),
					Email = loginInfo.EmailAddress,
					GivenName = loginInfo.GivenName,
					Identifier = loginInfo.NameIdentifier,
					Name = loginInfo.Name,
					SurName = loginInfo.Surname,
					IsActive = true
				};
				acdb.Insert(user);
				acdb.Save();
			}

			var ident = new ClaimsIdentity(
				new[] { 
					// adding following 2 claim just for supporting default antiforgery provider
					new Claim(ClaimTypes.NameIdentifier, user.Email),
					new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

					new Claim(ClaimTypes.Name, user.Name),
					new Claim(ClaimTypes.Email, user.Email),
				},
				CookieAuthenticationDefaults.AuthenticationType);

			HttpContext.GetOwinContext().Authentication.SignIn(
						new AuthenticationProperties { IsPersistent = false }, ident);
			return Redirect("~/");

		}
	}
}