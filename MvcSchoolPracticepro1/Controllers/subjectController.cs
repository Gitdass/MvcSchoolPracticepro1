using MvcSchoolPracticepro1.Models;
using SchoolMvspro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSchoolPracticepro1.Controllers
{





    public class subjectController : Controller
    {
        // GET: subject
        SchoolMvspro.SchoolDbEntities db = new SchoolDbEntities();


        public ActionResult Index()
        {

            List<Subject> subjects = db.Subjects.ToList();
            List<Submodel> sublist = new List<Submodel>();
            foreach (var item in subjects)
            {
                Submodel model = new Submodel();

                model.subid = item.SubId;
                model.subname = item.SubName;
                model.subdesc = item.SubDescription;
                sublist.Add(model);
            }


            return View(sublist);

        }

        // GET: subject/Details/5
        public ActionResult Details(int id)
        {
            Subject sj = db.Subjects.Find(id);
            Submodel model = new Submodel();

            model.subid = sj.SubId;
            model.subname = sj.SubName;
            model.subdesc = sj.SubDescription;

            return View(model);
        }

        // GET: subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Submodel model = new Submodel();
                model.subid = Convert.ToInt32(collection["subid"]);
                model.subname = collection["subname"].ToString();
                model.subdesc = collection["subdesc"].ToString();



                Subject sj = new Subject();
                sj.SubId = model.subid;
                sj.SubName = model.subname;
                sj.SubDescription = model.subdesc;

                db.Subjects.Add(sj);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

        // GET: subject/Edit/5
        public ActionResult Edit(int id)
        {
            Subject sj = db.Subjects.Find(id);
            Submodel model = new Submodel();

            model.subid = sj.SubId;
            model.subname = sj.SubName;
            model.subdesc = sj.SubDescription;

            return View(model);
        }

        // POST: subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Subject sj = db.Subjects.Find(id);

                sj.SubName = collection["subname"].ToString();
                sj.SubDescription = collection["subdesc"].ToString();
                db.SaveChanges();


                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: subject/Delete/5
        public ActionResult Delete(int id)
        {
            Subject S = db.Subjects.Find(id);
            Submodel model = new Submodel();
            model.subname = S.SubName;
            model.subdesc = S.SubDescription;

            return View(model);
        }

        // POST: subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Subject S = db.Subjects.Find(id);
                db.Subjects.Remove(S);
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
