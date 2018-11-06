using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Producto
    {
        public DateTime arrivalDate { get; set; }
        public List<CampaignCollection> campaignCollection { get; set; }
        public string category { get; set; }
        public DateTime departureDate { get; set; }
        public int id { get; set; }
        public List<ImageCollection> imageCollection { get; set; }
        public Lodging lodging { get; set; }
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Descripción")]
        public string show { get; set; }
        public ShowCity showCity { get; set; }
        public DateTime showDate { get; set; }
        public ShowType showType { get; set; }
        [DisplayName("Precio")]
        [DisplayFormat(DataFormatString = "{0:#,#.##}")]
        public float totalPrice { get; set; }
        public TransportType transportType { get; set; }
    }

    public class CampaignCollection
    {
        public string description { get; set; }
        public DateTime finalDate { get; set; }
        public int id { get; set; }
        public DateTime initialDate { get; set; }
    }

    public class ImageCollection
    {
        public int id { get; set; }
        public string url { get; set; }

    }

    public class Lodging
    {
        public int id { get; set; }
        public string nameType { get; set; }
        public int price { get; set; }
    }

    public class CityType
    {
        public int id { get; set; }
        public string nameType { get; set; }
        public int price { get; set; }
    }

    public class ShowCity
    {
        public CityType cityType { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public int id { get; set; }
    }

    public class ShowType
    {
        public int id { get; set; }
        [DisplayName("Especataculo")]
        public string nameType { get; set; }
        public int price { get; set; }
    }

    public class TransportType
    {
        public int id { get; set; }
        [DisplayName("Transporte")]
        public string nameType { get; set; }
        public int price { get; set; }
    }
}