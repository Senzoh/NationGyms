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

    public partial class Settings : Form
    {
        public static Settings instance;
        public Label displayUsername;
        public Label displayAccess;


        public Settings()
        {
            InitializeComponent();
            instance = this;

            //MessageBox.Show("Password: " + UserLogin.Password);
            //displayUsername = labLoginUsername;
            //displayAccess = labLoginAccess;

            //grabs username and access from login page
            labLoginUsername.Text = Login.currentLoginUsername;
            labLoginAccess.Text = Login.currentLoginAccess;

            //colour of header panel
            panelHeader.BackColor = Color.FromArgb(GlobalVar.colourRed, GlobalVar.colourGreen, GlobalVar.colourBlue);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labLogout_Click(object sender, EventArgs e)
        {
            Login loginPage = new Login();
            loginPage.Show();

            this.Hide();
        }

        private void labPassword_Click(object sender, EventArgs e)
        {
            

            this.Hide();
        }

        private void homeSideLogo_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.ShowDialog();

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
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            panelHeader.BackColor = Color.FromArgb(249, 160, 63);

            GlobalVar.colourRed = 249;
            GlobalVar.colourGreen = 160;
            GlobalVar.colourBlue = 63;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelHeader.BackColor = Color.FromArgb(242, 242, 48);

            GlobalVar.colourRed = 242;
            GlobalVar.colourGreen = 242;
            GlobalVar.colourBlue = 48;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelHeader.BackColor = Color.FromArgb(245, 0, 49);

            GlobalVar.colourRed = 245;
            GlobalVar.colourGreen = 0;
            GlobalVar.colourBlue = 49;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelHeader.BackColor = Color.FromArgb(117, 151, 209);

            GlobalVar.colourRed = 117;
            GlobalVar.colourGreen = 151;
            GlobalVar.colourBlue = 209;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelHeader.BackColor = Color.FromArgb(225, 226, 226);

            GlobalVar.colourRed = 225;
            GlobalVar.colourGreen = 226;
            GlobalVar.colourBlue = 226;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //sql conncetion
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            var password = txtNewPassword.Text;

            int min_char = 9;
            //bool valid_password = false;

            bool len_password = false;
            bool upp_password = false;
            bool low_password = false;
            bool num_password = false;

            if (txtCurrentPassword.Text == UserLogin.Password)
            {
                //MessageBox.Show("Match");

                if (txtNewPassword.Text == txtNewPassword_C.Text)
                {
                    //CHECK LENGTH
                    if (password.Length >= min_char)
                    {
                        len_password = true;
                        //MessageBox.Show("good length");
                    }
                    //MessageBox.Show("len state: " + len_password.ToString());

                    //checkes for upper case
                    for (int i = 0; i <= password.Length; i++)
                    {
                        if (char.IsUpper(password[i]))
                        {
                            //MessageBox.Show("upper found");
                            upp_password = true;
                            break;
                        }
                        break;
                    }

                    //checks for lower case
                    for (int i = 0; i <= password.Length; i++)
                    {
                        if (char.IsLower(password[i]))
                        {
                            //MessageBox.Show("lower found");
                            low_password = true;
                            break;
                        }
                        //break;
                    }

                    //checks for digits
                    for (int i = 0; i <= password.Length; i++)
                    {
                        try
                        {
                            if (char.IsDigit(password[i]))
                            {
                                //MessageBox.Show("digit found");
                                num_password = true;
                                break;
                            }
                        }
                        catch(Exception)
                        {
                            break;
                        }
                                              
                    }

                    //MessageBox.Show("upper state: " + upp_password.ToString());
                    //MessageBox.Show("lower state: " + low_password.ToString());
                    //MessageBox.Show("len state: " + len_password.ToString());
                    //MessageBox.Show("num state: " + num_password.ToString());

                    if (len_password == true && upp_password == true && low_password == true && num_password == true)
                    {
                        MessageBox.Show("Password has been updated","Strong Password");

                        //sql query
                        string updatePassword = "update tbl_login set Password = '" + txtNewPassword.Text.Trim() + "' where Username = '" + UserLogin.Username.Trim() + "'";

                        sqlCon.Open();
                        //upates users password
                        SqlCommand cmd = new SqlCommand(updatePassword, sqlCon);
                        cmd.ExecuteNonQuery();



                    }
                    else
                    {
                        MessageBox.Show("New Password Dosen't meet requirements ","Week Password");
                    }

                }
                else
                {
                    MessageBox.Show("Password not the same, please check both New passwords are the same");

                    txtNewPassword.Clear();
                    txtNewPassword_C.Clear();
                }
            }
            else{
                MessageBox.Show("Inccorect Password! try again");
            }
            

            
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
