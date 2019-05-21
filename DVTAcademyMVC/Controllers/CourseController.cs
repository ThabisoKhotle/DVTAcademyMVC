using BusinessLogic.Abstract;
using DataAccess.GenericRespository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DataAccess.Context;
using Newtonsoft.Json;

namespace DVTAcademyMVC.Controllers
{

    public class CourseController : Controller
    {
        private IGenericRepository<Course> CourseRepository = null;

        //private MVCDbContext db = new MVCDbContext();

        public CourseController()
        {
            this.CourseRepository = new GenericRepository<Course>();
        }
        
        private readonly ICourse _course;
        public CourseController(ICourse course)
        {
            this._course = course;
        }
        

        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var course = _course.GetAll().ToList();
            PagedList<Course> coursemodel = new PagedList<Course>(course, page, pagesize);
            return View(coursemodel);
        }

        //public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        //{
        //    ViewBag.CurrentSort = sortOrder;
        //    //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }
        //    ViewBag.currentFilter = searchString;

        //    var course = from c in db.Courses
        //                 select c;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        course = course.Where(c => c.Name.Contains(searchString) || c.Code.Contains(searchString));
        //    }

        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            course = course.OrderByDescending(c => c.Name);
        //            break;
        //        default:
        //            course = course.OrderBy(s => s.Code);
        //            break;
        //    }
        //    int pageSize = 3;
        //    int pageNumber = (page ?? 1);
        //    return View(course.ToPagedList(pageNumber, pageSize));

        //    //return View(db.Courses.OrderBy(i => i.Name).ToPagedList(pageNumber, pageSize));
        //}

        //public ViewResult Index1(string searchString)
        //{
        //    var course = from c in db.Courses
        //                 select c;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        course = course.Where(c => c.Name == searchString);
        //    }
        //    return View(course.ToList());
        //}

        //public JsonResult GetCourseList()
        //{
        //    List<Course> CourseList = db.Courses.Where(x => x.IsDeleted==false).Select(x => new Course()
        //    {
        //        ID = x.ID,
        //        Code = x.Code,
        //        Name = x.Name,
        //        Description = x.Description
        //    }).ToList();

        //    return Json(CourseList, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult GetCourseByID(int ID)
        {
            Course coursemodel = CourseRepository.GetByID(ID);
            //    return View(course)
            //Course coursemodel = db.Courses.Where(x => x.ID == ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(coursemodel, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult InsertCourse(Course obj)
        {
            return View(obj);

        }

        [HttpPost]
        public ActionResult InsertCourse(Course item, FormCollection formCollection)
        {
            try
            {
                _course.Insert(new Course { ID = item.ID, Code = item.Code, Name = item.Name, Description = item.Description });
                _course.Save();
                return RedirectToAction("Index", "Course");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteCourse(Course obj)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course item, FormCollection formCollection)
        {
            var courseId = formCollection["ID"];
            try
            {
                _course.Delete(item.ID);
                return RedirectToAction("Index", "Course");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult UpdateCourse(Course item, FormCollection formCollection)
        {


            try
            {

                _course.Update(new Course { ID = item.ID, Code = item.Code, Description = item.Description, Name = item.Name });
                _course.Save();
                return RedirectToAction("Index", "Course");

            }
            catch
            {

                return View();

            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            return View();
        }
    }
}
