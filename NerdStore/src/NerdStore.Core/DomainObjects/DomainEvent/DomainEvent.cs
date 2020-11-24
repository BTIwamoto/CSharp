using System;
using NerdStore.Core.Messages;

namespace NerdStore.Core.DomainObjects.DomainEvent
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}