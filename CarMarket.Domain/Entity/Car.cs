using CarMarket.Domain.Enum;
using System;

namespace CarMarket.Domain.Entity
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public TypeCar Type { get; set; }
        public string CarImage { get; set; }
    }
}
