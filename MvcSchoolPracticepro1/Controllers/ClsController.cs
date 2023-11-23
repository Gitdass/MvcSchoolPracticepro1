using MvcSchoolPracticepro1.Models;
using SchoolMvspro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSchoolPracticepro1.Controllers
{
    public class ClsController : Controller
    {
        // GET: Cls

        SchoolMvspro.SchoolDbEntities db = new SchoolDbEntities();

        public ActionResult Index()

        {

            List<ClassTable> Clss = db.ClassTables.ToList();
            List<Clsmodel> clslist = new List<Clsmodel>();
            foreach (var item in Clss)
            {
                Clsmodel model = new Clsmodel();

                model.clsid = item.Classid;
                model.Section = item.Section;
                model.TeacherName = item.Teachername;
                model.Totalstudents = (int)item.TotalStudents;


                clslist.Add(model);
            }


            return View(clslist);


        }

        // GET: Cls/Details/5
        public ActionResult Details(int id)
        {



            ClassTable sj = db.ClassTables.Find(id);
            Clsmodel model = new Clsmodel();

            model.clsid = sj.Classid;
            model.Section = sj.Section;
            model.TeacherName = sj.Teachername;
            model.Totalstudents = (int)sj.TotalStudents;

            return View(model);
        }

        // GET: Cls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cls/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Clsmodel model = new Clsmodel();
                model.clsid = Convert.ToInt32(collection["clsid"]);
                model.Section = collection["Section"].ToString();
                model.TeacherName = collection["TeacherName"].ToString();
                model.Totalstudents = Convert.ToInt32(collection["Totalstudents"]);


                ClassTable sj = new ClassTable();
                sj.Classid = model.clsid;
                sj.Section = model.Section;
                sj.Teachername = model.TeacherName;
                sj.TotalStudents = model.Totalstudents;

                db.ClassTables.Add(sj);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

        // GET: Cls/Edit/5
        public ActionResult Edit(int id)
        {
            ClassTable sj = db.ClassTables.Find(id);
            Clsmodel model = new Clsmodel();

            model.clsid = sj.Classid;
            model.Section = sj.Section;
            model.TeacherName = sj.Teachername;
            model.Totalstudents = (int)sj.TotalStudents;

            return View(model);

        }

        // POST: Cls/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ClassTable sj = db.ClassTables.Find(id);

                sj.Section = collection["Section"].ToString();
                sj.Teachername = collection["TeacherName"].ToString();
                sj.TotalStudents = Convert.ToInt32(collection["Totalstudents"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cls/Delete/5
        public ActionResult Delete(int id)
        {
            ClassTable sj = db.ClassTables.Find(id);
            Clsmodel model = new Clsmodel();
            model.Section = sj.Section;
            model.TeacherName = sj.Teachername;
            model.Totalstudents = Convert.ToInt32(sj.TotalStudents);
            return View(model);
        }

        // POST: Cls/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ClassTable sj = db.ClassTables.Find(id);
                db.ClassTables.Remove(sj);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
