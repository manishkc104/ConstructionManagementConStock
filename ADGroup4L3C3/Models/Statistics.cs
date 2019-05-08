using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADGroup4L3C3.Models
{
    public class Statistics
    {
        public int TotalSuppliers { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalProducts { get; set; }
        public int TotalSales { get; set; }


        public static IEnumerable<Statistics> CountSuppliers(ADG4_L3C3Entities db)
        {
            string objs = @"
                select count(supplierid) as 'TotalSuppliers' from Suppliers";
            var result = db.Database.SqlQuery<Statistics>(objs);
            return result;
        }

        public static IEnumerable<Statistics> CountCustomers(ADG4_L3C3Entities db)
        {
            string objs = @"
                select count(UserAccountID) as 'TotalCustomers' from UserAccounts where usertypeid = 3";
            var result = db.Database.SqlQuery<Statistics>(objs);
            return result;
        }

        public static IEnumerable<Statistics> CountTotalProducts(ADG4_L3C3Entities db)
        {
            string objs = @"
                select sum(QuantityRemaining) as 'TotalProducts' from Stock";
            var result = db.Database.SqlQuery<Statistics>(objs);
            return result;
        }

        public static IEnumerable<Statistics> CountTotalSales(ADG4_L3C3Entities db)
        {
            string objs = @"
                select sum(BillingAmount) as 'TotalSales' from Sales";
            var result = db.Database.SqlQuery<Statistics>(objs);
            return result;
        }
    }
}