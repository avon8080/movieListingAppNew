using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieListingApp
{
    public class DataManager : IDataManager
    {
        private ITextReader _read;
       private  ITextWriter _write;

       public DataManager(ITextReader read, ITextWriter write)
        {
            _read = read;
            _write = write;
        }

        public void TextReader()
        {
           _read.ReadFile();
        }

        public void TextWriter()
        {
            _write.WriteToFile();
        }

    }
}
