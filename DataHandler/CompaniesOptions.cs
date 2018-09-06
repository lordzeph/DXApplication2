using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataHandler
{
   public class CompaniesOptions
    {
        /// <summary>
        /// Creates new company
        /// </summary>
        ///    
      /// 
      ContabilidadEntities usercont;
        public CompaniesOptions(string ConnectionString)
        {
         usercont = new ContabilidadEntities(ConnectionString);
        }


        
        public CompaniesOptions()
        {
             usercont = new ContabilidadEntities();
        }
       
        public bool AddCompany(CompaniesSet newcompany)
        {
            Permisions aa = new Permisions();
         //   aa.PermissionsID = Permissionsp;
        
            try
            {
                usercont.CompaniesSet.Add(newcompany);
                usercont.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }



        }
      

        /// <summary>
        /// Deletes user
        /// </summary>
        public bool DeleteCompany(string CompanyId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates new user
        /// </summary>
        public bool ModifyCompany(string Name, string LastName, string PersonalId, string CompanyId, string Range, string Position, string Ocupation, string Permissions, string UserId)
        {
            throw new System.NotImplementedException();
        }

        public CompaniesSet[] GetCompanies()
        {

            

            var Companieslist = (from db in usercont.CompaniesSet
                            select db).ToArray();
            return Companieslist;



        }

        public List<string> GetCompaniesCB()
        {

            

            IEnumerable cities = (from contact in usercont.CompaniesSet select  contact.CompanyName).OrderBy(s => s).Distinct();
            return cities.Cast<string>().ToList();
     



        }

        public int GetCompaniesID(string CompanyName)
        {

          

            var id = (from contact in usercont.CompaniesSet where contact.CompanyName == CompanyName
                                  select contact.CompanyId).ToList()[0];
            return int.Parse(id.ToString());




        }




    }
}
