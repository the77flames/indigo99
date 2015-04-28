using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Indigo99.Web.Admin.Controllers
{
    public class ContestEntryController : Controller
    {
        //
        // GET: /contestEntry/

        private readonly ContestEntryManagementService _contestEntryMgmtService;
        public ContestEntryController(ContestEntryManagementService contestEntryMgmtService)
        {
            _contestEntryMgmtService = contestEntryMgmtService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            var contestEntries = _contestEntryMgmtService.GetAll();
            return View(contestEntries);
        }
        
        [HttpPost]
        public ActionResult Add(ContestEntry contestEntry)
        {
            _contestEntryMgmtService.Add(contestEntry);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {            
            var contestEntry = _contestEntryMgmtService.GetById(id);
            contestEntry.IdString = id.ToString();
            return View("EditcontestEntry", contestEntry);
        }

        [HttpPost]
        public ActionResult Edit(ContestEntry contestEntry)
        {          
            _contestEntryMgmtService.Update(contestEntry);
            return RedirectToAction("Index");
        }
    }
}
