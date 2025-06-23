using ProgrammingClubAPI.DataContext;
using ProgrammingClubAPI.Models;
using ProgrammingClubAPI.Repositories;
using ProgrammingClubAPI.UnitTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingClubAPI.UnitTests.Repositories.Test
{
    public class AnnouncementsRepositoryTest
    {
        private readonly IAnnouncementsRepository _announcementRepository;
        private readonly ProgrammingClubDataContext _contextInMemory;

        public AnnouncementsRepositoryTest()
        {
            _contextInMemory = DBContextHelper.GetDatabaseContext();
            _announcementRepository = new AnnouncementsRepository(_contextInMemory);
        }

        [Fact]
        public async Task GetAllAnnouncements_ShouldGetAllAnnouncements()
        {
            // Arrange
            var testAnnouncement1 = await DBContextHelper.AddTestAnnouncement(_contextInMemory);
            var testAnnouncement2 = await DBContextHelper.AddTestAnnouncement(_contextInMemory);

            // Act
            var announcements = await _announcementRepository.GetAllAnnouncementsAsync();

            // Assert
            Assert.NotNull(announcements);
            Assert.Equal(2, announcements.Count());
            Assert.Contains(announcements, a => a.IdAnnouncement == testAnnouncement1.IdAnnouncement);
            Assert.Contains(announcements, a => a.IdAnnouncement == testAnnouncement2.IdAnnouncement);
        }

        [Fact]
        public async Task GetAllAnnouncements_ShouldReturnEmpty_WhenNoAnnouncementsExist()
        {
            // Arrange
            // No announcements added

            // Act
            var announcements = await _announcementRepository.GetAllAnnouncementsAsync();

            // Assert
            Assert.NotNull(announcements);
            Assert.Empty(announcements);
        }

        [Fact]
        public async Task GetAnnouncementById_ShouldReturnAnnouncement_WhenExists()
        {
            // Arrange
            var testAnnouncement = await DBContextHelper.AddTestAnnouncement(_contextInMemory);

            // Act
            var announcement = await _announcementRepository.GetAnnouncementByIdAsync((Guid)testAnnouncement.IdAnnouncement);

            // Assert
            Assert.NotNull(announcement);
            Assert.Equal(testAnnouncement.IdAnnouncement, announcement.IdAnnouncement);
        }

        [Fact]
        public async Task GetAnnouncementById_ShouldReturnNull_WhenNotExists()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act
            var announcement = await _announcementRepository.GetAnnouncementByIdAsync(nonExistentId);

            // Assert
            Assert.Null(announcement);
        }

        [Fact]
        public async Task PostAnnouncement_ShouldAddAnnouncement_WhenValid()
        {
            // Arrange
            var testAnnouncement = new Announcement
            {
                Title = "Test Announcement",
            };

            // Act
            var createdAnnouncement = await _announcementRepository.PostAnnouncementAsync(testAnnouncement);

            // Assert
            Assert.NotNull(createdAnnouncement);
            Assert.NotEqual(Guid.Empty, createdAnnouncement.IdAnnouncement);
        }

        [Fact]
        public async Task PostAnnouncement_ShouldNotAddAnnouncement_WhenInvalid()
        {
            // Arrange
            var guid = Guid.Empty;
            var invalidAnnouncement = new Announcement(); // No IdAnnouncement set

            // Act
            var createdAnnouncement = await _announcementRepository.PostAnnouncementAsync(invalidAnnouncement);

            // Assert
            Assert.Null(createdAnnouncement);
        }
    }
}
