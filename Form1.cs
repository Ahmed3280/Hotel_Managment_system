using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Hotel_Mangment_System
{

    public partial class Formlogin : Form
    {
        //----------------------------------
        public Formlogin()
        {
            InitializeComponent();
        }
        FileStream myfile;
        StreamWriter sw;
        StreamReader sr;
        public string username {get; set;}
      



        private void pictureBoxminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxminimize_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxminimize, "Minimize");
        }

        private void pictureBoxclose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxclose, "Close");
        }

        private void pictureBoxclose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void pictureBoxShow_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxShow, "Show Password");
        }

        private void pictureBoxHide_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxHide,"Hide Password");
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            pictureBoxShow.Hide();
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
        }
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            myfile = new FileStream("Register.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(myfile);
            
            //bool flag3 = false;
            //for (int i = 0; i < 10; i++)
            //{
            //    if (textBoxUserName.Text == XD.usernames[i] && textBoxPassword.Text == XD.passwords[i])
            //    {
            //        Form2 f1 = new Form2();
            //        f1.username = textBoxUserName.Text;
            //        textBoxUserName.Clear();
            //        textBoxPassword.Clear();
            //        this.Hide();
            //        f1.ShowDialog();
            //        this.Close();
            //        flag3 = true;
            //        break;
            //    }
            //}
            //if(!flag3) MessageBox.Show("Incorrect username or password. Please try again.", "Error", MessageBoxButtons.OK);

            string record;
            string[] fields;
            while ((record = sr.ReadLine()) != null)
            {
                fields = record.Split('|');
                if (textBoxUserName.Text == fields[0] && textBoxPassword.Text == fields[1])
                {
                    sr.Close();
                    myfile.Close();

                    Form2 f1 = new Form2();
                    f1.username = textBoxUserName.Text;
                    this.Hide();
                  
                    f1.ShowDialog();
                    this.Close();
                    
                    
                    return;
                }
            }
            sr.Close();
            myfile.Close();
            MessageBox.Show("Username or password is wrong");

        }

        private void Formlogin_Load(object sender, EventArgs e)
        {
            myfile = new FileStream("Register.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(myfile);
            if (File.ReadAllText("Register.txt")== "")
            {
                buttonLogIn.Enabled = false;
                Button_register.Enabled = true;
            }
            else
            {
                Button_register.Enabled = false;
                buttonLogIn.Enabled = true;
            }
            sr.Close();
            myfile.Close();
        }

        private void Button_register_Click(object sender, EventArgs e)
        {
            myfile = new FileStream("Register.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            sr = new StreamReader(myfile);
            sw = new StreamWriter(myfile);
            if (textBoxUserName.Text=="" || textBoxPassword.Text=="")
            {
                MessageBox.Show("username or password is empty");
                sw.Close();
                sr.Close();
                myfile.Close();
                return;
            }
            string record = textBoxUserName.Text + "|" + textBoxPassword.Text;
            myfile.Seek(0, SeekOrigin.End);
            sw.WriteLine(record);
            sw.Close();
            sr.Close();
            myfile.Close();
            Button_register.Enabled = false;
            buttonLogIn.Enabled = true;
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //myfile = new FileStream("Register.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //sr = new StreamReader(myfile);
            //sw = new StreamWriter(myfile);

        }
    }

    public static class XD
    {
        public static string[] usernames = new string[10];
        public static string[] passwords = new string[10];
        public static int[] rooms = new int[105];
        public static string [] phonenumber = new string [105]; 
        public static Label[] rooms1 = new Label[105];
        public static int counterreserverd = 0;
        public static int counterempty = 100;
       
        //static XD()
        //{
        //    usernames[0] = "Nasser";
        //    passwords[0] = "01126759014";
        //    usernames[1] = "Akram";
        //    passwords[1] = "01002364406";
        //}


        public static void getdata(string name1, string pass1)
        {
            int counter = 2;
            if (counter < 10)
            {

                usernames[counter] = name1;
                passwords[counter] = pass1;
                MessageBox.Show("User has been added!", "Settings");
                counter++;
            }
            else MessageBox.Show("Sorry, Maximum users are 10!", "Settings");
        }
        public static void search(string name1)
        {
            bool b1 = false;
            for (int i = 0; i < 10; i++)
            {
                if (name1 == usernames[i])
                {
                    MessageBox.Show("Username Found!");
                    b1 = true;
                }
            }
            if (!b1) MessageBox.Show("Username doesn't exist!");
        }
    }
}
