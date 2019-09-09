using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Nagarro.BufferOverflow.DTOModel;
using Nagarro.BufferOverflow.Shared;
using System;
namespace Nagarro.BufferOverflow.UI
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthServiceProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            UserController user = new UserController();

            User userModel = new User();

            userModel.Email = context.UserName;
            userModel.Password = context.Password;

            User model = user.Login(userModel);

            if (model != null)
            {

                identity.AddClaim(new Claim("Id", Convert.ToString(model.Id)));
                identity.AddClaim(new Claim("FirstName", model.FirstName));
                identity.AddClaim(new Claim("LastName", model.FirstName));
                identity.AddClaim(new Claim("Email", model.Email));

                var props = new AuthenticationProperties(new Dictionary<string, string> {
                    {
                        "Id", Convert.ToString(model.Id)
                    },
                    {
                        "FirstName",
                        model.FirstName
                    },
                    {
                        "LastName",
                        model.LastName
                    },
                    {
                        "Email",
                        model.Email
                    }
                });
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is not matching, Please retry.");
                context.Rejected();
            }
       
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)

        {

            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)

            {

                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            }



            return Task.FromResult<object>(null);

        }

    }
}
