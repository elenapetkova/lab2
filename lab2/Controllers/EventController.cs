using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    
        public class EventController : Controller
        {
            private static List<EventModel> events = new List<EventModel>();

            // GET: Event
            public ActionResult Index()
            {
                return View(events);
            }

            // GET: Event/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EventModel eventModel = events.FirstOrDefault(e => e.Id == id);
                if (eventModel == null)
                {
                    return HttpNotFound();
                }
                return View(eventModel);
            }
            [HttpPost]
            public ActionResult Update(EventModel model)
            {
                EventModel existingEvent = events.FirstOrDefault(e => e.Id == model.Id);
                if (existingEvent == null)
                {
                    return HttpNotFound();
                }
                existingEvent.Ime = model.Ime;
                existingEvent.Lokacija = model.Lokacija;
                return RedirectToAction("Details", new { id = existingEvent.Id });
            }

            // GET: Event/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Event/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(EventModel eventModel)
            {
                if (ModelState.IsValid)
                {
                    events.Add(eventModel);
                    return RedirectToAction("Index");
                }

                return View(eventModel);
            }

            // GET: Event/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EventModel eventModel = events.FirstOrDefault(e => e.Id == id);
                if (eventModel == null)
                {
                    return HttpNotFound();
                }
                return View(eventModel);
            }

            // POST: Event/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(EventModel eventModel)
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View(eventModel);
            }

            // GET: Event/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EventModel eventModel = events.FirstOrDefault(e => e.Id == id);
                if (eventModel == null)
                {
                    return HttpNotFound();
                }
                return View(eventModel);
            }

            // POST: Event/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                EventModel eventModel = events.FirstOrDefault(e => e.Id == id);
                events.Remove(eventModel);
                return RedirectToAction("Index");
            }
        }
    }
