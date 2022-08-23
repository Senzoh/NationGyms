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

    public partial class Graphs : Form
    {
        //sql conncetion
        public SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NationGymsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public static Graphs instance;
        public Panel homePanelHeader;
        public Label displayUsername;
        public Label displayAccess;

        //header panel color RBG
        public int HeaderRed = GlobalVar.colourRed;
        public int HeaderGreen = GlobalVar.colourGreen;
        public int HeaderBlue = GlobalVar.colourBlue;


        public Graphs()
        {
            InitializeComponent();
            instance = this;

            displayUsername = labLoginUsername;
            displayAccess = labLoginAccess;

            //grabs username and access from login page
            labLoginUsername.Text = Login.currentLoginUsername;
            labLoginAccess.Text = Login.currentLoginAccess;

            //colour of header panel

            panelHeader.BackColor = Color.FromArgb(GlobalVar.colourRed, GlobalVar.colourGreen, GlobalVar.colourBlue);



        }

        private void upDateGymPlan()
        {
            //test            
            sqlCon.Open();
            //sql query       
            SqlDataAdapter sda = new SqlDataAdapter("SELECT GymPlan, count(FirstName) as PlanTotal From tbl_members group by GymPlan", sqlCon);

            //makes datatable | fills out data table 
            DataSet ds = new DataSet();
            sda.Fill(ds);

            //connects charts to database
            chartGymPlan.DataSource = ds;
            //column name for x axis
            chartGymPlan.Series["GymPlan"].XValueMember = "GymPlan";
            //column name for y axis
            chartGymPlan.Series["GymPlan"].YValueMembers = "PlanTotal";

            sqlCon.Close();
        }

        private void upDateBranch()
        {
            //test            
            sqlCon.Open();
            //sql query       
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Branch, count(FirstName) as BranchTotal From tbl_members group by Branch", sqlCon);

            //makes datatable | fills out data table 
            DataSet ds = new DataSet();
            sda.Fill(ds);

            //connects charts to database
            chartBranch.DataSource = ds;
            //column name for x axis
            chartBranch.Series["Branch"].XValueMember = "Branch";
            //column name for y axis
            chartBranch.Series["Branch"].YValueMembers = "BranchTotal";

            sqlCon.Close();
        }

        private void upDateJoinDate()
        {
            //test            
            sqlCon.Open();
            //sql query       
            SqlDataAdapter sda = new SqlDataAdapter("SELECT JoinDate, count(FirstName) as NewMembers From tbl_members group by JoinDate", sqlCon);

            //makes datatable | fills out data table 
            DataSet ds = new DataSet();
            sda.Fill(ds);

            //connects charts to database
            chartJoinDate.DataSource = ds;
            //column name for x axis
            chartJoinDate.Series["JoinDate"].XValueMember = "JoinDate";
            //column name for y axis
            chartJoinDate.Series["JoinDate"].YValueMembers = "NewMembers";


            chartJoinDate.Series["JoinDate"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            sqlCon.Close();
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

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void labPlans_Click(object sender, EventArgs e)
        {
            if (labLoginAccess.Text == "Normal")
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

        private void Graphs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nationGymsDBDataSet.tbl_members' table. You can move, or remove it, as needed.
            this.tbl_membersTableAdapter.Fill(this.nationGymsDBDataSet.tbl_members);

            //function to update gym plan chart
            upDateGymPlan();

            upDateBranch();

            upDateJoinDate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chartBranch.Series["Branch"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void btnUpdateGymPlan_Click(object sender, EventArgs e)
        {
            chartGymPlan.Series["GymPlan"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartGymPlan.Series["GymPlan"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            chartBranch.Series["Branch"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
        }

        private void chartGymPlan_Click(object sender, EventArgs e)
        {

        }
    }
}
