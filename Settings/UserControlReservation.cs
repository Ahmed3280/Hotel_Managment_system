using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Mangment_System.Settings
{
    public partial class tabcontrolreservation : UserControl
    {
        public int single = 100;
        public int double1 = 200;
        public int VIP = 300;
        public tabcontrolreservation()
        {
            InitializeComponent();
        }

     public void clear()
        {
            comboBoxtype.SelectedIndex = 0;
            roomnumber.Clear();
            phonenumber.Clear();
            dateTimePickerFrom.Value = DateTime.Now;
            dateTimePickerTo.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // time
            DateTime fromDate = dateTimePickerFrom.Value;
            DateTime toDate = dateTimePickerTo.Value;
            if (toDate <= fromDate)
            {
                MessageBox.Show("Invalid date range. Please select a valid date range.");
                return;
            }
            int numberOfDays = (int)(toDate - fromDate).TotalDays + 1;
            //--------------------------------------------
            // total price
            double price = 0;
            if (comboBoxtype.SelectedIndex == 0) price = 100;
            else if(comboBoxtype.SelectedIndex == 1) price = 200;
            else if(comboBoxtype.SelectedIndex == 2) price = 300;
            double totalPrice = numberOfDays * price;
            //

            bool pn = true;


            int temp=0;
            if (roomnumber.Text == "" && phonenumber.Text == "")
            {
                MessageBox.Show("You must select a room and a phone number to continue");
                pn = false;

            }
            else if (phonenumber.Text=="")
            {
                MessageBox.Show("You must enter a phone number to contact you back");
                pn = false;

            }
            else if (roomnumber.Text == "")
            {
                MessageBox.Show("You must select a room number to continue");
                pn = false;

            }
            if (pn)
            {
                 temp = int.Parse(roomnumber.Text);
            }
            
            if (pn)
            {
                if (comboBoxtype.SelectedIndex == 0 && temp <= 45 && temp >= 1)
                {
                    if (XD.rooms[temp] == 0)
                    {
                        DialogResult result = MessageBox.Show($"Room Type: {comboBoxtype.SelectedItem.ToString()}\nPrice per day: {price}$\nTotal Price: {totalPrice}$\n\nDo you want to proceed?", "Confirmation", MessageBoxButtons.OKCancel);

                        if (result == DialogResult.OK)
                        {
                            XD.rooms[temp]++;
                            XD.phonenumber[temp] = phonenumber.Text;
                            MessageBox.Show("Registered successfully\nwith the number : " + XD.phonenumber[temp]);
                            XD.counterreserverd++;
                        }
                        else
                        {
                            MessageBox.Show("Registration canceled.");
                            return;
                        }
                        
                       
                    }
                    else
                    {
                        MessageBox.Show("This room is already registered please Check The rooms part");
                    }


                }
                else if (comboBoxtype.SelectedIndex == 1 && temp <= 90 && temp >= 46)
                {
                    if (XD.rooms[temp] == 0)
                    {
                        DialogResult result = MessageBox.Show($"Room Type: {comboBoxtype.SelectedItem.ToString()}\nPrice per day: {price}$\nTotal Price: {totalPrice}$\n\nDo you want to proceed?", "Confirmation", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            XD.rooms[temp]++;
                            XD.phonenumber[temp] = phonenumber.Text;
                            MessageBox.Show("Registered successfully\nwith the number : " + XD.phonenumber[temp]);
                            XD.counterreserverd++;
                        }
                        else
                        {
                            MessageBox.Show("Registration canceled.");
                            return;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("This room is already registered please Check The rooms part to know the empty ones");
                    }


                }
                else if (comboBoxtype.SelectedIndex == 2 && temp >= 91 && temp <= 100)
                {

                    if (XD.rooms[temp] == 0)
                    {
                        DialogResult result = MessageBox.Show($"Room Type: {comboBoxtype.SelectedItem.ToString()}\nPrice per day: {price}$\nTotal Price: {totalPrice}$\n\nDo you want to proceed?", "Confirmation", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            XD.rooms[temp]++;
                            XD.phonenumber[temp] = phonenumber.Text;
                            MessageBox.Show("Registered successfully\nwith the number : " + XD.phonenumber[temp]);
                            XD.counterreserverd++;
                        }
                        else
                        {
                            MessageBox.Show("Registration canceled.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("This room is already registered please Check The rooms part to know the empty ones");
                    }


                }
                else
                {
                    MessageBox.Show("Please select a room from the given range");
                }
            }
        }

  

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Reserveroom_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxtype.SelectedIndex == 0)
            {
                Reserveroom.Text = "Single rooms 1 : 45";
            }
            else if (comboBoxtype.SelectedIndex == 1)
            {
                Reserveroom.Text = "Double rooms 46 : 90";
            }
            else if (comboBoxtype.SelectedIndex == 2)
            {
                Reserveroom.Text = "VIP rooms 91 : 100";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Single room costs : {single}$ per day\n\n ---------------------------------------------\n\nDouble room costs : {double1}$ per day\n\n ---------------------------------------------\n\nVIP rooms costs {VIP}$ per day \n\n\n\nClick on Add Button to see total price depending on your choices.","Price Details" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Single room costs : {single}$ per day\n\n ---------------------------------------------\n\nDouble room costs : {double1}$ per day\n\n ---------------------------------------------\n\nVIP rooms costs {VIP}$ per day \n\n\n\nClick on Add Button to see total price depending on your choices.", "Price Details" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void pricebtn_Click(object sender, EventArgs e)
        {

        }

   
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void clear1()
        {
            cantb1.Clear();
            cantb2.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int roomnumber_temp = 0;
            string phonenumber_temp = "";
            bool flag = true;
            if (cantb1.Text=="" && cantb2.Text=="")
            {
                MessageBox.Show("Please enter a room and phone number to continue");
                flag = false;
            }
            else if (cantb1.Text =="")
            {
                MessageBox.Show("Please enter a room number to continue");
                flag = false;
            }
            else if (cantb2.Text =="")
            {
                MessageBox.Show("Please enter a phone number to continue");
                flag = false;
            }
            if (flag)
            {
                roomnumber_temp = int.Parse(cantb1.Text);
                phonenumber_temp = cantb2.Text;
            }

            if (flag)
            {
                if (XD.phonenumber[roomnumber_temp] == phonenumber_temp)
                {
                    XD.rooms[roomnumber_temp] = 0;
                    MessageBox.Show("Reservation has been Canceled!");
                    XD.counterreserverd--;
                    XD.phonenumber[roomnumber_temp] = null;
                }
                else
                {
                    MessageBox.Show("There is no reservation with this data please make sure you entered the correct room and phone number!");
                }

            }
            
            
        }

        private void tabcontrolreservation_Load(object sender, EventArgs e)
        {

        }
    }
}
