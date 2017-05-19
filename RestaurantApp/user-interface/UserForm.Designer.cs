using System.Drawing;
using System.Windows.Forms;

namespace RestaurantApp
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plasareComandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generareBonFiscalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comenzileMeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delogareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.IdTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddTableToOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.FoodNameAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageOfFoodAdded = new System.Windows.Forms.DataGridViewImageColumn();
            this.RemoveFoodFromOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FoodNameFromList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoodImageFromFoodList = new System.Windows.Forms.DataGridViewImageColumn();
            this.AddToOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeStatus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plasareComandaToolStripMenuItem,
            this.generareBonFiscalToolStripMenuItem,
            this.comenzileMeleToolStripMenuItem,
            this.delogareToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plasareComandaToolStripMenuItem
            // 
            this.plasareComandaToolStripMenuItem.Name = "plasareComandaToolStripMenuItem";
            this.plasareComandaToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.plasareComandaToolStripMenuItem.Text = "Plasare comanda";
            this.plasareComandaToolStripMenuItem.Click += new System.EventHandler(this.plasareComandaToolStripMenuItem_Click);
            // 
            // generareBonFiscalToolStripMenuItem
            // 
            this.generareBonFiscalToolStripMenuItem.Name = "generareBonFiscalToolStripMenuItem";
            this.generareBonFiscalToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // comenzileMeleToolStripMenuItem
            // 
            this.comenzileMeleToolStripMenuItem.Name = "comenzileMeleToolStripMenuItem";
            this.comenzileMeleToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.comenzileMeleToolStripMenuItem.Text = "Comenzile mele";
            this.comenzileMeleToolStripMenuItem.Click += new System.EventHandler(this.comenzileMeleToolStripMenuItem_Click);
            // 
            // delogareToolStripMenuItem
            // 
            this.delogareToolStripMenuItem.Name = "delogareToolStripMenuItem";
            this.delogareToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.delogareToolStripMenuItem.Text = "Delogare";
            this.delogareToolStripMenuItem.Click += new System.EventHandler(this.delogareToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 495);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(851, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(845, 480);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(524, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 66);
            this.button2.TabIndex = 6;
            this.button2.Text = "Plaseaza comanda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Location = new System.Drawing.Point(11, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 159);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alege masa";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTable,
            this.TableSeats,
            this.AddTableToOrder});
            this.dataGridView3.Location = new System.Drawing.Point(12, 20);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(385, 133);
            this.dataGridView3.TabIndex = 1;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // IdTable
            // 
            this.IdTable.HeaderText = "Id masa";
            this.IdTable.Name = "IdTable";
            this.IdTable.Width = 90;
            // 
            // TableSeats
            // 
            this.TableSeats.HeaderText = "Locuri";
            this.TableSeats.Name = "TableSeats";
            // 
            // AddTableToOrder
            // 
            this.AddTableToOrder.HeaderText = "Adauga masa ";
            this.AddTableToOrder.Name = "AddTableToOrder";
            this.AddTableToOrder.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(829, 290);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Creare meniu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(551, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Preparate selectate pentru comanda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(102, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lisa de preparate disponibile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Timp de prepare";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cauta preparat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoodNameAdded,
            this.ImageOfFoodAdded,
            this.RemoveFoodFromOrder});
            this.dataGridView2.Location = new System.Drawing.Point(428, 34);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 50;
            this.dataGridView2.Size = new System.Drawing.Size(385, 214);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // FoodNameAdded
            // 
            this.FoodNameAdded.HeaderText = "Nume preparat";
            this.FoodNameAdded.Name = "FoodNameAdded";
            // 
            // ImageOfFoodAdded
            // 
            this.ImageOfFoodAdded.HeaderText = "Imagine preparat";
            this.ImageOfFoodAdded.Image = global::RestaurantApp.Properties.Resources.White_square;
            this.ImageOfFoodAdded.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ImageOfFoodAdded.Name = "ImageOfFoodAdded";
            this.ImageOfFoodAdded.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImageOfFoodAdded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImageOfFoodAdded.Width = 140;
            // 
            // RemoveFoodFromOrder
            // 
            this.RemoveFoodFromOrder.HeaderText = "Elimina";
            this.RemoveFoodFromOrder.Name = "RemoveFoodFromOrder";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(92, 262);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cauta dupa \r\nnume";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoodNameFromList,
            this.FoodImageFromFoodList,
            this.AddToOrder});
            this.dataGridView1.Location = new System.Drawing.Point(6, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(391, 214);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FoodNameFromList
            // 
            this.FoodNameFromList.HeaderText = "Nume preparat";
            this.FoodNameFromList.Name = "FoodNameFromList";
            // 
            // FoodImageFromFoodList
            // 
            this.FoodImageFromFoodList.HeaderText = "Imagine preparat";
            this.FoodImageFromFoodList.Image = global::RestaurantApp.Properties.Resources.White_square;
            this.FoodImageFromFoodList.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.FoodImageFromFoodList.Name = "FoodImageFromFoodList";
            this.FoodImageFromFoodList.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FoodImageFromFoodList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FoodImageFromFoodList.Width = 140;
            // 
            // AddToOrder
            // 
            this.AddToOrder.HeaderText = "Adauga la comanda";
            this.AddToOrder.Name = "AddToOrder";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(851, 486);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.dataGridView4);
            this.groupBox3.Location = new System.Drawing.Point(121, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(618, 455);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comenzile mele";
            // 
            // dataGridView4
            // 
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.TableId,
            this.OrderStatus,
            this.ChangeStatus});
            this.dataGridView4.Location = new System.Drawing.Point(65, 19);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(498, 421);
            this.dataGridView4.TabIndex = 0;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "Id";
            this.OrderId.Name = "OrderId";
            // 
            // TableId
            // 
            this.TableId.HeaderText = "Masa";
            this.TableId.Name = "TableId";
            // 
            // OrderStatus
            // 
            this.OrderStatus.HeaderText = "Status";
            this.OrderStatus.Name = "OrderStatus";
            // 
            // ChangeStatus
            // 
            this.ChangeStatus.HeaderText = "Schimba status";
            this.ChangeStatus.Name = "ChangeStatus";
            this.ChangeStatus.Width = 150;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 519);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Window";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plasareComandaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generareBonFiscalToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodNameAdded;
        private System.Windows.Forms.DataGridViewImageColumn ImageOfFoodAdded;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveFoodFromOrder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodNameFromList;
        private System.Windows.Forms.DataGridViewImageColumn FoodImageFromFoodList;
        private System.Windows.Forms.DataGridViewButtonColumn AddToOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableSeats;
        private System.Windows.Forms.DataGridViewButtonColumn AddTableToOrder;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ToolStripMenuItem comenzileMeleToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatus;
        private System.Windows.Forms.DataGridViewButtonColumn ChangeStatus;
        private System.Windows.Forms.ToolStripMenuItem delogareToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}