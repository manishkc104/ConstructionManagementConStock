using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ADGroup4L3C3.Models
{
    public class ADGroup4L3C3Context: DbContext 
    {
        public ADGroup4L3C3Context(string conn = "name=ADG4_L3C3Entities") : base(conn)
        {
            Database.SetInitializer<ADGroup4L3C3Context>(null);
        }
    }
}