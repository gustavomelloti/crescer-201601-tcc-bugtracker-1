﻿using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(UserSessionService.IsLogged)
                return View();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult SignIn()
        {

            return RedirectToAction("Index");
        }
    }
}