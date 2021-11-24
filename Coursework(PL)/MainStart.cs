using System;
using Coursework_BLL_;
using System.Text.RegularExpressions;

namespace Coursework_PL_
{
    class MainStart
    {
        BLLMain BLLMAIN = new BLLMain();
        static void Main(string[] args)
        {
            MainStart main = new MainStart();
            string chooser;
        MARK_MENU:
            Console.WriteLine("1. Hotel managment");
            Console.WriteLine("2. Client managment");
            chooser = Console.ReadLine();
            switch (chooser)
            {
                case "1":
                    Console.Clear();
                    main.Hotel_Managment();
                    goto MARK_MENU;
                case "2":
                    Console.Clear();
                    main.Client_Managment();
                    goto MARK_MENU;
                default:
                    Console.WriteLine("------------------");
                    Console.WriteLine("Wrong number, try again.");
                    Console.WriteLine("------------------");
                    goto MARK_MENU;
            }
        }

        private void Hotel_Managment()
        {
            BLLMAIN.GetInfoFromFileAboutClients();
            BLLMAIN.GetInfoFromFileAboutHotels();
            string chooser;
            string nameOfHotel;
            int numberOfHotels;
        HOTEL_MANAGMENT_MENU:
            Console.WriteLine("1. Add hotel to list.");
            Console.WriteLine("2. Info about all hotels.");
            Console.WriteLine("3. Delete hotel from list.");
            Console.WriteLine("4. Get more info about hotel.");
            Console.WriteLine("5. Back to menu.");
            chooser = Console.ReadLine();
            switch (chooser)
            {
                case "1":
                    Console.WriteLine("------------------");
                    Console.Write("Input a name of hotel: ");
                    nameOfHotel = Console.ReadLine();
                    int numberOfRooms = BLLMAIN.AddHotel(nameOfHotel);
                    Console.WriteLine($"Hotel {nameOfHotel} with {numberOfRooms} rooms was added.");
                    Console.WriteLine("------------------");
                    goto HOTEL_MANAGMENT_MENU;
                case "2":
                    Console.Clear();
                    Console.WriteLine("------------------");
                    numberOfHotels = BLLMAIN.GetInfoAboutCountOfHotels();
                    if(numberOfHotels != 0)
                    {
                        for (int i = 0; i < numberOfHotels; i++)
                        {
                            nameOfHotel = BLLMAIN.GetNameOfHotel(i);
                            int roomsInHotel = BLLMAIN.GetNumberOfRoomsInHotel(i);
                            Console.WriteLine($"{i + 1}. Hotel {nameOfHotel} with {roomsInHotel} rooms in total");
                        }
                        Console.WriteLine("------------------");
                    }
                    else
                    {
                        Console.WriteLine("You dont have any hotels in list, you need add hotel first");
                        Console.WriteLine("------------------");
                    }
                    goto HOTEL_MANAGMENT_MENU;
                case "3":
                    Console.Clear();
                    Console.WriteLine("------------------");
                    numberOfHotels = BLLMAIN.GetInfoAboutCountOfHotels();
                    if (numberOfHotels != 0)
                    {
                        for (int i = 0; i < numberOfHotels; i++)
                        {
                            nameOfHotel = BLLMAIN.GetNameOfHotel(i);
                            int roomsInHotel = BLLMAIN.GetNumberOfRoomsInHotel(i);
                            Console.WriteLine($"{i + 1}. Hotel {nameOfHotel} with {roomsInHotel} rooms in total");
                        }
                        Console.WriteLine("------------------");
                        MARKDELETE:
                        Console.Write("Choose a hotel you want to delete: ");
                        chooser = Console.ReadLine();
                        if(Convert.ToInt32(chooser) > numberOfHotels || Convert.ToInt32(chooser) < 1)
                        {
                            Console.WriteLine("Number outside of range, try again");
                            goto MARKDELETE;
                        }
                        else
                        {
                            BLLMAIN.DeleteHotel(Convert.ToInt32(chooser));
                        }
                    }
                    else
                    {
                        Console.WriteLine("You dont have any hotels in list, you need add hotel first");
                        Console.WriteLine("------------------");
                    }
                    goto HOTEL_MANAGMENT_MENU;
                case "4":
                    Console.Clear();
                    Console.WriteLine("------------------");
                    numberOfHotels = BLLMAIN.GetInfoAboutCountOfHotels();
                    if (numberOfHotels != 0)
                    {
                        for (int i = 0; i < numberOfHotels; i++)
                        {
                            nameOfHotel = BLLMAIN.GetNameOfHotel(i);
                            int roomsInHotel = BLLMAIN.GetNumberOfRoomsInHotel(i);
                            Console.WriteLine($"{i + 1}. Hotel {nameOfHotel} with {roomsInHotel} rooms in total");
                        }
                        Console.WriteLine("------------------");
                    MARKDELETE:
                        Console.Write("Choose a hotel you want to get more info: ");
                        chooser = Console.ReadLine();
                        if (Convert.ToInt32(chooser) > numberOfHotels || Convert.ToInt32(chooser) < 1)
                        {
                            Console.WriteLine("Number outside of range, try again");
                            goto MARKDELETE;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(BLLMAIN.MoreInfoAboutHotel(Convert.ToInt32(chooser)));
                            Console.WriteLine("------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You dont have any hotels in list, you need add hotel first");
                        Console.WriteLine("------------------");
                    }
                    goto HOTEL_MANAGMENT_MENU;
                case "5":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("------------------");
                    Console.WriteLine("Wrong number, try again.");
                    Console.WriteLine("------------------");
                    goto HOTEL_MANAGMENT_MENU;
            }
        }

        private void Client_Managment()
        {
            BLLMAIN.GetInfoFromFileAboutClients();
            BLLMAIN.GetInfoFromFileAboutHotels();
            string chooser;
            string firstname, lastname, phone;
            int numberOfClients;
            const string regexPhone = @"^([\+]?38[-]?|[0])?[0-9][0-9]{9}$";
        CLIENT_MANAGMENT_MENU:
            Console.WriteLine("1. Add client to list.");
            Console.WriteLine("2. Info about all clients.");
            Console.WriteLine("3. Delete client from list.");
            Console.WriteLine("4. Edit client.");
            Console.WriteLine("5. Back to menu.");
            chooser = Console.ReadLine();
            switch (chooser)
            {
                case "1":
                    Console.WriteLine("------------------");
                    Console.Write("Input a firstname of client: ");
                    firstname = Console.ReadLine();
                    Console.Write("Input a lastname of client: ");
                    lastname = Console.ReadLine();
                MARK_PHONE:
                    bool phoneSame = false;
                    Console.Write("Input a phone of client(example [+380123456789]): ");
                    phone = Console.ReadLine();
                    if(Regex.IsMatch(phone, regexPhone))
                    {
                        numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                        for (int i = 0; i < numberOfClients; i++)
                        {
                            if(BLLMAIN.GetPhoneOfClients(i) == phone)
                            {
                                phoneSame = true;
                            }
                        }
                        if (phoneSame)
                        {
                            Console.WriteLine("Phone the same as in other client, input other.");
                            goto MARK_PHONE;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Number is not right, try again.");
                        goto MARK_PHONE;
                    }
                    BLLMAIN.AddClient(firstname, lastname, phone);
                    Console.WriteLine("------------------");
                    goto CLIENT_MANAGMENT_MENU;
                case "2":
                    Console.Clear();
                    Console.WriteLine("------------------");
                    numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                    if (numberOfClients != 0)
                    {
                        for (int i = 0; i < numberOfClients; i++)
                        {
                            firstname = BLLMAIN.GetFirstnameOfClients(i);
                            lastname = BLLMAIN.GetLastnameOfClients(i);
                            phone = BLLMAIN.GetPhoneOfClients(i);
                            Console.WriteLine($"{i + 1}. {firstname} {lastname}: {phone}");
                        }
                        Console.WriteLine("------------------");
                    }
                    else
                    {
                        Console.WriteLine("You dont have any clients in list, you need add client first");
                        Console.WriteLine("------------------");
                    }
                    goto CLIENT_MANAGMENT_MENU;
                case "3":
                    Console.Clear();
                    Console.WriteLine("------------------");
                    numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                    if (numberOfClients != 0)
                    {
                        for (int i = 0; i < numberOfClients; i++)
                        {
                            firstname = BLLMAIN.GetFirstnameOfClients(i);
                            lastname = BLLMAIN.GetLastnameOfClients(i);
                            phone = BLLMAIN.GetPhoneOfClients(i);
                            Console.WriteLine($"{i + 1}. {firstname} {lastname}: {phone}");
                        }
                        Console.WriteLine("------------------");
                    MARKDELETE:
                        Console.Write("Choose a client you want to delete: ");
                        chooser = Console.ReadLine();
                        if (Convert.ToInt32(chooser) > numberOfClients || Convert.ToInt32(chooser) < 1)
                        {
                            Console.WriteLine("Number outside of range, try again");
                            goto MARKDELETE;
                        }
                        else
                        {
                            BLLMAIN.DeleteClient(Convert.ToInt32(chooser));
                            Console.WriteLine("------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You dont have any clients in list, you need add client first");
                        Console.WriteLine("------------------");
                    }
                    goto CLIENT_MANAGMENT_MENU;
                case "4":
                    Console.Clear();
                    Console.WriteLine("------------------");
                    numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                    if (numberOfClients != 0)
                    {
                        for (int i = 0; i < numberOfClients; i++)
                        {
                            firstname = BLLMAIN.GetFirstnameOfClients(i);
                            lastname = BLLMAIN.GetLastnameOfClients(i);
                            phone = BLLMAIN.GetPhoneOfClients(i);
                            Console.WriteLine($"{i + 1}. {firstname} {lastname}: {phone}");
                        }
                        Console.WriteLine("------------------");
                    MARKEDIT:
                        Console.Write("Choose a client you want to edit: ");
                        chooser = Console.ReadLine();
                        if (Convert.ToInt32(chooser) > numberOfClients || Convert.ToInt32(chooser) < 1)
                        {
                            Console.WriteLine("Number outside of range, try again");
                            goto MARKEDIT;
                        }
                        else
                        {
                            int clientChooser = Convert.ToInt32(chooser);
                            Console.WriteLine("------------------");
                        MARK_SELECT_EDIT:
                            Console.WriteLine("What you want to edit?");
                            Console.WriteLine("1. Firstname of client.");
                            Console.WriteLine("2. Lastname of client.");
                            Console.WriteLine("3. Phone of client.");
                            chooser = Console.ReadLine();

                            switch (chooser)
                            {
                                case "1":
                                    Console.Write("Input a firstname of client: ");
                                    firstname = Console.ReadLine();
                                    BLLMAIN.EditInfoAboutClient("1", firstname, clientChooser);
                                    break;
                                case "2":
                                    Console.Write("Input a lastname of client: ");
                                    lastname = Console.ReadLine();
                                    BLLMAIN.EditInfoAboutClient("2", lastname, clientChooser);
                                    break;
                                case "3":
                                MARK_PHONE_SECOND:
                                    bool phoneSameSECOND = false;
                                    Console.Write("Input a phone of client(example [+380123456789]): ");
                                    phone = Console.ReadLine();
                                    if (Regex.IsMatch(phone, regexPhone))
                                    {
                                        numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                                        for (int i = 0; i < numberOfClients; i++)
                                        {
                                            if (BLLMAIN.GetPhoneOfClients(i) == phone)
                                            {
                                                phoneSameSECOND = true;
                                            }
                                        }
                                        if (phoneSameSECOND)
                                        {
                                            Console.WriteLine("Phone the same as in other client, input other.");
                                            goto MARK_PHONE_SECOND;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Number is not right, try again.");
                                        goto MARK_PHONE_SECOND;
                                    }
                                    BLLMAIN.EditInfoAboutClient("3", phone, clientChooser);
                                    break;
                                default:
                                    Console.WriteLine("Number is not right, try again");
                                    goto MARK_SELECT_EDIT;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You dont have any clients in list, you need add client first");
                        Console.WriteLine("------------------");
                    }
                    goto CLIENT_MANAGMENT_MENU;
                case "5":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("------------------");
                    Console.WriteLine("Wrong number, try again.");
                    Console.WriteLine("------------------");
                    goto CLIENT_MANAGMENT_MENU;
            }
        }


    }
}
