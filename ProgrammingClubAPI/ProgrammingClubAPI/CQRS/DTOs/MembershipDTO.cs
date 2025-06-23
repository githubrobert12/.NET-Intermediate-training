namespace ProgrammingClubAPI.CQRS.DTOs
{
    public class MembershipDTO
    {
        public Guid IdMember { get; set; }
        public Guid IdMembershipType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Level { get; set; }
    }
}
