using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    class Room
    {
        private int placeInRoom { get; set; }
        private int priceForRoom { get; set; }
        private bool IsRoomOccupied { get; set; }
        private int roomNumber { get; set; }

        public Room(int placeInRoom, int roomNumber, bool isRoomOccupied, int priceForRoom)
        {
            this.placeInRoom = placeInRoom;
            this.priceForRoom = priceForRoom;
            IsRoomOccupied = isRoomOccupied;
            this.roomNumber = roomNumber;
        }

        public Room(int placeInRoom, int roomNumber, int priceForOneNight)
        {
            this.placeInRoom = placeInRoom;
            priceForRoom = priceForOneNight;
            priceForRoom = placeInRoom * priceForRoom;
            IsRoomOccupied = false;
            this.roomNumber = roomNumber;
        }

        public int PlaceInRoom
        {
            get
            {
                return placeInRoom;
            }
        }

        public int PriceForRoom
        {
            get
            {
                return priceForRoom;
            }
        }

        public bool ISRoomOccupied
        {
            get
            {
                return IsRoomOccupied;
            }
            set
            {
                IsRoomOccupied = value;
            }
        }

        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
        }
    }
}
