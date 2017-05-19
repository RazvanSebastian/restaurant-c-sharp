using RestaurantApp.data_base_configuration;
using RestaurantApp.model;
using RestaurantApp.repository;
using RestaurantApp.repository.inter;
using RestaurantApp.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class HomeLoginForm : Form
    {

        private MyDBContext context;
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private DataBaseSecurityService dbSecurer;

        public HomeLoginForm()
        {
            this.context = new MyDBContext();
            this.userRepository = new UserRepository(context);
            this.roleRepository = new RoleRepository(context);
            this.dbSecurer = new DataBaseSecurityService();
            this.InitDataBase();
            InitializeComponent();
        }

        private void InitDataBase()
        {    
            if (roleRepository.Count() == 0)
            {
                Role role = new Role();
               
                role.Authority = "USER";
                roleRepository.InsertRole(role);           

                role.Authority = "ADMIN";
                roleRepository.InsertRole(role);
            }

            if (userRepository.Count() == 0)
            {        
                User user = new User();
                Role role = roleRepository.FindRoleByGrade(Role.Grade.ADMIN);
                user.FirstName = "Razvan";
                user.LastName = "Parautiu";
                user.UserName = "RazvanAdmin";
                user.Password = dbSecurer.HashUserPassword("password"); 
                user.Role=role;
                userRepository.InsertUser(user);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //check user interface fields
            if (textBox1.Text != "" && textBox2.Text != "" && radioButton1.Checked  || radioButton2.Checked  )
            {
                User userSearched = this.userRepository.FindByUserName(textBox1.Text);
                //check if we have user by userName
                if (userSearched != null)
                {
                    //check if the hash password and plain password are matching
                    if (this.dbSecurer.checkPasswordMatching(textBox2.Text, userSearched.Password))
                    {                      
                        if (userSearched.Role.Authority == "ADMIN" && radioButton2.Checked == true)
                        {
                            Admin adminForm = new Admin(userSearched);
                            adminForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            if (userSearched.Role.Authority == "USER" && radioButton1.Checked == true)
                            {
                                UserForm userFrom = new UserForm(userSearched);
                                userFrom.Show();
                                context.Dispose();
                                this.Hide();
                            }
                            else
                                MessageBox.Show("Incearca alta autoritate!", "Date incorecte!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }     
                    }
                    else
                        MessageBox.Show("Parola nu se potriveste!", "Date incorecte!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Utilizatorul nu exista", "Date incorecte!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Toate campurile sunt necesare!", "Date incorecte!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

       
    }
}
