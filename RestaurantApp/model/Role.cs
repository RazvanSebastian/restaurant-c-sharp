using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.model
{
    [Table("Role")]
    public class Role
    {
        public enum Grade
        {
            ADMIN,USER
        }

        [Key]
        [Column("id_role")]
        public int IdRole { get; set; }

        [Required]
        [Column("user_role")]
        public String Authority { get; set; }

        //One to Many 
        public virtual ICollection<User> users { get; set; }

    }
}
