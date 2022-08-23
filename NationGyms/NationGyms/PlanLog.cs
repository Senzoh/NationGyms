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
    public partial class PlanLog : Form
    {
        public PlanLog()
        {
            InitializeComponent();

            panelHeader.BackColor = Color.FromArgb(GlobalVar.colourRed, GlobalVar.colourGreen, GlobalVar.colourBlue);
        }

        private void PlanLog_Load(object sender, EventArgs e)
        {
            try
            {
                string Record; //variable to hold records names

                StreamReader inputFile; //stream reader variable

                //opens text file
                inputFile = File.OpenText(@"C:\Users\alexr\Desktop\Files\YEAR 2\Info Systems Development (C#)\Coursework\NationGyms\TextFiles\changesLog.txt");

                while (!inputFile.EndOfStream)//reads files contents
                {
                    Record = inputFile.ReadLine();

                    listLog.Items.Add(Record);//add record names to list box
                }
                inputFile.Close();//closes file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//displays error
            }
        }

        private void homeClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
