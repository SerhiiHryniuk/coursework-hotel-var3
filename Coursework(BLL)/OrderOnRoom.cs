using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    class OrderOnRoom
    {
        private int price;
        private int numberOfRoom;
        private Room[] rooms;
        private Client client;
        private string descriptionToOrder;

        public OrderOnRoom(Client client, Room[] rooms, string descriptionToOrder)
        {
            this.client = client;
            this.rooms = rooms;
            this.descriptionToOrder = descriptionToOrder;
            numberOfRoom = rooms.Length;
        }
    }
}
