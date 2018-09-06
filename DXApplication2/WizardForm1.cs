﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using DataHandler;
using System.Data.Entity;
using DXApplication2.Properties;

namespace DXApplication2
{
    public partial class WizardForm1 : DevExpress.XtraEditors.XtraForm
    {

        private SqlConnectionStringBuilder sd;
        private bool finish=false;
        List<string> list;
        int validityCount = 0;
        EntityConnectionStringBuilder esb;
        public WizardForm1()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            DataHandler.ContabilidadEntities dbContext = new DataHandler.ContabilidadEntities();
            // Call the Load method to get the data for the given DbSet from the database.
            //dbContext.CompaniesSet.Load();
            //// This line of code is generated by Data Source Configuration Wizard
            //gridControl1.DataSource = dbContext.CompaniesSet.Local.ToBindingList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //  UpdateConfig("ContabilidadEntities", BuildConnectionString(SerList.Text, "Contabilidad"), "C:\\Users\\ivan\\Documents\\Visual Studio 2015\\Projects\\DXApplication2\\DXApplication2\\bin\\Debug\\DXApplication2.exe");
                sd = new SqlConnectionStringBuilder();
                if (SerList.Text == " ")
                {
                    sd.DataSource = (string)SerList.SelectedItem;
                }
                else
                {
                    sd.DataSource = (string)SerList.Text;
                }
               // servidoro = sd.DataSource;

                if (sqluser.Checked == true)
                {
                    sd.IntegratedSecurity = false;
                    sd.UserID = UserEdit.Text;
                    sd.Password = SQlLPassEdit.Text;
                }
                else
                {
                    sd.IntegratedSecurity = true;
                }
                SqlConnection asdd = new SqlConnection();
               
   
                asdd.ConnectionString = sd.ConnectionString;
              DBLisCB.Properties.Items.AddRange(  GetDatabaseList(sd.ConnectionString));
                //  asdd.Open();
                ConfigDBGroup.Enabled = true;
                NewServereRadio.Checked = true;
               // UpdateConfig(sd.ConnectionString);
               
                //Settings.Default.Save();

                
                //WriteDataToFile();
            }
            catch (Exception)
            {
                MessageBox.Show("error de config");
            }
        }

        private void FillSerList()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable dataTab = instance.GetDataSources();
           
         
            int cant = dataTab.Rows.Count;
            var serverlist = new object[cant];
            var dbaselist = new object[cant];
            for (int i = 0; i < cant; i++)
            {
                object[] arr = dataTab.Rows[i].ItemArray;
                if (arr[1] == null)
                {
                    serverlist[i] = (object)((string)arr[0] + "\\");
                }
                else
                {
                    serverlist[i] = (object)((string)arr[0] + "\\" + arr[1].ToString());
                }

                dbaselist[i] = arr[2];
            }

            int w = serverlist.Length;

            var element = new string[w];
            for (int i = 0; i < w; i++)
            {
                element[i] = serverlist[i].ToString();
            }
            SerList.Properties.Items.AddRange(element);
        }

        public List<string> GetDatabaseList(string connstring)
        {
            list = new List<string>();

            // Open connection to the database
           // string conString = "server=xeon;uid=sa;pwd=manager; database=northwind";

            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;
        }
        private void wizardControl1_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.Page == SQLServerPage)
            {
                SQLServerPage.AllowNext = false;
                FillSerList();
            }
            if ((e.PrevPage == SQLServerPage) & ExistServerRadio.Checked&!finish)
            {
              UpdateConfig(sd.ConnectionString);
                finish = true;
                wizardControl1.SelectedPage = FinishPage;
              

            }

            if ((e.PrevPage == SQLServerPage) & NewServereRadio.Checked)
                CreateDB(sd.ConnectionString);
            if ((e.PrevPage == CompaniesPage) & (validityCount == 2))
                CreateCompany();
            if ((e.PrevPage == AdminPage) & (validityCount == 7))
                CreateAdmin();
            if (e.Page == FinishPage)
                SaveExit();




        }

        private void SaveExit()
        {
           
           
            Settings.Default.First = false;
            Settings.Default.Save();
            UpdateConfig(sd.ConnectionString);
            this.Close();
          
        }

        private void CreateAdmin()
        {
            Users newuser = new Users();
            UserOptions useroptions = new UserOptions(esb.ConnectionString);
            if ((PassEdit.Text == CfPassEdit.Text))
            {
                if ((PassEdit.Text != string.Empty))
                {
                    newuser.Password = useroptions.GenerateHash(CfPassEdit.Text, CfPassEdit.Text.Length);
                }

                newuser.Name = NameEdit.Text;
                newuser.LastName = LnameEdit.Text;
                newuser.Email = EmailEdit.Text;
                newuser.Login = LoginEdit.Text;
                newuser.Notes = NotesEdit.Text;
                newuser.ActiveUser = true;
                newuser.UserTypeID = 1;
               

                useroptions.AddUserInit(newuser);
                    
            }
        }

        private void CreateCompany()
        {
            CompaniesOptions companiesoptions = new CompaniesOptions(esb.ConnectionString);
            CompaniesSet newcompany = new CompaniesSet() { CompanyName = CompNameEdit.Text, CompanyAdress = CompAdressEdit.Text ,Color = " ",VisualProp = " ",LogoAdress = " "};
            companiesoptions.AddCompany(newcompany);
            Options initdb = new Options();
            initdb.InitDB(esb.ConnectionString);
            validityCount = 0;
            // companiesoptions.AddCompany()
        }

        private void CreateDB(string connection)
        {
            
            using (SqlConnection con = new SqlConnection(connection))
            {
                var command = new SqlCommand(string.Format("CREATE DATABASE {0}; ", NewDBEdit.Text), con);
                con.Open();
                command.ExecuteNonQuery();
                string aaa = Resource1.ContabilidadScript;
               aaa = aaa.Replace("[xxx]", "["+NewDBEdit.Text+"]");

                 command = new SqlCommand(aaa, con);
                command.ExecuteNonQuery();
                sd.InitialCatalog = NewDBEdit.Text;
                UpdateConfig(sd.ConnectionString);

            }

       }
        private void DBLisCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            sd.InitialCatalog = DBLisCB.Text;

            SQLServerPage.AllowNext = true;
        }

        private void UpdateConfig(string value)
        {
            //var configFile = ConfigurationManager.OpenExeConfiguration(fileName);
            //configFile.ConnectionStrings[key].Value = value;

            //configFile.Save();


            // Build the MetaData... feel free to copy/paste it from the connection string in the config file.
             esb = new EntityConnectionStringBuilder();
            esb.Metadata = "res://*/DBData.csdl|res://*/DBData.ssdl|res://*/DBData.msl";
            esb.Provider = "System.Data.SqlClient";
            esb.ProviderConnectionString = value;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["ContabilidadEntities"].ConnectionString = esb.ConnectionString;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            //config.AppSettings.Settings["Init"].Value = "true";
        }

        private void NewDBEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!list.Contains(NewDBEdit.Text))
            {
                SQLServerPage.AllowNext = true;
            }
            else
            {
                SQLServerPage.AllowNext = false;
            }
        }

  
        private void Validate_Leave(object sender, EventArgs e)
        {
            TextEdit dfg = sender as TextEdit;
           
            if (String.IsNullOrWhiteSpace(dfg.Text)&(dfg.BackColor != Color.Snow) &(dfg.BackColor!= Color.PeachPuff))
            {
                dfg.BackColor = Color.PeachPuff;
                validityCount--;
            }

            if ((dfg.EditValue != null) & !string.IsNullOrEmpty(dfg.Text) & (dfg.BackColor != Color.White))
            {
                dfg.BackColor = Color.White;
                validityCount++;

            }
               

        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {

        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }
    }
}