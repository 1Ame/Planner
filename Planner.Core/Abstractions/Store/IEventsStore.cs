using Planner.Core.Models;
using System;

namespace Planner.Core.Abstractions.Store
{
    public interface IEventsStore
    {
        Guid CreateEvent(Event item);
        Guid DeleteEvent(Guid id);
    }
}
