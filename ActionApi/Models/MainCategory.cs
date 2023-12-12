using System.ComponentModel.DataAnnotations;

namespace ActionApi.Models
{
    public class MainCategory
    {
        [Key]
        public int ids { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public bool export { get; set; }
        public string description { get; set; }
        public int margin { get; set; }
    }
}
