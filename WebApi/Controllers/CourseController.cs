using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
   
    public class CourseController : ApiController
    {
        private readonly ICourse _course ;

        public CourseController(ICourse course)
        {
            this._course = course;
        }

        public CourseController()
        {
            _course = new CourseLogic();
        }

        [Route("Api/Course/GetAllCourses")]
        [HttpGet]
        public IEnumerable<Course> GetCourse()
        {
            var courses = _course.GetAll();
            return courses;
        }


      
        [Route("Api/Course/UpdateCourse")]
        [HttpPut]
        public IHttpActionResult UpdateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _course.Update(course);
                return Ok(course.Name + "Updated Successfully");
            }
            else
            {
                return Ok("Could not UpdateCourse" + course.ID);
            }
        }
        
        //public IHttpActionResult Post([FromBody]Course item)
        //{
        //    try
        //    {
        //        _course.Insert(new Course
        //        {
        //            ID = item.ID,
        //            Code = item.Code,
        //            Description = item.Description,
        //            Name = item.Name
        //        });
        //        _course.Save();
        //        return Ok(item);
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
        //}

        [Route("Api/Course/FindCourseByID")]
        [HttpGet]
        public IHttpActionResult FindCourseByID(int ID)
        {
            try
            {
                Course course = _course.GetByID(ID);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return Ok("Course Not found!");
            }
        }
        //public async Task<IHttpActionResult<Course>> FindCourseByID(int ID)
        //{
        //    var course = await _course.GetByID(ID);
        //    if (course == null)
        //    {
        //        return Ok("Course Not Found");
        //    }
        //    return course;
        //    //try
        //    //{
        //    //    Course course = await _course.GetByID.ExecuteAsync(ID);

        //    //    return Ok(course);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return Ok("Course Not found!");
        //    //}
        //}



        [Route("Api/Course/DeleteCourse")]
        [HttpDelete]
        public IHttpActionResult DeleteCourse(int ID)
        {
            try
            {
                _course.Delete(ID);
                _course.Save();
                return Ok();
            }
            catch
            {
                return Ok();
            }

        }


    }

}
