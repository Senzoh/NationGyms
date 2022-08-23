using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NationGyms
{
    
    public partial class Login : Form
    {
        //current user details
        public static string currentLoginUsername = "User";
        public static string currentLoginAccess = "False";

        //assign Home form to var
        public Home homeForm = new Home();

        //sql conncetion
        //SqlConnection sqlCon = new SqlConnection(@"C:\USERS\ALEXR\DESKTOP\FILES\YEAR 2\INFO SYSTEMS DEVELOPMENT (C#)\COURSEWORK\NATIONGYMS\NATIONGYMS\LOGINDATABASE.MDF");
        
        //function converts bool to string (Admin)
        private string checkIfAdmin(string adminBool)
        {
            if(adminBool == "True")
            {
                return "Admin";
            }
            else
            {
                return "Normal";
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //not use
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //sql conncetion
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //sql query
            string loginQuery = "select * from tbl_Login where Password = '"+loginPassword.Text.Trim()+"' and Username = '"+loginUsername.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(loginQuery,sqlCon);

            //makes datatable | fills out data table 
            DataTable dataTbl = new DataTable();
            sda.Fill(dataTbl);

            if (dataTbl.Rows.Count == 1)
            {
                //Saves logged in users username and admin access
                SqlCommand cmd = new SqlCommand(loginQuery, sqlCon);
                sqlCon.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //Inital display
                        Home.instance.displayUsername.Text = dr["Username"].ToString();
                        Home.instance.displayAccess.Text = checkIfAdmin(dr["Admin"].ToString());

                        UserLogin.Username = dr["Username"].ToString();
                        UserLogin.Password = dr["Password"].ToString();
                        UserLogin.Access = checkIfAdmin(dr["Admin"].ToString());


                        currentLoginUsername = dr["Username"].ToString();
                        currentLoginAccess = checkIfAdmin(dr["Admin"].ToString());

                        //MessageBox.Show(currentLoginUsername);
                        //MessageBox.Show(currentLoginAccess);
                    }
                }

                //header colour chnage 
                GlobalVar.colourRed = 249;
                GlobalVar.colourGreen = 160;
                GlobalVar.colourBlue = 63;

                //MessageBox.Show("Password: "+ UserLogin.Password);
                homeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Inncorrect Username or Password");
            }
        }
    }
}
