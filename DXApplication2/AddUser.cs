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
    public partial class AddUser : DevExpress.XtraEditors.XtraForm
    {
        Users newuser = new Users();
        Users newuserlocal = new Users();
        CompaniesSet newcompany = new CompaniesSet();
        Permissions newpermisions = new Permissions();
       
        
        UserOptions useroptions = new UserOptions();
        CompaniesOptions companiesoptions = new CompaniesOptions();
        PermissionsOptions permissionsoptions = new PermissionsOptions();

        bool IsEdit;
        public AddUser()
        {
            InitializeComponent();
            newuser.CompaniesSet = newcompany;
            newuser.Permissions = newpermisions;

            //UserOptions useroptions = new UserOptions();
            // CompaniesOptions companiesoptions = new CompaniesOptions();
            ///  newuserlocal.CompaniesSet = companiesoptions.GetCompanies()[0];
            //  newuserlocal.Permissions = permissionsoptions.GetPermissions()[0];

            newuser.BirthDate = DateTime.Now;
        }

        public AddUser( Users user)
        {
            InitializeComponent();
            newuser = user;
            IsEdit = true;
            //UserOptions useroptions = new UserOptions();
            // CompaniesOptions companiesoptions = new CompaniesOptions();
            ///  newuserlocal.CompaniesSet = companiesoptions.GetCompanies()[0];
            //  newuserlocal.Permissions = permissionsoptions.GetPermissions()[0];

            newuser.BirthDate = DateTime.Now;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ContabilidadEntities usercont = new ContabilidadEntities();
            try
            {
                newuser.PermissionsID = permissionsoptions.GetPermisionID(newuser.Permissions.Name);
                newuser.CompanyId = companiesoptions.GetCompaniesID(newuser.CompaniesSet.CompanyName);
                newuser.CompaniesSet = null;
                newuser.Permissions = null;

                if (PasswordEdit.Text == CfPasswordedit.Text)
                {
                    if (!IsEdit & (PasswordEdit.Text != string.Empty))
                    {
                        newuser.Password = useroptions.GenerateHash(CfPasswordedit.Text, CfPasswordedit.Text.Length);
                    }

                    Users clone = new Users();
                    clone.BirthDate = newuser.BirthDate;
                    clone.CompanyId = newuser.CompanyId;
                    clone.Email = newuser.Email;
                    clone.LastName = newuser.LastName;
                    clone.Login = newuser.Login;
                    clone.Name = newuser.Name;
                    clone.Notes = newuser.Notes;
                    clone.Password = newuser.Password;
                    clone.PermissionsID = newuser.PermissionsID;
                    clone.PersonalID = newuser.PersonalID;
                    clone.Phone = newuser.Phone;
                    clone.Userid = newuser.Userid;

                    if (IsEdit)
                    {

                   Users toup = usercont.Users.Single(u => u.Userid == clone.Userid) ;
                        //usercont.Users.Remove(toup);
                        usercont.Entry(toup).CurrentValues.SetValues(clone);
                        //usercont.Users. = clone;
                        //Users toup2 = usercont.Users.Single(u => u.Userid == clone.Userid);


                    }
                    else
                    {
                           usercont.Users.Add(clone);
                    }
                   
                       
                    

                      
                  
                usercont.SaveChanges();
                    Close();
                }
                else
                {
                    MessageBox.Show("Passwords Incorrectos");
                }
                


                 
               
            }
            catch (Exception ex)
            {

                
            }
          //  useroptions.AddUser(newuser.Name,newuser.LastName,newuser.PersonalID,newuser.co)

        }

        private void InitTextboxes()
        {
            CompanyCB.DataBindings.Add("EditValue", newuser.CompaniesSet, "CompanyName");
            OcupationCB.DataBindings.Add("EditValue", newuser.Permissions, "Name");
            NameEdit.DataBindings.Add("EditValue", newuser, "Name");
            LNameEdit.DataBindings.Add("EditValue", newuser, "LastName");
            IDEdit.DataBindings.Add("EditValue", newuser, "PersonalID");
            BirthDateEdit.DataBindings.Add("EditValue", newuser, "BirthDate");
            NotesEdit.DataBindings.Add("EditValue", newuser, "Notes");
            EmailEdit.DataBindings.Add("EditValue", newuser, "Email");
            PhoneEdit.DataBindings.Add("EditValue", newuser, "Phone");
            LoginEdit.DataBindings.Add("EditValue", newuser, "Login");
        }
        private void AddUser_Load(object sender, EventArgs e)
        {
          

            CompanyCB.Properties.Items.AddRange(companiesoptions.GetCompaniesCB());
            OcupationCB.Properties.Items.AddRange(permissionsoptions.GetPermissionsCB());
            //  newcompany.CompanyName = "";
            InitTextboxes();
            // PasswordEdit.DataBindings.Add("Text", newuser, "Password");
            BirthDateEdit.EditValue = DateTime.Now;
        }
        

        private void CompanyCB_SelectedValueChanged(object sender, EventArgs e)
        {
           // int a = (int)CompanyCB.EditValue;
        }
    }
}