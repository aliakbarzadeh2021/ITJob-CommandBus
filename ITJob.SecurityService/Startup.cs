using System;
using System.Data.Entity;
using ITJob.SecurityService.Providers;
using ITJob.SecurityService.Repository.DbContexts;
using ITJob.SecurityService.Repository.Migrations;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace ITJob.SecurityService
{
#if !DEBUG
    using Repository.Migrations;
    //using Repository.Migrations.PublishHfj; //=> Publish Hfj
#endif
#if DEBUG
#endif

    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public static void ConfigureOAuth(IAppBuilder app)
        {
            ////use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new AuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }

        public static void SetDatabaseInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, Configuration>());
        }
    }
}