using Indigo99.Data;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Indigo99.BusinessServices
{
    public class RecommendationsService : IRecommendationsService
    {
       
        public RecommendationsService()
        {
           
        }

          

        
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> GetRandomSequence<T>(this IEnumerable<T> holder, int sampleSize)
        {
            var randomIndexList = new List<int>();
            var size = holder.Count();
            for (int i = 0; i <= size; i++)
            {
                var randomIndex = new Random();
                yield return holder.ElementAt(randomIndex.Next(1, size) - 1);
            }
        }
    }
}
