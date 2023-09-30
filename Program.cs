namespace movieListingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataManager dataManager = Factory.CreateDataManager(Factory.CreateRead("moviess.csv"), Factory.CreateWriteFile("moviess.csv", true));
            string menu = Menu();
            while ( menu != "q")
            {
                if (menu == "1")
                {
                    dataManager.TextWriter();
                }
                else if (menu == "2")
                {
                   dataManager.TextReader(); 
                }

                menu = Menu();
               

            }

           
        }

        private static string Menu()
            {
                Console.WriteLine("\t--Menu--\nEnter 1 to write to file\nEnter 2 to read file\nEnter Q to quit");
                return Console.ReadLine().ToLower();
                
            }
    }
}