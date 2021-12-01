using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_DAL_
{
    [Serializable]
    public class DALOrder
    {
        private DALClient client { get; set; }
        private DALHotel hotel { get; set; }

        private List<int> roomsNumber = new List<int>();
        private int price { get; set; }
        private int howManyDays { get; set; }
        private DateTime dateIn { get; set; }
        private DateTime dateOut { get; set; }

        public DALOrder(DALClient client, DALHotel hotel, List<int> roomsNumber, DateTime dateIn, DateTime dateOut)
        {
            this.client = client;
            this.hotel = hotel;
            this.roomsNumber = roomsNumber;
            this.dateIn = dateIn;
            this.dateOut = dateOut;
            howManyDays = (dateOut - dateIn).Days;
        }
        
        public DateTime DateOut
        {
            get
            {
                return dateOut;
            }
        }
        public DateTime DateIn
        {
            get
            {
                return dateIn;
            }
        }
        public List<int> RoomsNumber
        {
            get
            {
                return roomsNumber;
            }
        }

        public DALClient Client
        {
            get
            {
                return client;
            }
        }

        public DALHotel Hotel
        {
            get
            {
                return hotel;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }
        }

        public int HowManyDays
        {
            get
            {
                return howManyDays;
            }
        }
    }
}
