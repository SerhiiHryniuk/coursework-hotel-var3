using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    class Hotel
    {
        private string nameOfHotel { get; set; }
        private int numberOfRooms { get; set; }
        private Room[] rooms { get; set; }

        public Hotel(Coursework_DAL_.DALHotel hotel)
        {
            nameOfHotel = hotel.NameOfHotel;
            numberOfRooms = hotel.NumberOfRooms;
            rooms = new Room[numberOfRooms];
            Coursework_DAL_.DALRoom[] roomsDAL;
            roomsDAL = hotel.Rooms;
            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms[i] = new Room(roomsDAL[i].PlaceInRoom, i + 1, roomsDAL[i].ISRoomOccupied);
            }
        }
        public Hotel(string nameOfHotel, int numberOfRooms)
        {
            this.nameOfHotel = nameOfHotel;
            this.numberOfRooms = numberOfRooms;
            rooms = new Room[numberOfRooms];
            GenerateRoom();
        }

        private void GenerateRoom()
        {
            Random placeInRoom = new Random();
            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms[i] = new Room(placeInRoom.Next(1, 4), i + 1);
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
