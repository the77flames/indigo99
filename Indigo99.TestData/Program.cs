using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.TestData
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new RepositoryData();

            Clear(app);

            app.AddMovies();
            app.AddEvent();
            app.AddLounge();
            app.AddNews();

            Console.WriteLine("Done!!!!");
            Console.ReadLine();
        }

        static void Clear(RepositoryData app)
        {
            app.DeleteEvent();
            app.DeleteLounge();
            app.DeleteMovies();
            app.DeleteNews();
        }
    }
}
