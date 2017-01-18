using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ForChepa.Models;
namespace ForChepa.Models
{
    public class Paginator
    {
        public int PNumber { get; set; }
        public int PSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PSize); }
        }
    }
}