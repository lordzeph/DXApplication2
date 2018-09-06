using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHandler;


namespace DXApplication2
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            UserOptions userdata = new UserOptions();
            LoginBox userlog = new LoginBox();
            userlog.FormClosed += Userlog_FormClosed;
        }

        private void Userlog_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            throw new NotImplementedException();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MainForm dfg = new MainForm();
            dfg.Show();
        }
    }
}
