using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NationGyms
{

    public partial class Search : Form
    {
        //list of querys 
        List<string> listQueryHistory = new List<string>();
        BindingSource bs = new BindingSource();

        public static Search instance;
        public Panel homePanelHeader;
        public Label displayUsername;
        public Label displayAccess;

        //data path
        public string DBPath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NationGymsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Search()
        {
            InitializeComponent();
            instance = this;

            //assigns binding source to List 
            bs.DataSource = listQueryHistory;

            displayUsername = labLoginUsername;
            displayAccess = labLoginAccess;

            //grabs username and access from login page
            labLoginUsername.Text = Login.currentLoginUsername;
            labLoginAccess .Text = Login.currentLoginAccess;

            //colour of header panel    
            panelHeader.BackColor = Color.FromArgb(GlobalVar.colourRed, GlobalVar.colourGreen, GlobalVar.colourBlue);



        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Settings settingsPage = new Settings();
            settingsPage.Show();

            this.Hide();
        }

        private void labLogout_Click(object sender, EventArgs e)
        {
            UserLogin.Username = "User";
            UserLogin.Password = "Password";
            UserLogin.Access = "Normal";

            Login loginPage = new Login();
            loginPage.Show();

            this.Hide();
        }

        private void labPassword_Click(object sender, EventArgs e)
        {
            Members formMembers = new Members();
            formMembers.ShowDialog();

            this.Hide();
        }

        private void homeSideLogo_Click(object sender, EventArgs e)
        {
            Home formHome = new Home();
            formHome.ShowDialog();

            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void labPlans_Click(object sender, EventArgs e)
        {
            if(labLoginAccess.Text == "Normal")
            {
                MessageBox.Show("NOTICE: you will need admin access to modify data!");
            }
           

            Plans plansForm = new Plans();
            plansForm.Show();

            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void labSearch_Click(object sender, EventArgs e)
        {
            Search searchForm = new Search();
            searchForm.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.ClearSelection();

            //sql conncetion
            using (SqlConnection sqlCon = new SqlConnection(DBPath))
            {
                sqlCon.Open();
                SqlDataAdapter sda = new SqlDataAdapter(txtQueryDB.Text, sqlCon);

                try
                {
                    //makes datatable | fills out data table 
                    DataTable dataTbl = new DataTable();
                    sda.Fill(dataTbl);

                    dataGridView1.DataSource = dataTbl;

                    listQueryHistory.Add(txtQueryDB.Text);
                    listBoxQueryHistory.DataSource = bs;
                    bs.ResetBindings(false);
                  
                }
                catch (Exception)
                {
                    MessageBox.Show("wrong");
                }

            }
        }

        private void btnDispMembers_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtQueryDB.Clear();

            txtQueryDB.Text = "SELECT * FROM tbl_members";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtQueryDB.Clear();

            txtQueryDB.Text = "SELECT firstname, lastname, gymplan FROM tbl_members ";
        }

        private void btnDispMembersAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtQueryDB.Clear();

            txtQueryDB.Text = "SELECT firstname, lastname, address FROM tbl_members ";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            //sql conncetion
            using (SqlConnection sqlCon = new SqlConnection(DBPath))
            {
                sqlCon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_members WHERE firstname = '"+txtQueryName.Text+"'", sqlCon);

                try
                {
                    //makes datatable | fills out data table 
                    DataTable dataTbl = new DataTable();
                    sda.Fill(dataTbl);

                    dataGridView1.DataSource = dataTbl;

                    listQueryHistory.Add("SELECT * FROM tbl_members WHERE firstname = '" + txtQueryName.Text + "'");
                    listBoxQueryHistory.DataSource = bs;
                    bs.ResetBindings(false);

                }
                catch (Exception)
                {
                    MessageBox.Show("wrong");
                }

            }
        }

        private void labGraph_Click(object sender, EventArgs e)
        {
            Graphs formGraphs = new Graphs();
            formGraphs.Show();

            this.Hide();
        }
    }
}
