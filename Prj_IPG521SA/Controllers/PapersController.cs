using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prj_IPG521SA.Models;
using Microsoft.AspNet.Identity;
namespace Prj_IPG521SA.Controllers

{
    public class PapersController : Controller
    {
        private IPG521SAEntities db = new IPG521SAEntities();

        // GET: Papers
        public ActionResult Index()
        {
            string user = User.Identity.GetUserName();
            return View(db.Papers.Where(x=>x.PaperAuthor.Equals(user)).ToList());
        }

        // GET: Papers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // GET: Papers/Create
        public ActionResult Create()
        {
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "TopicName");
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperDateSubmitted,TopicID")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                paper.PaperAuthor = User.Identity.GetUserName();
                paper.PaperDateSubmitted = DateTime.Now;
                db.Papers.Add(paper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", paper.TopicID);
            return View(paper);
        }

        // GET: Papers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperDateSubmitted,TopicID")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paper);
        }

        // GET: Papers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paper paper = db.Papers.Find(id);
            db.Papers.Remove(paper);
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
