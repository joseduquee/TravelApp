using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.TourLists.Commands.CreateTourList
{
    public class CreateTourListCommand : IRequest<int>
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
    }
}
