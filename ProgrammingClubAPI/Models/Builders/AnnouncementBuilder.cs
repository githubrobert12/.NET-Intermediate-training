using ProgrammingClubAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingClubAPI.UnitTests.Models.Builders
{
    internal class AnnouncementBuilder : BuilderBase<Announcement>
    {
        public AnnouncementBuilder()
        {
            _objectToBuild = new Announcement
            {
                IdAnnouncement = Guid.NewGuid(),
                Title = "Test Announcement",
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.UtcNow,
                EventDate = DateTime.UtcNow,
                Text = "This is a test announcement.",
                Tags = "Test,Announcement"
            };
        }
    }
}
