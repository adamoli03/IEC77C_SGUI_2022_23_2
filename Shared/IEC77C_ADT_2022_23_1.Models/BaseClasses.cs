using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Data;



namespace IEC77C_ADT_2022_23_1.Models
{
    [Table("Stores")]
    public class Store
    {
        [Key]
        [property: JsonPropertyName("Store_ID")]
        public int Store_ID { get; set; }
        [property: JsonPropertyName("Company_ID")]public int Company_ID { get; set; }
        [property: JsonPropertyName("City_ID")]public int City_ID { get; set; }
        [Required]
        [property: JsonPropertyName("Address")] public string Address { get; set; }
        [property: JsonPropertyName("Size")] public int Size { get; set; } //squareMeters
    }
    [Table("Companies")]
    public class Company
    {
        [Key]
        [property: JsonPropertyName("Company_ID")] public int Company_ID { get; set; }
        [Required]
        [property: JsonPropertyName("Name")] public string Name { get; set; }
        [property: JsonPropertyName("networth")] public int networth { get; set; }
    }
    [Table("Cities")]
    public class City
    {
        [Key]
        [property: JsonPropertyName("City_ID")] public int City_ID { get; set; }
        [Required]
        [property: JsonPropertyName("City_Name")] public string City_Name { get; set; }
        [property: JsonPropertyName("Country")] public string Country { get; set; }

    }


}
