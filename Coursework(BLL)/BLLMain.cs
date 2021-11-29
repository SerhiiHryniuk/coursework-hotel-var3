using System;
using System.Collections.Generic;
using Coursework_DAL_;

namespace Coursework_BLL_
{
    public class BLLMain
    {
        List<Hotel> hotels = new List<Hotel>();
        List<Client> clients = new List<Client>();
        List<OrderOnRoom> orders = new List<OrderOnRoom>();
        public BLLMain() {}

        ///ORDER WORK
        public void AddOrder(int client, int hotel, int roomForOne, int roomForTwo, int roomForThree, int howManyDays)
        {
            List<int> roomsNumber = new List<int>();
            Room[] rooms = hotels[hotel].Rooms;

            if (roomForOne > 0)
            {
                for (int i = 0; i < hotels[hotel].NumberOfRooms; i++)
                {
                    if (!rooms[i].ISRoomOccupied && rooms[i].PlaceInRoom == 1 && roomForOne > 0)
                    {
                        rooms[i].ISRoomOccupied = true;
                        roomForOne--;
                        roomsNumber.Add(rooms[i].RoomNumber);
                    }
                }
            }
            if (roomForTwo > 0)
            {
                for (int i = 0; i < hotels[hotel].NumberOfRooms; i++)
                {
                    if (!rooms[i].ISRoomOccupied && rooms[i].PlaceInRoom == 2 && roomForTwo > 0)
                    {
                        rooms[i].ISRoomOccupied = true;
                        roomForTwo--;
                        roomsNumber.Add(rooms[i].RoomNumber);
                    }
                }
            }
            if (roomForThree > 0)
            {
                for (int i = 0; i < hotels[hotel].NumberOfRooms; i++)
                {
                    if (!rooms[i].ISRoomOccupied && rooms[i].PlaceInRoom == 3 && roomForThree > 0)
                    {
                        rooms[i].ISRoomOccupied = true;
                        roomForThree--;
                        roomsNumber.Add(rooms[i].RoomNumber);
                    }
                }
            }

            hotels[hotel].Rooms = rooms;
            WriteOnFileHotel();

            OrderOnRoom order = new OrderOnRoom(clients[client], hotels[hotel], roomsNumber, howManyDays);
            orders.Add(order);
            WriteOnFileOrder();
        }
        public void WriteOnFileOrder()
        {
            List<Coursework_DAL_.DALOrder> DALorders = new List<Coursework_DAL_.DALOrder>();
            for (int i = 0; i < orders.Count; i++)
            {
                Coursework_DAL_.DALClient clientDAL = new Coursework_DAL_.DALClient(orders[i].Client.Firstname, orders[i].Client.Lastname, orders[i].Client.Phone);

                Coursework_DAL_.DALRoom[] rooms = new Coursework_DAL_.DALRoom[orders[i].Hotel.NumberOfRooms];
                Room[] roomInHotel = orders[i].Hotel.Rooms;
                for (int j = 0; j < orders[i].Hotel.NumberOfRooms; j++)
                {
                    rooms[j] = new DALRoom(roomInHotel[j].PlaceInRoom, roomInHotel[j].RoomNumber, roomInHotel[j].ISRoomOccupied);
                }
                Coursework_DAL_.DALHotel hotelDAL = new Coursework_DAL_.DALHotel(hotels[i].NameOfHotel, hotels[i].NumberOfRooms, rooms);

                Coursework_DAL_.DALOrder orderDAL = new Coursework_DAL_.DALOrder(clientDAL, hotelDAL, orders[i].RoomsNumber, orders[i].HowManyDays);
                DALorders.Add(orderDAL);
            }
            DALMain DALMAIN = new DALMain(DALorders);
        }
        public void GetInfoFromFileAboutOrders()
        {
            orders.Clear();
            DALMain DALMAIN = new DALMain();
            List<Coursework_DAL_.DALOrder> DALorders = DALMAIN.ReadFromFileOrders();
            for (int i = 0; i < DALorders.Count; i++)
            {
                Client client = new Client(DALorders[i].Client.Firstname, DALorders[i].Client.Lastname, DALorders[i].Client.Phone);
                Hotel hotel = new Hotel(DALorders[i].Hotel);
                List<int> roomsNumber = DALorders[i].RoomsNumber;
                OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, DALorders[i].HowManyDays);
                orders.Add(order);
            }
        }
        public int GetInfoAboutCountOfOrders()
        {
            return orders.Count;
        }
        public string GetClientFromOrder(int count)
        {
            return $"{orders[count].Client.Firstname} {orders[count].Client.Lastname}";
        }
        public string GetHotelFromOrder(int count)
        {
            return orders[count].Hotel.NameOfHotel;
        }
        public int GetDaysInOrder(int count)
        {
            return orders[count].HowManyDays;
        }
        public void DeleteOrder(int count)
        {
            int hotelIndex = 0;
            for (int i = 0; i < hotels.Count; i++)
            {
                if(hotels[i].NameOfHotel == orders[count - 1].Hotel.NameOfHotel)
                {
                    hotelIndex = i;
                    break;
                }
            }
            Room[] rooms = orders[count - 1].Hotel.Rooms;
            for (int i = 0; i < orders[count - 1].RoomsNumber.Count; i++)
            {
                rooms[orders[count - 1].RoomsNumber[i] - 1].ISRoomOccupied = false;
            }
            hotels[hotelIndex].Rooms = rooms;
            WriteOnFileHotel();
            orders.RemoveAt(count - 1);
            WriteOnFileOrder();
        }
        public string GetMoreInfoAboutOrder(int count)
        {
            string result = "";
            result = $"Order#{count} \n" +
                $"Client: {orders[count - 1].Client.Firstname} {orders[count - 1].Client.Lastname} {orders[count - 1].Client.Phone}; \n" +
                $"Hotel: {orders[count - 1].Hotel.NameOfHotel}; \n" +
                $"Rooms: \n";
            Room[] rooms = orders[count - 1].Hotel.Rooms;
            for (int i = 0; i < orders[count - 1].RoomsNumber.Count; i++)
            {
                Room room = rooms[orders[count - 1].RoomsNumber[i] - 1];
                result += $"Room#{room.RoomNumber}: {room.PlaceInRoom} people in room; \n";
            }
            result += "------------------ \n";
            result += $"Reservation for {orders[count - 1].HowManyDays} days;\n";
            result += $"Price: {orders[count - 1].Price} uah.";
            return result;
        }

        ///CLIENT WORK
        public void AddClient(string firstname, string lastname, string phone)
        {
            Client client = new Client(firstname, lastname, phone);
            clients.Add(client);
            List<Coursework_DAL_.DALClient> DALclients = new List<Coursework_DAL_.DALClient>();
            for (int i = 0; i < clients.Count; i++)
            {
                Coursework_DAL_.DALClient clientDAL = new Coursework_DAL_.DALClient(clients[i].Firstname, clients[i].Lastname, clients[i].Phone);
                DALclients.Add(clientDAL);
            }
            DALMain DALMAIN = new DALMain(DALclients);
        }
        public int GetInfoAboutCountOfClients()
        {
            return clients.Count;
        }
        public string GetFirstnameOfClients(int count)
        {
            return clients[count].Firstname;
        }
        public string GetLastnameOfClients(int count)
        {
            return clients[count].Lastname;
        }
        public string GetPhoneOfClients(int count)
        {
            return clients[count].Phone;
        }
        public void DeleteClient(int count)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if(clients[count - 1].Phone == orders[i].Client.Phone)
                {
                    DeleteOrder(i + 1);
                }
            }
            clients.RemoveAt(count - 1);
            WriteOnFileClient();
        }
        private void WriteOnFileClient()
        {
            List<Coursework_DAL_.DALClient> DALclients = new List<Coursework_DAL_.DALClient>();
            for (int i = 0; i < clients.Count; i++)
            {
                Coursework_DAL_.DALClient clientDAL = new Coursework_DAL_.DALClient(clients[i].Firstname, clients[i].Lastname, clients[i].Phone);
                DALclients.Add(clientDAL);
            }
            DALMain DALMAIN = new DALMain(DALclients);
        }
        public void EditInfoAboutClient(string chooser, string infoToChange, int count)
        {
            switch (chooser)
            {
                case "1":
                    clients[count - 1].Firstname = infoToChange;
                    break;
                case "2":
                    clients[count - 1].Lastname = infoToChange;
                    break;
                case "3":
                    clients[count - 1].Phone = infoToChange;
                    break;
            }
            WriteOnFileClient();
        }
        public void GetInfoFromFileAboutClients()
        {
            clients.Clear();
            DALMain DALMAIN = new DALMain();
            List<Coursework_DAL_.DALClient> DALclients = DALMAIN.ReadFromFileCLients();
            for (int i = 0; i < DALclients.Count; i++)
            {
                Client client = new Client(DALclients[i]);
                clients.Add(client);
            }
        }



        ///HOTEL WORK
        public int AddHotel(string nameOfHotel)
        {
            Random numberOfRooms = new Random();
            Hotel hotel = new Hotel(nameOfHotel, numberOfRooms.Next(100,150));
            hotels.Add(hotel);
            List<Coursework_DAL_.DALHotel> DALhotels = new List<Coursework_DAL_.DALHotel>();
            Coursework_DAL_.DALRoom[] rooms;
            Room[] roomInHotel;
            for (int i = 0; i < hotels.Count; i++)
            {
                rooms = new Coursework_DAL_.DALRoom[hotels[i].NumberOfRooms];
                roomInHotel = hotels[i].Rooms;
                for (int j = 0; j < hotels[i].NumberOfRooms; j++)
                {
                    rooms[j] = new DALRoom(roomInHotel[j].PlaceInRoom, roomInHotel[j].RoomNumber, roomInHotel[j].ISRoomOccupied);
                }
                Coursework_DAL_.DALHotel hotelDAL = new Coursework_DAL_.DALHotel(hotels[i].NameOfHotel, hotels[i].NumberOfRooms, rooms);
                DALhotels.Add(hotelDAL);
            }
            DALMain DALMAIN = new DALMain(DALhotels);
            return hotel.NumberOfRooms;
        }
        public string MoreInfoAboutHotel(int count)
        {
            int roomOneBusy = 0; int roomOneUnbusy = 0;
            int roomTwoBusy = 0; int roomTwoUnbusy = 0;
            int roomThreeBusy = 0; int roomThreeUnbusy = 0;
            Room[] rooms = hotels[count - 1].Rooms;
            for (int i = 0; i < rooms.Length; i++)
            {
                if(rooms[i].PlaceInRoom == 1)
                {
                    if (rooms[i].ISRoomOccupied)
                    {
                        roomOneBusy++;
                    }
                    else
                    {
                        roomOneUnbusy++;
                    }
                }
                if (rooms[i].PlaceInRoom == 2)
                {
                    if (rooms[i].ISRoomOccupied)
                    {
                        roomTwoBusy++;
                    }
                    else
                    {
                        roomTwoUnbusy++;
                    }
                }
                if (rooms[i].PlaceInRoom == 3)
                {
                    if (rooms[i].ISRoomOccupied)
                    {
                        roomThreeBusy++;
                    }
                    else
                    {
                        roomThreeUnbusy++;
                    }
                }
            }
            string result = $"Hotel {hotels[count - 1].NameOfHotel} with {hotels[count - 1].NumberOfRooms} rooms in total:\n" +
                $"Rooms for one person not occupied {roomOneUnbusy};\n" +
                $"Rooms for two person not occupied {roomTwoUnbusy};\n" +
                $"Rooms for three person not occupied {roomThreeUnbusy};";
            return result;
        }
        public void DeleteHotel(int count)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (hotels[count - 1].NameOfHotel == orders[i].Hotel.NameOfHotel)
                {
                    DeleteOrder(i + 1);
                }
            }
            hotels.RemoveAt(count - 1);
            WriteOnFileHotel();
        }
        private void WriteOnFileHotel()
        {
            List<Coursework_DAL_.DALHotel> DALhotels = new List<Coursework_DAL_.DALHotel>();
            Coursework_DAL_.DALRoom[] rooms;
            Room[] roomInHotel;
            for (int i = 0; i < hotels.Count; i++)
            {
                rooms = new Coursework_DAL_.DALRoom[hotels[i].NumberOfRooms];
                roomInHotel = hotels[i].Rooms;
                for (int j = 0; j < hotels[i].NumberOfRooms; j++)
                {
                    rooms[j] = new DALRoom(roomInHotel[j].PlaceInRoom, roomInHotel[j].RoomNumber, roomInHotel[j].ISRoomOccupied);
                }
                Coursework_DAL_.DALHotel hotelDAL = new Coursework_DAL_.DALHotel(hotels[i].NameOfHotel, hotels[i].NumberOfRooms, rooms);
                DALhotels.Add(hotelDAL);
            }
            DALMain DALMAIN = new DALMain(DALhotels);
        }
        public void GetInfoFromFileAboutHotels()
        {
            hotels.Clear();
            DALMain DALMAIN = new DALMain();
            List<Coursework_DAL_.DALHotel> DALhotels = DALMAIN.ReadFromFileHotel();
            for (int i = 0; i < DALhotels.Count; i++)
            {
                Hotel hotel = new Hotel(DALhotels[i]);
                hotels.Add(hotel);
            }
        }
        public int GetInfoAboutCountOfHotels()
        {
            return hotels.Count;
        }
        public string GetNameOfHotel(int count) 
        {
            return hotels[count].NameOfHotel;
        }
        public int GetNumberOfRoomsInHotel(int count)
        {
            return hotels[count].NumberOfRooms;
        }
        public bool AnalyzeIfHotelHaveRooms(int count, int roomForOne, int roomForTwo, int roomForThree)
        {
            bool solution = true;
            int roomOneUnbusy = 0;
            int roomTwoUnbusy = 0;
            int roomThreeUnbusy = 0;
            Room[] rooms = hotels[count].Rooms;
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].PlaceInRoom == 1)
                {
                    if (!rooms[i].ISRoomOccupied)
                    {
                        roomOneUnbusy++;
                    }
                }
                if (rooms[i].PlaceInRoom == 2)
                {
                    if (!rooms[i].ISRoomOccupied)
                    {
                        roomTwoUnbusy++;
                    }
                }
                if (rooms[i].PlaceInRoom == 3)
                {
                    if (!rooms[i].ISRoomOccupied)
                    {
                        roomThreeUnbusy++;
                    }
                }
            }
            if(roomForOne > 0)
            {
                if(roomOneUnbusy >= roomForOne)
                {
                    solution = true;
                }
                else
                {
                    solution = false;
                    return solution;
                }
            }
            if (roomForTwo > 0)
            {
                if (roomTwoUnbusy >= roomForTwo)
                {
                    solution = true;
                }
                else
                {
                    solution = false;
                    return solution;
                }
            }
            if (roomForThree > 0)
            {
                if (roomThreeUnbusy >= roomForThree)
                {
                    solution = true;
                }
                else
                {
                    solution = false;
                    return solution;
                }
            }
            return solution;
        }
    }
}
