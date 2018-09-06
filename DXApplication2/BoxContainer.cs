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
    public partial class BoxContainer : DevExpress.XtraEditors.XtraForm
    {
        UsersBox AddUsers;
        PartnersBox AddPartners;
        ClientsBox AddClients;
        public BoxContainer(int box,Users LoggedUser)
        {
            InitializeComponent();
            switch (box)
            {
                case 1:
                    AddUsers = new UsersBox(LoggedUser);
                    panelControl1.Controls.Add(AddUsers);
                    break;
                case 2:
                    AddPartners = new PartnersBox(LoggedUser);
                    panelControl1.Controls.Add(AddPartners);
                    break;
                case 3:
                    AddClients = new ClientsBox(LoggedUser);
                    panelControl1.Controls.Add(AddClients);
                 
                    break;
            }
        }

        private void BoxContainer_Load(object sender, EventArgs e)
        {

        }
    }
}