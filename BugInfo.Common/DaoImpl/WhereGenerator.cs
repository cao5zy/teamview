using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfoManagement.Dao;
using System.Reflection;

namespace BugInfoManagement.DaoImpl
{
    public class WhereGenerator
    {
        public string WhereClause { get; private set; }

        public WhereGenerator(QueryParameter parameter)
        {
            var properties = typeof(QueryParameter).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var sqlwhere = properties.ToList().FindAll(p => p.GetCustomAttributes(typeof(BugInfoParameterAttribute), true) != null)
                .ToList()
                .ConvertAll(
                p =>
                {
                    var value = p.GetValue(parameter, null);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                        return string.Empty;
                    else
                    {
                        var columnName = ((BugInfoParameterAttribute)p.GetCustomAttributes(typeof(BugInfoParameterAttribute), true)[0]).SqlColumnName;
                        if (columnName == "bugNum")
                            return string.Format("{0} like '{1}%'", columnName,
                            value.ToString());
                        else if (columnName == "description")
                            return string.Format("{0} like '%{1}%'", columnName, value.ToString());
                        else
                            return string.Format("{0}='{1}'", columnName,
                            value.ToString());
                    }
                }
                );

            var result = sqlwhere.FindAll(n => !string.IsNullOrEmpty(n));
            if (result.Count == 0)
                WhereClause = string.Empty;
            else
                WhereClause = string.Join(" and ", result.ToArray());


        }
    }
}
