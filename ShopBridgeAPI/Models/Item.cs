using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; } 

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name field Can't be empty.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Not a Valid Name")]
        public String Name { get; set; }

        public decimal Price { get; set; }

        [Required(AllowEmptyStrings =true)]
        [StringLength(150, MinimumLength = 0, ErrorMessage = "Not a Valid Discription. Cant be longer then 150 caracters.")]
        public string Discription { get; set; }

        [DataType(DataType.ImageUrl,ErrorMessage ="Not a valid Image url")]
        public string ImageUrl { get; set; }
    }
}
