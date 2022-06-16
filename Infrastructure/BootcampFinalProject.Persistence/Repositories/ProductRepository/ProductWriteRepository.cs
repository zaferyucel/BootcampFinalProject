using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities;
using BootcampFinalProject.Persistence.Contexts;
using BootcampFinalProject.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Persistence.Repositories.ProductRepository
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(FinalProjectDbContext context) : base(context)
        {
        }
    }
}
