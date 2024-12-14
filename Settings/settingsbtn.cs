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
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Hotel_Mangment_System.Settings
{
    public partial class settingspanel : UserControl
    {
        public settingspanel()
        {
            InitializeComponent();
        }
        FileStream myfile;
        StreamWriter sw;
        StreamReader sr;
        private void button1_Click(object sender, EventArgs e)
        {
            //bool flag1 = false;
            //for (int i = 0; i < 10; i++)
            //{
            //    if (textBox1username.Text == XD.usernames[i])
            //    {
            //        MessageBox.Show("Username already used, try another one!", "Settings");
            //        flag1 = true;
            //    }
            //}
            //if(!flag1) XD.getdata(textBox1username.Text,textBox2password.Text);

            myfile = new FileStream("Register.txt", FileMode.Open, FileAccess.ReadWrite);
            sw = new StreamWriter(myfile);
            sr = new StreamReader(myfile);

            string record;
            while ((record = sr.ReadLine()) != null)
            {
                string[] fields = record.Split('|');
                if (textBox1username.Text == fields[0])
                {
                    MessageBox.Show("Username already exists!");
                    sw.Close();
                    sr.Close();
                    myfile.Close();
                    return;
                }
            }
            if (textBox1username.Text == "" || textBox2password.Text == "")
            {
                MessageBox.Show("username or password is empty");
                sw.Close();
                myfile.Close();
                return;
            }
            string record2 = textBox1username.Text + "|" + textBox2password.Text;
            myfile.Seek(0, SeekOrigin.End);
            sw.WriteLine(record2);
            MessageBox.Show("User has been Added");
            textBox1username.Clear();
            textBox2password.Clear();
            sw.Close();
            myfile.Close();
      
        }

        public void Clear()
        {
            textBox1username.Clear();
            textBox2password.Clear();
            tabControl1settings.SelectedTab = tabPage1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //XD.search(usernamesearch.Text);
            myfile = new FileStream("Register.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(myfile);
            string record;
            while((record = sr.ReadLine()) != null)
            {
                string[] fields = record.Split('|');
                if(usernamesearch.Text == fields[0])
                {
                    MessageBox.Show("Username found!");
                    sr.Close();
                    myfile.Close();
                    return;
                }
            }
            MessageBox.Show("Username not found!");
            sr.Close();
            myfile.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myfile = new FileStream("Register.txt", FileMode.Open, FileAccess.ReadWrite);
            sr = new StreamReader(myfile);
            sw = new StreamWriter(myfile);
            myfile.Seek(0, SeekOrigin.Begin);
            myfile.Flush();
            sw.Flush();
            string record;
            int pos = 0;
            while((record = sr.ReadLine()) != null)
            {
                string[] fields = record.Split('|');
                if(usernamesearch.Text == fields[0])
                {
                    myfile.Seek(pos, SeekOrigin.Begin);
                    sw.Write("*");
                    MessageBox.Show("Deleted succesfully");
                    sw.Close();
                    sr.Close();
                    myfile.Close();
                    return;
                }
                pos += record.Length + 2;
            }
            MessageBox.Show("Username not Found!");
            sr.Close();
            sw.Close();
            myfile.Close();
        }
    }
}
