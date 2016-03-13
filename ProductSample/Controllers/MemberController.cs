﻿using ProductSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductSample.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        [AllowAnonymous]
        // GET: Member
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (CheckLogin(model.Email, model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.Email, false);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤");

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private bool CheckLogin(string username, string password)
        {
            return (
                username == "alisonfish@kimo.com" &&
                password == "123"
                );
        }
    }
}