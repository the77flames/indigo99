using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Indigo99.Web.RESTFulAPIs
{
    public class VotingRESTAPIController : ApiController
    {
       private readonly IContestEntryManagementService _contestEntryMgmtService;
       private readonly ICommentEntryManagementService _commentEntryMgmtService;

       public VotingRESTAPIController(IContestEntryManagementService contestEntryMgmtService,
           ICommentEntryManagementService commentEntryMgmtService)
       {
           _contestEntryMgmtService = contestEntryMgmtService;
           _commentEntryMgmtService = commentEntryMgmtService;
           
       }

        [IndigoAuthorize]
        public bool Vote(string id)
        {            
            var contestEntry = _contestEntryMgmtService.GetById(id);
            contestEntry.TotalVotes += 1;
            _contestEntryMgmtService.Update(contestEntry);
            return true;
        }

        public bool UpVoteComment(string id)
        {
            var commentEntry = _commentEntryMgmtService.GetById(id);
            commentEntry.TotalUpVotes += 1;
            _commentEntryMgmtService.Update(commentEntry);
            return true;
        }

        public bool DownVoteComment(string id)
        {
            var commentEntry = _commentEntryMgmtService.GetById(id);
            commentEntry.TotalDownVotes -= 1;
            _commentEntryMgmtService.Update(commentEntry);
            return true;
        }


    }
}
