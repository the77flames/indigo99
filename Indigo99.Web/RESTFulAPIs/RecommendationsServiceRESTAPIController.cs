using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Indigo99.Web.RESTFulAPIs
{
    public class RecommendationsServiceRESTAPIController : ApiController
    {
       private readonly IRecommendationsService _recommendationsService;
       public RecommendationsServiceRESTAPIController(IRecommendationsService recommendationsService)
       {
           _recommendationsService = recommendationsService;
           
       }

    }
}
