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

namespace NationGyms
{
    
    public partial class Plans : Form
    {

        string filePath = @"C:\Users\alexr\Desktop\Files\YEAR 2\Info Systems Development (C#)\Coursework\NationGyms\TextFiles\changesLog.txt";

        List<string> lines = new List<string>();

        public Plans()
        {
            InitializeComponent();

            //grabs username and access from login page
            labLoginUsername.Text = Login.currentLoginUsername;
            labLoginAccess.Text = Login.currentLoginAccess;

            //change header colour
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
            formMembers.Show();

            this.Hide();
        }

        private void homeSideLogo_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();

            this.Hide(); 
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Plans_Load(object sender, EventArgs e)
        {
            
        }

        private void radioBronze_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioSilver_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioGold_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnPlansAdd_Click(object sender, EventArgs e)
        {
            if(UserLogin.Access == "Admin")
            {
                if (radioBronze.Checked)
                {
                    lines.Add($"[{DateTime.Now.ToString("hh:mm:ss tt")}] BRONZE ++\"{txtPlans.Text}\" by user");
                    MessageBox.Show($"[{DateTime.Now.ToString("hh:mm:ss tt")}] BRONZE ++\"{txtPlans.Text}\" by user");



                    listBronze.Items.Add(txtPlans.Text);
                    txtPlans.Clear();
                }
                else if (radioSilver.Checked)
                {
                    lines.Add($"[{DateTime.Now.ToString("hh:mm:ss tt")}] SILVER ++\"{txtPlans.Text}\" by user");
                    MessageBox.Show($"[{DateTime.Now.ToString("hh:mm:ss tt")}] SILVER ++\"{txtPlans.Text}\" by user");

                    listSilver.Items.Add(txtPlans.Text);
                    txtPlans.Clear();
                }
                else if (radioGold.Checked)
                {
                    lines.Add($"[{DateTime.Now.ToString("hh:mm:ss tt")}] GOLD ++\"{txtPlans.Text}\" by user");
                    MessageBox.Show($"[{DateTime.Now.ToString("hh:mm:ss tt")}] GOLD ++\"{txtPlans.Text}\" by user");

                    listGold.Items.Add(txtPlans.Text);
                    txtPlans.Clear();
                }

                //writes to txt file
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                MessageBox.Show("You do not have permission to edit this data");
            }
         
        }

        private void btnPlansRemove_Click(object sender, EventArgs e)
        {
            if (UserLogin.Access == "Admin")
            {
                if (radioBronze.Checked)
                {
                    try
                    {
                        if (listBronze.SelectedIndex == -1) //checks if an item is selected
                        {
                            MessageBox.Show("Select an item to remove");
                        }
                        else
                        {
                            lines.Add($"[{DateTime.Now.ToString("hh:mm:ss tt")}] BRONZE --\"{listBronze.SelectedItem.ToString()}\" by user");
                            listBronze.Items.RemoveAt(listBronze.SelectedIndex);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Select an item to remove");
                    }
                }
                else if (radioSilver.Checked)
                {
                    try
                    {
                        if (listSilver.SelectedIndex == -1)
                        {
                            MessageBox.Show("Select an item to remove");
                        }
                        else
                        {
                            lines.Add($"[{DateTime.Now.ToString("hh:mm:ss tt")}] SILVER --\"{listSilver.SelectedItem.ToString()}\" by user");
                            listSilver.Items.RemoveAt(listSilver.SelectedIndex);
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Select an item to remove");
                    }
                }
                else if (radioGold.Checked)
                {
                    try
                    {
                        if (listGold.SelectedIndex == -1)
                        {
                            MessageBox.Show("Select an item to remove");
                        }
                        else
                        {
                            lines.Add($"[{DateTime.Now.ToString("hh:mm:ss tt")}] GOLD --\"{listGold.SelectedItem.ToString()}\" by user");
                            listGold.Items.RemoveAt(listGold.SelectedIndex);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Select an item to remove");
                    }
                }

                //writes to txt file
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                MessageBox.Show("You do not have permission to edit this data");
            }
            
                
        }

        private void btnEdits_Click(object sender, EventArgs e)
        {

        }

        private void btnEdits_Click_1(object sender, EventArgs e)
        {
            PlanLog formPlanLog = new PlanLog();
            formPlanLog.ShowDialog();


        }

        private void labSearch_Click(object sender, EventArgs e)
        {
            Search searchForm = new Search();
            searchForm.Show();

            this.Hide();
        }

        private void labGraph_Click(object sender, EventArgs e)
        {
            Graphs formGraphs = new Graphs();
            formGraphs.Show();

            this.Hide();
        }
    }
}
