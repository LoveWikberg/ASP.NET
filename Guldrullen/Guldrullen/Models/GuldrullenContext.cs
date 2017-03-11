using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace Guldrullen.Models.Entities
{
    public partial class GuldrullenContext : DbContext
    {
        public GuldrullenContext(DbContextOptions<GuldrullenContext> options) : base(options)
        {

        }

        public void AddMovie(MoviesCreateVM viewModel)
        {
            var movieToAdd = new Movie
            {
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                Length = viewModel.Length,
                //Review = viewModel.Review? //Visste inte om den skulle ligga här eller i ListMovies - Pascal
            };

            Movie.Add(movieToAdd);
            SaveChanges();
        }

        // Får ett exception i Modellvyn där det säger att "pipelinen inte leder någonstans". 
        // Är databasen kopplad till resten av funktionaliteten än?
        public MoviesIndexVM[] ListMovies()
        {
            Movie movie = new Movie();
            return Movie.Select(m => new MoviesIndexVM
            {
                Title = m.Title,
                Length = m.Length,
                Genre = m.Genre,
                Review = m.Review,
            }).OrderBy(m => m.Title).ToArray();
        }
    }
}