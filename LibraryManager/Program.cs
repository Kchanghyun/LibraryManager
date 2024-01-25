using System.Net;
using System.Text;
using LibraryManager.Model;
using LibraryManager.Service;

BookManager bookManager = new();
LoanManager loanManager = new();

// OCP 예문에서 if else로 늘리는것처럼 이것도 늘리는건가..? 아니면 그냥 보기니까 괜찮은건가..?
while(true) {
    Console.WriteLine("1. 책 추가");
    Console.WriteLine("2. 책 삭제");
    Console.WriteLine("3. 책 검색");
    Console.WriteLine("4. 모든 책 보기");

    Console.WriteLine("5. 리뷰 추가");
    Console.WriteLine("6. 리뷰 보기");

    Console.WriteLine("7. 대여하기");
    Console.WriteLine("8. 반납하기");
    Console.WriteLine("9. 서점 대여 리스트");

    Console.WriteLine("10. 종료");

    Console.Write("옵션을 선택하세요: ");

    int option = Convert.ToInt32(Console.ReadLine());

    switch(option) {
        case 1:
            AddBook();
            break;
        case 2:
            RemoveBook();
            break;
        case 3:
            FindBook();
            break;
        case 4:
            DisplayAllBooks();
            break;
        case 5: // add
            AddReview();
            break;
        case 6: // add
            FindReview();
            break;
        case 7:
            LoanBook();
            break;
        case 8:
            ReturnBook();
            break;
        case 9:
            ListOfLoanBooks();
            break;
        case 10:
            return;
        default:
            Console.WriteLine("잘못된 선택입니다.");
            break;
    }
}

void AddBook() {
    Console.Write("책 제목: ");
    string title = Console.ReadLine();

    Console.Write("저자: ");
    string author = Console.ReadLine();

    Book book = new Book { Title = title, Author = author };
    bookManager.AddBook(book);

    Console.WriteLine("책이 추가되었습니다.");
}

void RemoveBook() {
    Console.Write("삭제할 책의 ID를 입력하세요: ");
    int id = Convert.ToInt32(Console.ReadLine());

    bookManager.RemoveBook(id);

    Console.WriteLine("책이 삭제되었습니다.");
}

//void FindBook() {
//    Console.Write("검색할 책의 ID를 입력하세요: ");
//    int id = Convert.ToInt32(Console.ReadLine());

//    Book book = bookManager.FindBookById(id);

//    Console.WriteLine($"ID: {book.Id}, 제목: {book.Title}, 저자: {book.Author}");
//}

// FindBook() 메서드는 원래 있던 방법에서 아예 바꾼건데 음... 이것도 OCP 위반인가
void FindBook() {
    Console.WriteLine("책 검색 방법을 골라주세요.");
    Console.WriteLine("1. Id");
    Console.WriteLine("2. 제목");
    Console.WriteLine("3. 저자");

    int select = Convert.ToInt32(Console.ReadLine());
    Book book;

    switch(select) {
        case 1:
            Console.Write("ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            book = bookManager.FindBookById(id);
            break;
        case 2:
            Console.Write("제목 : ");
            string title = Console.ReadLine();
            book = bookManager.FindBookByTitle(title);
            break;
        case 3:
            Console.Write("저자 : ");
            string author = Console.ReadLine();
            book = bookManager.FindBookByAuthor(author);
            break;
        default:
            // 다른 값 입력 시 그냥 첫번째 Id의 책 가지고 오기
            book = bookManager.FindBookById(1);
            break;
    }
    Console.WriteLine($"ID: {book.Id}, 제목: {book.Title}, 저자: {book.Author}");
}

// 원래 있던 기능에 리뷰 없음 문자열 추가.. 이것도 OCP 위반,,?
void DisplayAllBooks() {
    var books = bookManager.GetAllBooks();

    foreach(var book in books) {
        string review = SumReviews(book.Reviews);
        Console.WriteLine($"ID: {book.Id}, 제목: {book.Title}, 저자: {book.Author} 리뷰: {review}");
    }
}
string SumReviews(List<Review> reviews) {
    if(reviews.Count == 0) return "리뷰 없음";

    StringBuilder sb = new StringBuilder();
    foreach(Review review in reviews) {
        sb.AppendLine(review.UserReview);
    }

    return sb.ToString();
}


// 리뷰 추가 및 리뷰 찾기
void AddReview() {
    Console.Write("책 ID : ");
    int id = Convert.ToInt32(Console.ReadLine());
    bookManager.AddReview(id);
}

void FindReview() {
    Console.Write("책 ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    bookManager.FindReview(id);
}

void LoanBook() {
    Console.Write("대여할 책 번호 입력 : ");
    int bookId = Convert.ToInt32(Console.ReadLine());

    Console.Write("사용자 번호 입력 : ");
    int userId = Convert.ToInt32(Console.ReadLine());

    loanManager.LoanBook(bookId, userId);
}

void ReturnBook() {
    Console.Write("반납할 책 번호 입력 : ");
    int bookId = Convert.ToInt32(Console.ReadLine());

    Console.Write("사용자 번호 입력 : ");
    int userId = Convert.ToInt32(Console.ReadLine());

    loanManager.ReturnBook(bookId, userId);
}

void ListOfLoanBooks() {
    List<LoanRecord> _loanRecords = loanManager.LoanList();
    foreach(var loanRecord in _loanRecords) {
        Console.WriteLine("--------------------------");
        Console.WriteLine($"ID : {loanRecord.Id}");
        Console.WriteLine($"사용자 번호 : {loanRecord.UserId}");
        Console.WriteLine($"책 번호 : {loanRecord.BookId}");
        Console.WriteLine($"대출 시간 : {loanRecord.LoanDate}");
        Console.WriteLine($"반납 시간 : {loanRecord.ReturnDate}");
        Console.WriteLine("--------------------------");
    }
}