using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.TourLists.Queries.GetTours
{
    public class GetToursQuery : IRequest<ToursVm>
    {
    }
}
