using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using GrupparbeteADL.Controllers;

namespace GrupparbeteADL.Models.Entities
{
    public partial class EastwindContext : DbContext
    {
        public EastwindContext(DbContextOptions<EastwindContext> options) : base(options)
        {

        }

        public void AddCar(CarsCreateVM viewModel)
        {
            var carToAdd = new Car
            {
                Brand = viewModel.Brand,
                TopSpeed = viewModel.TopSpeed,
                Model = viewModel.Model,
                Doors = viewModel.Doors,
            };

            Car.Add(carToAdd);
            SaveChanges();
        }

        public CarsIndexVM[] ListCars()
        {
            return Car.Select(c => new CarsIndexVM
            {
                Id = c.Id,
                Brand = c.Brand,
                Model = c.Model,
                Doors = c.Doors,
                TopSpeed = c.TopSpeed,
                OwnerName = c.Owner.Name,
                ShowAsFast = c.TopSpeed >= 250,
            }).OrderBy(c => c.Brand).ToArray();
        }

        public OwnerIndexVM[] ListOwners()
        {
            return Owner.Select(c => new OwnerIndexVM
            {
                Name = c.Name,
            }).ToArray();
        }

        public void RemoveCar(int id)
        {
            var carToRemove = Car.SingleOrDefault(c => c.Id == id);
            Car.Remove(carToRemove);
            SaveChanges();
        }

        public void EditCar(CarsEditVM viewModel, int id)
        {
            var car = Car.SingleOrDefault(c => c.Id == id);
            car.Brand = viewModel.Brand;
            car.TopSpeed = viewModel.TopSpeed;
            car.Model = viewModel.Model;
            car.Doors = viewModel.Doors;
            SaveChanges();
        }

        internal CarsEditVM GetCarForEdit(int id)
        {
            var car = Car.SingleOrDefault(c => c.Id == id);
            return new CarsEditVM
            {
                Brand = car.Brand,
                Model = car.Model,
                Doors = car.Doors,
                TopSpeed = car.TopSpeed,
            };
        }
    }
}