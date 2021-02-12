using AutoMapper;
using Core;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;
using ToDoDotNet.Data;
using SimpleInjector.Integration.Web;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Web;

namespace ToDoDotNet.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static Container Initialize(IAppBuilder app)
        {
            var container = GetInitializeContainer(app);

            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));

            return container;
        }

        public static Container GetInitializeContainer(
                  IAppBuilder app)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterInstance(app);

            container.Register<
                   ApplicationUserManager>(Lifestyle.Scoped);

            MapperConfiguration configuration = MappingProfile.Configure();
            container.Register<ToDoDbContext>(Lifestyle.Scoped);
            container.Register<IMapper>(() => configuration.CreateMapper(container.GetInstance));
            container.Register<IToDoRepository, ToDoRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<IUserStore<
              ApplicationUser>>(() =>
                new UserStore<ApplicationUser>(
                  container.GetInstance<ToDoDbContext>()), Lifestyle.Scoped);

            container.RegisterInitializer<ApplicationUserManager>(
                manager => InitializeUserManager(manager, app));

            container.Register<SignInManager<ApplicationUser, string>, ApplicationSignInManager>(Lifestyle.Scoped);

            container.Register(() =>
                container.IsVerifying
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);


            container.RegisterMvcControllers(
                    Assembly.GetExecutingAssembly());

            return container;
        }

        private static void InitializeUserManager(
            ApplicationUserManager manager, IAppBuilder app)
        {
            manager.UserValidator =
             new UserValidator<ApplicationUser>(manager)
             {
                 AllowOnlyAlphanumericUserNames = false,
                 RequireUniqueEmail = true
             };

            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var dataProtectionProvider =
                 app.GetDataProtectionProvider();

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                 new DataProtectorTokenProvider<ApplicationUser>(
                  dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }


        private static void InitializeContainer(Container container)
        {
            // Register your types, for instance:


        }
    }
}
