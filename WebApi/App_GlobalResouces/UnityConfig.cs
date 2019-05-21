using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.GenericRespository;
using DataAccess.Models;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<ICourse, CourseLogic>();
            container.RegisterType<IGenericRepository<Course>, GenericRepository<Course>>();
        }
    }
}