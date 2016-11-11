using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HCI_Project.Models;

namespace HCI_Project.Controllers
{
    public class IndividualController : Controller
    {
        List<Individual> individual;

        public IndividualController()
        {
            individual = new List<Individual>
            {
                new Individual() { id=0, firstname = "G", middlename = "Scott", lastname = "Madeira", cell = "4124180163", relationship = "dad", familyId = 0 },
                new Individual() { id=1, firstname="Jean" , middlename="E" , lastname="Madeira" , cell="4125551122" , relationship="mom" , familyId=0 },
                new Individual() { id=2, firstname="Nick" , middlename="A" , lastname="Madeira" , cell="4125559988" , relationship="son" , familyId=0 },
                new Individual() { id=3, firstname="John" , middlename="M" , lastname="Madeira" , cell="4125551234" , relationship="son" , familyId=0 },
                new Individual() { id=4, firstname="Chris" , middlename="T" , lastname="Madeira" , cell="4125556758" , relationship="son" , familyId=0 },
                new Individual() { id=5, firstname="Jimmy" , middlename="J" , lastname="Johns" , cell="6075556758" , relationship="dad" , familyId=1 },
                new Individual() { id=6, firstname="Stacey" , middlename="H" , lastname="Johns" , cell="6075556757" , relationship="mom" , familyId=1 },
                new Individual() { id=7, firstname="Ian" , middlename="F" , lastname="Johns" , cell="6075552257" , relationship="son" , familyId=1 },
                new Individual() { id=8, firstname="Avery" , middlename="K" , lastname="Johns" , cell="6075534757" , relationship="daughter" , familyId=1 },
                new Individual() { id=9, firstname="Roy" , middlename="F" , lastname="Ellis" , cell="9035534757" , relationship="dad" , familyId=2 },
                new Individual() { id=10, firstname="Michelle" , middlename="" , lastname="Ellis" , cell="9035531947" , relationship="mom" , familyId=2 },
                new Individual() { id=11, firstname="Bernie" , middlename="S" , lastname="Braddock" , cell="8145534757" , relationship="mom" , familyId=3 },
                new Individual() { id=12, firstname="Mark" , middlename="P" , lastname="Anderson" , cell="3025534757" , relationship="son" , familyId=3 }
            };

        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["individualList"] == null)
            {
                Session["individualList"] = individual;
            }
        }

        // GET: Person
        public ActionResult Index()
        {
            var p = (List<Individual>)Session["individualList"];
            return View(individual);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var pList = (List<Individual>)Session["individualList"];
            var p = pList[id];

            var i = individual[id];

            return View(i);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                Individual newIndividual = new Individual()
                {
                    id = 99,
                    firstname = collection["firstname"],
                    middlename = collection["middlename"],
                    lastname = collection["lastname"],
                    cell = collection["cell"],
                    relationship = collection["relationship"],
                    familyId = int.Parse(collection["familyId"]
                    )
                };

                // Add the person to the list
                individual = (List<Individual>)Session["individualList"];
                individual.Add(newIndividual);

                // Save the list to the session
                Session["individualList"] = individual;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}
   