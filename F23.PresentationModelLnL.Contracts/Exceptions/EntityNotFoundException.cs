using System;

namespace F23.PresentationModelLnL.Contracts.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type, int entityId)
        {
            EntityId = entityId;
            Type = type;
        }

        public int EntityId { get; }

        public Type Type { get; set; }
    }
}
