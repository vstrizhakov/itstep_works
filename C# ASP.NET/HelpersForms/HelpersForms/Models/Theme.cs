using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpersForms.Models
{
    public class Theme
    {
        private static int _id = 0;

        public int Id { get; set; }
        public string Name { get; set; }

        public Theme()
        {
            Id = _id++;
        }
    }
}