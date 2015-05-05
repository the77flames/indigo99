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
    public class CommentsRESTAPIController : ApiController
    {
       private readonly ICommentEntryManagementService _commentEntryManagementService;
       private readonly ICustomerManagementService _customerManagementService;
       public CommentsRESTAPIController(ICommentEntryManagementService commentEntryManagementService,
                                                              ICustomerManagementService customerManagementService)
       {
           _commentEntryManagementService = commentEntryManagementService;
           _customerManagementService = customerManagementService;
           
       }

       public IHttpActionResult Post(string email, int contestType, string comment)
       {
           var customer = _customerManagementService.GetCustomerByEmail(email);
           var newCommentEntry = new CommentEntry();
           newCommentEntry.CommenterId = customer.Id.ToString();
           newCommentEntry.ContestDate = DateTime.Now;
           newCommentEntry.ContestType = contestType;
           newCommentEntry.CommentString = comment;
           return Ok();

       }

       public IEnumerable<CommentEntry> GetTodaysComments(int contestType)
       {
           var date = DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-1);
           var result = _commentEntryManagementService.GetAllByDateAndType(date, contestType);

           return result ?? Enumerable.Empty<CommentEntry>();

       }
    }
}
