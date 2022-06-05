using MediatR;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.TourPackages.Commands.CreateTourPackage
{
    public class CreateTourPackageCommandHandler : IRequestHandler<CreateTourPackageCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTourPackageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTourPackageCommand request, CancellationToken cancellationToken)
        {
            var entity = new TourPackage
            {
                ListId = request.ListId,
                Name = request.Name,
                WhatToExpect = request.WhatToExpect,
                MapLocation = request.MapLocation,
                Price = request.Price,
                Duration = request.Duration,
                InstantConfirmation = request.InstantConfirmation,
                Currency = request.Currency
            };
            _context.TourPackages.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
