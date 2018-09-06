using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandler;
using System.Collections;

namespace DataHandler
{
   public class PermissionsOptions
    {
        /// <summary>
        /// Creates new company
        /// </summary>
        /// 
        ContabilidadEntities usercont;

        public PermissionsOptions(string connection)
        {
           
            usercont = new ContabilidadEntities(connection);

        }
        public PermissionsOptions()
        {

            usercont = new ContabilidadEntities();

        }
        public bool AddPermission(Permisions newpermission)
        {
            Permisions aa = new Permisions();
         //   aa.PermissionsID = Permissionsp;
             usercont = new ContabilidadEntities();
            try
            {
                usercont.Permisions.Add(newpermission);
                usercont.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public bool AddPermissionType(PermissionsTypes newpermissionType)
        {
            PermissionsTypes aa = new PermissionsTypes();
            //   aa.PermissionsID = Permissionsp;
            ContabilidadEntities usercont = new ContabilidadEntities();
            try
            {
                usercont.PermissionsTypes.Add(newpermissionType);
                usercont.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }


        /// <summary>
        /// Deletes user
        /// </summary>
      

        /// <summary>
        /// Creates new user
        /// </summary>
       

        public Permisions[] GetPermissions(int UserID)
        {

           

            var Permissionslist = (from db in usercont.Permisions
                                   where (db.UserID == UserID)
                            select db).ToArray();
            return Permissionslist;



        }

        public PermissionsTypes[] GetPermissionsTypes()
        {

            

            var PermissionsTypeslist = (from db in usercont.PermissionsTypes
                                   
                                   select db).ToArray();
            return PermissionsTypeslist;



        }

        public PermissionsTypes[] GetPermissionsTypesAcces(bool accestype)
        {

           

            PermissionsTypes []  PermissionsTypeslist = (from db in usercont.PermissionsTypes
                                      where db.IsUserID == accestype
                                        select db).ToArray();
            return PermissionsTypeslist;



        }

        public List<string> GetPermissionsCB()
        {

          

            IEnumerable permissions = (from contact in usercont.Permisions select contact.PermissionsTypes).OrderBy(s => s).Distinct();
            return permissions.Cast<string>().ToList();
     



        }

        public int GetPermisionID(string PermissionName)
        {

         

            var id = (from contact in usercont.Permisions
                      where contact.PermissionsTypes.PermissionTypeName == PermissionName
                      select contact.PermissionsTypeID).ToList()[0];
            return int.Parse(id.ToString());




        }

    }
}
