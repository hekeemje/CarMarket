using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Domain.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public string Type { get; set; }
        public IFormFile Avatar { get; set; }
        public string CarImage { get; set; }
    }
}
