using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.Entities
{
    public class SimpleBugInfo
    {
        public static readonly string _bugNumColumn = "bugNum";
        public string bugNum { get; set; }


        public static readonly string _dealManColumn = "dealMan";
        public string dealMan { get; set; }


        public static readonly string _descriptionColumn = "description";
        public string description { get; set; }


        public static readonly string _sizeColumn = "size";
        public int size { get; set; }


        public static readonly string _firedColumn = "fired";
        public int fired { get; set; }

    }
}
