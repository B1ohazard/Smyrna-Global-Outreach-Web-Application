namespace Smyrna_Prototype.Models
{
    public interface IAddReviewRepository
    {
        // IEnumerable to get all products from database
        IEnumerable<AddReview> GetAllReviews { get; }

        // How do we want to fetch this data --> Using product ID (Primary Key)
        AddReview GetReviewById(int addReviewId);
    }
}
