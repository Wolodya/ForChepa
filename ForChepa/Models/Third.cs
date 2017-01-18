using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForChepa.Models
{
    public class Third
    {
        public int Id { get; set; }
       
        public Countries Countries { get; set; }
        public Cities Cities { get; set; }
        public int? CountriesId { get; set; }
        public int? CitiesId { get; set; }
    }
}