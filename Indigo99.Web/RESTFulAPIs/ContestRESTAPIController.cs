using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace Indigo99.Web.RESTFulAPIs
{
    public class ContestRESTAPIController : ApiController
    {
       private readonly IContestEntryManagementService _contestEntryManagementService;
       private readonly ICustomerManagementService _customerManagementService;
       public ContestRESTAPIController(IContestEntryManagementService contestEntryManagementService,
                                                              ICustomerManagementService customerManagementService)
       {
           _contestEntryManagementService = contestEntryManagementService;
           _customerManagementService = customerManagementService;
           
       }

       public IHttpActionResult Enter(string email, int contestType)
       {
           if(!HttpContext.Current.Request.Files.AllKeys.Any())
               return new StatusCodeResult(HttpStatusCode.InternalServerError, this);

           var customer = _customerManagementService.GetCustomerByEmail(email);
           var newContestEntry = new ContestEntry();
           var file = HttpContext.Current.Request.Files[""];
           newContestEntry.ImageBytes = new byte[file.ContentLength];
           file.InputStream.Read(newContestEntry.ImageBytes, 0, file.ContentLength);
           newContestEntry.ContestantId = customer.Id.ToString();
           newContestEntry.ContestDate = DateTime.Now;
           newContestEntry.ContestType = null;
           return Ok();

       }

       public IEnumerable<ContestEntry> GetTodaysEntries()
       {
           var result = Enumerable.Empty<ContestEntry>();

           return result;

       }
    }
}
