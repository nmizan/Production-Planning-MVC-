using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Production_Planner.Models
{
    public class CategoryModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public CategoryModel()
        {
            CategoryList = new List<SelectListItem>
            {
                
                new SelectListItem {Text = "A", Value = "A"},
                new SelectListItem {Text = "B", Value = "B"},
                new SelectListItem {Text = "C", Value = "C"},
                new SelectListItem {Text = "D", Value = "D"},
                new SelectListItem {Text = "E", Value = "E"},
                new SelectListItem {Text = "F", Value = "F"},
                new SelectListItem {Text = "G", Value = "G"},
                new SelectListItem {Text = "H", Value = "H"}
            };  
        
        }
    }
}