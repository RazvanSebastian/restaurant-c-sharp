using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.model
{
    [Table("food_stuff")]
    public class FoodStuff
    {
        [Key]
        [Column("id_food")]
        public int IdFood { get; set; }

        [Required]
        [Column("food_name")]
        public String Name { get; set; }

        [Required]
        [Column("food_weight")]
        public int Weigth { get; set; }

        [Required]
        [Column("food_details")]
        public String Details { get; set; }

        [Required]
        [Column("preparation_time")]
        public int PreparationTime { get; set; }

        [Required]
        [Column("price")]
        public double Price { get; set; }

        [Column("image")]
        public byte[] ImageContent { get; set; }
        
        public virtual ICollection<Order> OrderFood { get; set; }
    }
}
