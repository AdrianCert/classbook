using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

namespace class_book
{
	public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
		{
			app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				LoginPath = new PathString("/Account/Index"),
				SlidingExpiration = true
			});
			app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			{
				ClientId = "533550947301-3i3n7uaisvpj5j2fkr1mq5f5h1uovpc5.apps.googleusercontent.com",
				ClientSecret = "cP-e3joqvanZagOCZfmrvswi",
				CallbackPath = new PathString("/GoogleLoginCallback")
			});
		}
	}
}