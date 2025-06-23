using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProgrammingClubAPI.v1.DTOs
{
    public class MemberV1DTO
    {
            public string Name { get; set; }
            public string Description{ get; set; }
    }
}
