using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cobalt.Infrastructure.Enums;
using Cobalt.Infrastructure.Models;
using Cobalt.Modules.TabContent.Services.Interfaces;

namespace Cobalt.Modules.TabContent.Services
{
    /// <summary>
    ///     Provides dynamic Linq strings to be used by the Dynamic Linq Library.
    /// </summary>
    public class ExpressionBuilder : IExpressionBuilder
    {
        public string BuildExpression(ObservableCollection<Filter> filters)
        {
            var expressionsList = new List<string>();

            foreach (var filter in filters)
            {
                switch (filter.Operator)
                {
                    case OperatorEnum.Equals:
                        if (filter.Value is Enum)
                        {
                            expressionsList.Add(filter.PropertyName + "=" + $"\"{filter.Value}\"");
                        }
                        else
                        {
                            expressionsList.Add(filter.PropertyName + "=" + filter.Value);
                        }
                        break;
                    case OperatorEnum.Contains:
                        expressionsList.Add(filter.PropertyName + ".Contains(" + $"\"{filter.Value}\")");
                        break;
                    case OperatorEnum.LessThen:
                        expressionsList.Add(filter.PropertyName + "<" + filter.Value);
                        break;
                    case OperatorEnum.MoreThen:
                        expressionsList.Add(filter.PropertyName + ">" + filter.Value);
                        break;
                    case OperatorEnum.LessThenOrEqualTo:
                        expressionsList.Add(filter.PropertyName + "<=" + filter.Value);
                        break;
                    case OperatorEnum.MoreThenOrEqualTo:
                        expressionsList.Add(filter.PropertyName + ">=" + filter.Value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return expressionsList.Aggregate((left, right) => left + " AND " + right);
        }
    }
}