namespace LibraryManager.Model {
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Review> Reviews { get; set; } = new();

        public void AddReview(Review review) {
            if(review == null) throw new ArgumentNullException(nameof(review));

            Reviews.Add(review);
        }
    }
}
