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

        public DALMain() { }

        ///FILE WORk WITH CLIENTS
        public DALMain(List<DALClient> clients)
        {
            DALclient = clients;
            WriteOnFileClients();
        }
        public void WriteOnFileClients()
        {
            File.Delete("ListOfClients.dat");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfClients.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DALclient.ToArray());
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
                    DALClient[] clientDALdes = (DALClient[])formatter.Deserialize(fs);
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
            DALhotels = hotels;
            WriteOnFileHotels();
        }
        public void WriteOnFileHotels()
        {
            File.Delete("ListOfHotels.dat");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ListOfHotels.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DALhotels.ToArray());
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
                    DALHotel[] hotelDALDes = (DALHotel[])formatter.Deserialize(fs);
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
