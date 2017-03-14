﻿using System;
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
                        movie.Rate = double.Parse(movie.Rate.ToString().Remove(3));
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


        public MovieReviewVM[] ListReviews(int id)
        {
            //var movieTitle = Movie.SingleOrDefault(m => m.Id == id).Title;
            var reviews = Review
                .Where(c => c.MovieId == id)
                .Select(m => new MovieReviewVM
                {
                    ReviewTitle = m.Title,
                    Text = m.Text,
                    Rate = m.Rate,
                    Id = m.Id,
                    // Movie = movieTitle,
                }).ToArray();


            return reviews;

        }

        public string GetMovie(int id)
        {
            string movieTitle = Movie.SingleOrDefault(m => m.Id == id).Title;
            return movieTitle;
        }

        internal MovieShowVM GetMovieToShowOnReviewPage(int id)
        {
            var movie = Movie.SingleOrDefault(c => c.Id == id);
            return new MovieShowVM
            {
                Title = movie.Title,
                Id = movie.Id
            };
        }
    }
}