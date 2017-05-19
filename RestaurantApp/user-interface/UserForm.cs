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
using IronPdf;

namespace RestaurantApp
{
    public partial class UserForm : Form
    {
        private User userLogged;

        private List<FoodStuff> foodListAvailable;
        private List<FoodStuff> foodListSelected;
        private double totalValueToPay;
        private int totalTimeToCook;

        private List<Table> tableList;
        private Table tableSelected;
        private bool selected;

        private List<Order> userOrders;

        private MyDBContext context;
        private IUserRepository userRepository;
        private IFoodStuffRepository foodRepository;
        private ITableRepository tableRepository;
        private IOrderRepository orderRepository;

        private ImageHandlerService imageService;
        private GeneratorPdfService pdfGeneratorService;

        public UserForm(User user )
        {
            this.userLogged = user;
            this.context = new MyDBContext();
            this.userRepository = new UserRepository(context);
            this.foodRepository = new FoodStuffRepository(context);
            this.tableRepository = new TableRepository(context);
            this.orderRepository = new OrderRepository(context);
            this.imageService = new ImageHandlerService();
            this.pdfGeneratorService = new GeneratorPdfService();
        
            InitializeComponent();
        }

        /*
         * PLACE ORDER
         */

       private void initComponentsByDefault()
        {
            this.totalValueToPay = 0;
            this.totalTimeToCook = 0;
            this.label3.Text = "Cost total : " + 0 + " lei";
            this.label2.Text = "Timp de preparare : " + 0 + " minute";

            this.selected = false;
            this.tableSelected = null;

            this.initGridView1();
            this.initGridView3();

            //clear list of selected food for order
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }

        private void plasareComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage1.Hide();
            tabPage2.Show();
            tabPage3.Hide();
            this.foodListSelected = new List<FoodStuff>();
            this.initComponentsByDefault();         
        }
        
        // Initialize grid of food list 
        private void initGridView1()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if (this.foodListAvailable != null)
                this.foodListAvailable.Clear();         
            this.foodListAvailable = this.foodRepository.FindAll();

            foreach (FoodStuff food in this.foodListAvailable)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = food.Name;
                dataGridView1.Rows[index].Cells[1].Value = this.imageService.convertByteArrayToImage(food.ImageContent);
                dataGridView1.Rows[index].Cells[2].Value = "Adauga";
            }
        }

        //Initialize table of redtaurant tables
        private void initGridView3()
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            if (this.tableList != null)
                this.tableList.Clear();
            this.tableList = this.tableRepository.FindOnlyFreeTables();

            foreach(Table table in tableList)
            {
                var index = dataGridView3.Rows.Add();
                dataGridView3.Rows[index].Cells[0].Value = table.IdTable;
                dataGridView3.Rows[index].Cells[1].Value = table.Seats;
                dataGridView3.Rows[index].Cells[2].Value = "Adauga masa";
            }
        }

        //add to order list
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = this.foodListAvailable[e.RowIndex].Name;
                dataGridView2.Rows[index].Cells[1].Value = this.imageService.convertByteArrayToImage(this.foodListAvailable[e.RowIndex].ImageContent);
                dataGridView2.Rows[index].Cells[2].Value = "Elimina";

                this.totalValueToPay+=this.foodListAvailable[e.RowIndex].Price;
                this.label3.Text = "Cost total : "+ this.totalValueToPay + " lei";
                this.totalTimeToCook += this.foodListAvailable[e.RowIndex].PreparationTime;
                this.label2.Text= "Timp de preparare : " + this.totalTimeToCook + " minute";

                this.foodListSelected.Add(this.foodListAvailable[e.RowIndex]);
            }
        }

        //delete from order list
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridView2.Rows.RemoveAt(e.RowIndex);
                if (this.foodListSelected.Count() != 0)
                {
                    this.totalValueToPay -= this.foodListSelected[e.RowIndex].Price;
                    this.label3.Text = "Cost total : " + this.totalValueToPay + " lei";
                    this.totalTimeToCook -= this.foodListSelected[e.RowIndex].PreparationTime;
                    this.label2.Text = "Timp de preparare : " + this.totalTimeToCook + " minute";
                    this.foodListSelected.Remove(this.foodListSelected[e.RowIndex]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
                this.initGridView1();
            else
            {
                List<FoodStuff> auxList = new List<FoodStuff>();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                foreach (FoodStuff food in this.foodListAvailable)
                    if (food.Name.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        var index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells[0].Value = food.Name;
                        dataGridView1.Rows[index].Cells[1].Value = this.imageService.convertByteArrayToImage(food.ImageContent);
                        dataGridView1.Rows[index].Cells[2].Value = "Adauga";
                    }
            }
        }


        // Add or remove table (same data grid)
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.selected == false)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    this.tableSelected = this.tableList[e.RowIndex];
                    this.selected = true;
                    //delete every row
                    this.dataGridView3.Rows.Clear();
                    this.dataGridView3.Refresh();
                    //add only the selected table
                    var index=this.dataGridView3.Rows.Add();
                    this.dataGridView3.Rows[index].Cells[0].Value = this.tableSelected.IdTable;
                    this.dataGridView3.Rows[index].Cells[1].Value = this.tableSelected.Seats;
                    this.dataGridView3.Rows[index].Cells[2].Value = "Alta masa";
                }
            }
            else
            {
                this.initGridView3();
                this.selected = false;
                this.tableSelected = null;
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.foodListSelected.Count() == 0)
            {
                MessageBox.Show("Nu a fost selectat niciun preparat!","Lipsa date!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (this.tableSelected == null)
            {
                MessageBox.Show("Nu a fost selectata nicio masa!", "Lipsa date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.Now;
            newOrder.Status = "PREPARING";
            newOrder.User = this.userRepository.FindByUserName(this.userLogged.UserName);
            newOrder.Table = this.tableSelected;
            newOrder.OrderFood = this.foodListSelected;

            this.tableRepository.UpdateTableStatusById(tableSelected.IdTable, "OCCUPIED");
            this.orderRepository.InsertOrder(newOrder);

            MessageBox.Show("Comanda adaugata cu succes!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.initComponentsByDefault();
        }




        /*
        * HANDLING USER ORDERS
        */


        private void comenzileMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage1.Hide();
            tabPage2.Hide();
            tabPage3.Show();
            this.initGridView4();
        }

        private void initGridView4()
        {
            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();
            if (this.userOrders != null)
                this.userOrders.Clear();
            this.userOrders = this.orderRepository.FindOrdersByUserId(this.userLogged.IdUser);
            if (userOrders!=null) {
                foreach (Order order in userOrders)
                {
                    var index = dataGridView4.Rows.Add();
                    dataGridView4.Rows[index].Cells[0].Value = order.IdOrder;
                    dataGridView4.Rows[index].Cells[1].Value = order.Table.IdTable;

                    if (order.Status.Equals("PREPARING"))
                    {
                        dataGridView4.Rows[index].Cells[2].Value = "Se prepara";
                        dataGridView4.Rows[index].Cells[3].Value = "Serveste";
                    }
                    if (order.Status.Equals("SERVED"))
                    {
                        dataGridView4.Rows[index].Cells[2].Value = "Servit";
                        dataGridView4.Rows[index].Cells[3].Value = "Finalizeaza";
                    }
                    if (order.Status.Equals("FINALISED"))
                    {
                        dataGridView4.Rows[index].Cells[2].Value = "Finalizat";
                        dataGridView4.Rows[index].Cells[3].Value = "Genereaza bon fiscal";
                    }
                }
            }

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;        

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 )
            {
                if (this.userOrders[e.RowIndex].Status.Equals("PREPARING"))
                {
                    this.orderRepository.ChangeStatusById(this.userOrders[e.RowIndex].IdOrder, "SERVED");
                    this.initGridView4();
                    return;
                }
                if (this.userOrders[e.RowIndex].Status.Equals("SERVED"))
                {                   
                    this.tableRepository.UpdateTableStatusById(this.userOrders[e.RowIndex].Table.IdTable,"FREE");
                    this.orderRepository.ChangeStatusById(this.userOrders[e.RowIndex].IdOrder, "FINALISED");
                    this.initGridView4();
                    return;
                }
                if (this.userOrders[e.RowIndex].Status.Equals("FINALISED"))
                {
                    this.pdfGeneratorService.generatePdfByOrder(this.userOrders[e.RowIndex]);
                }
            }
        }

        private void delogareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HomeLoginForm().Show();
        }
    }
}
