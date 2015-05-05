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
    public class PastWinnersRESTAPIController : ApiController
    {
       private readonly IContestEntryManagementService _contestEntryManagementService;
       private readonly ICustomerManagementService _customerManagementService;
       public PastWinnersRESTAPIController(IContestEntryManagementService contestEntryManagementService,
                                                              ICustomerManagementService customerManagementService)
       {
           _contestEntryManagementService = contestEntryManagementService;
           _customerManagementService = customerManagementService;
           
       }


       public IEnumerable<ContestEntry> GetAllWinners(int count = 20)
       {
          
           var result = _contestEntryManagementService.GetAllWinners(count);
           return result ?? Enumerable.Empty<ContestEntry>();

       }
    }
}
