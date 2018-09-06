﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using DataHandler;

namespace DXApplication2
{
    public partial class PartnersBox : DevExpress.XtraEditors.XtraUserControl
    {
        bool IsEdit = false;
        PartnersSet newpartner = new PartnersSet();
        PartnersSet SelectedPartner = new PartnersSet();
        PartnersOptions partnersoptions = new PartnersOptions();
        DataHandler.ContabilidadEntities dbContext = new DataHandler.ContabilidadEntities();
      
       ContabilidadEntities usercont = new ContabilidadEntities();
     
        List<PartnersSet> partnerList = new List<PartnersSet>();





        public PartnersBox(Users Loggeduser)
        {
            InitializeComponent();
            //InitTextboxes();
            LoggedUserText.Text = string.Format("{0} {1}", Loggeduser.Name, Loggeduser.LastName);

            //newuser.Permisions = null;

            

                Users clone = new Users();

         
               
              
                partnerList = partnersoptions.GetActivePartners().ToList();

            if (partnerList.Count > 0)
            {
                SelectedPartner = SetSelectedPart(partnerList[0], false);
            }
            else
            {
               
                    layoutControl1.Hide();
                    layoutControl2.Hide();
                    layoutControl3.Hide();

                
            }
            gridControl1.DataSource = partnerList;
        
                      }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


        //private void InitTextboxes()
        //{
        //    NameEdit.DataBindings.Add("EditValue", SelectedUser, "Name");
        //    LNameEdit.DataBindings.Add("EditValue", SelectedUser, "LastName");
        //    NotesEdit.DataBindings.Add("EditValue", SelectedUser, "Notes");
        //    EmailEdit.DataBindings.Add("EditValue", SelectedUser, "Email");
        //    PNickEdit.DataBindings.Add("EditValue", SelectedUser, "Login");
        //}

        //private void FillPermissions()
        //{
        //    PermissionsOptions permissiontypes = new PermissionsOptions();
           
        // PermissionsTree.DataSource = permissiontypes.GetPermissionsTypesAcces(false);
        //    UserAlowTree.DataSource = permissiontypes.GetPermissionsTypesAcces(true);
        //    PermissionsTree.KeyFieldName = "PermissionsTypesID";
        //    PermissionsTree.ParentFieldName = "IsUserID";
        //    //PermissionsTree.da
        // int aas =    PermissionsTree.Nodes.Count;
        //    //PermissionsTypes [] perlist = permissiontypes.GetPermissionsTypesAcces(true);
        //    //for (int i = 0; i < perlist.Length; i++)
        //    //{
        //    //    DevExpress.XtraTreeList.Nodes.TreeListNode dfd;
              
        //    //    PermissionsTree.AppendNode(perlist[i], PermissionsTree.Nodes[0]);
               

               

        //    //}



        //    //   PermissionsTree.Nodes[0].Nodes.Add(permissiontypes.GetPermissionsTypesAcces(false));

        //}

        private void AddNew()
        {
            IsEdit = false;
            newpartner = new PartnersSet() {

                ContractDate = DateTime.Now,
                FinacialValue = 0,
                FundingTimeLimit = DateTime.Now,
                Extra3 = 0,
                Extra4 = DateTime.Now,
                Iscreditor = true,
                Isprovider = false,
                ContractNumber = string.Empty,
                OrganizationPostalCode = string.Empty,
                Email = string.Empty,
                Extra1 = string.Empty,
                Extra2 = string.Empty,
                IsActive = true,
                LawAdress = string.Empty,
                OrganizationLocation = string.Empty,
                NickName = string.Empty,
                Nombramiento = string.Empty,
                Notes = string.Empty,
                PartnerName = string.Empty,
                Phone = string.Empty,
                RealAdress = string.Empty,
                RegNumber = string.Empty

            };
            SelectedPartner = newpartner;

            SetSelectedPart(newpartner,true);
            layoutControl1.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
            layoutControl2.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
            layoutControl3.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
           
                layoutControl1.Show();
                layoutControl2.Show();
                layoutControl3.Show();

           

        }

      

        // This event is generated by Data Source Configuration Wizard
        

        // This event is generated by Data Source Configuration Wizard
        

        private PartnersSet SetSelectedPart(PartnersSet selected, bool isnew)
        {
            usercont = new ContabilidadEntities();
           

             PNickEdit.Text  = selected.NickName;
               PNameEdit.Text = selected.PartnerName;
               LawAEdit.Text = selected.LawAdress;
                RAdressEdit.Text = selected.RealAdress;
                ContDatEdit.DateTime = selected.ContractDate.Value;
                ContNumbEdit.Text = selected.ContractNumber.ToString() ;
               EmailEdit.Text = selected.Email  ;
               EF1Edit.Text = selected.Extra1 ;
               EF2Edit.Text = selected.Extra2 ;
               EF3Edit.Text = selected.Extra3.ToString();
               EF4Edit.DateTime = selected.Extra4.Value ;
              FinValEdit.Text = selected.FinacialValue.ToString();
               FDLEdit.DateTime = selected.FundingTimeLimit.Value ;
               IsCredChB.Checked = selected.Iscreditor.Value  ;
               IsProvChB.Checked = selected.Isprovider.Value ;
              // layout10.Text = selected.Nombramiento  ;
               NotesEdit.Text = selected.Notes ;
               OrgPlaceEdit.Text = selected.OrganizationLocation ;
               PEmailEdit.Text = selected.OrganizationPostalCode  ;
             TelEdit.Text =  selected.Phone.ToString() ;
               RegNumEdit.Text = selected.RegNumber.ToString();
              NamEdit.Text = selected.Nombramiento;
            IsCredChB.Checked = selected.Iscreditor.Value;
            IsProvChB.Checked = selected.Isprovider.Value;
            if (isnew)
            {
                ContDatEdit.Text = string.Empty;
                ContNumbEdit.Text = string.Empty;
                EF3Edit.Text = string.Empty;
                EF4Edit.Text = string.Empty;
                FinValEdit.Text = string.Empty;
                FDLEdit.Text = string.Empty;
                TelEdit.Text = string.Empty;
                RegNumEdit.Text = string.Empty;
                SelectedPartner.IsActive = true;
            }

            return selected;



                
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            layoutControl1.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
            layoutControl2.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
            layoutControl3.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
            if (gridView1.GetFocusedRowCellValue("PartnerID") != null)
            {

                //SelectedPartner = partnersoptions.GetPartnerbyID(int.Parse(gridView1.GetFocusedRowCellValue("PartnerID").ToString()));
            SelectedPartner =    SetSelectedPart(partnersoptions.GetPartnerbyID(int.Parse(gridView1.GetFocusedRowCellValue("PartnerID").ToString())),false);
                //  AddUser newuser = new DXApplication2.AddUser(SelectedUser);
                //  newuser.FormClosed += Newuser_FormClosed;
                //  newuser.Show();
               
            }

        }

      

       

       
        private void EditMode()
        {
            SetReadOnly(false);
            IsEdit = true;
            //simpleButton4_Click(sender, e);
            //layoutControl1.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
            //layoutControl2.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
            //layoutControl3.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;

        }


        private bool Validatedata(TextEdit text )
        {

            if (String.IsNullOrWhiteSpace(text.Text))
                return false;
            if ((usercont.PartnersSet.Any(item => item.PartnerName ==text.Text) == true))

                return false;
            return true;


        }
        

        private void LoginEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Validatedata(PNickEdit))
            {
                PNickEdit.BackColor = Color.White;
                SelectedPartner.NickName = PNickEdit.Text;

            }
            else
            {
                PNickEdit.BackColor = Color.PeachPuff;
            }
        }


        private void Validate_Leave(object sender, EventArgs e)
        {
            TextEdit dfg = sender as TextEdit;
            if(IsEdit)
            dfg.BackColor = Color.White;
            if (String.IsNullOrWhiteSpace(dfg.Text)&IsEdit)
                dfg.BackColor = Color.PeachPuff;
            if(dfg.EditValue != null & !string.IsNullOrEmpty(dfg.Text))
            switch (dfg.Name)
            {
                case "PNickEdit":

                    if (Validatedata(dfg))
                    {
                        PNickEdit.BackColor = Color.White;
                        SelectedPartner.NickName = PNickEdit.Text;

                    }
                    else
                    {
                        PNickEdit.BackColor = Color.PeachPuff;
                    }
                    break;

                case "PNameEdit":
                    if (Validatedata(dfg))
                    {
                        dfg.BackColor = Color.White;
                        SelectedPartner.PartnerName = dfg.Text;

                    }
                    else
                    {
                        PNameEdit.BackColor = Color.PeachPuff;
                    }

                    break;
                case "LawAEdit":
                    SelectedPartner.LawAdress = dfg.Text;

                    break;
                case "RAdressEdit":
                    SelectedPartner.RealAdress = dfg.Text;

                    break;
                case "ContDatEdit":
                    SelectedPartner.ContractDate = DateTime.Parse(dfg.Text);

                    break;
                case "ContNumbEdit":
                    SelectedPartner.ContractNumber = dfg.Text;

                    break;
                case "EmailEdit":
                    SelectedPartner.Email = dfg.Text;

                    break;
                case "EF1Edit":
                    SelectedPartner.Extra1 = dfg.Text;

                    break;
                case "EF2Edit":
                    SelectedPartner.Extra2 = dfg.Text;

                    break;
                case "EF3Edit":
                    SelectedPartner.Extra3 =decimal.Parse(dfg.Text);

                    break;
                case "EF4Edit":
                    SelectedPartner.Extra4 =DateTime.Parse(dfg.Text);

                    break;
                case "FinValEdit":
                    SelectedPartner.FinacialValue =decimal.Parse(dfg.Text);

                    break;
                case "FDLEdit":
                    SelectedPartner.FundingTimeLimit = DateTime.Parse(dfg.Text);

                    break;
                case "IsCredChB":
                    SelectedPartner.Iscreditor = bool.Parse(dfg.Text);

                    break;
                case "IsProvChB":
                    SelectedPartner.Isprovider = bool.Parse(dfg.Text);

                    break;
                case "NamEdit":
                    SelectedPartner.Nombramiento = dfg.Text;

                    break;
                case "NotesEdit":
                    SelectedPartner.Notes = dfg.Text;

                    break;
                case "OrgPlaceEdit":
                    SelectedPartner.OrganizationLocation = dfg.Text;

                    break;
                case "PEmailEdit":
                    SelectedPartner.OrganizationPostalCode = dfg.Text;

                    break;
                case "TelEdit":
                    SelectedPartner.Phone = dfg.Text;

                    break;
                case "RegNumEdit":
                    SelectedPartner.RegNumber =dfg.Text;

                    break;
                        SelectedPartner.IsActive = true;
            }
            
        }

        private void SetInactive()
        {
            PartnersSet toup = usercont.PartnersSet.Single(u => u.PartnerId == SelectedPartner.PartnerId);
            //usercont.Users.Remove(toup);
             SelectedPartner.IsActive = false;
            usercont.Entry(toup).CurrentValues.SetValues(SelectedPartner);
            usercont.SaveChanges();
            partnerList.Clear();
            partnerList.AddRange(partnersoptions.GetActivePartners());
            if (partnerList.Count == 0)
            {
                layoutControl1.Hide();
                layoutControl2.Hide();
                layoutControl3.Hide();

            }
            else
            {
                SetSelectedPart(partnerList[partnerList.Count-1], false);
            }
            gridView1.RefreshData();


        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("PartnerId") != null)
            {

                //SelectedPartner = partnersoptions.GetPartnerbyID(int.Parse(gridView1.GetFocusedRowCellValue("PartnerID").ToString()));
          SelectedPartner =      SetSelectedPart(partnersoptions.GetPartnerbyID(int.Parse(gridView1.GetFocusedRowCellValue("PartnerId").ToString())),false);
                //  AddUser newuser = new DXApplication2.AddUser(SelectedUser);
                //  newuser.FormClosed += Newuser_FormClosed;
                //  newuser.Show();

            }
        }

        private void ConmitChanges()
        {
            try
            {

                //newuser.PermissionsID = permissionsoptions.GetPermisionID(newuser.Permissions.Name);
                //  newuser.UserCompanies = companiesoptions.GetCompaniesID(newuser.UserCompanies);
                // newuser.CompaniesSet = null;




                // PartnersSet clone = new PartnersSet();

                // //clone.CompanyId = newuser.CompanyId;

                // clone.Email = SelectedUser.Email;
                // clone.LastName = SelectedUser.LastName;
                // clone.Login = SelectedUser.Login;
                // clone.Name = SelectedUser.Name;
                // clone.Notes = SelectedUser.Notes;
                // clone.Password = newuser.Password;
                // clone.UserTypeID = SelectedUser.UserTypeID;
                // clone.ActiveUser = true;
                //// clone.PermissionsID = newuser.PermissionsID;

                // clone.UserID = SelectedUser.UserID;

                if (IsEdit)
                {

                    PartnersSet toup = usercont.PartnersSet.Single(u => u.PartnerId == SelectedPartner.PartnerId);
                    //usercont.Users.Remove(toup);
                    //clone.UserID = SelectedPartner.PartnerId;
                    usercont.Entry(toup).CurrentValues.SetValues(SelectedPartner);
                    //usercont.Users. = clone;
                    //Users toup2 = usercont.Users.Single(u => u.Userid == clone.Userid);


                }
                else
                {
                    
                    usercont.PartnersSet.Add(SelectedPartner);
                    usercont.SaveChanges();
                    

                    //var permissionchecked =    UserAlowTree.GetAllCheckedNodes().ToArray();
                    //   for (int i = 0; i < permissionchecked.Length; i++)
                    //   {
                    //       Permisions permissionscheck = new Permisions() { PermissionsTypeID = int.Parse(permissionchecked[i].GetValue("PermissionsTypeID").ToString()), UserID = newuserid  };
                    //       usercont.Permisions.Add(permissionscheck);
                    //   }

                    //   permissionchecked =PermissionsTree.GetAllCheckedNodes().ToArray();
                    //   for (int i = 0; i < permissionchecked.Length; i++)
                    //   {
                    //       Permisions permissionscheck = new Permisions() { PermissionsTypeID = int.Parse(permissionchecked[i].GetValue("PermissionsTypeID").ToString()), UserID = newuserid };
                    //       usercont.Permisions.Add(permissionscheck);
                    //   }

                }

                //var companieschecked = CompaniesList.CheckedItems;
                // var companyList = companiesoptions.GetCompanies();
                // var compa = companieschecked.Cast<CompaniesSet>().ToArray();

                // for (int i = 0; i <  companyList.Length; i++)
                // {

                //         UserCompanies usercomp = new UserCompanies() { CompaniID = companyList[i].CompanyId, UserID = clone.UserID };
                //     usercont.UserCompanies.Add(usercomp);

                // //companieschecked.
                // }





                usercont.SaveChanges();
                partnerList.Clear();

                partnerList.AddRange(partnersoptions.GetActivePartners());

                gridView1.RefreshData();
                //layoutControl1.OptionsView.IsReadOnly  = DevExpress.Utils.DefaultBoolean.True;
                //layoutControl2.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
                //layoutControl3.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;

                SetReadOnly(true);





            }
            catch (Exception ex)
            {


            }
        }

        private void SetReadOnly(bool set)
        {
            if (set)
            {
                layoutControl1.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
                layoutControl2.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
                layoutControl3.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;

                NotesEdit.ReadOnly = true;
                gridView1.OptionsBehavior.Editable = false;
             
                //IsEdit = false;
                //IsNew = false;
                
                //CashCBtn.Enabled = false;
                //SaleCBtn.Enabled = false;
                //AdminCBtn.Enabled = false;
                SetBackColors(Color.AliceBlue);
            }
            else
            {
                layoutControl1.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
                layoutControl2.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
                layoutControl3.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;

                NotesEdit.ReadOnly = false;
                gridView1.OptionsBehavior.Editable = true;
                
                SetBackColors(Color.White);
                //CashCBtn.Enabled = true;
                //SaleCBtn.Enabled = true;
                //AdminCBtn.Enabled = true;
            }


        }


        private void SetBackColors(Color color)
        {
            PNickEdit.BackColor = color;
            PNameEdit.BackColor = color;
            RAdressEdit.BackColor = color;
            LawAEdit.BackColor = color;
           TelEdit.BackColor = color;
            EmailEdit.BackColor = color;
            NotesEdit.BackColor = color;

            FinValEdit.BackColor = color;
            RegNumEdit.BackColor = color;
            ContDatEdit.BackColor = color;
            ContNumbEdit.BackColor = color;
            FDLEdit.BackColor = color;
            OrgPlaceEdit.BackColor = color;
            PEmailEdit.BackColor = color;
            NamEdit.BackColor = color;
            EF1Edit.BackColor = color;
           EF2Edit.BackColor = color;
          EF3Edit.BackColor = color;
            EF4Edit.BackColor = color;

            gridControl1.BackColor = color;
        
        }

        private void IsProvChB_CheckedChanged(object sender, EventArgs e)
        {
            SelectedPartner.Isprovider = IsProvChB.Checked;
        }

        private void IsCredChB_CheckedChanged(object sender, EventArgs e)
        {
            SelectedPartner.Iscreditor = IsCredChB.Checked;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            ConmitChanges();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            SetInactive();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
