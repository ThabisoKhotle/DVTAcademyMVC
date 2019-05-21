using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.GenericRespository;
using DataAccess.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace DVTAcademyMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICourse, CourseLogic>();
            container.RegisterType<IGenericRepository<Course>, GenericRepository<Course>>();
            container.RegisterType<ITraining, TrainingLogic>();
            container.RegisterType<IGenericRepository<Training>, GenericRepository<Training>>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}