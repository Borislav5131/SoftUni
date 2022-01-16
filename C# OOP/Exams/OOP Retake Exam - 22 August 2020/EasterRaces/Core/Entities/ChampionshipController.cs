using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly DriverRepository driverRepository;
        private readonly CarRepository carRepository;
        private readonly RaceRepository raceRepository;
        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }


        public string CreateDriver(string driverName)
        {
            IDriver driver = driverRepository.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            driver = new Driver(driverName);
            driverRepository.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = carRepository.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException($"Car {model} is already create.");
            }

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);
            return $"{type} {model} is created.";

        }

        public string CreateRace(string name, int laps)
        {
            IRace race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);
            raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            IDriver driver = driverRepository.GetByName(driverName);

            if (driver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }


            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driverRepository.GetByName(driverName);

            if (driver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            ICar car = carRepository.GetByName(carModel);

            if (car is null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            List<IDriver> raceDriverList = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var first = raceDriverList[0];
            var second = raceDriverList[1];
            var third = raceDriverList[2];

            raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {first.Name} wins {raceName} race.");
            sb.AppendLine($"Driver {second.Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {third.Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
