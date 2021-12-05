using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    public class Hotel
    {
        private string nameOfHotel { get; set; }
        private int numberOfRooms { get; set; }
        private Room[] rooms { get; set; }
        private int priceForOneNightPeople { get; set; }

        public Hotel(Coursework_DAL_.DALHotel hotel)
        {
            priceForOneNightPeople = hotel.PriceForOneNight;
            nameOfHotel = hotel.NameOfHotel;
            numberOfRooms = hotel.NumberOfRooms;
            rooms = new Room[numberOfRooms];
            Coursework_DAL_.DALRoom[] roomsDAL;
            roomsDAL = hotel.Rooms;
            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms[i] = new Room(roomsDAL[i].PlaceInRoom, i + 1, roomsDAL[i].ISRoomOccupied, roomsDAL[i].PriceForRoom);
            }
        }
        public Hotel(string nameOfHotel, int numberOfRooms, int priceForOneNight)
        {
            this.nameOfHotel = nameOfHotel;
            this.numberOfRooms = numberOfRooms;
            priceForOneNightPeople = priceForOneNight;
            rooms = new Room[numberOfRooms];
            GenerateRoom(priceForOneNight);
        }

        private void GenerateRoom(int priceForOneNight)
        {
            Random placeInRoom = new Random();
            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms[i] = new Room(placeInRoom.Next(1, 4), i + 1, priceForOneNight);
            }
        }
        public int PriceForOneNightPeople
        {
            get
            {
                return priceForOneNightPeople;
            }
        }
        public Room[] Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = null;
                rooms = value;
            }
        }

        public int NumberOfRooms
        {
            get
            {
                return numberOfRooms;
            }
        }

        public string NameOfHotel
        {
            get
            {
                return nameOfHotel;
            }
        }
    }
}
