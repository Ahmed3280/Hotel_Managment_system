using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mangment_System.Settings
{
    public partial class roomsform : UserControl
    {
    
        public roomsform()
        {
            InitializeComponent();
            for (int i = 1; i <= 100; i++)
            {
                string n = "lab" + (i);
                XD.rooms1[i] = this.Controls.Find(n, true).FirstOrDefault() as System.Windows.Forms.Label;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void roomsform_Load(object sender, EventArgs e)
        {

        }
    }
}
