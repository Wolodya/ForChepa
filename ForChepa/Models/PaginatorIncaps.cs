using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ForChepa.Models;
namespace ForChepa.Models
{
    public class PaginatorIncaps
    {
        public IEnumerable<Third> Third { get; set; }
        public Paginator Paginator { get; set; }
    }
}