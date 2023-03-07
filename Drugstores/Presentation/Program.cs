﻿using Core.Constants;
using Core.Contants;
using Core.Helpers;
using Data.Repositories;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using Presentation.Services;

namespace Presentation
{
    public static class Program
    {

        private readonly static OwnerService _ownerService;
        private readonly static DrugstoreService _drugStoreService;
        private readonly static DruggistService _druggistService;
        private readonly static DrugService _drugService;
        private readonly static DrugstoreRepository _drugStoreRepository;
        private readonly static DrugRepository _drugRepository;
        private readonly static AdminService _adminService;

        static Program()
        {
            DbInitializer.SeedAdmins();

            _ownerService = new OwnerService();
            _drugStoreService = new DrugstoreService();
            _druggistService = new DruggistService();
            _drugService = new DrugService();
            _drugStoreRepository = new DrugstoreRepository();
            _drugRepository = new DrugRepository();
            _adminService = new AdminService();

        }
        static void Main()
        {

            ConsoleHelper.WriteWithColor(" --- Welcome --- ", ConsoleColor.DarkCyan);
        MainMenuDesc: ConsoleHelper.WriteWithColor(" Owners", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("2. Drugstores", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("3. Druggists ", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("4. Drugs", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("5. Logout", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("--- Choose option ---", ConsoleColor.DarkCyan);

            int number;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto MainMenuDesc;
            }

            switch (number)
            {
                case (int)MainMenuOptions.Owners:
                    while (true)
                    {
                    OwnerMenuDesc: ConsoleHelper.WriteWithColor("1. Create Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);

                        ConsoleHelper.WriteWithColor("--- Choose option ---", ConsoleColor.DarkCyan);

                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format", ConsoleColor.Red);
                            goto OwnerMenuDesc;
                        }

                        switch (number)
                        {
                            case (int)OwnersOptions.Create:
                                _ownerService.Create();
                                break;
                            case (int)OwnersOptions.Update:
                                _ownerService.Update();
                                break;
                            case (int)OwnersOptions.Delete:
                                _ownerService.Delete();
                                break;
                            case (int)OwnersOptions.GetAll:
                                _ownerService.GetAll();
                                break;
                            case (int)OwnersOptions.MainMenu:
                                goto MainMenuDesc;
                            default:
                                ConsoleHelper.WriteWithColor("Please try again your choise is not correct", ConsoleColor.Red);
                                goto OwnerMenuDesc;
                        }
                    }

                case (int)MainMenuOptions.Drugstores:
                    while (true)
                    {
                    DrugStoreDesc: ConsoleHelper.WriteWithColor("1. Create DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("5. Get all drugstores by owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);


                        ConsoleHelper.WriteWithColor("--- Choose option ---", ConsoleColor.DarkCyan);
                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                            goto DrugStoreDesc;
                        }

                        switch (number)
                        {
                            case (int)DrugstoresOptions.Create:
                                _drugStoreService.Craete();
                                break;

                            case (int)DrugstoresOptions.Update:
                                _drugStoreService.Update();
                                break;

                            case (int)DrugstoresOptions.Delete:
                                _drugStoreService.Delete();
                                break;

                            case (int)DrugstoresOptions.GetAll:
                                _drugStoreService.GetAll();
                                break;
                            case (int)DrugstoresOptions.GetAllDrugstoresByOwner:
                                _drugStoreService.GetAllDrugstoresByOwner();
                                break;

                            case (int)DrugstoresOptions.MainMenu:
                                goto MainMenuDesc;

                        }
                    }

                case (int)MainMenuOptions.Druggists:
                    while (true)
                    {
                    DruggistMenuDesc: ConsoleHelper.WriteWithColor("1. Create Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);

                        ConsoleHelper.WriteWithColor("--- Choose option ---", ConsoleColor.DarkCyan);

                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format", ConsoleColor.Red);
                            goto DruggistMenuDesc;
                        }

                        switch (number)
                        {
                            case (int)DruggistsOptions.Create:
                                _druggistService.Create();
                                break;

                            case (int)DruggistsOptions.Update:
                                _druggistService.Update();
                                break;

                            case (int)DruggistsOptions.Delete:
                                _druggistService.Delete();
                                break;

                            case (int)DruggistsOptions.GetAll:
                                _druggistService.GetAll();
                                break;

                            case (int)DruggistsOptions.MainMenu:
                                goto MainMenuDesc;

                            default:
                                ConsoleHelper.WriteWithColor("Please try again your choise is not correct", ConsoleColor.Red);

                                goto DruggistMenuDesc;
                        }
                    }
                    break;


                case (int)MainMenuOptions.Drugs:
                    while (true)
                    {
                    DrugsMenuDesc: ConsoleHelper.WriteWithColor("1. Create Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);

                        ConsoleHelper.WriteWithColor("--- Choose option ---", ConsoleColor.DarkCyan);

                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format", ConsoleColor.Red);
                            goto DrugsMenuDesc;
                        }

                        switch (number)
                        {
                            case (int)DrugsOptions.Create:
                                break;

                            case (int)DrugsOptions.Update:
                                break;

                            case (int)DrugsOptions.Delete:
                                break;

                            case (int)DrugsOptions.GetAll:
                                break;

                            case (int)DrugsOptions.GetAllDrugsByDrugstore:
                                break;

                            case (int)DrugsOptions.Filter:
                                break;

                            case (int)DrugsOptions.MainMenu:
                                goto DrugsMenuDesc;


                            default:
                                ConsoleHelper.WriteWithColor("Please try again your choise is not correct", ConsoleColor.Red);

                                goto DrugsMenuDesc;
                        }
                    }

                case (int)MainMenuOptions.Logout:
                    break;

                default:
                    ConsoleHelper.WriteWithColor("Please try again your choise is not correct", ConsoleColor.Red);
                    goto MainMenuDesc;
            }
        }
    }
}
