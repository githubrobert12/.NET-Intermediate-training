namespace ProgrammingClubAPI.Models
{
    public class MembershipType
    {
        public Guid IDMembershipType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubscriptionLength { get; set; }
    }
}
