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
    public class TraditionalFestivalsController : Controller
    {
        private FIT5120_Quality_Education_in_Australia_Iteration_01_dbEntities db = new FIT5120_Quality_Education_in_Australia_Iteration_01_dbEntities();

        public ActionResult Intro()
        {
            var festivals = db.TraditionalFestivals.ToList();
            var festivalsList = new List<TraditionalFestivalsVM>();
            foreach (var festival in festivals)
            {
                festivalsList.Add(new TraditionalFestivalsVM()
                {
                    Id = festival.Id,
                    Name = festival.Name,
                    ShortInfo = festival.ShortInfo,
                    DetailInformation = festival.DetailInformation,
                    Image01 = festival.Image01,
                    Image02 = festival.Image02,
                    Date = festival.Date
                });
            }
            return View(festivalsList);
        }

        // GET: TraditionalFestivals
        public ActionResult Index()
        {
            return View(db.TraditionalFestivals.ToList());
        }

        // GET: TraditionalFestivals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraditionalFestival traditionalFestival = db.TraditionalFestivals.Find(id);
            if (traditionalFestival == null)
            {
                return HttpNotFound();
            }
            return View(traditionalFestival);
        }

        // GET: TraditionalFestivals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TraditionalFestivals/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortInfo,DetailInformation,Image01,Image02,Date")] TraditionalFestival traditionalFestival)
        {
            if (ModelState.IsValid)
            {
                db.TraditionalFestivals.Add(traditionalFestival);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traditionalFestival);
        }

        // GET: TraditionalFestivals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraditionalFestival traditionalFestival = db.TraditionalFestivals.Find(id);
            if (traditionalFestival == null)
            {
                return HttpNotFound();
            }
            return View(traditionalFestival);
        }

        // POST: TraditionalFestivals/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortInfo,DetailInformation,Image01,Image02,Date")] TraditionalFestival traditionalFestival)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traditionalFestival).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traditionalFestival);
        }

        // GET: TraditionalFestivals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraditionalFestival traditionalFestival = db.TraditionalFestivals.Find(id);
            if (traditionalFestival == null)
            {
                return HttpNotFound();
            }
            return View(traditionalFestival);
        }

        // POST: TraditionalFestivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraditionalFestival traditionalFestival = db.TraditionalFestivals.Find(id);
            db.TraditionalFestivals.Remove(traditionalFestival);
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
