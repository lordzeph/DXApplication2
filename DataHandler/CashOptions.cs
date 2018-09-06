using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
   public class CashOptions
    {
        ContabilidadEntities usercont;
        public IncomesSet[] GetServiceIncomes(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.IncomesSet
                                where db.ServiceId == serviceid
                                select db).ToArray();
            return incomes;


                               
        }
        public ExpensesSet[] GetServiceExpenses(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var incomes = (from db in usercont.ExpensesSet
                           where db.PartnersServices.ServiceId == serviceid
                           select db).ToArray();
            return incomes;



        }

        public void AddIncome(IncomesSet income)
        {
            usercont = new ContabilidadEntities();

            usercont.IncomesSet.Add(income);
            usercont.SaveChanges();
            usercont.Dispose();



        }

        public void AddExpense(ExpensesSet expense)
        {
            usercont = new ContabilidadEntities();

            usercont.ExpensesSet.Add(expense);
            usercont.SaveChanges();
            usercont.Dispose();



        }

        public int GetServiceID(string name)
        {
            usercont = new ContabilidadEntities();

            var serviceid = (from db in usercont.ServicesSet
                                where db.Servicename == name
                                select db.ServiceId).ToArray().Last();
            return serviceid;



        }

     

        

       

       
        

    }
}
