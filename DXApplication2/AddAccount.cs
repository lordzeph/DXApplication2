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
    public partial class AddAccount : DevExpress.XtraEditors.XtraForm
    {
        int CompanyId;
        BankAccountsSet newaccount = new BankAccountsSet();
       CompCashOptions cashoperoptions = new CompCashOptions();
        string[] bankAcclist;
        public AddAccount(int companyId)
        {
            InitializeComponent();
            newaccount.CompanyId = companyId;
           bankAcclist = cashoperoptions.GetBankAccountsItems();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
                cashoperoptions.AddBanAccount(newaccount);
        }
        private bool Validatedata(string data)
        {

            if (String.IsNullOrWhiteSpace(data))
                return false;
            if ((bankAcclist.Any(item => item == data)))

                return false;
            return true;


        }

        private void Validate_Leave(object sender, EventArgs e)
        {
            TextEdit dfg = sender as TextEdit;
         
            
            if (dfg.EditValue != null & !string.IsNullOrEmpty(dfg.Text))
                switch (dfg.Name)
                {
                    case "AccountNameEdit":

                        if (Validatedata(dfg.Text))
                        {
                            AccountNameEdit.BackColor = Color.White;
                          newaccount.AccountName = AccountNameEdit.Text;
                            simpleButton1.Enabled = true;

                        }
                        else
                        {
                            AccountNameEdit.BackColor = Color.PeachPuff;
                            simpleButton1.Enabled = false;
                        }
                        break;

                    case "Ammount":

                    
                            newaccount.AccountValue =Decimal.Parse(dfg.Text);
                          

                      
                        break;
                    case "AccountNumber":


                        newaccount.AccountNumber = dfg.Text;

                        break;


                }

        }
    }
}