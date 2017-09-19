﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420NewWebsite.Models
{
    public class Member
    {
        public int Id { get; set; }
        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


    }
}