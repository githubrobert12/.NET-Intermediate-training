﻿namespace ProgrammingClubAPI.Models
{
    public class Announcement
    {
        public Guid IDAnnouncement { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Tags { get; set; }
    
    }
}
