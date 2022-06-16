using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public int? Id;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }

    }
}
