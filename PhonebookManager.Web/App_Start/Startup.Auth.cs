using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PhonebookManager.DataAccess.Context;
using PhonebookManager.DataAccess.Identity;
using PhonebookManager.Web.App_Start.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookManager.Web
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {

            app.CreatePerOwinContext(PhonebookManagerContext.Create);
            app.CreatePerOwinContext(PhonebookUserManager.Create);


            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}