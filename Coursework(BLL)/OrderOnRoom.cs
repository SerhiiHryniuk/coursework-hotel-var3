﻿using System;
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

        public OrderOnRoom(Client client, Hotel hotel, List<int> roomsNumber, int howManyDays)
        {
            this.client = client;
            this.hotel = hotel;
            this.roomsNumber = roomsNumber;
            this.howManyDays = howManyDays;
            price = 0;
            Room[] rooms = hotel.Rooms;
            for (int i = 0; i < roomsNumber.Count; i++)
            {
                price += rooms[roomsNumber[i] - 1].PriceForRoom;
            }
            price *= howManyDays;
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
