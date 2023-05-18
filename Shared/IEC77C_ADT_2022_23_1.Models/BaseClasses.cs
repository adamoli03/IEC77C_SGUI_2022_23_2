﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Data;
using System.Text.Json;

namespace IEC77C_ADT_2022_23_1.Models
{
    [Table("Stores")]
    public class Store
    {
        [Key]
        public int Store_ID { get; set; }
        public int Company_ID { get; set; }
        public int City_ID { get; set; }
        [Required]
        public string Address { get; set; }
        public int Size { get; set; } //squareMeters

        public string GetString()
        {
            return JsonSerializer.Serialize<Store>(this);
        }
    }
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int Company_ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int networth { get; set; }

        public string GetString()
        {
            return JsonSerializer.Serialize<Company>(this);
        }
    }
    [Table("Cities")]
    public class City
    {
        [Key]
        public int City_ID { get; set; }
        [Required]
        public string City_Name { get; set; }
        public string Country { get; set; }

        public string GetString()
        {
            return JsonSerializer.Serialize<City>(this);
        }
    }


}
