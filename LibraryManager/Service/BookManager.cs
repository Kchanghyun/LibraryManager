using System.Text;
using LibraryManager.Interfaces;
using LibraryManager.Model;

namespace LibraryManager.Service
{
    public class BookManager : IBookManager {
        private List<Book?> _books = new();
        private int _nextId = 1;

        public void AddBook(Book book) {
            if(book == null) throw new ArgumentNullException(nameof(book));

            book.Id = _nextId++;
            _books.Add(book);
        }

        public void RemoveBook(int bookId) {
            Book? book = _books.FirstOrDefault(b => b.Id == bookId);
            if(book != null) _books.Remove(book);
        }

        //FirstOrDefault => umm.. b.Id가 bookId와 같다면 그 Id의 인덱스 반환하는듯..?
        public Book FindBookById(int bookId) {
            return _books.FirstOrDefault(b => b.Id == bookId);
        }

        // FindBookByTitle 기능 추가
        public Book FindBookByTitle(string bookTitle) {
            return _books.FirstOrDefault(b => b.Title == bookTitle);
        }

        // FindBookByAuthor 기능 추가
        public Book FindBookByAuthor(string bookAuthor) {
            return _books.FirstOrDefault(b => b.Author == bookAuthor);
        }

        // 오버로딩을 하는 게 더 나으려나?
        //public Book FindBook(int bookId) {
        //    return _books.FirstOrDefault(b => b.Id == bookId);
        //}

        //public Book FindBook(string bookTitle)
        //{
        //    return _books.FirstOrDefault(b => b.Title == bookTitle);
        //}

        // tmp는 Title 메서드와 겹쳐서 의미 없는 변수로 만듦..
        //public Book FindBook(int tmp, string bookAuthor)
        //{
        //    return _books.FirstOrDefault(b => b.Author == bookAuthor);
        //}

        public List<Book> GetAllBooks() {
            return _books;
        }

        // 리뷰 추가 및 리뷰 찾기 기능
        public void AddReview(int bookId) {
            Book book = _books.FirstOrDefault(b => b.Id == bookId);

            if(book != null) {
                Console.WriteLine("이 책의 리뷰를 남겨주세요");
                string? tmp = Console.ReadLine();

                book.AddReview(new Review { UserReview = tmp });
                Console.WriteLine("리뷰 추가 완료");
            }
        }

        public void FindReview(int bookId) {
            Book book = _books.FirstOrDefault(b => b.Id == bookId);
            if(book != null) {
                //찾았는데 review가 없으면 리뷰 추가하기
                if(book.Reviews.Count == 0) AddReview(bookId);

                StringBuilder sb = new StringBuilder();
                foreach(var bookReview in book.Reviews) {
                    sb.AppendLine(bookReview.UserReview);
                }

                Console.WriteLine($"ID : {book.Id}, 제목 : {book.Title}, 저자 : {book.Author} \n리뷰 : {sb}");
            }
        }
    }
}
