using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Exceptions;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.TourLists.Commands.UpdateTourList
{
    public class UpdateTourListCommandHandler : IRequestHandler<UpdateTourListCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateTourListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourLists.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(TourList), request.Id);
            }
            entity.City = request.City;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
