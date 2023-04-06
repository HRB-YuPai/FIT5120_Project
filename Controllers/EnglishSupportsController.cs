using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5120_Quality_Education_in_Australia_Iteration_01.Models;

namespace FIT5120_Quality_Education_in_Australia_Iteration_01.Controllers
{
    public class EnglishSupportsController : Controller
    {
        private FIT5120_Quality_Education_in_Australia_Iteration_01_dbEntities db = new FIT5120_Quality_Education_in_Australia_Iteration_01_dbEntities();

        public ActionResult Intro ()
        {
            return View();
        }

        // GET: EnglishSupports
        public ActionResult Index()
        {
            var institutions = db.EnglishSupports.ToList();
            var institutionsList = new List<EnglishSupportsVM>();
            foreach (var institution in institutions)
            {
                institutionsList.Add(new EnglishSupportsVM()
                {
                    Id = institution.Id,
                    InstitutionName = institution.InstitutionName,
                    Address = institution.Address,
                    Suburb = institution.Suburb,
                    DetailInformation = institution.DetailInformation,
                    Image = institution.Image,
                    OfficialWebsite = institution.OfficialWebsite,
                    Telephone = institution.Telephone
                });
            }
            return View(institutionsList);
        }

        // GET: EnglishSupports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishSupport englishSupport = db.EnglishSupports.Find(id);
            if (englishSupport == null)
            {
                return HttpNotFound();
            }
            return View(englishSupport);
        }

        // GET: EnglishSupports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishSupports/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InstitutionName,Address,Suburb,DetailInformation,Image,OfficialWebsite,Telephone")] EnglishSupport englishSupport)
        {
            if (ModelState.IsValid)
            {
                db.EnglishSupports.Add(englishSupport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishSupport);
        }

        // GET: EnglishSupports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishSupport englishSupport = db.EnglishSupports.Find(id);
            if (englishSupport == null)
            {
                return HttpNotFound();
            }
            return View(englishSupport);
        }

        // POST: EnglishSupports/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InstitutionName,Address,Suburb,DetailInformation,Image,OfficialWebsite,Telephone")] EnglishSupport englishSupport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishSupport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishSupport);
        }

        // GET: EnglishSupports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishSupport englishSupport = db.EnglishSupports.Find(id);
            if (englishSupport == null)
            {
                return HttpNotFound();
            }
            return View(englishSupport);
        }

        // POST: EnglishSupports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishSupport englishSupport = db.EnglishSupports.Find(id);
            db.EnglishSupports.Remove(englishSupport);
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
