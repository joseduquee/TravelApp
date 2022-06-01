using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Entities
{
    public class TourPackage
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string WhatToExpect { get; set; } = String.Empty;
        public string MapLocation { get; set; } = String.Empty;
        public float Price { get; set; }
        public int Duration { get; set; }
        public bool InstantConfirmation { get; set; }
        public Currency Currency { get; set; }
        public TourList List { get; set; }

    }
}
