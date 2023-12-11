namespace ActionApi.Models
{
    public class SubCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool export { get; set; }
        public string description { get; set; }
        public int margin { get; set; }
        public string idMainCategory { get; set; } = string.Empty;
    }
}
