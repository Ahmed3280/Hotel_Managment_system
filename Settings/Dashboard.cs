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
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            XD2.getinfo(ref ReservedRooms, ref Emptyrooms); // form2 access
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ReservedRooms.Text = XD.counterreserverd.ToString();
            int temp = 100 - XD.counterreserverd;
            Emptyrooms.Text = temp.ToString();
        }
    }
}
