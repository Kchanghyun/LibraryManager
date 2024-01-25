using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.JavaScript;
using LibraryManager.Interfaces;
using LibraryManager.Model;

namespace LibraryManager.Service
{
    public class LoanManager {
        public List<LoanRecord> _LoanRecords = new();
        private int _nextId = 1;

        public void LoanBook(int bookId, int userId) {

            _LoanRecords.Add(new LoanRecord
                { Id = _nextId++, UserId = userId, BookId = bookId, LoanDate = DateTime.Now, ReturnDate = null });

            Console.WriteLine("대출 완료!");
            Console.WriteLine($"ID : {_nextId - 1}");
            Console.WriteLine($"사용자 번호 : {userId}");
            Console.WriteLine($"책 번호 : {bookId}");
            Console.WriteLine($"대출 시간 : {DateTime.Now}");
        }

        public void ReturnBook(int bookId, int userId) {

            LoanRecord? record = _LoanRecords.FirstOrDefault(b => b.BookId == bookId);
            record.ReturnDate = DateTime.Now;

            Console.WriteLine("반납 완료!");
            Console.WriteLine($"ID : {record.Id}");
            Console.WriteLine($"사용자 번호 : {userId}");
            Console.WriteLine($"책 번호 : {bookId}");
            Console.WriteLine($"대출 시간 : {record.LoanDate}");
            Console.WriteLine($"반납 시간 : {record.ReturnDate}");
        }

        public List<LoanRecord> LoanList() {
            return _LoanRecords;
        }
    }
}
