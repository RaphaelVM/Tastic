using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class Catering
    {
        public int caID;
        public string Name;
        public string Emailadress;
        public string Street;
        public string Streetnumber;
        public string Postalcode;
        public string City;
        public string Phonenumber;

        public Catering() { }
        
        public Catering(int caid, string name, string emailadress, string street,
                        string streetnumer, string postalcode, string city,
                        string phonenumber)
        {
            caID = caid;
            Name = name;
            Emailadress = emailadress;
            Street = street;
            Streetnumber = streetnumer;
            Postalcode = postalcode;
            City = city;
            Phonenumber = phonenumber;
        }
    }
}