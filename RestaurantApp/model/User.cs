using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace RestaurantApp.model
{
    [Table ("User")]
    public class User
    {   

        [Key]
        [Column("id_user")]
        public int IdUser {get;set;}

        [Required]
        [Column("first_name")]
        public String FirstName { get; set; }

        [Required]
        [Column("last_name")]
        public String LastName { get; set; }

        [Required]
        [Column("user_name")]
       
        public String UserName { get; set; }

        [Required]
        [MinLength(6)]
        [Column("password")]
        public String Password { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Order> rOrders { get; set; }

    }
    

}
