using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Production_Planner.Models
{
    public class HolidayDataModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public List<SelectListItem> HolidayType { get; set; }
        public List<SelectListItem> WorkingDay { get; set; }

        public HolidayDataModel()
        {
            HolidayType = new List<SelectListItem>
             {
                 new SelectListItem {Text = "Weekly Holiday", Value = "W"},
                 new SelectListItem {Text = "National Holiday", Value = "N"},
                 new SelectListItem {Text = "Festival Holiday", Value = "F"},
                 new SelectListItem {Text = "Others Holiday", Value = "O"}
             };

            WorkingDay = new List<SelectListItem>
             {
                 new SelectListItem {Text = "Close",   Value = "0"},
                 new SelectListItem {Text = "Half", Value = "50"},
                 new SelectListItem {Text = "Full", Value = "100"}
             };

            
        }
    }
}