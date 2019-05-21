using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVTAcademyMVC.Controllers
{
    public class UploadController : Controller
    {


        //public ActionResult Upload()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase upload)
        //{
        //    if (upload != null && upload.ContentLength > 0)
        //    {
        //        if (upload.FileName.EndsWith(".csv"))
        //        {
        //            Stream stream = upload.InputStream;
        //            DataTable csvDataTable = new DataTable();
        //            using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true))
        //            {
        //                csvDataTable.Load(csvReader);
        //            }
        //            return View(csvDataTable);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("File", "This Format is not supported");
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("File", "Please upload your file first");
        //    }

        //    return View();
        //}

        //public ActionResult ExportData(HttpPostedFileBase export)
        //{
        //    if (export != null && export.ContentLength > 0)
        //    {
        //        if (export.FileName.EndsWith(".csv"))
        //        {
        //        }
        //    }
        //}
    }
}