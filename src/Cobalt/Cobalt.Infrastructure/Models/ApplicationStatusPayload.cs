using Cobalt.Infrastructure.Enums;

namespace Cobalt.Infrastructure.Models
{
    public struct ApplicationStatusPayload
    {
        public ApplicationStatusEnum ApplicationStatusEnum;
        public string Message;
    }
}