﻿using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<MovieModel>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }
    }
}
