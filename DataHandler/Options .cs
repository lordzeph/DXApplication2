using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;



namespace DataHandler
{
   public class Options 
    {
        ContabilidadEntities dbcontext;
       


        private String BuildConnectionString(String DataSource, String Database)
        {
            // Build the connection string from the provided datasource and database
            String connString = @"data source=" + DataSource +
            ";initial catalog=" + Database +
            ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";

            // Build the MetaData... feel free to copy/paste it from the connection string in the config file.
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            esb.Metadata = "res://*/DBData.csdl|res://*/DBData.ssdl|res://*/DBData.msl";
            esb.Provider = "System.Data.SqlClient";

            esb.ProviderConnectionString = connString;

            // Generate the full string and return it
            return esb.ToString();
        }

        public void InitDB(string connection)
        {
            dbcontext = new ContabilidadEntities( connection);

            UserType admin = new UserType() { UserTypeName = "Administrador" };
            UserType cash = new UserType() { UserTypeName = "Cajero" };
            UserType sale = new UserType() { UserTypeName = "Vendedor" };
            dbcontext.UserType.Add(admin);
            dbcontext.UserType.Add(cash);
            dbcontext.UserType.Add(sale);
            PermissionsTypes permsr = new PermissionsTypes() { PermissionTypeName = "Read", IsUserID = false, PermisionValue = 1 };
            PermissionsTypes permsw = new PermissionsTypes() { PermissionTypeName = "Write", IsUserID = false, PermisionValue = 2 };
            PermissionsTypes permsu = new PermissionsTypes() { PermissionTypeName = "All Users", IsUserID = true, PermisionValue = 0 };
            dbcontext.PermissionsTypes.Add(permsr);
            dbcontext.PermissionsTypes.Add(permsw);
            dbcontext.PermissionsTypes.Add(permsu);
            ServiceTypes tour = new ServiceTypes() { ServiceType = "Tour" };
            ServiceTypes trasnf = new ServiceTypes() { ServiceType = "Transfer" };
            ServiceTypes exc = new ServiceTypes() { ServiceType = "Excursion" };
            ServiceTypes etic = new ServiceTypes() { ServiceType = "Tickets" };
            dbcontext.ServiceTypes.Add(tour);
            dbcontext.ServiceTypes.Add(trasnf);
            dbcontext.ServiceTypes.Add(exc);
            dbcontext.ServiceTypes.Add(etic);
            CountriesSet cuba = new CountriesSet() { CountryCode = "00", CountryName = "Cuba", EnglishName = "Cuba", RussianName = "Cuba", SpanishName = "Cuba" };
            CountriesSet russia = new CountriesSet() { CountryCode = "01", CountryName = "Russia", EnglishName = "Russia", RussianName = "Russia", SpanishName = "Russia" };
            dbcontext.CountriesSet.Add(cuba);
            dbcontext.CountriesSet.Add(russia);
            CashOperationsTypesSet offices = new CashOperationsTypesSet { CashOPTypeName = "Office" };
            CashOperationsTypesSet salaries = new CashOperationsTypesSet { CashOPTypeName = "Salaries" };
            CashOperationsTypesSet donations = new CashOperationsTypesSet { CashOPTypeName = "Donations" };
            CashOperationsTypesSet telephone = new CashOperationsTypesSet { CashOPTypeName = "Telephone" };
            CashOperationsTypesSet transportation = new CashOperationsTypesSet { CashOPTypeName = "Transportation" };
            CashOperationsTypesSet investment = new CashOperationsTypesSet { CashOPTypeName = "Investments" };
            CashOperationsTypesSet recovery = new CashOperationsTypesSet { CashOPTypeName = "Recoveries" };
            CashOperationsTypesSet others = new CashOperationsTypesSet { CashOPTypeName = "Others" };
            dbcontext.CashOperationsTypesSet.Add(offices);
            dbcontext.CashOperationsTypesSet.Add(salaries);
            dbcontext.CashOperationsTypesSet.Add(donations);
            dbcontext.CashOperationsTypesSet.Add(telephone);
            dbcontext.CashOperationsTypesSet.Add(transportation);
            dbcontext.CashOperationsTypesSet.Add(investment);
            dbcontext.CashOperationsTypesSet.Add(recovery);
            dbcontext.CashOperationsTypesSet.Add(others);

            dbcontext.SaveChanges();


        }




    }
}
