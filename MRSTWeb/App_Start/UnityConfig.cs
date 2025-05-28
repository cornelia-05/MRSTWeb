using System.Web.Mvc;
using Unity;
using MRSTWeb.Data.Context;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.BusinessLogic;
using BusinessLogic;
using System;
using Unity.AspNet.Mvc;
using Unity.Lifetime;
using MRSTWeb.BusinessLogic.Core;


namespace MRSTWeb
{
     /// <summary>
     /// Specifies the Unity configuration for the main container.
     /// </summary>
     public static class UnityConfig
     {
          private readonly static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
          {
               var container = new UnityContainer();
               RegisterTypes(container);
               return container;
          });

          public static IUnityContainer Container => container.Value;

          public static void RegisterTypes(IUnityContainer container)
          {
               container.RegisterType<ISession, SessionLogic>();
               container.RegisterType<IProduct, ProductBL>();
               container.RegisterType<DBContext>(new PerRequestLifetimeManager());
               container.RegisterType<IAdminApi, AdminApi>();
               container.RegisterType<IUserApi, UserApi>();
               container.RegisterType<IContactBL, ContactBL>();

          }


          public static void RegisterComponents()
          {
               DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
          }
     }

}
