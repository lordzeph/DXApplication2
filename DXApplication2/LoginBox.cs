using System.Collections.Generic;
using DataHandler;
using System.Security.Cryptography;
using System.Collections;


namespace DXApplication2
{
    public partial class LoginBox : DevExpress.XtraEditors.XtraForm
    {
       UserOptions Userop = new UserOptions();
        Users user = new Users();
        bool pass;
        public LoginBox()
        {
          //  Userlist.AddRange(inUserList);
            InitializeComponent();
           
        }

        public bool Pass
        {
            get
            {
                return pass;
            }

        }

        public Users Userlogged
        {
            get
            {
                return user;
            }

        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {

            user = Userop.GetUserby_Login(LoginEdit.Text);
            if (user.Name != null)
            {

                byte[] passto = new byte[50];

                byte[] password = Userop.GenerateHash(PassEdit.Text, PassEdit.Text.Length);
                password.CopyTo(passto, 0);




                IStructuralEquatable se1 = user.Password;



                if (se1.Equals(passto, StructuralComparisons.StructuralEqualityComparer))
                { pass = true; this.Close(); }

            }
            else
            {

            }






        }

        private void LoginBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
          
        }

        private void PassEdit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') simpleButton1.PerformClick();

               
        }
    }
}