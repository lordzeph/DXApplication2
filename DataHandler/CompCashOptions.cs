using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
   public class CompCashOptions
    {
        ContabilidadEntities usercont;
        public CashOperationsSet[] GetCompOperations(DateTime fromD,DateTime toD,bool Isincome)
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.CashOperationsSet
                                where db.CashOPDate >= fromD & db.CashOPDate <= toD & db.IsIncome == Isincome
                                
                           select db).ToArray();
            return incomes;


                               
        }
        public CashOperationsSet[] GetCompOperations()
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.CashOperationsSet
                           
                           select db).ToArray();
            return incomes;



        }

        public CashOperationsSet[] GetCompOperations(DateTime fromD, DateTime toD, bool Isincome,string type)
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.CashOperationsSet
                           where db.CashOPDate >= fromD & db.CashOPDate <= toD & db.IsIncome == Isincome & db.CashOperationsTypesSet.CashOPTypeName == type

                           select db).ToArray();
            return incomes;



        }

        public CashOperationsSet[] GetCompOperations(DateTime fromD, DateTime toD, string type)
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.CashOperationsSet
                           where db.CashOPDate >= fromD & db.CashOPDate <= toD  & db.CashOperationsTypesSet.CashOPTypeName == type

                           select db).ToArray();
            return incomes;



        }

        public CashOperationsSet[] GetCompOperations(DateTime fromD, DateTime toD)
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.CashOperationsSet
                           where db.CashOPDate >= fromD & db.CashOPDate <= toD 

                           select db).ToArray();
            return incomes;



        }

        public void AddCashOPeration(CashOperationsSet cashoperation)
        {
            usercont = new ContabilidadEntities();

            usercont.CashOperationsSet.Add(cashoperation);
            usercont.SaveChanges();
            usercont.Dispose();



        }

        public string []  GetCompOperationstypesItems()
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.CashOperationsTypesSet
                          

                           select db.CashOPTypeName).ToArray();
            return incomes;



        }

        public CashOperationsTypesSet GetCompOperationstypesId(string type)
        {
            usercont = new ContabilidadEntities();

            var typeid = (from db in usercont.CashOperationsTypesSet
                           where db.CashOPTypeName == type

                           select db).Single();
            return typeid;



        }

        public string[] GetBankAccountsItems()
        {
            usercont = new ContabilidadEntities();

            var typeid = (from db in usercont.BankAccountsSet
                       

                          select db.AccountName).ToArray();
            return typeid;



        }

        public int  GetBankAccountId(string Accname)
        {
            usercont = new ContabilidadEntities();

            var typeid = (from db in usercont.BankAccountsSet
                          where db.AccountName == Accname

                          select db.AcccountId).Single();
            return typeid;



        }



        public void AddCompOperationstype(string type)
        {
            usercont = new ContabilidadEntities();
            CashOperationsTypesSet newtype = new CashOperationsTypesSet()
            {
                CashOPTypeName = type,
 
            };



            usercont.CashOperationsTypesSet.Add(newtype);
            usercont.SaveChanges(); 



        }

        public void AddBanAccount(BankAccountsSet newwacc)
        {
            usercont = new ContabilidadEntities();
            BankAccountsSet newAcc = new BankAccountsSet()
            {
                AccountName = newwacc.AccountName,
                CompanyId = newwacc.CompanyId,
                AccountValue = newwacc.AccountValue,
                AccountNumber = newwacc.AccountNumber
               

            };



            usercont.BankAccountsSet.Add(newAcc);
            usercont.SaveChanges();



        }



    }
















   
}
