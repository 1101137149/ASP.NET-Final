﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using final_asp.net.Models;

namespace final_asp.net.Controllers
{
    public class ms_GridController : Controller
    {
        private DatabaseEntities_ms db = new DatabaseEntities_ms();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ms_data_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ms_data> ms_data = db.ms_data;
            DataSourceResult result = ms_data.ToDataSourceResult(request, c => new ms_data 
            {
                id = c.id,
                name = c.name,
                email = c.email,
                message = c.message,
                time = c.time
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ms_data_Create([DataSourceRequest]DataSourceRequest request, ms_data ms_data)
        {
            if (ModelState.IsValid)
            {
                var entity = new ms_data
                {
                    name = ms_data.name,
                    email = ms_data.email,
                    message = ms_data.message,
                    time = ms_data.time
                };

                db.ms_data.Add(entity);
                db.SaveChanges();
                ms_data.id = entity.id;
            }

            return Json(new[] { ms_data }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ms_data_Update([DataSourceRequest]DataSourceRequest request, ms_data ms_data)
        {
            if (ModelState.IsValid)
            {
                var entity = new ms_data
                {
                    id = ms_data.id,
                    name = ms_data.name,
                    email = ms_data.email,
                    message = ms_data.message,
                    time = ms_data.time
                };

                db.ms_data.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { ms_data }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ms_data_Destroy([DataSourceRequest]DataSourceRequest request, ms_data ms_data)
        {
            if (ModelState.IsValid)
            {
                var entity = new ms_data
                {
                    id = ms_data.id,
                    name = ms_data.name,
                    email = ms_data.email,
                    message = ms_data.message,
                    time = ms_data.time
                };

                db.ms_data.Attach(entity);
                db.ms_data.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { ms_data }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
