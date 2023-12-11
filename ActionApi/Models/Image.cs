namespace ActionApi.Models
{
    public class Image
    {
        public string Id { get; set; }
        public string url1 { set; get; }
        public string url2 { set; get; }
        public string url3 { set; get; }
        public string url4 { set; get; }
        public string url5 { set; get; }
        public bool isMain { get; set; }
        public string date { get; set; }
        public bool copyright { get; set; } = true;

    }
}
