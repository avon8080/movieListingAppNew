using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movieListingApp.FileService;
using movieListingApp.FileService.FileServiceFactory;
using MovieLibraryEntities;

namespace movieListingApp
{
    public class Menu
    {
        private IDataManager _dataManager;



        public Menu(IDataManager dataManager)
        {
            _dataManager = dataManager;


        }


        public void Run()
        {
            string choice;
            do
            {
               choice = DisplayMenu();
                switch (choice)
                {
                    case "1":
                        ListMenu();
                        break;
                    case "2":
                        _dataManager.AddMovieDB();
                        break;
                    case "3":
                        _dataManager.ListMovies();
                        break;
                    case "4":
                        _dataManager.Search();
                        break;
                    case "5":
                        _dataManager.UpdateMovieDb();
                        break;
                    case "6":
                        Console.WriteLine(_dataManager.RemoveMovieDB());
                        break;
                    case "7":
                        _dataManager.AddUserDb();
                        break;
                    case "8":
                        _dataManager.AddRating();
                        break;
                    //case "9":
                    //    _dataManager.getTopRatedByOccupation();
                    //    break;

                }
            } while (choice != "q") ;
        }

        private string DisplayMenu()
        {
            Console.Write("\t--Menu--\n1. File service (read/write)\n2. Add movie to database\n3. List all movies From DB\n4. Search movie\n5. Update movie\n6. Remove movie\n7. Add user\n8. Add Rating\nQ to Quit\n==>");
            return Console.ReadLine().ToLower();

        }
        private string ListMenu()
        {
            Console.WriteLine("\t--Menu--\n Enter 1 to write to file\nEnter 2 to read file\nEnter Q to quit");
            return Console.ReadLine().ToLower();
        }

    }
}
