using System;
using Coursework_BLL_;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Coursework_PL_
{
    class MainStart
    {
        BLLMain BLLMAIN = new BLLMain();
        EXCEPTION_FOR_PL exceptionForPL = new EXCEPTION_FOR_PL();
        static void Main(string[] args)
        {
            MainStart main = new MainStart();
            string chooser;
            bool forWhile = true;
            while (forWhile)
            {
                Console.WriteLine("1. Hotel managment.");
                Console.WriteLine("2. Client managment.");
                Console.WriteLine("3. Order managment.");
                Console.WriteLine("4. End program.");
                chooser = Console.ReadLine();
                switch (chooser)
                {
                    case "1":
                        Console.Clear();
                        main.Hotel_Managment();
                        break;
                    case "2":
                        Console.Clear();
                        main.Client_Managment();
                        break;
                    case "3":
                        Console.Clear();
                        main.Order_Managment();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Session ended.");
                        forWhile = !forWhile;
                        break;
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong number, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }

        private void Hotel_Managment()
        {
            BLLMAIN.GetInfoFromFileAboutClients();
            BLLMAIN.GetInfoFromFileAboutHotels();
            BLLMAIN.GetInfoFromFileAboutOrders();
            string chooser;
            string nameOfHotel = "";
            int numberOfHotels;
            int priceForOneNight = 0;
            bool forWhile = true;
            while (forWhile)
            {
                Console.WriteLine("1. Add hotel to list.");
                Console.WriteLine("2. Info about all hotels.");
                Console.WriteLine("3. Delete hotel from list.");
                Console.WriteLine("4. Get more info about hotel.");
                Console.WriteLine("5. Back to menu.");
                chooser = Console.ReadLine();
                switch (chooser)
                {
                    case "1":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            bool MARK_CHECK_NAME_HOTEL = true;
                            bool MARK_PRICE_FOR_ONE = true;
                            bool symbol = false;
                            while (MARK_CHECK_NAME_HOTEL)
                            {
                                Console.Write("Input a name of hotel(if you want cancel adding write symbol /): ");
                                nameOfHotel = Console.ReadLine();
                                if(nameOfHotel != "/")
                                {
                                    if (BLLMAIN.GetInfoAboutCountOfHotels() == 0)
                                    {
                                        MARK_CHECK_NAME_HOTEL = false;
                                    }
                                    for (int i = 0; i < BLLMAIN.GetInfoAboutCountOfHotels(); i++)
                                    {
                                        if (BLLMAIN.GetNameOfHotel(i) == nameOfHotel)
                                        {
                                            Console.WriteLine("The hotel with this name exist, try another name.");
                                        }
                                        else
                                        {
                                            MARK_CHECK_NAME_HOTEL = false;
                                        }
                                    }
                                }
                                else 
                                {
                                    symbol = true;
                                    MARK_CHECK_NAME_HOTEL = false;
                                    MARK_PRICE_FOR_ONE = false;
                                }
                            }
                            while (MARK_PRICE_FOR_ONE)
                            {
                                bool Error = false;
                                Console.Write("Input a price of hotel for one people for one night(if you want cancel adding write symbol /): ");
                                chooser = Console.ReadLine();
                                if (chooser != "/")
                                {
                                    try
                                    {
                                        priceForOneNight = Convert.ToInt32(chooser);
                                    }
                                    catch(Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                        Error = true;
                                    }
                                    if (!Error)
                                    {
                                        MARK_PRICE_FOR_ONE = false;
                                    }
                                }
                                else
                                {
                                    symbol = true;
                                    MARK_PRICE_FOR_ONE = false;
                                }
                            }
                            if (symbol)
                            {
                                Console.Clear();
                                Console.WriteLine("You cancel adding.");
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                int numberOfRooms = BLLMAIN.AddHotel(nameOfHotel, priceForOneNight);
                                Console.WriteLine($"Hotel {nameOfHotel} with {numberOfRooms} rooms was added.");
                                Console.WriteLine("------------------");
                            }
                        } break;///ADD HOTEL TO LIST
                    case "2":{
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
                            }
                            else
                            {
                                Console.WriteLine("You dont have any hotels in list, you need add hotel first");
                                Console.WriteLine("------------------");
                            }
                        } break;///INFO ABOUT ALL HOTELS
                    case "3":{
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
                                bool MARK_DELETE = true;
                                while (MARK_DELETE)
                                {
                                    Console.Write("Choose a hotel you want to delete(if you want cancel write symbol /): ");
                                    chooser = Console.ReadLine();
                                    int deleteInt = 0;
                                    bool check = true;
                                    if(chooser != "/")
                                    {
                                        try
                                        {
                                            deleteInt = Convert.ToInt32(chooser);
                                        }
                                        catch (Exception e)
                                        {
                                            exceptionForPL.InputNumberAreWrong(e);
                                            check = false;
                                        }
                                        if (check)
                                        {
                                            if (deleteInt > numberOfHotels || deleteInt < 1)
                                            {
                                                Console.WriteLine("Number outside of range, try again");
                                            }
                                            else
                                            {
                                                BLLMAIN.DeleteHotel(deleteInt);
                                                MARK_DELETE = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You cancel deleting.");
                                        Console.WriteLine("------------------");
                                        MARK_DELETE = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any hotels in list, you need add hotel first");
                                Console.WriteLine("------------------");
                            }
                        } break;///DELETE HOTEL FROM LIST
                    case "4":{
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
                                bool MARK_CHOOSE_HOTEL = true;
                                while (MARK_CHOOSE_HOTEL)
                                {
                                    Console.Write("Choose a hotel you want to get more info(if you want cancel write symbol /): ");
                                    chooser = Console.ReadLine();
                                    int intInfo = 0;
                                    bool check = true;
                                    if (chooser != "/")
                                    {
                                        try
                                        {
                                            intInfo = Convert.ToInt32(chooser);
                                        }
                                        catch (Exception e)
                                        {
                                            exceptionForPL.InputNumberAreWrong(e);
                                            check = false;
                                        }
                                        if (check)
                                        {
                                            if (intInfo > numberOfHotels || intInfo < 1)
                                            {
                                                Console.WriteLine("Number outside of range, try again");
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine(BLLMAIN.MoreInfoAboutHotel(Convert.ToInt32(chooser)));
                                                Console.WriteLine("------------------");
                                                MARK_CHOOSE_HOTEL = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You cancel getting info.");
                                        Console.WriteLine("------------------");
                                        MARK_CHOOSE_HOTEL = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any hotels in list, you need add hotel first");
                                Console.WriteLine("------------------");
                            }
                        } break;///GET MORE INFO ABOUNT HOTEL
                    case "5":{
                            Console.Clear();
                            forWhile = false;
                        } break;///BACK TO MENU
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong number, try again.");
                        Console.WriteLine("------------------");
                        break;
                }       
            }
        }

        private void Client_Managment()
        {
            BLLMAIN.GetInfoFromFileAboutClients();
            BLLMAIN.GetInfoFromFileAboutHotels();
            BLLMAIN.GetInfoFromFileAboutOrders();
            string chooser;
            string firstname, lastname, phone = "";
            int numberOfClients;
            int numberOfOrders;
            const string regexPhone = @"^([\+]?38[-]?|[0])?[0-9][0-9]{9}$";
            bool forWhile = true;
            while (forWhile)
            {
                Console.WriteLine("1. Add client to list.");
                Console.WriteLine("2. Info about all clients.");
                Console.WriteLine("3. Delete client from list.");
                Console.WriteLine("4. Edit client.");
                Console.WriteLine("5. Sort clients for lastname.");
                Console.WriteLine("6. Sort clients for firstname.");
                Console.WriteLine("7. Get more info about client.");
                Console.WriteLine("8. Back to menu.");
                chooser = Console.ReadLine();
                switch (chooser)
                {
                    case "1":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.Write("Input a firstname of client(if you want cancel adding write symbol /): ");
                            firstname = Console.ReadLine();
                            if(firstname == "/")
                            {
                                Console.Clear();
                                Console.WriteLine("You canceled adding.");
                                break;
                            }
                            Console.Write("Input a lastname of client(if you want cancel adding write symbol /): ");
                            lastname = Console.ReadLine();
                            if(lastname == "/")
                            {
                                Console.Clear();
                                Console.WriteLine("You canceled adding.");
                                break;
                            }
                            bool forWhileSecond = true;
                            while (forWhileSecond)
                            {
                                bool phoneSame = false;
                                Console.Write("Input a phone of client(example [+380123456789]) (if you want cancel write symbol /): ");
                                phone = Console.ReadLine();
                                if(phone == "/")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled addinng.");
                                    break;
                                }
                                if (Regex.IsMatch(phone, regexPhone))
                                {
                                    numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                                    for (int i = 0; i < numberOfClients; i++)
                                    {
                                        if (BLLMAIN.GetPhoneOfClients(i) == phone)
                                        {
                                            phoneSame = true;
                                        }
                                    }
                                    if (phoneSame)
                                    {
                                        Console.WriteLine("Phone the same as in other client, input other.");
                                    }
                                    else
                                    {
                                        BLLMAIN.AddClient(firstname, lastname, phone);
                                        forWhileSecond = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Number is not right, try again.");
                                }
                            }
                            Console.WriteLine("------------------");
                        } break;///ADD CLIENT TO LIST
                    case "2":{
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
                        } break;///INFO ABOUT ALL CLIENTS
                    case "3":{
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
                                bool forWhileS = true;
                                while (forWhileS)
                                {
                                    Console.Write("Choose a client you want to delete(if you want cancel write symbol /): ");
                                    chooser = Console.ReadLine();
                                    int intDel = 0;
                                    bool check = true;
                                    if(chooser == "/")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled deleting.");
                                        break;
                                    }

                                    try
                                    {
                                        intDel = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                        check = false;
                                    }

                                    if (check)
                                    {
                                        if (intDel > numberOfClients || intDel < 1)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            forWhileS = false;
                                            BLLMAIN.DeleteClient(intDel);
                                            Console.WriteLine("------------------");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any clients in list, you need add client first");
                                Console.WriteLine("------------------");
                            }
                        } break;///DELETE CLIENT FROM LIST
                    case "4":{
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
                                bool forWhileS = true;
                                while (forWhileS)
                                {
                                    bool test = true;
                                    Console.Write("Choose a client you want to edit(if you want cancel write symbol /): ");
                                    chooser = Console.ReadLine();
                                    int clientEdit = 0;
                                    if(chooser == "/")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled editing.");
                                        break;
                                    }

                                    try
                                    {
                                        clientEdit = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                        test = false;
                                    }
                                    if (test)
                                    {
                                        if (clientEdit > numberOfClients || clientEdit < 1)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            int clientChooser = Convert.ToInt32(chooser);
                                            Console.WriteLine("------------------");
                                            bool forWhileSS = true;
                                            while (forWhileSS)
                                            {
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
                                                        forWhileS = false;
                                                        forWhileSS = false;
                                                        Console.Clear();
                                                        break;
                                                    case "2":
                                                        Console.Write("Input a lastname of client: ");
                                                        lastname = Console.ReadLine();
                                                        BLLMAIN.EditInfoAboutClient("2", lastname, clientChooser);
                                                        forWhileS = false;
                                                        forWhileSS = false;
                                                        Console.Clear();
                                                        break;
                                                    case "3":
                                                        bool forWhileSSS = true;
                                                        while (forWhileSSS)
                                                        {
                                                            bool phoneSameSECOND = false;
                                                            Console.Write("Input a phone of client(example [+380123456789]): ");
                                                            phone = Console.ReadLine();
                                                            if (Regex.IsMatch(phone, regexPhone))
                                                            {
                                                                numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                                                                for (int i = 0; i < numberOfClients; i++)
                                                                {
                                                                    if (BLLMAIN.GetPhoneOfClients(i) == phone && clientChooser - 1 != i)
                                                                    {
                                                                        phoneSameSECOND = true;
                                                                    }
                                                                }
                                                                if (phoneSameSECOND)
                                                                {
                                                                    Console.WriteLine("Phone the same as in other client, input other.");
                                                                }
                                                                else
                                                                {
                                                                    forWhileSSS = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Number is not right, try again.");
                                                            }
                                                        }
                                                        BLLMAIN.EditInfoAboutClient("3", phone, clientChooser);
                                                        forWhileS = false;
                                                        forWhileSS = false;
                                                        Console.Clear();
                                                        break;
                                                    default:
                                                        Console.WriteLine("Number is not right, try again");
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                  
                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any clients in list, you need add client first");
                                Console.WriteLine("------------------");
                            }
                        } break;///EDIT CLIENT
                    case "5":{
                            BLLMAIN.SortClientsForLastname();
                            Console.Clear();
                            Console.WriteLine("Clients was sorted for lastname");
                            Console.WriteLine("------------------");
                        } break;///SORT CLIENTS LASTNAMES
                    case "6":{
                            BLLMAIN.SortClientsForFirstname();
                            Console.Clear();
                            Console.WriteLine("Clients was sorted for firstname");
                            Console.WriteLine("------------------");
                        } break;///SORT CLIENTS FIRSTNAMES
                    case "7":{
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
                                bool forWhileS = true;
                                while (forWhileS)
                                {
                                    bool test = true;
                                    Console.Write("Choose a client you want to edit(if you want cancel write symbol /): ");
                                    chooser = Console.ReadLine();
                                    int clientEdit = 0;
                                    if (chooser == "/")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You canceled editing.");
                                        break;
                                    }

                                    try
                                    {
                                        clientEdit = Convert.ToInt32(chooser);
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                        test = false;
                                    }
                                    if (test)
                                    {
                                        if (clientEdit > numberOfClients || clientEdit < 1)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            int clientChooser = Convert.ToInt32(chooser);
                                            bool nullEqual = true;
                                            clientChooser--;
                                            Console.WriteLine("------------------");
                                            firstname = BLLMAIN.GetFirstnameOfClients(clientChooser);
                                            lastname = BLLMAIN.GetLastnameOfClients(clientChooser);
                                            phone = BLLMAIN.GetPhoneOfClients(clientChooser);
                                            Console.WriteLine($"Client: {firstname} {lastname}: {phone};");
                                            Console.WriteLine($"Orders on this client:");
                                            numberOfOrders = BLLMAIN.GetInfoAboutCountOfOrders();
                                            if (numberOfOrders != 0)
                                            {
                                                for (int i = 0; i < numberOfOrders; i++)
                                                {
                                                    if (phone == BLLMAIN.GetPhoneFromOrder(i))
                                                    {
                                                        nullEqual = false;
                                                        string client = BLLMAIN.GetClientFromOrder(i);
                                                        string hotel = BLLMAIN.GetHotelFromOrder(i);
                                                        int days = BLLMAIN.GetDaysInOrder(i);
                                                        Console.WriteLine($"Order#{i + 1}: Hotel {hotel}; Client {client}; {days} days long.");
                                                    }
                                                }
                                                if (nullEqual)
                                                {
                                                    Console.WriteLine("This clients doesnt order anything.");
                                                }
                                                Console.WriteLine("------------------");
                                            }
                                            else
                                            {
                                                Console.WriteLine("You dont have any orders in list, you need add order first");
                                                Console.WriteLine("------------------");
                                            }
                                            forWhileS = false;
                                        }
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any clients in list, you need add client first");
                                Console.WriteLine("------------------");
                            }
                        } break;///GET MORE INFO ABOUT CLIENT
                    case "8":{
                            Console.Clear();
                            forWhile = false;
                        } break;///BACK TO MENU
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong number, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }

        private void Order_Managment()
        {
            BLLMAIN.GetInfoFromFileAboutClients();
            BLLMAIN.GetInfoFromFileAboutHotels();
            BLLMAIN.GetInfoFromFileAboutOrders();
            string chooser;
            string nameOfHotel, firstname, lastname, phone;
            int numberOfHotels, numberOfClients, numberOfOrders, chooserClient = 0, chooserHotel = 0, numbersOfRoomsToOrder = 0;
            int roomForOne = 0, roomForTwo = 0, roomForThree = 0;
            DateTime DateIn = DateTime.MinValue;
            DateTime DateOut = DateTime.MinValue;
            bool ORDER_MANAGMENT_MENU = true;
            bool[] whichHotelToChoose;
            string stringAddInfo = "";
            bool test = true;
            bool breakfast = false;
            int[] PlaceInRoom;
            bool cancel = false;
            while (ORDER_MANAGMENT_MENU)
            {
                Console.WriteLine("1. Add order to list.");
                Console.WriteLine("2. Info about all orders.");
                Console.WriteLine("3. Delete order from list.");
                Console.WriteLine("4. Get more info about order.");
                Console.WriteLine("5. Find orders in certain termin.");
                Console.WriteLine("6. Get info about clients that made a order.");
                Console.WriteLine("7. Edit additional info in order");
                Console.WriteLine("8. Back to menu.");
                chooser = Console.ReadLine();
                switch (chooser)
                {
                    case "1":{
                            cancel = false;
                            Console.Clear();
                            //TEST FOR COUNTS HOTELS AND CLIENTS
                            {
                                if (BLLMAIN.GetInfoAboutCountOfClients() == 0 && BLLMAIN.GetInfoAboutCountOfHotels() == 0)
                                {
                                    Console.WriteLine("------------------");
                                    Console.WriteLine("Before making order, you must add client and hotel to lists");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                                if (BLLMAIN.GetInfoAboutCountOfClients() == 0)
                                {
                                    Console.WriteLine("------------------");
                                    Console.WriteLine("Before making order, you must add client to list.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                                if (BLLMAIN.GetInfoAboutCountOfHotels() == 0)
                                {
                                    Console.WriteLine("------------------");
                                    Console.WriteLine("Before making order, you must add hotel to list.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //CHOOSE A CLIENT
                            {
                                Console.WriteLine("------------------");
                                Console.WriteLine("Choose which client, want to make order(if you want cancel write symbol /):");
                                numberOfClients = BLLMAIN.GetInfoAboutCountOfClients();
                                for (int i = 0; i < numberOfClients; i++)
                                {
                                    firstname = BLLMAIN.GetFirstnameOfClients(i);
                                    lastname = BLLMAIN.GetLastnameOfClients(i);
                                    phone = BLLMAIN.GetPhoneOfClients(i);
                                    Console.WriteLine($"{i + 1}. {firstname} {lastname}: {phone}");
                                }
                                bool MARK_CHOOSE_CLIENT = true;
                                while (MARK_CHOOSE_CLIENT)
                                {
                                    chooser = Console.ReadLine();
                                    int intClient;
                                    bool testM = true;
                                    if(chooser == "/")
                                    {
                                        cancel = true;
                                        break;
                                    }
                                    try
                                    {
                                        intClient = Convert.ToInt32(chooser);
                                    }
                                    catch(Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                        testM = false;
                                    }
                                    if (testM)
                                    {
                                        if (Convert.ToInt32(chooser) > numberOfClients || Convert.ToInt32(chooser) < 1)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            chooserClient = Convert.ToInt32(chooser);
                                            Console.WriteLine("------------------");
                                            break;
                                        }
                                    }
                                }
                                if (cancel)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding order.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //INPUT A NUMBER OF ROOMS TO ORDER
                            {
                                bool MARK_CHOOSE_NUMBER_ROOM = true;
                                while (MARK_CHOOSE_NUMBER_ROOM)
                                {
                                    Console.WriteLine("Input how many rooms you want to order(in number type)(if you want cancel adding write symbol /):");
                                    string stringRoom = Console.ReadLine();
                                    if(stringRoom == "/")
                                    {
                                        cancel = true;
                                        break;
                                    }
                                    try
                                    {
                                        numbersOfRoomsToOrder = Convert.ToInt32(stringRoom);
                                        test = true;
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                        test = false;
                                    }
                                    if (test)
                                    {
                                        Console.WriteLine("------------------");
                                        break;
                                    }
                                }
                                if (cancel)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding order.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //INPUT A PLACE IN ROOMS FOR HOW MANY PEOPLE
                            {
                                PlaceInRoom = new int[numbersOfRoomsToOrder];
                                for (int i = 0; i < numbersOfRoomsToOrder; i++)
                                {
                                    Console.WriteLine($"Input how many people in room#{i + 1}");
                                    bool MARK_PLACE_IN_ROOM = true;
                                    test = true;
                                    while (MARK_PLACE_IN_ROOM)
                                    {
                                        Console.Write($"Input a number in range 1-3 of people in room#{i + 1}(in number type): ");
                                        int place = 0;
                                        try
                                        {
                                            place = Convert.ToInt32(Console.ReadLine());
                                            test = true;
                                        }
                                        catch (Exception e)
                                        {
                                            exceptionForPL.InputNumberAreWrong(e);
                                            test = false;
                                        }
                                        if (test)
                                        {
                                            if (place >= 1 && place <= 3)
                                            {
                                                switch (place)
                                                {
                                                    case 1:
                                                        roomForOne++;
                                                        break;
                                                    case 2:
                                                        roomForTwo++;
                                                        break;
                                                    case 3:
                                                        roomForThree++;
                                                        break;
                                                }
                                                MARK_PLACE_IN_ROOM = false;
                                                PlaceInRoom[i] = place;
                                                Console.WriteLine("------------------");
                                            }
                                            else
                                            {
                                                Console.WriteLine("This number is not in range 1-3, try again");
                                                Console.WriteLine("------------------");
                                            }
                                        }
                                    }
                                }
                            }
                            //INPUT BREAKFAST OR NOT
                            {
                                bool MARK_BREAKFAST = true;
                                while (MARK_BREAKFAST)
                                {
                                    Console.WriteLine("Input: 1.if you want include breakfast(price will be multiply by 2), 2.if does not(if you want cancel adding write symbol /):");
                                    string stringChoose = Console.ReadLine();
                                    switch (stringChoose)
                                    {
                                        case "1":
                                            breakfast = true;
                                            MARK_BREAKFAST = false;
                                            break;
                                        case "2":
                                            breakfast = false;
                                            MARK_BREAKFAST = false;
                                            break;
                                        case "/":
                                            cancel = true;
                                            MARK_BREAKFAST = false;
                                            break;
                                        default:
                                            Console.WriteLine("Symbol doesnt right, try again.");
                                            break;
                                    }
                                }
                                if (cancel)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding order.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //ANALYZE WHICH HOTEL TO CHOOSE
                            {
                                bool MARK_CHOOSE_HOTEL = true;
                                while (MARK_CHOOSE_HOTEL)
                                {
                                    Console.WriteLine("Input which hotel, client want to choose(if you want cancel adding write symbol /):");
                                    numberOfHotels = BLLMAIN.GetInfoAboutCountOfHotels();
                                    whichHotelToChoose = new bool[numberOfHotels];
                                    for (int i = 0; i < numberOfHotels; i++)
                                    {
                                        nameOfHotel = BLLMAIN.GetNameOfHotel(i);
                                        int price = BLLMAIN.GetPriceForOneNight(i);
                                        if (BLLMAIN.AnalyzeIfHotelHaveRooms(i, roomForOne, roomForTwo, roomForThree))
                                        {
                                            Console.WriteLine($"{i + 1}. Hotel {nameOfHotel}: price for one night for one person {price} uah");
                                            whichHotelToChoose[i] = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{i + 1}. Hotel {nameOfHotel}, NOT AVAILABLE FOR YOUR ORDER");
                                            whichHotelToChoose[i] = false;
                                        }
                                    }

                                    bool tester = true;
                                    string stringHotel = Console.ReadLine();
                                    if(stringHotel == "/")
                                    {
                                        cancel = true;
                                        break;
                                    }
                                    try
                                    {
                                        chooserHotel = Convert.ToInt32(stringHotel);
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                        tester = false;
                                    }
                                    if (tester)
                                    {
                                        if (chooserHotel > numberOfHotels || chooserHotel < 1)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Number outside of range, try again");
                                            Console.WriteLine("------------------");
                                        }
                                        else
                                        {
                                            if (whichHotelToChoose[chooserHotel - 1])
                                            {
                                                MARK_CHOOSE_HOTEL = false;
                                                Console.WriteLine("------------------");
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("This hotel not available for your order try another");
                                                Console.WriteLine("------------------");
                                            }
                                        }
                                    }
                                }
                                if (cancel)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding order.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //INPUT FOR HOW LONG TO STAY
                            {
                                string dateIn = "";
                                string dateOut = "";
                                string pattern = "dd/MM/yyyy";

                                DateTime DateMinimum;
                                DateTime.TryParseExact("01/01/2022", pattern, null, DateTimeStyles.None, out DateMinimum);


                                bool MARK_WRITE_DATE_IN_OUT = true;
                                while (MARK_WRITE_DATE_IN_OUT)
                                {
                                    bool MARK_WRITE_DATE_IN = true;
                                    while (MARK_WRITE_DATE_IN)
                                    {
                                        Console.Write("Input a date IN(example: 01/01/2022) start begin from 01/01/2022(if you want cancel write symbol /): ");
                                        dateIn = Console.ReadLine();
                                        if(dateIn == "/")
                                        {
                                            cancel = true;
                                            break;
                                        }
                                        if (DateTime.TryParseExact(dateIn, pattern, null, DateTimeStyles.None, out DateIn))
                                        {
                                            if (DateIn < DateMinimum)
                                            {
                                                Console.WriteLine("This date was before 01/01/2022, try again.");
                                            }
                                            else
                                            {
                                                MARK_WRITE_DATE_IN = false;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Unable input for this pattern, try again");
                                        }
                                    }

                                    bool MARK_WRITE_DATE_OUT = true;
                                    if (!cancel)
                                    {
                                        while (MARK_WRITE_DATE_OUT)
                                        {
                                            Console.Write("Input a date OUT(example: 01/01/2022) it must be after date IN(if you want cancel write symbol /): ");
                                            dateOut = Console.ReadLine();
                                            if(dateOut == "/")
                                            {
                                                cancel = true;
                                                break;
                                            }
                                            if (DateTime.TryParseExact(dateOut, pattern, null, DateTimeStyles.None, out DateOut))
                                            {
                                                if (DateIn > DateOut)
                                                {
                                                    Console.WriteLine("This date before date IN, try again.");
                                                }
                                                else if (DateIn == DateOut)
                                                {
                                                    Console.WriteLine("This date equal date IN, try again.");
                                                }
                                                else
                                                {
                                                    MARK_WRITE_DATE_OUT = false;
                                                    MARK_WRITE_DATE_IN_OUT = false;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Unable input for this pattern, try again");
                                            }
                                        }
                                    }
                                    if (cancel)
                                    {
                                        break;
                                    }
                                }
                                if (cancel)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding order.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            //INPUT ADDITIONAL INFO FROM CLIENT
                            {
                                Console.WriteLine("------------------");
                                bool MARK_CHOOSE_ADD_INFO = true;
                                while (MARK_CHOOSE_ADD_INFO)
                                {
                                    Console.WriteLine("Input additional text from client(if you want cancel adding write symbol /)(if you do not write anything write symbol *):");
                                    stringAddInfo = Console.ReadLine();
                                    if(stringAddInfo.Length != 0)
                                    {
                                        switch (stringAddInfo)
                                        {
                                            case "/":
                                                cancel = true;
                                                MARK_CHOOSE_ADD_INFO = false;
                                                break;
                                            case "*":
                                                stringAddInfo = "";
                                                MARK_CHOOSE_ADD_INFO = false;
                                                break;
                                            default:
                                                MARK_CHOOSE_ADD_INFO = false;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You write nothing, try again.");
                                    }
                                }
                                if (cancel)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You canceled adding order.");
                                    Console.WriteLine("------------------");
                                    break;
                                }
                            }
                            BLLMAIN.AddOrder(chooserClient - 1, chooserHotel - 1, roomForOne, roomForTwo, roomForThree, DateIn, DateOut, breakfast, stringAddInfo);
                            Console.Clear();
                        } break;///ADD ORDER TO LIST
                    case "2":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfOrders = BLLMAIN.GetInfoAboutCountOfOrders();
                            if (numberOfOrders != 0)
                            {
                                for (int i = 0; i < numberOfOrders; i++)
                                {
                                    string client = BLLMAIN.GetClientFromOrder(i);
                                    string hotel = BLLMAIN.GetHotelFromOrder(i);
                                    int days = BLLMAIN.GetDaysInOrder(i);
                                    Console.WriteLine($"Order#{i + 1}: Hotel {hotel}; Client {client}; {days} days long.");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any orders in list, you need add order first");
                                Console.WriteLine("------------------");
                            }
                        } break;///INFO ABOUT ALL ORDERS
                    case "3":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfOrders = BLLMAIN.GetInfoAboutCountOfOrders();
                            if (numberOfOrders != 0)
                            {
                                for (int i = 0; i < numberOfOrders; i++)
                                {
                                    string client = BLLMAIN.GetClientFromOrder(i);
                                    string hotel = BLLMAIN.GetHotelFromOrder(i);
                                    int days = BLLMAIN.GetDaysInOrder(i);
                                    Console.WriteLine($"Order#{i + 1}: Hotel {hotel}; Client {client}; {days} days long.");
                                }
                                Console.WriteLine("------------------");
                                bool MARK_DELETE = true;
                                while (MARK_DELETE)
                                {
                                    Console.Write("Choose a order you want to delete(if you want cancel deleting write symbol /): ");
                                    chooser = Console.ReadLine();
                                    if(chooser == "/")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You cancel deleting.");
                                        Console.WriteLine("------------------");
                                        break;
                                    }
                                    try
                                    {
                                        if (Convert.ToInt32(chooser) > numberOfOrders || Convert.ToInt32(chooser) < 1)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            BLLMAIN.DeleteOrder(Convert.ToInt32(chooser));
                                            MARK_DELETE = false;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any orders in list, you need add order first");
                                Console.WriteLine("------------------");
                            }
                        } break;///DELETE ORDER DROM LIST
                    case "4":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfOrders = BLLMAIN.GetInfoAboutCountOfOrders();
                            if (numberOfOrders != 0)
                            {
                                for (int i = 0; i < numberOfOrders; i++)
                                {
                                    string client = BLLMAIN.GetClientFromOrder(i);
                                    string hotel = BLLMAIN.GetHotelFromOrder(i);
                                    int days = BLLMAIN.GetDaysInOrder(i);
                                    Console.WriteLine($"Order#{i + 1}: Hotel {hotel}; Client {client}; {days} days long.");
                                }
                                Console.WriteLine("------------------");
                                bool MARK_DELETE = true;
                                while (MARK_DELETE)
                                {
                                    Console.Write("Choose a order you want to get more info(if you want cancel write symbol /): ");
                                    chooser = Console.ReadLine();
                                    if(chooser == "/")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You cancel action get more info.");
                                        Console.WriteLine("------------------");
                                        break;
                                    }
                                    try
                                    {
                                        if (Convert.ToInt32(chooser) > numberOfOrders || Convert.ToInt32(chooser) < 1)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine(BLLMAIN.GetMoreInfoAboutOrder(Convert.ToInt32(chooser)));
                                            Console.WriteLine("------------------");
                                            MARK_DELETE = false;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any orders in list, you need add order first");
                                Console.WriteLine("------------------");
                            }
                        } break;///GET MORE INFO ABOUT ORDER             
                    case "5":{
                            Console.Clear();
                            string dateInTemp = "";
                            string dateOutTemp = "";
                            string patternTemp = "dd/MM/yyyy";

                            DateTime DateMinimumTemp;
                            DateTime.TryParseExact("01/01/2022", patternTemp, null, DateTimeStyles.None, out DateMinimumTemp);


                            bool MARK_WRITE_DATE_IN_OUT_TEMP = true;
                            while (MARK_WRITE_DATE_IN_OUT_TEMP)
                            {
                                bool MARK_WRITE_DATE_IN = true;
                                while (MARK_WRITE_DATE_IN)
                                {
                                    Console.Write("Input a date IN(example: 01/01/2022) start begin from 01/01/2022(if you want cancel write symbol /): ");
                                    dateInTemp = Console.ReadLine();
                                    if (dateInTemp == "/")
                                    {
                                        cancel = true;
                                        break;
                                    }
                                    if (DateTime.TryParseExact(dateInTemp, patternTemp, null, DateTimeStyles.None, out DateIn))
                                    {
                                        if (DateIn < DateMinimumTemp)
                                        {
                                            Console.WriteLine("This date was before 01/01/2022, try again.");
                                        }
                                        else
                                        {
                                            MARK_WRITE_DATE_IN = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Unable input for this pattern, try again");
                                    }
                                }

                                bool MARK_WRITE_DATE_OUT = true;
                                if (!cancel)
                                {
                                    while (MARK_WRITE_DATE_OUT)
                                    {
                                        Console.Write("Input a date OUT(example: 01/01/2022) it must be after date IN(if you want cancel write symbol /): ");
                                        dateOutTemp = Console.ReadLine();
                                        if (dateOutTemp == "/")
                                        {
                                            cancel = true;
                                            break;
                                        }
                                        if (DateTime.TryParseExact(dateOutTemp, patternTemp, null, DateTimeStyles.None, out DateOut))
                                        {
                                            if (DateIn > DateOut)
                                            {
                                                Console.WriteLine("This date before date IN, try again.");
                                            }
                                            else if (DateIn == DateOut)
                                            {
                                                Console.WriteLine("This date equal date IN, try again.");
                                            }
                                            else
                                            {
                                                MARK_WRITE_DATE_OUT = false;
                                                MARK_WRITE_DATE_IN_OUT_TEMP = false;
                                                bool checkTEMP = false;
                                                Console.Clear();
                                                Console.WriteLine("------------------");
                                                numberOfOrders = BLLMAIN.GetInfoAboutCountOfOrders();
                                                if (numberOfOrders != 0)
                                                {
                                                    for (int i = 0; i < numberOfOrders; i++)
                                                    {
                                                        string client = BLLMAIN.GetClientFromOrder(i);
                                                        string hotel = BLLMAIN.GetHotelFromOrder(i);
                                                        int days = BLLMAIN.GetDaysInOrder(i);
                                                        DateTime checkThisDate = BLLMAIN.GetDateInOrder(i);
                                                        if (checkThisDate >= DateIn && checkThisDate <= DateOut)
                                                        {
                                                            Console.WriteLine($"Order#{i + 1}: Hotel {hotel}; Client {client}; {days} days long.");
                                                            checkTEMP = true;
                                                        }
                                                    }
                                                    if (!checkTEMP)
                                                    {
                                                        Console.WriteLine("Not orders were found in this temrin");
                                                    }
                                                    Console.WriteLine("------------------");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You dont have any orders in list, you need add order first");
                                                    Console.WriteLine("------------------");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Unable input for this pattern, try again");
                                        }
                                    }
                                }
                                if (cancel)
                                {
                                    break;
                                }
                            }
                            if (cancel)
                            {
                                Console.Clear();
                                Console.WriteLine("You canceled find by termin order.");
                                Console.WriteLine("------------------");
                                break;
                            }
                        } break;///FIND ORDERS IN CERTAIN TERMIN
                    case "6":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfOrders = BLLMAIN.GetInfoAboutCountOfOrders();
                            if (numberOfOrders != 0)
                            {
                                for (int i = 0; i < numberOfOrders; i++)
                                {
                                    string client = BLLMAIN.GetClientFromOrder(i);
                                    string hotel = BLLMAIN.GetHotelFromOrder(i);
                                    phone = BLLMAIN.GetPhoneFromOrder(i);
                                    int days = BLLMAIN.GetDaysInOrder(i);
                                    Console.WriteLine($"Order#{i + 1}: Client: {client}: {phone}");
                                }
                                Console.WriteLine("------------------");
                            }
                            else
                            {
                                Console.WriteLine("You dont have any orders in list, you need add order first");
                                Console.WriteLine("------------------");
                            }
                        } break;///GET INFO ABOUT CLIENTS THAT MADE A ORDER
                    case "7":{
                            Console.Clear();
                            Console.WriteLine("------------------");
                            numberOfOrders = BLLMAIN.GetInfoAboutCountOfOrders();
                            if (numberOfOrders != 0)
                            {
                                for (int i = 0; i < numberOfOrders; i++)
                                {
                                    string client = BLLMAIN.GetClientFromOrder(i);
                                    string hotel = BLLMAIN.GetHotelFromOrder(i);
                                    int days = BLLMAIN.GetDaysInOrder(i);
                                    Console.WriteLine($"Order#{i + 1}: Hotel {hotel}; Client {client}; {days} days long.");
                                }
                                Console.WriteLine("------------------");
                                bool MARK_DELETE = true;
                                while (MARK_DELETE)
                                {
                                    Console.Write("Choose a order you want to edit additional info(if you want cancel write symbol /): ");
                                    chooser = Console.ReadLine();
                                    if (chooser == "/")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You cancel action get more info.");
                                        Console.WriteLine("------------------");
                                        break;
                                    }
                                    try
                                    {
                                        if (Convert.ToInt32(chooser) > numberOfOrders || Convert.ToInt32(chooser) < 1)
                                        {
                                            Console.WriteLine("Number outside of range, try again");
                                        }
                                        else
                                        {
                                            Console.WriteLine("------------------");
                                            bool MARK_CHOOSE_ADD_INFO = true;
                                            while (MARK_CHOOSE_ADD_INFO)
                                            {
                                                Console.WriteLine("Input additional text from client you want to change(if you want cancel adding write symbol /)(if you do not write anything write symbol *):");
                                                stringAddInfo = Console.ReadLine();
                                                if (stringAddInfo.Length != 0)
                                                {
                                                    switch (stringAddInfo)
                                                    {
                                                        case "/":
                                                            cancel = true;
                                                            MARK_CHOOSE_ADD_INFO = false;
                                                            break;
                                                        case "*":
                                                            stringAddInfo = "";
                                                            MARK_CHOOSE_ADD_INFO = false;
                                                            break;
                                                        default:
                                                            MARK_CHOOSE_ADD_INFO = false;
                                                            BLLMAIN.EditAdditionalInfoInOrder(Convert.ToInt32(chooser), stringAddInfo);
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You write nothing, try again.");
                                                }
                                            }
                                            if (cancel)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You canceled adding order.");
                                                Console.WriteLine("------------------");
                                                break;
                                            }

                                            Console.WriteLine("------------------");
                                            MARK_DELETE = false;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        exceptionForPL.InputNumberAreWrong(e);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You dont have any orders in list, you need add order first");
                                Console.WriteLine("------------------");
                            }
                        } break;///EDIT ADDITIONAL INFO IN ORDER
                    case "8":{
                            Console.Clear();
                            ORDER_MANAGMENT_MENU = false;
                        } break;///BACK TO MENU
                    default:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Wrong number, try again.");
                        Console.WriteLine("------------------");
                        break;
                }
            }
        }
    }
}
