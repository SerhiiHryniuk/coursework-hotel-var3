using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    public class OrderOnRoom
    {
        private Client client { get; set; }
        private Hotel hotel { get; set; }
        private List<int> roomsNumber = new List<int>();
        private int price { get; set; }
        private int howManyDays { get; set; }
        private DateTime dateIn { get; set; }
        private DateTime dateOut { get; set; }
        private bool breakfast { get; set; }
        private string addInfo { get; set; }

        public OrderOnRoom(Client client, Hotel hotel, List<int> roomsNumber, DateTime dateIn, DateTime dateOut, bool breakfast, string addInfo)
        {
            this.addInfo = addInfo;
            this.breakfast = breakfast;
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
            if (breakfast)
            {
                price *= 2;
            }
        }
        public string AddInfo
        {
            get
            {
                return addInfo;
            }
            set
            {
                addInfo = value;
            }
        }
        public bool Breakfast
        {
            get
            {
                return breakfast;
            }
        }

        public DateTime DateOut
        {
            get
            {
                return dateOut;
            }
            set
            {
                dateOut = value;
            }
        }
        public DateTime DateIn
        {
            get
            {
                return dateIn;
            }
            set
            {
                dateIn = value;
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
            set
            {
                client = value;
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
