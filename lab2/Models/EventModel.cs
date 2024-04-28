using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab2.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        [StringLength(30, MinimumLength = 5)]
        public string Lokacija { get; set; }
    }
}