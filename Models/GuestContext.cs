﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace party.Models
{
    public class GuestContext : DbContext
    {  
        public DbSet<Guest> Guests { get; set; }
        public int? PeodId { get; set; }

        public virtual Peod Peod { get; set; }
    }
}