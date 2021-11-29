using System;
using Coursework_BLL_;
using System.Text.RegularExpressions;

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
            string nameOfHotel;
            int numberOfHotels;
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
                            Console.WriteLine("------------------");
                            Console.Write("Input a name of hotel: ");
                            nameOfHotel = Console.ReadLine();
                            int numberOfRooms = BLLMAIN.AddHotel(nameOfHotel);
                            Console.WriteLine($"Hotel {nameOfHotel} with {numberOfRooms} rooms was added.");
                            Console.WriteLine("------------------");
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
                            MARKDELETE:
                                Console.Write("Choose a hotel you want to delete: ");
                                chooser = Console.ReadLine();
                                if (Convert.ToInt32(chooser) > numberOfHotels || Convert.ToInt32(chooser) < 1)
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
            const string regexPhone = @"^([\+]?38[-]?|[0])?[0-9][0-9]{9}$";
            bool forWhile = true;
            while (forWhile)
            {
                Console.WriteLine("1. Add client to list.");
                Console.WriteLine("2. Info about all clients.");
                Console.WriteLine("3. Delete client from list.");
                Console.WriteLine("4. Edit client.");
                Console.WriteLine("5. Back to menu.");
                chooser = Console.ReadLine();
                switch (chooser)
                {
                    case "1":{
                            Console.WriteLine("------------------");
                            Console.Write("Input a firstname of client: ");
                            firstname = Console.ReadLine();
                            Console.Write("Input a lastname of client: ");
                            lastname = Console.ReadLine();
                            bool forWhileSecond = true;
                            while (forWhileSecond)
                            {
                                bool phoneSame = false;
                                Console.Write("Input a phone of client(example [+380123456789]): ");
                                phone = Console.ReadLine();
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
                                        forWhileSecond = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Number is not right, try again.");
                                }
                            }
                            BLLMAIN.AddClient(firstname, lastname, phone);
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
                                    Console.Write("Choose a client you want to delete: ");
                                    chooser = Console.ReadLine();
                                    if (Convert.ToInt32(chooser) > numberOfClients || Convert.ToInt32(chooser) < 1)
                                    {
                                        Console.WriteLine("Number outside of range, try again");
                                    }
                                    else
                                    {
                                        forWhileS = false;
                                        BLLMAIN.DeleteClient(Convert.ToInt32(chooser));
                                        Console.WriteLine("------------------");
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
                                    Console.Write("Choose a client you want to edit: ");
                                    chooser = Console.ReadLine();
                                    if (Convert.ToInt32(chooser) > numberOfClients || Convert.ToInt32(chooser) < 1)
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
                            else
                            {
                                Console.WriteLine("You dont have any clients in list, you need add client first");
                                Console.WriteLine("------------------");
                            }
                        } break;///EDIT CLIENT
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

        private void Order_Managment()
        {
            BLLMAIN.GetInfoFromFileAboutClients();
            BLLMAIN.GetInfoFromFileAboutHotels();
            BLLMAIN.GetInfoFromFileAboutOrders();
            string chooser;
            string nameOfHotel, firstname, lastname, phone;
            int numberOfHotels, numberOfClients, numberOfOrders, chooserClient = 0, chooserHotel = 0, numbersOfRoomsToOrder = 0;
            int roomForOne = 0, roomForTwo = 0, roomForThree = 0;
            int howManyDays = 0;
            bool ORDER_MANAGMENT_MENU = true;
            bool[] whichHotelToChoose;
            bool test = true;
            int[] PlaceInRoom;
            while (ORDER_MANAGMENT_MENU)
            {
                Console.WriteLine("1. Add order to list.");
                Console.WriteLine("2. Info about all orders.");
                Console.WriteLine("3. Delete order from list.");
                Console.WriteLine("4. Get more info about order.");
                Console.WriteLine("5. Back to menu.");
                chooser = Console.ReadLine();
                switch (chooser)
                {
                    case "1":{
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
                                Console.WriteLine("Choose which client, want to make order:");
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
                            //INPUT A NUMBER OF ROOMS TO ORDER
                            {
                                bool MARK_CHOOSE_NUMBER_ROOM = true;
                                while (MARK_CHOOSE_NUMBER_ROOM)
                                {
                                    Console.WriteLine("Input how many rooms you want to order(in number type):");
                                    try
                                    {
                                        numbersOfRoomsToOrder = Convert.ToInt32(Console.ReadLine());
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
                            //ANALYZE WHICH HOTEL TO CHOOSE
                            {
                                bool MARK_CHOOSE_HOTEL = true;
                                while (MARK_CHOOSE_HOTEL)
                                {
                                    Console.WriteLine("Input which hotel, client want to choose:");
                                    numberOfHotels = BLLMAIN.GetInfoAboutCountOfHotels();
                                    whichHotelToChoose = new bool[numberOfHotels];
                                    for (int i = 0; i < numberOfHotels; i++)
                                    {
                                        nameOfHotel = BLLMAIN.GetNameOfHotel(i);
                                        if (BLLMAIN.AnalyzeIfHotelHaveRooms(i, roomForOne, roomForTwo, roomForThree))
                                        {
                                            Console.WriteLine($"{i + 1}. Hotel {nameOfHotel}");
                                            whichHotelToChoose[i] = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{i + 1}. Hotel {nameOfHotel}, NOT AVAILABLE FOR YOUR ORDER");
                                            whichHotelToChoose[i] = false;
                                        }
                                    }

                                    bool tester = true;
                                    try
                                    {
                                        chooserHotel = Convert.ToInt32(Console.ReadLine());
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
                            }
                            //INPUT FOR HOW LONG TO STAY
                            {
                                bool MARK_CHOOSE_HOW_LONG = true;
                                while (MARK_CHOOSE_HOW_LONG)
                                {
                                    Console.WriteLine("Input for how long client want to order room(in number type):");
                                    try
                                    {
                                        howManyDays = Convert.ToInt32(Console.ReadLine());
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
                            }
                            BLLMAIN.AddOrder(chooserClient - 1, chooserHotel - 1, roomForOne, roomForTwo, roomForThree, howManyDays);
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
                                    Console.Write("Choose a order you want to delete: ");
                                    try
                                    {
                                        chooser = Console.ReadLine();
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
                                    Console.Write("Choose a order you want to delete: ");
                                    try
                                    {
                                        chooser = Console.ReadLine();
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
