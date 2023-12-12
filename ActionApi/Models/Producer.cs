using System.ComponentModel.DataAnnotations;

namespace ActionApi.Models
{
    public class Producer
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }

    }
}
