using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_DAL_
{
    [Serializable]
    public class DALRoom
    {
        private int placeInRoom { get; set; }
        private int priceForRoom { get; set; }
        private bool IsRoomOccupied { get; set; }
        private int roomNumber { get; set; }
        public DALRoom(int placeInRoom, int roomNumber, bool isOccupied, int priceForRoom)
        {
            this.placeInRoom = placeInRoom;
            this.priceForRoom = priceForRoom;
            IsRoomOccupied = isOccupied;
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
