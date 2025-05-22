namespace ProgrammingClubAPI.Models
{
    public class Membership
    {
        public Guid IDMembership { get; set; }
        public int IDMember { get; set; }
        public int IDMembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Level { get; set; }
    }
}
