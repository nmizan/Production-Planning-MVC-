using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Production_Planner.Models
{
    public class BuyerDataModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public List<SelectListItem> TerritoryList { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> ComTypeList { get; set; }

        public BuyerDataModel()
        {
            TerritoryList = new List<SelectListItem>
             {
                 new SelectListItem {Text = "Foreign", Value = "F"},
                 new SelectListItem {Text = "Local", Value = "L"}
             };

            StatusList = new List<SelectListItem>
             {
                 new SelectListItem {Text = "Regular",   Value = "R"},
                 new SelectListItem {Text = "Irregular", Value = "I"}
             };

            ComTypeList = new List<SelectListItem>
             {
                 new SelectListItem {Text = "Buyer", Value = "Buyer"},
                 new SelectListItem {Text = "Exporter", Value = "Exporter"},
                 new SelectListItem {Text = "Supplier", Value = "Supplier"},
                 new SelectListItem {Text = "Bank", Value = "Bank"},
                 new SelectListItem {Text = "Buying House", Value = "Buying House"},
                 new SelectListItem {Text = "Sub Contract Company", Value = "Sub Contract Company"}
             };
        }
    }
}