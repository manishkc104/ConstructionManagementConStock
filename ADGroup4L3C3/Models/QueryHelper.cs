﻿using ADGroup4L3C3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ADGroup4L3C3.ViewModel
{
    public class QueryHelper{
        public static Task<int> UpdateBillingAmount(ADG4_L3C3Entities db, int? BillingAmount, int SalesID)
        {
            //Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("ProjectID", new KeyValuePair<string, object>("string", ProjectID));

            SqlParameter amountParam = new SqlParameter("BillingAmount", BillingAmount);
            SqlParameter salesParam = new SqlParameter("SalesID", SalesID);
            try
            {
                string objs = @"
                UPDATE Sales SET BillingAmount = @BillingAmount
                WHERE SalesID = @SalesID";
                object[] parameters = new object[] { amountParam, salesParam };
                var result = db.Database.ExecuteSqlCommandAsync(objs, parameters);
                return result;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static IEnumerable<Product> GetProductPrice (ADG4_L3C3Entities db, int ProductID)
        {
            SqlParameter proParam = new SqlParameter("ProductID", ProductID);

            string objs = @"
                SELECT * FROM Product
                WHERE ProductID = @ProductID";
            object[] parameters = new object[] { proParam };
            var result = db.Database.SqlQuery<Product>(objs, parameters);
            return result;
        }

        public static IEnumerable<Stock> GetQuantity(ADG4_L3C3Entities db, int ProductID)
        {
            SqlParameter proParam = new SqlParameter("ProductID", ProductID);

            string objs = @"
                SELECT * FROM Stock
                WHERE ProductID = @ProductID";
            object[] parameters = new object[] { proParam };
            var result = db.Database.SqlQuery<Stock>(objs, parameters);
            return result;
        }

        public static Task<int> UpdateQuantityRemaining(ADG4_L3C3Entities db, int? QuantityRemaining, int ProductID)
        {

            SqlParameter quantParam = new SqlParameter("QuantityRemaining", QuantityRemaining);
            SqlParameter proParam = new SqlParameter("ProductID", ProductID);
            try
            {
                string objs = @"
                UPDATE Stock SET QuantityRemaining = @QuantityRemaining
                WHERE ProductID = @ProductID";
                object[] parameters = new object[] { quantParam, proParam };
                var result = db.Database.ExecuteSqlCommandAsync(objs, parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static Task<int> UpdatePassowrd (ADG4_L3C3Entities db, int? UserAccountID, string Password)
        {

            SqlParameter IDParam = new SqlParameter("UserAccountID", UserAccountID);
            SqlParameter PasswordParam = new SqlParameter("Password", Password);
            try
            {
                string objs = @"
                UPDATE UserAccounts SET Password = @Password
                WHERE UserAccountID = @UserAccountID";
                object[] parameters = new object[] { IDParam, PasswordParam };
                var result = db.Database.ExecuteSqlCommandAsync(objs, parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}