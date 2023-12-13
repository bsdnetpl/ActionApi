using System.ComponentModel.DataAnnotations;

namespace ActionApi.Models
{
    public class MainCategory
    {
        
        public Guid ids { get; set; }
        public string idntification { get; set; }
        public string name { get; set; }
        public bool export { get; set; }
        public string description { get; set; }
        public int margin { get; set; }
    }
}
