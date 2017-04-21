using RestaurantApp.data_base_configuration;
using RestaurantApp.model;
using RestaurantApp.repository;
using RestaurantApp.repository.inter;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new HomeLoginForm()); 
        }
    }
}
