namespace Smyrna_Prototype.Models
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        // private readonly variable to access the database
        private readonly AppDbContext _appDbContext;

        public CustomerReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // IEnumerable to get all reviews from database
        public IEnumerable<CustomerReview> GetCustomerReviews => _appDbContext.CustomerReviews;

        public CustomerReview GetReviewById(int custReviewId)
        {
            return _appDbContext.CustomerReviews.FirstOrDefault(c => c.ReviewId == custReviewId);
        }
    }
}
