using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model;

namespace LibraryManager.Interfaces
{
    public interface IBookSearch {
        public List<Book> FindBookByTitle(string bookTitle);

        public List<Book> FindBookByAuthor(string bookAuthor);
    }
}
