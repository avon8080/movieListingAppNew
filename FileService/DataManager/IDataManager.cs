namespace movieListingApp.FileService
{
    public interface IDataManager
    {
        void TextReader();
        void TextWriter();
        void AddMovieDB();
        string RemoveMovieDB();
        void Search();
        void ListMovies();
        void UpdateMovieDb();
        void AddUserDb();
        void AddRating();
        //void getTopRatedByOccupation();

    }
}