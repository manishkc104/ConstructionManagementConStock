using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ADGroup4L3C3.Models
{
    public class ProductCount
    {
        public int Total { get; set; }

        public static IEnumerable<ProductCount> CountBalwa(ADG4_L3C3Entities db)
        {
            string objs = @"
                select sum(s.QuantityRemaining) as 'Total' from Product p
                inner join stock s on p.productid = s.ProductID
                inner join ProductType pt on p.ProductTypeID = pt.ProductTypeID 
                where pt.ProductTypeID =  1";
            var result = db.Database.SqlQuery<ProductCount>(objs);
            return result;
        }

        public static IEnumerable<ProductCount> CountGitti(ADG4_L3C3Entities db)
        {
            string objs = @"
                select sum(s.QuantityRemaining) as 'Total' from Product p
                inner join stock s on p.productid = s.ProductID
                inner join ProductType pt on p.ProductTypeID = pt.ProductTypeID 
                where pt.ProductTypeID =  2";
            var result = db.Database.SqlQuery<ProductCount>(objs);
            return result;
        }

        public static IEnumerable<ProductCount> CountCement(ADG4_L3C3Entities db)
        {
            string objs = @"
                select sum(s.QuantityRemaining) as 'Total' from Product p
                inner join stock s on p.productid = s.ProductID
                inner join ProductType pt on p.ProductTypeID = pt.ProductTypeID 
                where pt.ProductTypeID =  3";
            var result = db.Database.SqlQuery<ProductCount>(objs);
            return result;
        }

        public static IEnumerable<ProductCount> CountRod(ADG4_L3C3Entities db)
        {
            string objs = @"
                select sum(s.QuantityRemaining) as 'Total' from Product p
                inner join stock s on p.productid = s.ProductID
                inner join ProductType pt on p.ProductTypeID = pt.ProductTypeID 
                where pt.ProductTypeID =  4";
            var result = db.Database.SqlQuery<ProductCount>(objs);
            return result;
        }
    }
}