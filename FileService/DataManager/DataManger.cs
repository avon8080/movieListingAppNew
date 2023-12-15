using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using movieListingApp.FileService;
using movieListingApp.FileService.DataManager;

using movieListingApp.FileService.FileServiceFactory;

namespace movieListingApp.FileService.DataManager
{
    public class DataManager : IDataManager
    {
        private ITextReader _read;
        private ITextWriter _write;
        private IRepository _repository;


        public DataManager(ITextReader read, ITextWriter write, IContext context)
        {
            _read = read;
            _write = write;
            _repository = Factory.CreateRepository(Factory.CreateContext()); // I know this a dependency. This is where I ran into some trouble.
        }

        public void AddMovieDB()
        {
            _repository.CreateMovie();
        }

        public void Search()
        {
            Console.WriteLine("Enter a movie to search: ");
            var userMovieLine = Console.ReadLine();
            Console.WriteLine("Movies: ");
            var movieSearch = _repository.Search(userMovieLine).ToList();
            foreach (var movie in movieSearch )
            {
                Console.WriteLine($"\n{movie.Title}");
                Console.WriteLine("Genres: ");
                foreach (var genre in movie.MovieGenres.ToList())
                {
                    Console.WriteLine(genre.Genre.Name);
                }
                
            }
        }

        public string RemoveMovieDB()
        {
            long id = getId();
           return _repository.DeleteMovie(id);
        }

        public void TextReader()
        {
            _read.ReadFile();
        }

        public void TextWriter()
        {
            _write.WriteToFile();
        }

        public void ListMovies()
        {
           
            Console.WriteLine("Enter the number of movies displayed per page (type v to view all): ");
            var list = _repository.ListMovies();
            var count = 0;

            if (int.TryParse(Console.ReadLine(), out var page ))
            {
                count = page;
                var continueReading = "";
                do
                {
                    foreach (var movie in list.ToList())
                    {
                        count--;
                        if (count == 0)
                        {
                            Console.WriteLine("Would you like to continue (y/n)");
                            continueReading = Console.ReadLine().ToLower();
                            if (continueReading == "y")
                            {
                                count = page;
                            }
                            else 
                                break;
                            
                        }
                        Console.WriteLine($"{movie.Title}");
                    }

                } while (continueReading != "n");
            }
            else
            {
                _repository.ListMovies().ToList().ForEach(Console.WriteLine);
            }
        }

        public void UpdateMovieDb()
        {
            long id = getId();
            _repository.UpdateMovie(id);
        }

        private long getId()
        {
            Console.WriteLine("Enter Id:");
            var isValid = long.TryParse(Console.ReadLine(), out var id);
            return id;
        }

        public void AddUserDb()
        {
            _repository.AddUser();

        }

        public void AddRating()
        {
            _repository.UserRating();

        }

        //public void getTopRatedByOccupation()
        //{
            
        //    foreach (var rating in _repository.TopRated().ToList())
        //    {
        //        Console.WriteLine(rating.Movie.Title);
        //    }
        //}
    }
}
