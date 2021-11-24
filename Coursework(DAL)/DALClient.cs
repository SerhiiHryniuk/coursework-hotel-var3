using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_DAL_
{
    [Serializable]
    public class DALClient
    {
        private string firstname { get; set; }
        private string lastname { get; set; }
        private string phone { get; set; }

        public DALClient(string firstname, string lastname, string phone)
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
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
        }
    }
}
