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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RestaurantApp.model.Role;

namespace RestaurantApp
{
    public partial class Admin : Form
    {
        private List<User> userList;
        private User userUpdated;
        private User userLogged;

        private FoodStuff newFoodMenu;
        private byte[] imageAsByte;
        private List<FoodStuff> foodList;
        private FoodStuff foodUpdated;

        private MyDBContext context;
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private IFoodStuffRepository foodRepository;
        private DataBaseSecurityService dbSecurer;

        ImageHandlerService imageService;

        public Admin(User user)
        {
            this.context = new MyDBContext();
            this.userRepository = new UserRepository(context);
            this.roleRepository = new RoleRepository(context);
            this.foodRepository = new FoodStuffRepository(context);
            this.imageService = new ImageHandlerService();
            this.dbSecurer = new DataBaseSecurityService();
            this.userLogged = user;
        
            InitializeComponent();
        }

        /*
         * SECTION OF ADDING NEW USER/ADMIN
         */

        private void adaugaUtlizatorNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage2.Show();
            tabPage1.Hide();
            tabPage4.Hide();
            tabPage3.Hide();
            tabPage5.Hide();
            tabPage6.Hide();
            tabPage7.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                (radioButton1.Checked || radioButton2.Checked))
            {
                if (textBox4.Text.Length >= 6)
                {
                    User userByUserName = this.userRepository.FindByUserName(textBox3.Text);

                    if (userByUserName == null)
                    {
                        newUser.LastName = textBox1.Text;
                        newUser.FirstName = textBox2.Text;
                        newUser.UserName = textBox3.Text;
                        newUser.Password = this.dbSecurer.HashUserPassword(textBox4.Text);
                        if (radioButton1.Checked)
                            newUser.Role = this.roleRepository.FindRoleByGrade(Grade.USER);
                        else
                            newUser.Role = this.roleRepository.FindRoleByGrade(Grade.ADMIN);

                        this.userRepository.InsertUser(newUser);
                        MessageBox.Show("Utilizator adaugat cu succes!", "Succes!", MessageBoxButtons.OK);
                        this.textBox1.Clear(); this.textBox2.Clear(); this.textBox3.Clear(); this.textBox4.Clear();
                        this.radioButton1.Checked = false; this.radioButton2.Checked = false;
                    }
                    else
                        MessageBox.Show("Numele de utilizator este utlizat!", "Duplicat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Parola trebuie sa contina minim 6 caractere!", "Date incorecte!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Toate campurile sunt obligatorii!", "Lipsa date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

   
        
        /*
         * SECTION OF UPDATE USER/ADMIN 
         */

        private void refreshDataGridView1OnChange()
        {
            if (this.userList != null)
                this.userList.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            this.userUpdated = null;

            this.userList = this.userRepository.FindAll();
            foreach (User user in userList)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["Id"].Value = user.IdUser;
                dataGridView1.Rows[index].Cells["FullName"].Value = user.LastName + " " + user.FirstName;
                dataGridView1.Rows[index].Cells["UserName"].Value = user.UserName;
                dataGridView1.Rows[index].Cells["Edit"].Value = "Edit";
            }
        }

        private void modificaDateUtilizatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage3.Show();
            tabPage1.Hide();
            tabPage2.Hide();
            tabPage4.Hide();
            tabPage5.Hide();
            tabPage6.Hide();
            tabPage7.Hide();
            //init data structure at every refresh
            this.refreshDataGridView1OnChange();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //init user with initial data
                this.userUpdated = this.userList[e.RowIndex];
                //export data
                textBox9.Text = this.userList[e.RowIndex].LastName;
                textBox8.Text = this.userList[e.RowIndex].FirstName;
                textBox7.Text = this.userList[e.RowIndex].UserName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.userUpdated != null)
            {
                if (textBox9.Text != "")
                {
                    this.userUpdated.LastName = textBox9.Text;
                }
                if (textBox8.Text != "")
                {
                    this.userUpdated.FirstName = textBox8.Text;
                }
                if (textBox7.Text != "")
                {
                    this.userUpdated.UserName = textBox7.Text;
                }

                if (textBox6.Text != "" || textBox5.Text != "")
                {
                    if (textBox6.Text.Length >= 6 && textBox5.Text.Length >= 6 && textBox6.Text.Equals(textBox5.Text))
                        this.userUpdated.Password = this.dbSecurer.HashUserPassword(textBox6.Text);
                    else
                    {
                        MessageBox.Show("Daca doriti sa schimbati parola, campurile pentru parola trebuie sa coincida si sa contina minim 6 caractere!", "Inconsistenta date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DialogResult dialogResult = MessageBox.Show("Sunteti sigur de modificari?", "Verificare", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.userRepository.UpdateUserByUserUpdated(this.userUpdated);
                    this.refreshDataGridView1OnChange();
                    textBox9.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    this.userUpdated = null;
                }
            }
            else
                MessageBox.Show("Este nevoie sa selectati un utilizator!", "Lipsa date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        /*
        * SECTION OF DELETING USER 
        */

        private void stergeUtilizatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage4.Show();
            tabPage1.Hide();
            tabPage2.Hide();
            tabPage3.Hide();
            tabPage5.Hide();
            tabPage6.Hide();
            tabPage7.Hide();
            this.refreshDataGridView2OnChange();
        }

        private void refreshDataGridView2OnChange()
        {
            if (this.userList != null)
                this.userList.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            this.userList = this.userRepository.FindAll();

            foreach (User user in userList)
            {
                var index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = user.IdUser;
                dataGridView2.Rows[index].Cells[1].Value = user.FirstName;
                dataGridView2.Rows[index].Cells[2].Value = user.LastName;
                dataGridView2.Rows[index].Cells[3].Value = user.UserName;
                dataGridView2.Rows[index].Cells[4].Value = user.Role.Authority;
                dataGridView2.Rows[index].Cells[5].Value = "Delete";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteti sigur ca doriti sa stergeti utilizatorul?", "Verificare", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.userRepository.DeleteUserById(this.userList[e.RowIndex].IdUser);
                    this.refreshDataGridView2OnChange();
                }
            }
        }


        /*
         * SECTION OFF ADD NEW FOOD 
         */

        private void adaugareMeniuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage5.Show();
            tabPage1.Hide();
            tabPage2.Hide();
            tabPage3.Hide();
            tabPage4.Hide();
            tabPage6.Hide();
            tabPage7.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {             
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    // Receive image from computer
                    string text = File.ReadAllText(file);              
                    Image image = Image.FromFile(file);
                    pictureBox1.Image = image;

                    //converting image to byte array        
                    this.imageAsByte = this.imageService.convertImageToByteArray(image);                
                }
                catch (IOException)
                {
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox10.Text!="" && textBox12.Text!="" && maskedTextBox1.Text!="" && maskedTextBox2.Text!="" && maskedTextBox3.Text != "")
            {
                this.newFoodMenu = new FoodStuff();
                this.newFoodMenu.Name = textBox10.Text;
                this.newFoodMenu.Details = textBox12.Text;
                this.newFoodMenu.Weigth = Int16.Parse(maskedTextBox1.Text);
                this.newFoodMenu.PreparationTime = Int16.Parse(maskedTextBox2.Text);
                this.newFoodMenu.Price = Double.Parse(maskedTextBox3.Text);
                if (this.imageAsByte != null)
                    this.newFoodMenu.ImageContent = this.imageAsByte;
                this.foodRepository.InserFoodStuff(this.newFoodMenu);

                MessageBox.Show("Preparat adaugat cu succes !", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox10.Text = "";
                textBox12.Text = "";
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                maskedTextBox3.Text = "";
                pictureBox1.Image = null;
                this.imageAsByte = null;

            }
            else
                MessageBox.Show("Toate campurile sunt obligatorii !", "Lipsa date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /*
         * SECTION OF UPDATE FOOD STUFF
         */
        
        private void modificaMeniuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage6.Show();
            tabPage1.Hide();
            tabPage2.Hide();
            tabPage3.Hide();
            tabPage4.Hide();
            tabPage5.Hide();
            tabPage7.Hide();
            this.refreshDataGridView3OnChange();
        }

        private void refreshDataGridView3OnChange()
        {
            if (this.foodList != null)
                this.foodList.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();

            this.foodList = this.foodRepository.FindAll();

            foreach (FoodStuff food in foodList)
            {
                var index = dataGridView3.Rows.Add();
                dataGridView3.Rows[index].Cells[0].Value = food.IdFood;
                dataGridView3.Rows[index].Cells[1].Value = food.Name;
                dataGridView3.Rows[index].Cells[2].Value = food.Price; 
                dataGridView3.Rows[index].Cells[3].Value = "Edit";
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                this.foodUpdated = this.foodList[e.RowIndex];
                this.textBox13.Text = this.foodUpdated.Name;
                this.textBox11.Text = this.foodUpdated.Details;
                this.maskedTextBox6.Text = this.foodUpdated.Weigth.ToString();
                this.maskedTextBox5.Text = this.foodUpdated.PreparationTime.ToString();

                this.maskedTextBox4.Text = this.foodUpdated.Price.ToString("00#.#");
                if (this.foodUpdated.ImageContent != null)
                    this.pictureBox2.Image = this.imageService.convertByteArrayToImage(this.foodUpdated.ImageContent);
                else
                    this.pictureBox2.Image = null;
            }
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog2.FileName;
                try
                {
                    // Receive image from computer
                    string text = File.ReadAllText(file);
                    Image image = Image.FromFile(file);
                    pictureBox2.Image = image;
                }
                catch (IOException)
                {
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "" && textBox11.Text != "" && maskedTextBox4.Text != "" && maskedTextBox5.Text != "" && maskedTextBox6.Text != "" && this.foodUpdated != null)
            {
                this.foodUpdated.Name = this.textBox13.Text;
                this.foodUpdated.Details = this.textBox11.Text;
                this.foodUpdated.Weigth = Int32.Parse(this.maskedTextBox6.Text);
                this.foodUpdated.PreparationTime = Int32.Parse(this.maskedTextBox5.Text);
                this.foodUpdated.Price = Double.Parse(this.maskedTextBox4.Text);
                this.foodUpdated.ImageContent = this.imageService.convertImageToByteArray(pictureBox2.Image);
                this.foodRepository.UpdateFoodStuff(this.foodUpdated);

                DialogResult dialogResult = MessageBox.Show("Sunteti sigur de modificari?", "Verificare", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.foodRepository.UpdateFoodStuff(this.foodUpdated);
                    this.refreshDataGridView3OnChange();
                    this.foodUpdated = null;
                    this.textBox13.Text = "";
                    this.textBox11.Text = "";
                    this.maskedTextBox6.Text = "";
                    this.maskedTextBox5.Text = "";
                    this.maskedTextBox4.Text = "";
                    this.pictureBox2.Image = null;
                }
            }
            else
                MessageBox.Show("Preparat neselectat sau campuri goale!", "Lipsa date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
        /*
         * DELETE FOOD STUFF 
         */

        private void stergeMeniuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage7.Show();
            tabPage1.Hide();
            tabPage2.Hide();
            tabPage3.Hide();
            tabPage4.Hide();
            tabPage5.Hide();
            tabPage6.Hide();
            this.refreshDataGridView4OnChange();
        }

        private void refreshDataGridView4OnChange()
        {
            if (this.foodList != null)
                this.foodList.Clear();
            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();
            this.foodList = this.foodRepository.FindAll();

            foreach (FoodStuff food in foodList)
            {
                var index = dataGridView4.Rows.Add();
                dataGridView4.Rows[index].Cells[0].Value = food.IdFood;
                dataGridView4.Rows[index].Cells[1].Value = food.Name;               
                dataGridView4.Rows[index].Cells[2].Value = this.imageService.convertByteArrayToImage(food.ImageContent);
                dataGridView4.Rows[index].Cells[3].Value = "Elimina";
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteti sigur ca doriti sa stergeti preparatul?", "Verificare", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.foodRepository.DeleteById(this.foodList[e.RowIndex].IdFood);
                    this.refreshDataGridView4OnChange();
                }
            }
        }

        private void delogareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.context.Dispose();
            new HomeLoginForm().Show();
        }
    }
}

