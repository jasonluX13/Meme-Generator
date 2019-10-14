using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Security.Principal;
using MemeGenerator.Security;
using MemeGenerator.Data;
using System.Data.Entity;
using System.Threading;

namespace MemeGenerator
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        protected void Application_PostAuthenticateRequest()
        {
            IPrincipal user = HttpContext.Current.User;
            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                CustomIdentity customIdentity = new CustomIdentity(ticket);
                string currentUserEmail = ticket.Name;
                User user1 = new User();
                using (var context = new Context())
                {
                     user1 = context.Users
                        .Include(u => u.Roles)
                        .Where(u => u.Username == user.Identity.Name)
                        .SingleOrDefault();
                    
                }

                CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, user1);
                HttpContext.Current.User = customPrincipal;
                Thread.CurrentPrincipal = customPrincipal;
            }
        }
    }
}