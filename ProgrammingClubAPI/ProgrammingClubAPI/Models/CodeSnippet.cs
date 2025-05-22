namespace ProgrammingClubAPI.Models
{
    public class CodeSnippet
    {
        public Guid IDCodeSnippet { get; set; }
        public int IDMember { get; set; }
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public int Revision { get; set; }
        public int IDSnippetPreviousVersion { get; set; }
        public bool IsPublished { get; set; }
   
    }
}
