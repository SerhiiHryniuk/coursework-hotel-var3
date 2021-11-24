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

        public Room(int placeInRoom, int roomNumber)
        {
            this.placeInRoom = placeInRoom;
            priceForRoom = placeInRoom * 25;
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
