using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForChepaDAL.Entities;
namespace ForChepaBLL.DTO
{
    class ThirdDTO
    {
        public int Id { get; set; }

        public Countries Countries { get; set; }
        public Cities Cities { get; set; }
        public int? CountriesId { get; set; }
        public int? CitiesId { get; set; }
    }
}
