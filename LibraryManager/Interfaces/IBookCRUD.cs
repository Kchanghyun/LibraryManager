using LibraryManager.Model;

namespace LibraryManager.Interfaces {
    public interface IBookCRUD {
        public void AddBook(Book book);
        public void RemoveBook(int bookId);
        public Book FindBookById(int bookId);
    }
}
