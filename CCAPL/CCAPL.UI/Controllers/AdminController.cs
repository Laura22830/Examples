﻿using CCAPL.Data.ADO;
using CCAPL.Models.Tables;
using CCAPL.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCAPL.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddMember(Members member)
        {
            var repo = new MembersRepository();
            var model = new AddEditMembersViewModel();
            model.Member = new Members();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddMember(AddEditMembersViewModel model)
        {
            var repo = new MembersRepository();

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Create(model.Member);

                    return RedirectToAction("Members", "Admin");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            model.Member = repo.GetById(model.Member.MemberId);
            return View(model);

        }

        public ActionResult EditMember(int id)
        {
            var repo = new MembersRepository();
            var model = new AddEditMembersViewModel();
            model.Member = repo.GetById(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult EditMember(AddEditMembersViewModel model)
        {
            var repo = new MembersRepository();

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Edit(model.Member);

                    return RedirectToAction("Members", "Admin");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            model.Member = repo.GetById(model.Member.MemberId);
            return View(model);

        }

        public ActionResult Members()
        {
            var repo = new MembersRepository();
            var model = repo.GetAll();

            return View(model);
        }
    }
}