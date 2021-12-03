using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Coursework_DAL_
{
    public class DALMain
    {
        List<DALHotel> DALhotels = new List<DALHotel>();
        List<DALClient> DALclient = new List<DALClient>();
        List<DALOrder> DALorders = new List<DALOrder>();

        public DALMain() { }

        ///FILE WORK WITH ORDERS
        public DALMain(List<DALOrder> DALorders)
        {
            try
            {
                this.DALorders = DALorders;
            }
            catch
            {
                throw new ExceptionsWhenInitializeClass("Something wrong while initialize classes in DALorders");
            }
            WriteOnFileOrders();
        }
        public void WriteOnFileOrders()
        {
            try
            {
                File.Delete("ListOfOrders.dat");
            }
            catch
            {
                throw new ExceptionFileDoesntExist("File ListOfOrders doesnt exist.");
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfOrders.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, DALorders.ToArray());
                }
                catch
                {
                    throw new ExceptionWhileSerialize("Something wrong when serialize orders");
                }
            }
        }
        public List<DALOrder> ReadFromFileOrders()
        {
            DALorders.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("ListOfOrders.dat"))
            {
                using (FileStream fs = new FileStream($"ListOfOrders.dat", FileMode.OpenOrCreate))
                {
                    DALOrder[] ordersDALdes;
                    try
                    {
                        ordersDALdes = (DALOrder[])formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new ExceptionWhileDeseralize("Something wrong when deseralize orders");
                    }
                    for (int i = 0; i < ordersDALdes.Length; i++)
                    {
                        DALorders.Add(ordersDALdes[i]);
                    }
                }
            }
            return DALorders;
        }



        ///FILE WORk WITH CLIENTS
        public DALMain(List<DALClient> clients)
        {
            try
            {
                DALclient = clients;
            }
            catch
            {
                throw  new ExceptionsWhenInitializeClass("Something wrong while initialize classes in DALClient");
            }
            WriteOnFileClients();
        }
        public void WriteOnFileClients()
        {
            try
            {
                File.Delete("ListOfClients.dat");
            }
            catch
            {
                throw new ExceptionFileDoesntExist("File ListOfCLient doesnt exist.");
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfClients.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, DALclient.ToArray());
                }
                catch
                {
                    throw new ExceptionWhileSerialize("Something wrong when serialize cients");
                }
            }
        }
        public List<DALClient> ReadFromFileCLients()
        {
            DALclient.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("ListOfClients.dat"))
            {
                using (FileStream fs = new FileStream($"ListOfClients.dat", FileMode.OpenOrCreate))
                {
                    DALClient[] clientDALdes;
                    try
                    {
                        clientDALdes = (DALClient[])formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new ExceptionWhileDeseralize("Something wrong when deseralize clients");
                    }
                    for (int i = 0; i < clientDALdes.Length; i++)
                    {
                        DALclient.Add(clientDALdes[i]);
                    }
                }
            }
            return DALclient;
        }



        ///FILE WORK WITH HOTELS
        public DALMain(List<DALHotel> hotels)
        {
            try
            {
                DALhotels = hotels;
            }
            catch
            {
                throw new ExceptionsWhenInitializeClass("Something wrong while initialize classes in DALHotel");
            }
            WriteOnFileHotels();
        }
        public void WriteOnFileHotels()
        {
            try
            {
                File.Delete("ListOfHotels.dat");
            }
            catch
            {
                throw new ExceptionFileDoesntExist("File ListOfHotels doesnt exist.");
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfHotels.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, DALhotels.ToArray());
                }
                catch
                {
                    throw new ExceptionWhileSerialize("Something wrong when serialize hotels");
                }
            }
        }
        public List<DALHotel> ReadFromFileHotel()
        {
            DALhotels.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("ListOfHotels.dat"))
            {
                using (FileStream fs = new FileStream($"ListOfHotels.dat", FileMode.OpenOrCreate))
                {
                    DALHotel[] hotelDALDes;
                    try
                    {
                        hotelDALDes = (DALHotel[])formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new ExceptionWhileDeseralize("Something wrong when deseralize hotels");
                    }
                    for (int i = 0; i < hotelDALDes.Length; i++)
                    {
                        DALhotels.Add(hotelDALDes[i]);
                    }
                }
            }
            return DALhotels;
        }
    }
}
