namespace MQuince.Review.Domain.Contracts.DTO
{
    public class FeedbackDTO
    {
        public string Comment { get; set; }
        public string User { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
        public bool Approved { get; set; }
    }
}
