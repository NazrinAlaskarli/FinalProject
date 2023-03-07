using Core.Constants;
using Core.Entities;
using Core.Helpers;
using Data.Repositories.Concrete;
using System.Text.RegularExpressions;

namespace Presentation.Services
{
    public class OwnerService
    {
        private readonly OwnerRepository _ownerRepository;
        public OwnerService()
        {
            _ownerRepository = new OwnerRepository();
        }
        public void GetAll()
        {
            var owners = _ownerRepository.GetAll();

            ConsoleHelper.WriteWithColor("---All owners---", ConsoleColor.Cyan);
            foreach (var owner in owners)
            {
                ConsoleHelper.WriteWithColor($"id:{owner.Id},Name:{owner.Name},Surname:{owner.Surname},Drugstore:{owner.Drugstores} ", ConsoleColor.Magenta);

            }
        }
        public void Create()
        {
            
            ConsoleHelper.WriteWithColor("---Enter owner name---",ConsoleColor.Cyan);
            string name=Console.ReadLine();
            ConsoleHelper.WriteWithColor("---Enter owner surname---", ConsoleColor.Cyan);
            string surname=Console.ReadLine();

            var owners = new Owner
            {
                Name = name,
                Surname = surname

            };

            _ownerRepository.Add(owners);
            ConsoleHelper.WriteWithColor($"Id:{owners.Id},Name:{owners.Name},Surname:{owners.Surname} is successfully created",ConsoleColor.Cyan);
        }
        public void Update()
        {
            GetAll();

            if (_ownerRepository.GetAll().Count == 0)
            {
                return;
            }

        UpdatingDesc: ConsoleHelper.WriteWithColor("Enter Owner Id for updating", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format", ConsoleColor.Red);
                goto UpdatingDesc;
            }
            var owner = _ownerRepository.Get(id);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this Id", ConsoleColor.Red);
                goto UpdatingDesc;
            }
            ConsoleHelper.WriteWithColor("---Enter New Name---");
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("---Enter New Surname---");
            string surname = Console.ReadLine();

            owner.Name = name;
            owner.Surname = surname;

            _ownerRepository.Update(owner);
            ConsoleHelper.WriteWithColor("Owner is succesfully updating", ConsoleColor.Green);

        }
        public void Delete()
        {
            GetAll();

        EnterIdDescription: ConsoleHelper.WriteWithColor("--- Enter ID ---", ConsoleColor.DarkCyan);
            int id;
            bool isSecceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSecceeded)
            {
                ConsoleHelper.WriteWithColor("Invalid ID Format ", ConsoleColor.Red);
                goto EnterIdDescription;
            }

            var owner = _ownerRepository.Get(id);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("We can`tfind any owner by this Id", ConsoleColor.Red);
            }
            else
            {
                _ownerRepository.Delete(owner);
                ConsoleHelper.WriteWithColor($"{owner.Name} {owner.Surname} is succesfuly deleted :)", ConsoleColor.Green);
            }
        }



    }
}
