using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ProjectConakry.Data;
using ProjectConakry.DomainObjects;

namespace ProjectConakry.TestData
{
    public class RepositoryData
    {
        private MovieRepository _movieRepository;
        private NewsRepository _newsRepository;
        private LoungeItemRepository _loungeRepository;
        private EventRepository _eventRepository;

        private List<Movie> movielist;

        public RepositoryData()
        {
            this._movieRepository = new MovieRepository();
            this._newsRepository = new NewsRepository();
            this._eventRepository = new EventRepository();
            this._loungeRepository= new LoungeItemRepository();

            this.movielist = new List<Movie>();
        }

        public void AddMovies()
        {
            var list = Enum.GetValues(typeof(Sections));
            int k = 1;
            foreach (Sections item in list)
            {
                for (int i = 0; i < 25; i++)
                {
                    var movie = new Movie()
                    {
                        Name = "Batman " + (i + k * 24), 
                        Artists = new List<Artist>(), 
                        SectionId = item,
                        ThumbNailImagePath = ((i % 12) + 1) + ".jpg"
                    };
                    this._movieRepository.Create(movie);
                }
            }
        }

        public void DeleteMovies()
        {
            var movies = this._movieRepository.GetAll();
            foreach (var movie in movies)
            {
                this._movieRepository.Delete(movie.Id.ToString());
            }            
        }

        //public void AddRecommendations()
        //{
        //    var list = Enum.GetValues(typeof(Sections));

        //    foreach (Sections item in list)
        //    {
        //        for (int i = 0; i < 24; i++)
        //        {
        //            var recommendation = new Media()
        //            {
        //                Name = "Recommendation" + i,
        //                // Artists = new List<Artist>(),
        //                SectionId = item,
        //                ThumbNailImagePath = ((i % 12) + 1) + ".jpg"
        //            };
        //            _recommendationRepository.Create(recommendation);
        //        }
        //    }
        //}

        //public void DeleteRecommendations()
        //{
        //    var recommendations = _recommendationRepository.GetAll();
        //    foreach (var recommendation in recommendations)
        //    {
        //        _recommendationRepository.Delete(recommendation.Id.ToString());
        //    }
        //}

        private string[] ReadFile(string fileName)
        {
            const string filePath = @"..\..\Files";
            var data = File.ReadAllLines(Path.Combine(filePath, fileName));
            return data.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        }

        public void AddNews()
        {
            var lines = this.ReadFile("news.html");
            for (int i = 0; i < lines.Length; i++)
            {
                var news = new News()
                {
                    Caption = "News " + i,
                    CreatedDate = DateTime.Now,
                    ExpireDate = DateTime.Today.AddYears(1),
                    ImagePath = ((i % 12) + 1) + ".jpg",
                    Text = lines[i]
                };
                this._newsRepository.Create(news);
            }
        }

        public void DeleteNews()
        {
            var list = this._newsRepository.GetAll();
            foreach (var news in list)
            {
                this._newsRepository.Delete(news.Id.ToString());
            }
        }

        public void AddLounge()
        {
            var lines = this.ReadFile("lounge.html");
            for (int i = 0; i < lines.Length; i++)
            {
                var lounge = new LoungeItem()
                {
                    Caption = "Lounge " + i,
                    CreatedDate = DateTime.Now,
                    ExpireDate = DateTime.Today.AddYears(1),
                    ImagePath = ((i % 12) + 1) + ".jpg",
                    Text = lines[i]
                };
                this._loungeRepository.Create(lounge);
            }
        }

        public void DeleteLounge()
        {
            var list = this._loungeRepository.GetAll();
            foreach (var news in list)
            {
                this._loungeRepository.Delete(news.Id.ToString());
            }
        }

        public void AddEvent()
        {
            for (int i = 0; i < 20; i++)
            {
                var @event = new Events()
                {
                    EventName = "PSquare Live " + i,
                    EventDate = DateTime.Today.AddDays(i * 5),
                    Time = DateTime.MinValue.AddHours(10).ToString("HH:mm"),
                    Venue = "Muson",
                    ImageThumbNailPath = ((i % 12) + 1) + ".jpg",
                    TicketPrice = 10.ToString("c")
                };
                this._eventRepository.Create(@event);
            }
        }

        public void DeleteEvent()
        {
            var list = this._eventRepository.GetAll();
            foreach (var item in list)
            {
                this._eventRepository.Delete(item.Id.ToString());
            }
        }
    }
}
