using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    class Client
    {
        private string firstname { get; set; }
        private string lastname { get; set; }
        private string phone { get; set; }

        public Client(Coursework_DAL_.DALClient client)
        {
            firstname = client.Firstname;
            lastname = client.Lastname;
            phone = client.Phone;
        }

        public Client(string firstname, string lastname, string phone)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.phone = phone;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

    }
}
