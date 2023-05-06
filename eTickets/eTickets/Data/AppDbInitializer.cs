using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using eTickets.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope()) { 
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Add Cinema
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<CinemaModel>()
                    {
                        new CinemaModel()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new CinemaModel()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the second cinema"
                        },
                        new CinemaModel()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the third cinema"
                        },
                        new CinemaModel()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the fourth cinema"
                        },
                        new CinemaModel()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the fifth cinema"
                        },
                    });
                    context.SaveChanges();
                }

                // Add Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<ActorModel>()
                    {
                        new ActorModel()
                        {
                            FullName = "Actor 1",
                            Biography = "This is the Bio of the first actor",
                            ProfilePicURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new ActorModel()
                        {
                            FullName = "Actor 2",
                            Biography = "This is the Bio of the second actor",
                            ProfilePicURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new ActorModel()
                        {
                            FullName = "Actor 3",
                            Biography = "This is the Bio of the third actor",
                            ProfilePicURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new ActorModel()
                        {
                            FullName = "Actor 4",
                            Biography = "This is the Bio of the fourth actor",
                            ProfilePicURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new ActorModel()
                        {
                            FullName = "Actor 5",
                            Biography = "This is the Bio of the fifth actor",
                            ProfilePicURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // Add Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<ProducerModel>()
                    {
                        new ProducerModel()
                        {
                            FullName = "Producer 1",
                            Biography = "This is the Bio of the first prodcuer",
                            ProfilePicURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new ProducerModel()
                        {
                            FullName = "Producer 2",
                            Biography = "This is the Bio of the second prodcuer",
                            ProfilePicURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new ProducerModel()
                        {
                            FullName = "Producer 3",
                            Biography = "This is the Bio of the third prodcuer",
                            ProfilePicURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new ProducerModel()
                        {
                            FullName = "Producer 4",
                            Biography = "This is the Bio of the fourth prodcuer",
                            ProfilePicURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new ProducerModel()
                        {
                            FullName = "Producer 5",
                            Biography = "This is the Bio of the fifth prodcuer",
                            ProfilePicURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // Add Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<MovieModel>()
                    {
                        new MovieModel()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 15.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            Start_Date = DateTime.Now.AddDays(-10),
                            End_Date = DateTime.Now.AddDays(10),
                            Cinema_ID = 3,
                            Producer_ID = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new MovieModel()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 15.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            Start_Date = DateTime.Now,
                            End_Date = DateTime.Now.AddDays(3),
                            Cinema_ID = 1,
                            Producer_ID = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new MovieModel()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 15.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            Start_Date = DateTime.Now, 
                            End_Date = DateTime.Now.AddDays(7),
                            Cinema_ID = 4,
                            Producer_ID = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new MovieModel()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 15.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            Start_Date = DateTime.Now.AddDays(-10),
                            End_Date = DateTime.Now.AddDays(-5),
                            Cinema_ID = 1,
                            Producer_ID = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new MovieModel()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 15.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            Start_Date = DateTime.Now.AddDays(-10),
                            End_Date = DateTime.Now.AddDays(-2),
                            Cinema_ID = 1,
                            Producer_ID = 3,
                            MovieCategory = MovieCategory.Comedy
                        },
                        new MovieModel()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 15.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            Start_Date = DateTime.Now.AddDays(3),
                            End_Date = DateTime.Now.AddDays(20),
                            Cinema_ID = 1,
                            Producer_ID = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }

                // Add Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actors_Movies>()
                    {
                        new Actors_Movies()
                        {Actor_ID = 1,Movie_ID = 1},

                        new Actors_Movies()
                        {Actor_ID = 3,Movie_ID = 1},

                        new Actors_Movies()
                        {Actor_ID = 1,Movie_ID = 2},

                        new Actors_Movies()
                        {Actor_ID = 4, Movie_ID = 2},

                        new Actors_Movies()
                        {Actor_ID = 1, Movie_ID = 3},

                        new Actors_Movies()
                        {Actor_ID = 2, Movie_ID = 3},

                        new Actors_Movies()
                        {Actor_ID = 5, Movie_ID = 3},

                        new Actors_Movies()
                        {Actor_ID = 2, Movie_ID = 4},

                        new Actors_Movies()
                        {Actor_ID = 3, Movie_ID = 4},

                        new Actors_Movies()
                        {Actor_ID = 4, Movie_ID = 4},

                        new Actors_Movies()
                        {Actor_ID = 2, Movie_ID = 5},

                        new Actors_Movies()
                        {Actor_ID = 3, Movie_ID = 5},

                        new Actors_Movies()
                        {Actor_ID = 4, Movie_ID = 5},

                        new Actors_Movies()
                        {Actor_ID = 5,Movie_ID = 5},

                        new Actors_Movies()
                        {Actor_ID = 3, Movie_ID = 6},

                        new Actors_Movies()
                        {Actor_ID = 4, Movie_ID = 6},

                        new Actors_Movies()
                        {Actor_ID = 5, Movie_ID = 6},
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
