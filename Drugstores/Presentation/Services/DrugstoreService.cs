using Core.Entities;
using Core.Extensions;
using Core.Helpers;
using Data.Repositories.Concrete;

namespace Presentation.Services
{
    public class DrugstoreService
    {
        private readonly DrugstoreRepository _drugStoreRepository;
        private readonly OwnerRepository _ownerRepository;
        private readonly OwnerService _ownerService;
        private readonly string email;
        private readonly object _drugstoreRepository;

        public DrugstoreService()
        {
            _drugStoreRepository = new DrugstoreRepository();
            _ownerRepository = new OwnerRepository();
            _ownerService = new OwnerService();
        }
        public void GetAll()
        {
            var drugstores = _drugStoreRepository.GetAll();
            ConsoleHelper.WriteWithColor("-- All Drugstore --");
            if (drugstores.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no any DrugStore", ConsoleColor.Red);
            }
            foreach (var drugStore in drugstores)
            {
                ConsoleHelper.WriteWithColor($"ID:{drugStore.Id} Name:{drugStore.Name} Email:{drugStore.Email},Owner:{drugStore.Owner}");
            }
        }
        public void Craete()
        {
            if (_ownerRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create owner for DrugStore!", ConsoleColor.DarkCyan);
                return;
            }

            ConsoleHelper.WriteWithColor("Enter DrugStore name", ConsoleColor.Cyan);
            string name = Console.ReadLine();

            ConsoleHelper.WriteWithColor("Enter DrugStore address", ConsoleColor.Cyan);
            string address = Console.ReadLine();
           
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter Owner ID", ConsoleColor.Cyan);
            int ownerid;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out ownerid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var owner = _ownerRepository.Get(ownerid);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto EnterIdDesc;
            }


            var drugstore = new Drugstore
            {
                Name = name,
                Address = address,
                Email = email,
                Owner = owner
            };
            owner.Drugstores.Add(drugstore);
            ConsoleHelper.WriteWithColor($"Drug successfully created with Name:{drugstore.Name},Adress:{drugstore.Address} ");
        }
        public void Update()
        {
            GetAll();

            if (_drugStoreRepository.GetAll().Count == 0)
            {
                return;
            }
        UpdatingDesc: ConsoleHelper.WriteWithColor("Enter DrugStore ID for updating", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed ID is not correct format!", ConsoleColor.Red);
                goto UpdatingDesc;
            }
            var drugStore = _drugStoreRepository.Get(id);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("There is no any DrugStore in this ID", ConsoleColor.Red);
                goto UpdatingDesc;
            }
            ConsoleHelper.WriteWithColor("Enter new name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter new DrugStore address", ConsoleColor.Cyan);
            string address = Console.ReadLine();

            ConsoleHelper.WriteWithColor("Enter new DrugStore contact number", ConsoleColor.Cyan);
            string contactnumber = Console.ReadLine();
        EmailDesc: ConsoleHelper.WriteWithColor("Enter new Drugstore email", ConsoleColor.Cyan);
            string email = Console.ReadLine();
            if (!email.IsEmail())
            {
                ConsoleHelper.WriteWithColor("Email is not correct format!", ConsoleColor.Red);
                goto EmailDesc;
            }

            if (_drugStoreRepository.IsDuplicatedEmail(email))
            {
                ConsoleHelper.WriteWithColor("This email already used", ConsoleColor.Red);
                goto EmailDesc;
            }
            _ownerService.GetAll();
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter new owner Id", ConsoleColor.Cyan);
            int ownerid;
            isSucceeded = int.TryParse(Console.ReadLine(), out ownerid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var owner = _ownerRepository.Get(ownerid);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto EnterIdDesc;
            }


            drugStore.Name = name;
            drugStore.Email = email;
            drugStore.Address = address;
            drugStore.Owner = owner;


            _drugStoreRepository.Update(drugStore);
            ConsoleHelper.WriteWithColor("DrugStore is succesfully updating", ConsoleColor.Green);
        }
        public void Delete()
        {
            GetAll();

            if (_drugStoreRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is not any DrugStore", ConsoleColor.Red);
                return;
            }
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter Id", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format", ConsoleColor.Red);
                goto EnterIdDesc;
            }

            Drugstore DbdrugStore = _drugStoreRepository.Get(id);
            if (DbdrugStore is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this Id", ConsoleColor.Red);
                return;
            }
            _drugStoreRepository.Delete(DbdrugStore);
            ConsoleHelper.WriteWithColor("DrugStore is succesfully deleted", ConsoleColor.Green);
        }
           
        }
    }

}
