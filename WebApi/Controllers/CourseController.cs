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
        private readonly ICourse _course = null;

        public CourseController(ICourse course)
        {
            this._course = course;
        }

        public CourseController()
        {
            _course = new CourseLogic();
        }

        [Route("Api/Course")]
        [HttpGet]
        public IHttpActionResult GetCourse()
        {
            //var courses = _course.GetAll();
            //return courses;

            List<Course> courses = _course.GetAll().ToList();

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

                    this._course.Update(EditCourse);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        [Route("Api/Course/FindCourseByID")]
        [HttpGet]
        public IHttpActionResult FindCourseByID(int ID)
        {
            try
            {
                Course course = _course.GetByID(ID);
                var courses = new Course()
                {
                    ID = course.ID,
                    Code = course.Code,
                    Name = course.Name,
                    Description = course.Description
                };
                return Ok(course);
            }
            catch (Exception ex)
            {
                return Ok("Course Not found!");
            }
        }
        // DELETE: api/Course/5

        [Route("api/Course/DeleteCourse")]
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                _course.Delete(id);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}

