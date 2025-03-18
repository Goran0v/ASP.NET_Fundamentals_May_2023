using Homies.Data;
using Homies.Extensions;
using Homies.Models.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Type = Homies.Data.Type;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext dbContext;

        public EventController(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All(HashSet<EventAllViewModel> models)
        {
            List<Event> events = await this.dbContext
                .Events
                .ToListAsync();

            models = new HashSet<EventAllViewModel>();
            if (events.Count > 0)
            {
                foreach (var currEvent in events)
                {
                    IdentityUser user = await this.dbContext.Users.FirstAsync(u => u.Id == currEvent.OrganiserId);
                    Type type = await this.dbContext.Types.FirstAsync(t => t.Id == currEvent.TypeId);

                    EventAllViewModel viewModel = new EventAllViewModel()
                    {
                        Id = currEvent.Id,
                        Name = currEvent.Name,
                        Start = currEvent.Start,
                        Organiser = user.UserName,
                        Type = type.Name
                    };
                    models.Add(viewModel);
                }
            }

            return this.View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Joined(HashSet<EventAllViewModel> models)
        {
            List<Event> events = await this.dbContext
                .Events
                .ToListAsync();

            models = new HashSet<EventAllViewModel>();
            if (events.Count > 0)
            {
                foreach (var currEvent in events)
                {
                    IdentityUser user = await this.dbContext.Users.FirstAsync(u => u.Id == currEvent.OrganiserId);
                    Type type = await this.dbContext.Types.FirstAsync(t => t.Id == currEvent.TypeId);

                    EventAllViewModel viewModel = new EventAllViewModel()
                    {
                        Id = currEvent.Id,
                        Name = currEvent.Name,
                        Start = currEvent.Start,
                        Organiser = user.UserName,
                        Type = type.Name
                    };

                    if (viewModel.JoinedUsers.Contains(user))
                    {
                        models.Add(viewModel);
                    }
                }
            }

            return this.View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            Event @event = await this.dbContext.Events.FirstAsync(e => e.Id == id);
            IdentityUser organiser = await this.dbContext.Users.FirstAsync(u => u.Id == @event.OrganiserId);
            IdentityUser user = await this.dbContext.Users.FirstAsync(u => u.Id == this.User.GetId()!);
            Type type = await this.dbContext.Types.FirstAsync(t => t.Id == @event.TypeId);

            EventAllViewModel model = new EventAllViewModel()
            {
                Id = @event.Id,
                Name = @event.Name,
                Start = @event.Start,
                Organiser = organiser.UserName,
                Type = type.Name
            };

            model.JoinedUsers.Add(user);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("Joined", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Event currEvent = await this.dbContext.Events.FirstAsync(e => e.Id == id);
            Type type = await this.dbContext.Types.FirstAsync(t => t.Id == currEvent.TypeId);
            IdentityUser user = await this.dbContext.Users.FirstAsync(u => u.Id == currEvent.OrganiserId);

            EventDetailsViewModel model = new EventDetailsViewModel()
            {
                Id = currEvent.Id,
                Name = currEvent.Name,
                Description = currEvent.Description,
                Organiser = user.UserName,
                OrganiserId = currEvent.OrganiserId,
                CreatedOn = currEvent.CreatedOn,
                Start = currEvent.Start,
                End = currEvent.End,
                Type = type.Name
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            EventAddViewModel viewModel = new EventAddViewModel();
            viewModel.Types.AddRange(this.dbContext.Types);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventAddViewModel viewModel)
        {
            Event newEvent = new Event()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                OrganiserId = this.User.GetId()!,
                CreatedOn = DateTime.Now,
                Start = viewModel.Start,
                End = viewModel.End,
                TypeId = viewModel.TypeId
            };

            await this.dbContext.Events.AddAsync(newEvent);
            await this.dbContext.SaveChangesAsync();

            return this.View(viewModel);
        }
    }
}