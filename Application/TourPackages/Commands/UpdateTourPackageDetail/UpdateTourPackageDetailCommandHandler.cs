using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Exceptions;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.TourPackages.Commands.UpdateTourPackageDetail
{
    public class UpdateTourPackageDetailCommandHandler : IRequestHandler<UpdateTourPackageDetailCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateTourPackageDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateTourPackageDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourPackages.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(TourPackage), request.Id);
            }
            entity.ListId = request.ListId;
            entity.WhatToExpect = request.WhatToExpect;
            entity.MapLocation = request.MapLocation;
            entity.Price = request.Price;
            entity.Duration = request.Duration;
            entity.InstantConfirmation = request.InstantConfirmation;
            entity.Currency = request.Currency;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
