using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Indigo99.Web.RESTFulAPIs
{
    public class VotingRESTAPIController : ApiController
    {
       private readonly ContestEntryManagementService _contestEntryMgmtService;

       public VotingRESTAPIController(ContestEntryManagementService contestEntryMgmtService)
       {
           _contestEntryMgmtService = contestEntryMgmtService;
           
       }

        [IndigoAuthorize]
        public bool Vote(string id)
        {            
            var contestEntry = _contestEntryMgmtService.GetById(id);
            contestEntry.TotalVotes += 1;
            _contestEntryMgmtService.Update(contestEntry);
            return true;
        }


    }
}
