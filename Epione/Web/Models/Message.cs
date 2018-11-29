using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace Web.Models
{
    public class Message
    {
        public InsertionMode InsertionMode { get; set; }
        public string nom { get; set; }
        public DateTime date { get; set; }

        public string Content { get; set; }
    }
}