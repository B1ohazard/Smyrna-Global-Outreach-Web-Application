namespace Smyrna_Prototype.Models
{
    public class AddReviewRepository : IAddReviewRepository
    {
        // private readonly variable to access the database
        private readonly AppDbContext _appDbContext;

        public AddReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // IEnumerable to get all reviews from database
        public IEnumerable<AddReview> GetAllReviews => _appDbContext.AddReviews;

        public AddReview GetReviewById(int addReviewId)
        {
            return _appDbContext.AddReviews.FirstOrDefault(a => a.AddReviewId == addReviewId);
        }
    }
}
