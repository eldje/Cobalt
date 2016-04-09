using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Cobalt.DataAccess.Helpers
{
    public static class DataHelpers
    {
        // Created by Mary Hamlin of StackOverflow
        // http://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable/5805044#5805044
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof (T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
