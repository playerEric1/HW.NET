namespace ApplicationCore.Models.RequestModels;

public class ReviewRequestModel
{
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public string ReviewText { get; set; }
    public decimal Rating { get; set; }
}