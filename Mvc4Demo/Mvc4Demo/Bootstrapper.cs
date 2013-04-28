using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Mvc4Demo.Services;
using Mvc4Demo.Controllers;

namespace Mvc4Demo
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();   
      container.RegisterType<ICategoriesServices, CategoriesServices>();
      container.RegisterType<IController, CategoriesController>("Categories");
      container.RegisterType<IController, KendoCategoriesController>("Categories"); 

      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}