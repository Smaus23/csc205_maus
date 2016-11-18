using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HCI_Project.Models;
using System.Diagnostics;

namespace HCI_Project.Controllers
{
    public class FamilyController : Controller
    {
            List<Family> families;

            public FamilyController()
            {
                families = new List<Family>
            {
                new Family() { id=0, familyname = "Madeira", address1 = "123 Hastings Dr", city = "Cranberry Township", state = "PA", zip = "16066", homephone = "7247797964" },
                new Family() { id=1, familyname = "Johns", address1 = "3200 College Ave", city = "Beaver Falls", state = "PA", zip = "15010", homephone = "7248461298" },
                new Family() { id=2, familyname = "Ellis", address1 = "1 Sycamore Hollow", city = "Pittsburgh", state = "PA", zip = "15212", homephone = "4122371212" },
                new Family() { id=3, familyname = "Braddock", address1 = "23 Livingstone Dr", city = "Monroeville", state = "PA", zip = "15010", homephone = "4123277486" }
            };


            }

        protected override void Initialize (RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["familyList"] == null)
            {
                Session["familyList"] = families;
            }
        }

        // GET: Family
        public ActionResult Index()
            {
            var families = (List<Family>)Session["familyList"];
            return View(families);
            }

            // GET: Family/Details/5
            public ActionResult Details(int id)
            {
            var families = (List<Family>)Session["familyList"];
            var f = families[id];
            return View(f);
            }

        // GET: Family/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Family/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {  
                Family newFamily = new Family()
                {
                    id = families.Count,
                    familyname = collection["familyname"],
                    address1 = collection["address1"],
                    city = collection["city"],
                    state = collection["state"],
                    zip = collection["zip"],
                    homephone = collection["homephone"]
                };

                var f = (List<Family>)Session["familyList"];
                f.Add(newFamily);
                // Save the list to the session
                Session["familyList"] = f;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Edit/5
        public ActionResult Edit(int id)
        {
            var f = families[id];

            return View(f);
        }

        // POST: Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var families = (List<Family>)Session["familyList"];
                var f = families[id];

                Family newFamily = new Family()
                {
                    id = families.Count,
                    familyname = collection["familyname"],
                    address1 = collection["address1"],
                    city = collection["city"],
                    state = collection["state"],
                    zip = collection["zip"],
                    homephone = collection["homephone"]
                };

                families.Where(x => x.id == id).First().familyname = collection["familyname"];
                families.Where(x => x.id == id).First().address1 = collection["address1"];
                families.Where(x => x.id == id).First().city = collection["city"];
                families.Where(x => x.id == id).First().state = collection["state"];
                families.Where(x => x.id == id).First().zip = collection["zip"];
                families.Where(x => x.id == id).First().homephone = collection["homephone"];


                for (int x = id; x < families.Count(); x++)
                {
                    if (families[x] != null)
                        families[x].id = x;
                }

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Delete/5
        public ActionResult Delete(int id)
        {
            var f = families[id];
            return View(f);
        }

        // POST: Family/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var families = (List<Family>)Session["familyList"];
                var f = families[id];
                families.Remove(f);
                // Save the list to the session
                Session["familyList"] = families;

                for (int x = id; x < families.Count(); x++)
                {
                    if (families[x] != null)
                        families[x].id = x;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
