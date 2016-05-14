using System.Collections.ObjectModel;
using Cobalt.Infrastructure.Models;

namespace Cobalt.Modules.TabContent.Services.Interfaces
{
    public interface IExpressionBuilder
    {
        string BuildExpression(ObservableCollection<Filter> filters);
    }
}