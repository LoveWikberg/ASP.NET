using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

namespace Guldrullen.Models.Entities
{
    public partial class GuldrullenContext : DbContext
    {
        public GuldrullenContext(DbContextOptions<GuldrullenContext> options) : base(options)
        {

        }

        public MovieShowVM[] ListMovies(string title)
        {
            var ret = Movie
                .Select(m => new MovieShowVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    Length = m.Length,
                })
            .Where(m => m.Title.Contains(title))
            .OrderBy(m => m.Title)
            .ToArray();

            foreach (var movie in ret)
            {
                var ratings = this.Review
                    .Where(o => o.MovieId == movie.Id)
                    .Select(o => o.Rate)
                    .ToArray();

                if (ratings.Length > 0)
                {
                    movie.Rate = ratings
                          .Average();

                    if (movie.Rate.ToString().Length > 2)
                        movie.Rate = Math.Round(movie.Rate, 1);
                }
            }
            return ret;
        }


        public void AddMovie(MovieCreateVM viewModel)
        {
            var movieToAdd = new Movie
            {
                Title = viewModel.Title,
                Length = viewModel.Length,
                Genre = viewModel.Genre,
            };

            Movie.Add(movieToAdd);
            SaveChanges();
        }

        public void AddReview(ReviewCreateVM viewModel, int id)
        {
            var movie = Movie.SingleOrDefault(c => c.Id == id);

            var reviewToAdd = new Review
            {
                Title = viewModel.Title,
                Text = viewModel.Text,
                Rate = viewModel.Rate,
                MovieId = movie.Id,
            };


            Review.Add(reviewToAdd);
            SaveChanges();
        }

        public MovieInfoVM[] ListReviews(int id)
        {
            //var movieTitle = Movie.SingleOrDefault(m => m.Id == id).Title;
            var reviews = Review
                .Where(c => c.MovieId == id)
                .Select(m => new MovieInfoVM
                {
                    ReviewTitle = m.Title,
                    Text = m.Text,
                    Rate = m.Rate,
                    Id = m.Id,
                    // Movie = movieTitle,
                }).ToArray();


            return reviews;

        }

        internal MovieShowVM GetMovieToShowOnReviewPage(int id)
        {
            var movie = Movie.SingleOrDefault(c => c.Id == id);
            return new MovieShowVM
            {
                Title = movie.Title,
                InfoText = movie.About,
                Id = movie.Id
            };
        }



    }
}