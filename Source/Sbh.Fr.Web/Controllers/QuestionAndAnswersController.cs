using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sbh.Fr.Model.DbCtx;
using Sbh.Fr.Model.View;

namespace Sbh.Fr.Web.Controllers
{
    public class QuestionAndAnswersController : Controller
    {
        private DbConn db = new DbConn();

        // GET: QuestionAndAnswers
        public ActionResult Index()
        {
            return View(db.QuestionAndAnswers.ToList());
        }

        // GET: QuestionAndAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAndAnswer questionAndAnswer = db.QuestionAndAnswers.Find(id);
            if (questionAndAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAndAnswer);
        }

        // GET: QuestionAndAnswers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionAndAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CATEGORY,ID_QUESTIONS,CATEGORY_DESC,ID_USER_QUESTIONS,QUESTIONS_NAME,QUESTIONS,ANSWER,ID_USER_ANSWER,ANSWER_NAME")] QuestionAndAnswer questionAndAnswer)
        {
            if (ModelState.IsValid)
            {
                db.QuestionAndAnswers.Add(questionAndAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionAndAnswer);
        }

        // GET: QuestionAndAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAndAnswer questionAndAnswer = db.QuestionAndAnswers.Find(id);
            if (questionAndAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAndAnswer);
        }

        // POST: QuestionAndAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CATEGORY,ID_QUESTIONS,CATEGORY_DESC,ID_USER_QUESTIONS,QUESTIONS_NAME,QUESTIONS,ANSWER,ID_USER_ANSWER,ANSWER_NAME")] QuestionAndAnswer questionAndAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionAndAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionAndAnswer);
        }

        // GET: QuestionAndAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAndAnswer questionAndAnswer = db.QuestionAndAnswers.Find(id);
            if (questionAndAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAndAnswer);
        }

        // POST: QuestionAndAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionAndAnswer questionAndAnswer = db.QuestionAndAnswers.Find(id);
            db.QuestionAndAnswers.Remove(questionAndAnswer);
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
