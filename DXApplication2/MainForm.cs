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
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        Users Loggeduser;
        int oldpanel = -1;
          SQLServer server = new SQLServer();

        UsersBox userbox;
        PartnersBox partbox;
        ClientsBox clientbox;
        SettingsBox settingsbox;
        OperationsBox operationbox;
        LoginBox start;
        GeneralBox generalbox;
        CountingBox countingbox;
        bool closeform = false;
        public MainForm()
        {
            InitializeComponent();
          
            server.FormClosed += Server_FormClosed;

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                panelControl1.Controls.Clear();
                userbox.Dispose();
                partbox.Dispose();
                start.Dispose();
                clientbox.Dispose();
            }
            catch (Exception)
            {


            }



            start = new LoginBox();
            start.FormClosed += Start_FormClosed1;
            InitUser();

        }

        private void InitUser()
        {

            start.ShowDialog(this);
            if (closeform)
                Close();
            //  Loggeduser = start.Userlogged;
            // Loggeduser = new Users() { Name = "Admin", LastName = "Admin", UserTypeID = 1 };

            try
            {

                initBoxes();




            }
            catch (Exception ex)
            {
                // panelControl1.Controls.Clear();
                // userbox.Dispose();
                // partbox.Dispose();
                // clientbox.Dispose();
                //server.Show();
            }
        }

        private void initBoxes()
        {
           // accordionControl1.Elements.Clear();
            userbox = new UsersBox(Loggeduser);
            partbox = new PartnersBox(Loggeduser);
            clientbox = new ClientsBox(Loggeduser);
            operationbox = new OperationsBox(Loggeduser);
            generalbox = new GeneralBox(Loggeduser);
            settingsbox = new SettingsBox();
            countingbox = new CountingBox(Loggeduser);
            LoggeduserDDMenu.Text = Loggeduser.Name;
         Utype.Text = Loggeduser.UserType.UserTypeName;
            UnameL.Text = Loggeduser.Name;

           
            panelControl1.Controls.Add(generalbox);
            panelControl1.Controls.Add(countingbox);
            panelControl1.Controls.Add(partbox);
            accordionControl1.Elements[0].Visible = true;
            accordionControl1.Elements[1].Visible = true;
            accordionControl1.Elements[2].Visible = true;
            //  accordionControl1.Elements.Add(accordionControlElement2);
            // accordionControl1.Elements.Add(accordionControlElement3);
            // accordionControl1.Elements.Add(accordionControlElement4);
            panelControl1.Controls[0].Dock = DockStyle.Fill;
            panelControl1.Controls[1].Dock = DockStyle.Fill;
            panelControl1.Controls[2].Dock = DockStyle.Fill;
            panelControl1.Controls[1].Hide();
            panelControl1.Controls[2].Hide();

            switch (Loggeduser.UserTypeID)
            {
                case 1:

                    panelControl1.Controls.Add(userbox);
                    panelControl1.Controls.Add(clientbox);
                    panelControl1.Controls.Add(settingsbox);
                  //  accordionControl1.Elements.Add(accordionControlElement1);
                   // accordionControl1.Elements.Add(accordionControlElement5);
                   // accordionControl1.Elements.Add(accordionControlElement5);
                    accordionControl1.Elements[3].Visible = true;
                    accordionControl1.Elements[4].Visible = true;
                    accordionControl1.Elements[5].Visible = true;


                    panelControl1.Controls[3].Dock = DockStyle.Fill;
                    panelControl1.Controls[4].Dock = DockStyle.Fill;
                     panelControl1.Controls[5].Dock = DockStyle.Fill;

                    panelControl1.Controls[3].Hide();
                     panelControl1.Controls[4].Hide();
                     panelControl1.Controls[5].Hide();


                    break;
                case 2:

                    //panelControl1.Controls.Add(generalbox);
                    //panelControl1.Controls.Add(countingbox);
                    panelControl1.Controls.Add(userbox);
                    panelControl1.Controls.Add(clientbox);
                    panelControl1.Controls.Add(settingsbox);
                    //panelControl1.Controls[0].Dock = DockStyle.Fill;
                    //panelControl1.Controls[1].Dock = DockStyle.Fill;
                    accordionControl1.Elements[3].Visible = false;
                    accordionControl1.Elements[4].Visible = true;


                    panelControl1.Controls[3].Hide();
                    panelControl1.Controls[4].Hide();
                    panelControl1.Controls[5].Hide();

                    break;

                case 3:

                    //panelControl1.Controls.Add(generalbox);
                    //panelControl1.Controls.Add(countingbox);
                    panelControl1.Controls.Add(userbox);
                    panelControl1.Controls.Add(clientbox);
                    panelControl1.Controls.Add(settingsbox);
                    //panelControl1.Controls[0].Dock = DockStyle.Fill;
                    //panelControl1.Controls[1].Dock = DockStyle.Fill;
                    accordionControl1.Elements[3].Visible = false;
                    accordionControl1.Elements[4].Visible = true;

                   

                    panelControl1.Controls[3].Hide();
                    panelControl1.Controls[4].Hide();
                    panelControl1.Controls[5].Hide();

                    break;

            }
            oldpanel = 0;
            accordionControl1.SelectedElement = accordionControlElement3;
        }
           
        private void Start_FormClosed1(object sender, FormClosedEventArgs e)
        {
            
                LoginBox asdf = sender as LoginBox;
            Loggeduser = asdf.Userlogged;
            if (Loggeduser.Login==null) closeform = true;
                bool yut =   asdf.Pass;
        }

       

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
          
        
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            //panelControl1.Controls[1].Hide();
            //panelControl1.Controls[0].Show();
            //panelControl1.Refresh();
            
        }

        private void accordionControl1_SelectedElementChanged(object sender, DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs e)
        {
           
        }

        private void accordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {

           
                int newpanel = accordionControl1.Elements.IndexOf(e.Element);
            if (newpanel < 5)
            {

                if (oldpanel == -1) panelControl1.Controls[0].Hide();
                panelControl1.Controls[newpanel].Show();
                if ((oldpanel != -1) & (oldpanel != newpanel))
                {

                    panelControl1.Controls[oldpanel].Hide();


                }

                oldpanel = newpanel;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
           
           // server.Show();
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.MainForm_Load(this, e);
        }

        private void LoggeduserDDMenu_Click(object sender, EventArgs e)
        {

        }

        private void LogoutB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            userbox.Dispose();
            partbox.Dispose();
            //start.Dispose();
            clientbox.Dispose();
            InitUser();
        }
    }
}