﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.OfferCommands
{
    public class CreateOfferCommandRequest : IRequest<CreateOfferCommandResponse>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
    }
}
