namespace Smyrna_Prototype.Models
{
    public interface ICustomerReviewRepository
    {
        // IEnumerable to get all products from database
        IEnumerable<CustomerReview> GetCustomerReviews { get; }

        // How do we want to fetch this data --> Using custReviewId (Primary Key)
        CustomerReview GetReviewById(int customerReviewId);
    }
}
