using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.DomainObjects
{
    public class ContestEntryVector : ContestEntry
    {
        public double RecentlyFeaturedScore { get; set; }
        public double RatingsScore { get; set; }
        public double PopularScore { get; set; }

        public double ComputeAggregatedScore()
        {
            return RatingsScore * 10 + RecentlyFeaturedScore * 20 + PopularScore * 5;
        }
    }
}
