using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_DAL_
{
    [Serializable]
    public class DALHotel
    {
        private string nameOfHotel { get; set; }
        private int numberOfRooms { get; set; }
        private DALRoom[] rooms;
        private int priceForOneNight { get; set; }
        public DALHotel(string nameOfHotel, int numberOfRooms, DALRoom[] rooms, int priceForOneNight)
        {
            this.priceForOneNight = priceForOneNight;
            this.nameOfHotel = nameOfHotel;
            this.numberOfRooms = numberOfRooms;
            this.rooms = rooms;
        }

        public int PriceForOneNight
        {
            get
            {
                return priceForOneNight;
            }
        }
        public DALRoom[] Rooms
        {
            get
            {
                return rooms;
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
