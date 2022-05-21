using System.ComponentModel.DataAnnotations;

namespace Res_WebApp.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public int Price { get; set; }
        
    }
}
