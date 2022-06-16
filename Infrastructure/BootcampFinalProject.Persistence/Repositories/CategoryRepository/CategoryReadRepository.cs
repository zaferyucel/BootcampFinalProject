using BootcampFinalProject.Application.Repositories.CategoryRepository;
using BootcampFinalProject.Domain.Entities;
using BootcampFinalProject.Persistence.Contexts;
using BootcampFinalProject.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Persistence.Repositories.CategoryRepository
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(FinalProjectDbContext database) : base(database)
        {
        }
    }
}
