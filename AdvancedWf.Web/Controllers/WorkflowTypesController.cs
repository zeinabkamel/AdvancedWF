using AdvancedWf.Data.Repositories;
using AdvancedWf.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedWf.Web.Controllers
{
    public class WorkflowTypesController : BaseController
    {
        private readonly IWorkflowtypesService _workflowtypesService;
     

        public WorkflowTypesController(IWorkflowtypesService workflowtypesService)
        {
            this._workflowtypesService = workflowtypesService;
    
        }

        // GET: WorkflowTypes
        public ActionResult Index()
        {
            return View();
        }
        public string GetList()
        {
            try
            {
               
                    var param = GetDatatableParamsFromRequest();
                    var result = _workflowtypesService.GetList(param);
                    return result;


            }
            catch (Exception e)
            {
                new ErrorLogsRepository().AddErrorLog(Request, null, e);
            }
            return string.Empty;
        }
        // GET: WorkflowTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkflowTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkflowTypes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkflowTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkflowTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkflowTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkflowTypes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
