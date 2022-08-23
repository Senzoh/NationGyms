using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NationGyms
{

    public partial class Members : Form
    {
        public static Members instance;
        public Label displayUsername;
        public Label displayAccess;

        public Members()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Members_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nationGymsDBDataSet.tbl_members' table. You can move, or remove it, as needed.
            this.tbl_membersTableAdapter.Fill(this.nationGymsDBDataSet.tbl_members);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tblmembersBindingSource.EndEdit();
                tbl_membersTableAdapter.Update(nationGymsDBDataSet.tbl_members);
            }
            catch(Exception)
            {
                MessageBox.Show("All data Must be filled in");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tblmembersBindingSource.AddNew();
            }
            catch (Exception)
            {
                MessageBox.Show("Empty values are not allowed");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update this record?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tblmembersBindingSource.EndEdit();
                tbl_membersTableAdapter.Update(nationGymsDBDataSet.tbl_members);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tblmembersBindingSource.RemoveCurrent();
                tbl_membersTableAdapter.Update(nationGymsDBDataSet.tbl_members);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (UserLogin.Access == "Admin")
            {
                Staff formStaff = new Staff();
                formStaff.ShowDialog();

                this.Hide();
            }
            else
            {
                MessageBox.Show("You dont have permission");
            }
        }

        private void labUsername_Click(object sender, EventArgs e)
        {

        }

        private void labGraph_Click(object sender, EventArgs e)
        {
            Graphs formGraphs = new Graphs();
            formGraphs.Show();

            this.Hide();
        }
    }
}