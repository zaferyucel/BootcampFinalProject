using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.ProductCommands.BuyProduct
{
    public class BuyProductCommandRequest : IRequest<BuyProductCommandResponse>
    {
        //public int UserId { get; set; }
        public int ProductId { get; set; }
       

    }
}
