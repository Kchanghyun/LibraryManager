using LibraryManager.Model;

namespace LibraryManager.Interfaces {
    public interface IBookManager {
        public void AddBook(Book book);
        public void RemoveBook(int bookId);
        public Book FindBookById(int bookId);
        //test
    }
}
