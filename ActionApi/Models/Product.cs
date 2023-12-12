using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActionApi.Models
{
    public class Product
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public string categoryId { get; set; }
        public string warranty { get; set; }
        public double priceNet { get; set; }
        public int vat { get; set; }
        public string pkwiu { get; set; }
        public int available { get; set; }
        public string EAN { get; set; }
        public string manufacturerPartNumber { get; set; }
        public int sizeWidth { get; set; }
        public int sizeHeight { get; set; }
        public int sizeLength { get; set; }
        public int weight { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; }
        public string urlImg1 { get; set; } = string.Empty;
        public string urlImg2 { get; set; } = string.Empty;
        public string urlImg3 { get; set; } = string.Empty;
        public string urlImg4 { get; set; } = string.Empty;
        public string urlImg5 { get; set; } = string.Empty;
    }

}
