namespace MarGate.Campaign.Api.Requests.Campaign
{
    public class CreateCampaignRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
