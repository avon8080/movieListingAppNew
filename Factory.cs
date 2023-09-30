using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieListingApp
{
    public static class Factory
    {
        public static IDataManager CreateDataManager(ITextReader read, ITextWriter write)
        {
            return new DataManager(read, write);
        }

        public static StreamReader CreateStreamReader(string file)
        {
            return new StreamReader(file);
        }

        public static Read CreateRead(string filename)
        {
            return new Read(filename);
        }

        public static WriteFile CreateWriteFile(string filename, bool write)
        {
            return new WriteFile(filename, write);
        }

        public static StreamWriter CreateStreamWriter(string filename, bool write)
        {
            return new StreamWriter(filename, write);
        }

        

    }
}
