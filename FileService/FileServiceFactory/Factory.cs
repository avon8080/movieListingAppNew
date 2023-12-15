using movieListingApp.FileService.DataManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieLibraryEntities;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using MovieLibraryEntities.Models;

namespace movieListingApp.FileService.FileServiceFactory
{
    public static class Factory
    {
        public static IDataManager CreateDataManager(ITextReader read, ITextWriter write, IContext context)
        {
            return new DataManager.DataManager(read, write, context);
        }


        public static IContext CreateContext()
        {
            return new MovieContext();
        }

        
        public static IRepository CreateRepository(IContext context)
        {
            return new Repository(context);
        }





    }
}
