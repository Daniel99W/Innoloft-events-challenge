using EventsAPI.Core.Entities;
using EventsAPI.Core.Interfaces;
using EventsAPI.DAL;
using EventsAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventsAPI.Core.Tests
{
    public class EventRepositoryTests
    {
        [Theory]
        [InlineData(7)]
        public async Task GetEventByEventIdTest(int eventId)
        {
            var options = new DbContextOptionsBuilder<EventsDbContext>()
            .UseInMemoryDatabase("EventsDbContext")
            .Options;

            using (var context = new EventsDbContext(options))
            {
                IRepositoryEvent eventRepository = new EventRepository(context);

                eventRepository.Create(new Event()
                {
                    Id = eventId,
                    Title = "Test",
                    StartDate = DateTime.Now,
                    Description = "Desc",
                    EndDate = null,
                    CreatorId = 1
                });

                Event? ev = await eventRepository.Read(eventId);
                Assert.NotNull(ev);
            }
        }
    }
}
