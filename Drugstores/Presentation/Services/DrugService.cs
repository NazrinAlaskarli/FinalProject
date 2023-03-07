using Core.Entities;
using Core.Helpers;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
   
    public class DrugService
    {
        private readonly DruggistService _druggistService;
        private readonly DrugstoreRepository _drugstoreRepository;
        private readonly DrugstoreService _drugstoreService;
        private readonly DrugRepository _drugRepository;
        public DrugService()
        {
            _druggistService = new DruggistService();
            _drugstoreRepository = new DrugstoreRepository();
            _drugstoreService = new DrugstoreService();
            _drugRepository = new DrugRepository();
        }
        public void GetAll()
        {
            var drugs = _drugRepository.GetAll();

            ConsoleHelper.WriteWithColor("--- All Owners ---", ConsoleColor.Cyan);

            foreach (var drug in drugs)
            {
                ConsoleHelper.WriteWithColor($"Id : {drug.Id} \nName : {drug.Name} \nSurname : {drug.Price} \nSurname : {drug.Count} \nSurname : {drug.Drugstore}", ConsoleColor.Blue);
            }
        }
        public void Create()
        {
            if (_drugstoreRepository.GetAll().Count is 0)
            {
                ConsoleHelper.WriteWithColor("You must create Drugstore first");
            }
            ConsoleHelper.WriteWithColor("Enter name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
        EnterPrice: ConsoleHelper.WriteWithColor("Enter price", ConsoleColor.Cyan);
            int price;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out price);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed price is not correct format", ConsoleColor.Red);
                goto EnterPrice;
            }
            ConsoleHelper.WriteWithColor("Enter Drug count", ConsoleColor.Cyan);
            int count;
            isSucceeded = int.TryParse(Console.ReadLine(), out count);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed count is not correct format", ConsoleColor.Red);
                goto EnterPrice;
            }

            _drugstoreService.GetAll();
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter DrugStore Id");
            int drugstoreId;
            isSucceeded = int.TryParse(Console.ReadLine(), out drugstoreId);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var drugstore = _drugstoreRepository.Get(drugstoreId);
            if (drugstore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var drug = new Drug
            {
                Name = name,
                Price = price,
                Count = count,
               
            };
            drugstore.Drugs.Add(drug);
            _drugRepository.Add(drug);
            ConsoleHelper.WriteWithColor($"Drug successfully created with Name:{drug.Name},Price:{drug.Price},Count:{drug.Count}");


        }
        public void Update()
        {

        EnterIdDesc: GetAll();

         ConsoleHelper.WriteWithColor("Enter ID ", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }

            Drug drug = _drugRepository.Get(id);
            if (drug is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                return;
            }

            ConsoleHelper.WriteWithColor("Enter new drug name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
        EnterPrice: ConsoleHelper.WriteWithColor("Enter new drug price", ConsoleColor.Cyan);   
            int price;
            isSucceeded = int.TryParse(Console.ReadLine(), out price);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed price is not correct format!", ConsoleColor.Red);
                goto EnterPrice;
            }
            ConsoleHelper.WriteWithColor("Enter new drug count", ConsoleColor.Cyan);
            int count;
            isSucceeded = int.TryParse(Console.ReadLine(), out count);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed count is not correct format!", ConsoleColor.Red);
                goto EnterPrice;
            }
            if (count <= 0)
            {
                ConsoleHelper.WriteWithColor("Inputed count must be bigger than 0!", ConsoleColor.Red);
            }

            _drugstoreService.GetAll();
            ConsoleHelper.WriteWithColor("Enter new DrugStore ID");
            int drugStoreid;
            isSucceeded = int.TryParse(Console.ReadLine(), out drugStoreid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var drugStore = _drugstoreRepository.Get(drugStoreid);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto EnterIdDesc;
            }

            drug.Name = name;
            drug.Price = price;
            drug.Count = count;


            drugStore.Drugs.Add(drug);
            _drugRepository.Add(drug);
            ConsoleHelper.WriteWithColor($"{drug.Name}  is succesfully updated", ConsoleColor.Green); 
        }
        public void Delete()
        {
            GetAll();

            if (_drugRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is not any drug", ConsoleColor.Red);
                return;
            }
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter Id ", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }

            Drug Dbdrug = _drugRepository.Get(id);
            if (Dbdrug is null)
            {
                ConsoleHelper.WriteWithColor("There is no owner in this Id", ConsoleColor.Red);
                return;
            }
            _drugRepository.Delete(Dbdrug);
            ConsoleHelper.WriteWithColor("DrugStore is succesfully deleted", ConsoleColor.Green);
        }
        public void GetAllDrugsByDrugstore()
        {
            _drugstoreService.GetAll();
            if (_drugstoreRepository.GetAll().Count == 0)
            {
               
                ConsoleHelper.WriteWithColor("Enter drugstores id", ConsoleColor.Red);
                return;
            }
        drugStoreIdCheck: ConsoleHelper.WriteWithColor("Enter DrugStore ID");
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto drugStoreIdCheck;
            }
            var drugStore = _drugstoreRepository.Get(id);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto drugStoreIdCheck;
            }

            var drugs = _drugRepository.GetAll();
            ConsoleHelper.WriteWithColor("-- All Drugs --");
            if (drugs.Count is 0)
            {
                return;
            }
            foreach (var drug in drugStore.Drugs)
            {
                ConsoleHelper.WriteWithColor($"ID:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}");
            }

        }


    }
   


}
