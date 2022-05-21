using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Res_WebApp.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [DisplayName("Food")]
        public string ?ImgFood { get; set; }
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        [DataType(DataType.Currency)]
        public float? Price { get; set; }
        [NotMapped]
        [DisplayName("Upload")]
        public IFormFile ?ImageFile { get; set; }

    }
}
