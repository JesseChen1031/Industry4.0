using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }
        public string accountName { get; set; }
        public string password { get; set; }
        public string storePosition { get; set; }
        public string type { get; set; }
        public string sendOrder { get; set; }
        public string accountAdmin { get; set; }
        public string deviceOperate { get; set; }
        public string paramSetting { get; set; }
        public string materialAdmin { get; set; }

    }

    public class Admin
    {
        public int Id { get; set; }
        public string adminname { get; set; }
        public string password { get; set; }
    }

    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int phoneNum { get; set; }

        public string firstAddress { get; set; }
        public string secondAddress { get; set; }
        public bool defaultAddress {get;set;}
    }

    public class order
    {
        [Key]
        public int id { get; set; }
        public string productName { get; set; }
        public string axisMaterial { get; set; }
        public string sleeveMaterial { get; set; }
        public string pressTime { get; set; }
        public string num { get; set; }
        public string storePosition { get; set; }
        public string clientName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }
        public int status { get; set; }
    }

    public class deviceOW
    {
        [Key]
        public int id { get; set; }
        public string deviceName { get; set; }
        public string ip { get; set; }
        public int deviceState { get; set; }
    }

    public class product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public string axisMaterial { get; set; }
        public string sleeveMaterial { get; set; }
        public string quality { get; set; }
        public string color { get; set; }
        public string pressTime { get; set; }

    }

    public class material
    {
        public int id { get; set; }
        public string materialName { get; set; }
        public int materialType { get; set; }
        
    }

    public class bin
    {
        public int id { get; set; }
        public int binMaterialId { get; set; }
        public int binType { get; set; }
    }
}
