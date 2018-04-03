﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SL.Cross;

namespace SL.Controllers
{
    public class MasterRaceController : Controller
    {
        DAL.nubebfsEntities db = new DAL.nubebfsEntities();
        // GET: MasterRace
        public ActionResult Index()
        {
            return View();
        }

        [NubeCrossSiteAttribute]
        public JsonResult ToList(string term)
        {
            var l1 = db.MASTERRACEs.OrderBy(x => x.RACE_NAME).ToList();
            if (!string.IsNullOrWhiteSpace(term))
            {
                l1 = l1.Where(x => x.RACE_NAME.ToLower().Contains(term.ToLower())).ToList();
            }
            return Json(l1, JsonRequestBehavior.AllowGet);
        }
    }
}