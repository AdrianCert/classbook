using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace class_book.ViewModel
{
    public class GoogleLoginViewModel
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string NameIdentifier { get; set; }

        internal static GoogleLoginViewModel GetLoginInfo(ClaimsIdentity identity)
        {
            if (identity.Claims.Count() == 0 || identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email) == null)
            {
                return null;
            }

            return new GoogleLoginViewModel
            {
                EmailAddress = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value,
                Name = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value,
                GivenName = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName).Value,
                Surname = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname).Value,
                NameIdentifier = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value,
            };
        }
    }
}