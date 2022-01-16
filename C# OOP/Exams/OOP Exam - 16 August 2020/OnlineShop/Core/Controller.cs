using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (computerType == nameof(Laptop))
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            if (computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral;

            if (peripheralType == nameof(Headset))
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            if (peripherals.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return $"Peripheral {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computer.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return $"Successfully removed {peripheral.GetType().Name} with id {peripheral.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent component;

            if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(VideoCard))
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            computer.AddComponent(component);
            components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);

            computer.RemoveComponent(componentType);
            components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string BuyComputer(int id)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            computers.Remove(computer);

            if (computer is null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }
    }
}
