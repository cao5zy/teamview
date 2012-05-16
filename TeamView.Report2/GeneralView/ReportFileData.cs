using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Dev3Lib;

namespace TeamView.Report2.GeneralView
{
    public sealed class ReportFileData
    {
        public static void WriteToFile(string tempFileName, ReportEntity[] reportEntities)
        {
            new XDocument(
                new XElement("ReportEntities",
                reportEntities.Select(
                n => new XElement("ReportEntity",
                    new XElement("BugNum", n.BugNum),
                    new XElement("_burnedMins", n._burnedMins),
                    new XElement("_sizeInMins", n._sizeInMins),
                    new XElement("Programmer", n.Programmer),
                    new XElement("Points", n.Points),
                    new XElement("ResultPoint", n.ResultPoint),
                    new XElement("Description", n.Description),
                    new XElement("FixedPoint", n.FixedPoint)
                    )))).Save(tempFileName);

        }

        public static ReportEntity[] LoadFromFile(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);

            return (from n in doc.Descendants("ReportEntity")
                    select new ReportEntity
                    {
                        _burnedMins = n.Element("_burnedMins").Value.ToInt32(),
                        _sizeInMins = n.Element("_sizeInMins").Value.ToInt32(),
                        BugNum = n.Element("BugNum").Value,
                        Points = n.Element("Points").Value.ToDouble(),
                        Programmer = n.Element("Programmer").Value,
                        ResultPoint = n.Element("ResultPoint").Value.ToDouble(),
                        Description = n.Element("Description").Value,
                        FixedPoint = n.Element("FixedPoint").Value.ToDouble(),
                    }).ToArray();

        }
    }
}
