using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FptAptechEdu.Models;

namespace FptAptechEdu.Controllers
{
    public class Student_CourseController : Controller
    {
        private MyConnection db = new MyConnection();

        // GET: Student_Course
        public ActionResult Index()
        {
            var student_Course = db.Student_Course.Include(s => s.Course).Include(s => s.Student);
            return View(student_Course.ToList());
        }

        // GET: Student_Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // GET: Student_Course/Create
        public ActionResult Create()
        {
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "CourseTitle");
            ViewBag.ID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: Student_Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollID,GRADE,ID,courseID")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                db.Student_Course.Add(student_Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseID = new SelectList(db.Courses, "courseID", "CourseTitle", student_Course.courseID);
            ViewBag.ID = new SelectList(db.Students, "ID", "LastName", student_Course.ID);
            return View(student_Course);
        }

        // GET: Student_Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "CourseTitle", student_Course.courseID);
            ViewBag.ID = new SelectList(db.Students, "ID", "LastName", student_Course.ID);
            return View(student_Course);
        }

        // POST: Student_Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollID,GRADE,ID,courseID")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "CourseTitle", student_Course.courseID);
            ViewBag.ID = new SelectList(db.Students, "ID", "LastName", student_Course.ID);
            return View(student_Course);
        }

        // GET: Student_Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // POST: Student_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Course student_Course = db.Student_Course.Find(id);
            db.Student_Course.Remove(student_Course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
