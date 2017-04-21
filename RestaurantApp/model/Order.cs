using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.model
{
    [Table("Order")]
    public class Order
    {
        public enum OrderStatus
        {
            WAITING,PREPARING,SERVED,PAID
        }

        [Key]
        [Column("id_order")]
        public int IdOrder { get; set; }

        [Column("order_date")]
        [Required]
        public DateTime OrderDate { get; set; }

        [Column("status")]
        [Required]
        public String Status { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<FoodStuff> FoodStuffs { get; set; }

        public virtual Table Table { get; set; }
    }
}
