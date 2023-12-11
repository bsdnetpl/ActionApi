namespace ActionApi.Models
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public string categoryId { get; set; }
        public string warranty { get; set; }
        public double priceNet { get; set; }
        public int vat { get; set; }
        public string pkwiu { get; set; }
        public int available { get; set;}
        public string EAN { get; set;}
        public string manufacturerPartNumber { get; set;}
        public int sizeWidth { get; set; }
        public int sizeHeight { get; set; }
        public int sizeLength { get; set; }
        public int weight { get; set; }
    }
}
