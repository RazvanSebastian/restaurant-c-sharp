using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.model
{
    [Table("table")]
    public class Table
    {
        public enum TableStatus
        {
            FREE,OCCUPIED
        }

        [Key]
        [Column("id_table")]
        public int IdTable { get; set; }

        [Column("seats_number")]
        public int Seats { get; set; }

        [Column("status")]
        public String Status { get; set; }

        public Order Order;
    }
}
