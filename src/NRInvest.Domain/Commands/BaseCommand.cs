using MediatR;
using System;
using System.Text.Json.Serialization;

namespace NRInvest.Domain.Commands
{
    public abstract class BaseCommand : IRequest<object>
    {
        [JsonIgnore]
        public Guid CorrelationId => Guid.NewGuid();
    }
}