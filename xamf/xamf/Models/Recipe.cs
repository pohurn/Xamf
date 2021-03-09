using System;
using System.Collections.Generic;
using System.Text;

namespace xamf.Models
{
    public class Recipe
    {
        public string title { get; set; }
        public double version { get; set; }
        public string href { get; set; }
        public List<menus> results { get; set; }
    }

    public class menus
    {
        public string title { get; set; }
        public string href { get; set; }
        public string ingredients { get; set; }
        public string thumbnail { get; set; }
    }
}
