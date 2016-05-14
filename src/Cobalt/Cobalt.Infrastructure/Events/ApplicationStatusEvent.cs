using Cobalt.Infrastructure.Models;
using Prism.Events;

namespace Cobalt.Infrastructure.Events
{
    public class ApplicationStatusEvent : PubSubEvent<ApplicationStatusPayload>
    {
    }
}