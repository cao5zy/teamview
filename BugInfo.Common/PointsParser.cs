using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common.Entity;
using FxLib;


namespace BugInfoManagement.Common
{
    public static class PointsParser
    {
        enum KeyEnum { 
            Assignee,
            EstimatedBy,
            EstimatedLevel
        };

        public static string ToParseString(ProgrammerPoint point)
        {
            if (string.IsNullOrEmpty(point.EstimatedLevel))
                return string.Empty;

            KeyGenerator<KeyEnum> key = new KeyGenerator<KeyEnum>();
            var result = key.Add(KeyEnum.Assignee, point.Assignee)
                .Add(KeyEnum.EstimatedBy, point.EstimatedBy)
                .Add(KeyEnum.EstimatedLevel, point.EstimatedLevel);

            return result.ToValues();
        }

        public static ProgrammerPoint ToPoint(string valueStr)
        {
            KeyGenerator<KeyEnum> key = new KeyGenerator<KeyEnum>();
            var values = key.ToDictionary(valueStr);

            return new ProgrammerPoint { 
                Assignee = values[KeyEnum.Assignee],
                EstimatedBy = values[KeyEnum.EstimatedBy],
                EstimatedLevel = values[KeyEnum.EstimatedLevel]
            };
        }
    }
}
