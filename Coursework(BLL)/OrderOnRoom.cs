using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    class OrderOnRoom
    {
        private Client client { get; set; }
        private Hotel hotel { get; set; }
        private List<int> roomsNumber = new List<int>();
        private int price { get; set; }
        private int howManyDays { get; set; }
        private DateTime dateIn { get; set; }
        private DateTime dateOut { get; set; }

        public OrderOnRoom(Client client, Hotel hotel, List<int> roomsNumber, DateTime dateIn, DateTime dateOut)
        {
            this.client = client;
            this.hotel = hotel;
            this.roomsNumber = roomsNumber;
            this.dateIn = dateIn;
            this.dateOut = dateOut;
            price = 0;
            Room[] rooms = hotel.Rooms;
            for (int i = 0; i < roomsNumber.Count; i++)
            {
                price += rooms[roomsNumber[i] - 1].PriceForRoom;
            }
            howManyDays = (dateOut - dateIn).Days;
            price *= howManyDays;
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
        public Hotel Hotel
        {
            get
            {
                return hotel;
            }
        }
        public Client Client
        {
            get
            {
                return client;
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
