using System;
using System.Collections.Generic;
using Coursework_DAL_;

namespace Coursework_BLL_
{
    public class BLLMain
    {
        List<Hotel> hotels = new List<Hotel>();
        List<Client> clients = new List<Client>();
        public BLLMain() {}

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
                    rooms[j] = new DALRoom(roomInHotel[j].PlaceInRoom, roomInHotel[j].RoomNumber);
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
                    rooms[j] = new DALRoom(roomInHotel[j].PlaceInRoom, roomInHotel[j].RoomNumber);
                }
                Coursework_DAL_.DALHotel hotelDAL = new Coursework_DAL_.DALHotel(hotels[i].NameOfHotel, hotels[i].NumberOfRooms, rooms);
                DALhotels.Add(hotelDAL);
            }
            DALMain DALMAIN = new DALMain(DALhotels);
        }
        public void GetInfoFromFileAboutHotels()
        {
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
    }
}
