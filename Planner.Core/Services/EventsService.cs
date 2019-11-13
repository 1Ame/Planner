using Microsoft.Extensions.Logging;
using Planner.Core.Abstractions;
using Planner.Core.Abstractions.Store;

namespace Planner.Core.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsStore _store;
        private readonly ILogger<EventsService> _logger;

        public EventsService(IEventsStore store, ILogger<EventsService> logger)
        {
            _store = store;
            _logger = logger;
        }
    }
}
