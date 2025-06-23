using System.ComponentModel.DataAnnotations;

namespace ProgrammingClubAPI.CQRS.DTOs
{
    public class CreateMembershipTypeDTO
    {
        public string? Name { get; set; }
        public string Description { get; set; }
        public int? SubscriptionLengthInMonths { get; set; }
    }
}
