﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookOcean.Repository.Abstract;
using BookOcean.Domain;

namespace BookOcean.Web.Controllers
{
    public class StandardController : Controller
    {
        #region  Private Variables
        private IStandard _standard;
        #endregion

        #region
        public StandardController(IStandard standard)
        {
            this._standard = standard;
        }

        #endregion
        // GET: Standard
        public ActionResult Index()
        {
            return View(_standard.GetAllStandards());
        }

        public ActionResult Standard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Standard(Standard model)
        {
            _standard.AddStandard(model);
            return View();
        }

    }
}