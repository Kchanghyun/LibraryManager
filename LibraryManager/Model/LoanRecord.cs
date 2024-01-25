namespace LibraryManager.Model {
    public class LoanRecord {
        // 대출 고유 번호..?
        public int Id { get; set; }
        // BookId를 가져와서 책 정보를 읽어들이기
        public int BookId { get; set; }
        // UserId를 가져와서 사용자 정보 읽어들이기
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
