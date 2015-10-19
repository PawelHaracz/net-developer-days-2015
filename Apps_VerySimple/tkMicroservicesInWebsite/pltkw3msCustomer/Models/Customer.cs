using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pltkw3msCustomer.Models
{
    internal static class Helper {
        static Random m_rnd = new Random();
        public static string GetRandomStr() { return m_rnd.Next(10000).ToString(); }
        public static int GetRandomInt() { return m_rnd.Next(10000); }

    }

    /// <summary>
    /// Customer address 
    /// </summary>
    public class Address
    {
        public string Street { get; set; } = "Street" + Helper.GetRandomStr();
        public string HouseNo { get; set; } = "House" + Helper.GetRandomStr();
        public string City{ get; set; } = "City" + Helper.GetRandomStr();
        public string PostalCode { get; set; } = "P" + Helper.GetRandomStr();
    }
    /// <summary>
    /// Customer entity
    /// </summary>
    public class Customer
    {
        public int Id { get; set; } = Helper.GetRandomInt();
        public string Name { get; set; } = "ClientName" + Helper.GetRandomStr();
        public Address Address { get; set; } = new Address();
    }
}