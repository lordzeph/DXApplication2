using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataHandler;

namespace DXApplication2
{
    public partial class NewOperation : DevExpress.XtraEditors.XtraForm
    {
        public NewOperation(Users LoggedUser)
        {
            InitializeComponent();
            OperationsBox opperationbox = new OperationsBox(LoggedUser);
            opperationbox.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(opperationbox);
            panelControl1.Controls[0].Dock = DockStyle.Fill;
            

        }

        public NewOperation(Users LoggedUser, ServicesSet service)
        {
            InitializeComponent();
            OperationsBox opperationbox = new OperationsBox(service,LoggedUser);
            opperationbox.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(opperationbox);
            panelControl1.Controls[0].Dock = DockStyle.Fill;


        }
    }
}