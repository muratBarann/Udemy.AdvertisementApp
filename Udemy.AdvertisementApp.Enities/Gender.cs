﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.AdvertisementApp.Enities
{
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
