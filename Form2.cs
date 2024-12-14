using Hotel_Mangment_System.Settings;
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

namespace Hotel_Mangment_System
{
    public partial class Form2 : Form
    {
        public string username;
        public int counter = 0;

        public Form2()
        {
            InitializeComponent();
        }
        
        public string lw;
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelusername.Text = username;
            loginusername.Text = username;
            tabcontrolreservation1.Hide();
            settingspanel1.Hide();
            roomsform1.Hide();
            userControl11.Show();

        }

        private void MovePanel(Control btn)
        {
            panelslide.Top = btn.Top;
            panelslide.Height = btn.Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labeldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void button1dashboard_Click(object sender, EventArgs e)
        {
            //--------------------------------------------- Auto Update for Dashboard
            XD2.lxd.Text = XD.counterreserverd.ToString();
            int temp = XD.counterreserverd;
            int total = 100 - temp;
            XD2.sxd.Text = total.ToString();
            //---------------------------------------------
            MovePanel(button1dashboard);
            tabcontrolreservation1.Hide();
            settingspanel1.Hide();
            roomsform1.Hide();
            userControl11.Show();
        }

        private void button2rooms_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++) // updating rooms BackColor
            {
                if (XD.rooms[i] == 1)
                {
                    XD.rooms1[i].BackColor = Color.Red;
                }
                if (XD.rooms[i] == 0)
                {
                    XD.rooms1[i].BackColor = Color.Green;
                }

            }
            MovePanel(button2rooms);
            tabcontrolreservation1.Hide();
            settingspanel1.Hide();
            userControl11.Hide();
            roomsform1.Show();
        }

        private void button3reservation_Click(object sender, EventArgs e)
        {
            MovePanel(button3reservation);
            settingspanel1.Hide();
            roomsform1.Hide();
            tabcontrolreservation1.clear();
            tabcontrolreservation1.clear1();
            tabcontrolreservation1.Show();
            userControl11.Hide();
            
        }
        private void pictureBoxclose_Click(object sender, EventArgs e)
        {
            Formlogin xd = new Formlogin();
            this.Hide();
            xd.ShowDialog();
            this.Close();

        }

        private void settings_Click(object sender, EventArgs e)
        {
            MovePanel(settingsbtn);
            tabcontrolreservation1.Hide();
            roomsform1.Hide();
            userControl11.Hide();
            settingspanel1.Clear();
            settingspanel1.Show();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabcontrolreservation1_Load(object sender, EventArgs e)
        {

        }

        private void loginusername_Click(object sender, EventArgs e)
        {

        }

        private void labelusername_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }


    public static class XD2
    {   // updating dashboard
        public static Label lxd;
        public static Label sxd;
        public static void getinfo(ref Label lw, ref Label sw)
        {
            lxd = lw;
            sxd = sw;
        }
        //----------------------------------------------------
    }
}
