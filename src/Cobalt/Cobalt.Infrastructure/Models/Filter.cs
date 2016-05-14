using Cobalt.Infrastructure.Enums;

namespace Cobalt.Infrastructure.Models
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public OperatorEnum Operator { get; set; }
        public bool IsStringOrEnum { get; set; }
        public object Value { get; set; }
    }
}