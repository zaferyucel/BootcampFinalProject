using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.OfferCommands.DeleteOffer
{
    public class DeleteOfferCommandRequest : IRequest<DeleteOfferCommandResponse>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
