using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{

    public class CourseController : ApiController
    {
        private readonly ICourse course;

        public CourseController(ICourse course)
        {
            this.course = course;
        }

        public CourseController()
        {
            course = new CourseLogic();
        }

        [Route("Api/Course")]
        [HttpGet]
        public IHttpActionResult GetCourse()
        {
            //var courses = _course.GetAll();
            //return courses;

            List<Course> courses = course.GetAll().ToList();

            List<Course> modelCourseList = new List<Course>();

            foreach (Course item in courses)
            {
                modelCourseList.Add(new Course()
                {
                    ID = item.ID,
                    Code = item.Code,
                    Name = item.Name,
                    Description = item.Description,

                });
            }

            return Ok(modelCourseList);
        }

        [Route("api/Course/AddCourse")]
        [HttpPost]
        public Course Post(Course course)
        {
            using (MVCDbContext entities = new MVCDbContext())
            {
                entities.Courses.Add(course);
                entities.SaveChanges();

            }

            return course;
        }

        [Route("api/Course/EditCourse")]

        //[HttpPost]
        //// PUT: api/Course/5
        public void Put(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Course EditCourse = new Course
                    {
                        ID = course.ID,
                        Code = course.Code,
                        Name = course.Name,
                        Description = course.Description
                    };

                    this.course.Update(EditCourse);
                }
                catch
                {

                }
            }
        }

        // DELETE: api/Course/5

        [Route("api/Course/DeleteCourse")]
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                course.Delete(id);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}

